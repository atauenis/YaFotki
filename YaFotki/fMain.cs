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
			tUser.Text = "";
#endif
		}

		private async void bUser_Click(object sender, EventArgs e)
		{
			Application.UseWaitCursor = true;
			lStatus.Text = lDetected.Text = "";
			string act = "Подготовка строки запроса.";
			ApiPath = lApi.Text + tUser.Text + "/";
			
			try
			{
				fWork fw = new fWork();
				fw.Show();
				act = "Загрузка API";
				lStatus.Text = "Запрос " + ApiPath;
				System.Net.Http.HttpClient hc = new System.Net.Http.HttpClient();
				Stream atomStream = await hc.GetStreamAsync(ApiPath);
				fw.Hide();
				
				act = "Обработка Atom";
				lStatus.Text = "Получен ответ сервера. Разборка...";
				XmlReader xr = XmlReader.Create(atomStream);

				while (xr.Read()) {
					if(xr.NodeType == XmlNodeType.Element) {
						if (xr.Name == "app:workspace") ParseWorkspace(xr);
					}
				}

				act = "Okay";
				lStatus.Text = "Готово.";
			}
			catch (Exception ex)
			{
				MessageBox.Show("Не выполнено: " + act + "\n" + ex.Message + "\n" + ex.StackTrace);
				lStatus.Text = "Ошибка.";

			}
			finally
			{
				Application.UseWaitCursor = false;
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
			fa.LoadAlbums(await Program.Open(bAlbums.Tag.ToString()), false);

			fw.Hide();
		}

		private async void bTags_Click(object sender, EventArgs e)
		{
			fWork fw = new fWork();
			fw.Show();

			fList fa = new fList();
			fa.Show();
			fa.LoadAlbums(await Program.Open(bTags.Tag.ToString()), true);

			fw.Hide();
		}

		private async void bAllPhoto_Click(object sender, EventArgs e)
		{
			fWork fw = new fWork();
			fw.Show();

			fList fa = new fList();
			fa.Show();
			fa.LoadAlbums(await Program.Open(bAllPhoto.Tag.ToString()), true, "Все фото: ");

			fw.Hide();
		}

		private void bOpenLocal_Click(object sender, EventArgs e)
		{
			Program.VirtualBase = ApiPath;
			Program.SaveTo = tLocal.Text;
		}
	}
}
