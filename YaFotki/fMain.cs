using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.ServiceModel.Syndication;

namespace YaFotki
{
	public partial class fMain : Form
	{
		string ApiPath;
		public fMain()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
#if !DEBUG
			tUser.Text = Environment.UserName;
			tLocal.Text = Directory.GetCurrentDirectory();
#endif
		}

		private void bUser_Click(object sender, EventArgs e)
		{
			if (tLocal.Text.Length == 0 || tUser.Text.Length == 0)
			{
				MessageBox.Show("Введите локальный адрес и имя пользователя.","Экспорт Яндекс.Фоток",MessageBoxButtons.OK,MessageBoxIcon.Stop);
				return;
			}

			bAlbums.Enabled = bAllPhoto.Enabled = bTags.Enabled = false;
			lDetected.Text = "";
			if(cbLocal.Checked) {
				Program.VirtualBase = ApiPath;
				Program.LocalBase = tLocal.Text;
				Program.LocalOnly = true;
				LoadUser();
			}
			LoadUser();
		}

		private async void LoadUser() {
			Application.UseWaitCursor = true;
			lStatus.Text = lDetected.Text = "";
			string act = "Подготовка строки запроса.";
			ApiPath = lApi.Text + tUser.Text + "/";
			Program.LocalBase = tLocal.Text;
			Program.VirtualBase = ApiPath;

			fWork fw = new fWork();
			fw.Show();
			try
			{

				act = "Загрузка API";
				lStatus.Text = "Запрос " + ApiPath;
				Stream atomStream = await Program.Open(ApiPath);
				fw.Hide();

				act = "Обработка Atom";
				lStatus.Text = "Получен ответ сервера. Разборка...";
				XmlReader xr = XmlReader.Create(atomStream);

				while (xr.Read())
				{
					if (xr.NodeType == XmlNodeType.Element)
					{
						if (xr.Name == "app:workspace") ParseWorkspace(xr);
					}
				}

				act = "Okay";
				if(Program.LocalOnly) lStatus.Text = "Готово. Работа с локальной базой.";
				else lStatus.Text = "Готово. Сетевой режим.";
				atomStream.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Не выполнено: " + act);
				lStatus.Text = "Ошибка.";
				
			}
			finally
			{
				Application.UseWaitCursor = false;
				fw.Dispose();
			}

		}

		//<app:workspace></>
		private void ParseWorkspace(XmlReader XR) {
			while (XR.Read())
			{
				if (XR.NodeType == XmlNodeType.Element)
				{
					if (XR.Name == "atom:title")
					{
						lDetected.Text = XR.ReadInnerXml();
					}
					if (XR.Name == "app:collection") ParseCollection(XR);
				}
				if (XR.NodeType == XmlNodeType.EndElement) {
					if (XR.Name == "app:workspace") break;
				}
			}
		}

		//<app:collection href=... id=...></>
		private void ParseCollection(XmlReader XR)
		{
			switch(XR.GetAttribute("id")) {
				case "album-list":
					bAlbums.Tag = XR.GetAttribute("href");
					bAlbums.Enabled = true;
					break;
				case "photo-list":
					bAllPhoto.Tag = XR.GetAttribute("href");
					bAllPhoto.Enabled = true;
					break;
				case "tag-list":
					bTags.Tag = XR.GetAttribute("href");
					bTags.Enabled = true;
					break;
				default:
					MessageBox.Show("\r\nНеизвестная коллекция: " + XR.GetAttribute("id"));
					break;
			}

			while (XR.Read())
			{
				if (XR.NodeType == XmlNodeType.EndElement) {
					if (XR.Name == "app:collection") break;
				}
			}
		}

		private async void bAlbums_Click(object sender, EventArgs e)
		{
			fWork fw = new fWork();
			fw.Show();

			fList fa = new fList();
			fa.Show();
			fa.LoadAlbums(await Program.Open(bAlbums.Tag.ToString()), false,"",true);

			fw.Hide();
		}

		private async void bTags_Click(object sender, EventArgs e)
		{
			fWork fw = new fWork();
			fw.Show();

			fList fa = new fList();
			fa.Show();
			fa.LoadAlbums(await Program.Open(bTags.Tag.ToString()), true,"",true);

			fw.Hide();
		}

		private async void bAllPhoto_Click(object sender, EventArgs e)
		{
			fWork fw = new fWork();
			fw.Show();

			fList fa = new fList();
			fa.Show();
			fa.LoadAlbums(await Program.Open(bAllPhoto.Tag.ToString()), true, "Все фото: ",true);

			fw.Hide();
		}

		private void bOpenLocal_Click(object sender, EventArgs e)
		{
			Program.VirtualBase = ApiPath;
			Program.LocalBase = tLocal.Text;
			Program.LocalOnly = true;
			LoadUser();
		}

		private void bBrowseLocal_Click(object sender, EventArgs e)
		{
			if (fbd.ShowDialog() != DialogResult.Cancel)
			tLocal.Text = fbd.SelectedPath;
		}

		private void cbSave_CheckedChanged(object sender, EventArgs e)
		{
			Program.Save = cbSave.Checked;
			cbLocal.Checked = false;
			cbLocal.Enabled = !cbSave.Checked;
		}

		private void cbLocal_CheckedChanged(object sender, EventArgs e)
		{
			Program.LocalOnly = cbLocal.Checked;
			cbSave.Checked = false;
			cbSave.Enabled = !cbLocal.Checked;
		}
	}
}
