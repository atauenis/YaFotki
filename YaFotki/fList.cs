using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace YaFotki
{
	public partial class fList : Form
	{
		Stream atomStream = null;
		fList nextWindow = null;
		bool isAlbum = false;
		string winTitle = "Список альбомов: ";
					
		public fList()
		{
			InitializeComponent();
		}

		public async void LoadAlbums(Stream AtomStream, bool IsAlbum, string WinTitle="", bool All=false) {
			atomStream = AtomStream;
			isAlbum = IsAlbum;
			Application.UseWaitCursor = true;
			string act = "Начало работы формы.";


			if (isAlbum) winTitle = "Альбом: ";
			if (WinTitle != "") winTitle = WinTitle;

			try
			{
				act = "Обработка Atom";
				lStatus.Text = "Получен ответ сервера. Разборка...";
				Application.DoEvents();
				XmlReader xr = XmlReader.Create(atomStream);

				while (xr.Read())
				{
					if (xr.NodeType == XmlNodeType.Element)
					{
						//Console.WriteLine(xr.Name);

						//Автор альбомов, название страницы и дата обновления
						if (xr.Name == "name") lAuthor.Text = "Автор: " + xr.ReadInnerXml();
						if (xr.Name == "f:uid") lAuthor.Text += " / UID=" + xr.ReadInnerXml();
						if (xr.Name == "title") Text = winTitle + xr.ReadInnerXml();
						if (xr.Name == "updated") { lUpdated.Text = "Обновлено: " + xr.ReadInnerXml(); Application.DoEvents(); }
						//Кнопка перехода на следующую страницу
						//(какому чудаку допёрло сортировать страницы на backend?)
						if (xr.Name == "link" && xr.GetAttribute("rel") == "next")
						{
							bNext.Tag = xr.GetAttribute("href");
							bNext.Enabled = true;
							if (All) bNext_Click(null, null, true);
						}


						if (xr.Name == "entry") {
							ParseEntry(xr);
						}
					}
				}

				act = "Okay";
				lStatus.Text = "Готово.";
				atomStream.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Не выполнено: " + act + "\n" + ex.Message + "\n" + ex.StackTrace,ex.ToString());
				lStatus.Text = "Ошибка.";

			}
			finally
			{
				Application.UseWaitCursor = false;
			}
		}

		//<entry></>
		private void ParseEntry(XmlReader XR)
		{
			AlbumEntry ae = new AlbumEntry();
			while (XR.Read())
			{
				
				if (XR.NodeType == XmlNodeType.Element)
				{
					if (XR.Name == "id") {ae.id = XR.ReadInnerXml();}
					if (XR.Name == "name") {ae.authorName = XR.ReadInnerXml();}
					if (XR.Name == "f:uid") {ae.authorFuid = XR.ReadInnerXml();}
					if (XR.Name == "title") {ae.title = XR.ReadInnerXml();}
					if (XR.Name == "summary") {ae.summary = XR.ReadInnerXml();}
					if (XR.Name == "link" && XR.GetAttribute("rel") == "self") {ae.self = XR.GetAttribute("href"); }
					if (XR.Name == "link" && XR.GetAttribute("rel") == "photos") { ae.photos = XR.GetAttribute("href"); }
					if (XR.Name == "link" && XR.GetAttribute("rel") == "cover") { ae.cover = XR.GetAttribute("href"); }
					if (XR.Name == "published") {ae.published = XR.ReadInnerXml();}
					if (XR.Name == "app:edited") {ae.edited = XR.ReadInnerXml();}
					if (XR.Name == "updated") {ae.updated = XR.ReadInnerXml();}
					if (XR.Name == "f:protected") {ae.fProtected = XR.GetAttribute("value");}
					if (XR.Name == "f:image-count") {ae.fTmageCount = XR.GetAttribute("value");}

					if (XR.Name == "link" && XR.GetAttribute("rel") == "edit-media") { ae.editMedia = XR.GetAttribute("href"); }
					if (XR.Name == "f:created") {ae.fCreated = XR.ReadInnerXml();}
					if (XR.Name == "access") {ae.access = XR.GetAttribute("value");}
					if (XR.Name == "xxx") {ae.xxx = XR.GetAttribute("value");}
					if (XR.Name == "hide_original") {ae.hideOriginal = XR.GetAttribute("value");}
					if (XR.Name == "disable_comments") {ae.disableComments = XR.GetAttribute("value");}
					if (XR.Name == "category" && XR.GetAttribute("scheme").Contains("tags")) { ae.tags.Add(XR.GetAttribute("term")); }
					if (XR.Name == "georss:point") {ae.edited = XR.ReadOuterXml();}
					if (XR.Name == "f:pod-date") {ae.fPodDate = XR.ReadInnerXml();}
					if (XR.Name == "f:address-binding") {ae.fAddressBinding = XR.ReadInnerXml();}
					if (XR.Name == "f:img" && XR.GetAttribute("size") == "orig") { ae.fImgOrig = XR.GetAttribute("href"); }

				}
				if (XR.NodeType == XmlNodeType.EndElement)
				{
					if (XR.Name == "entry") break;
				}
			}
			lbItems.Items.Add(ae);
		}

		private async void bNext_Click(object sender, EventArgs e) { bNext_Click(sender, e, false); }

		private async void bNext_Click(object sender, EventArgs e, bool All = false)
		{
			if(nextWindow!= null) { nextWindow.Activate(); return; }


			fWork fw = new fWork();
			fw.Show();

			fList fa = new fList();
			fa.Show();
			fa.LoadAlbums(await Program.Open(bNext.Tag.ToString()), isAlbum,winTitle,All);
			nextWindow = fa;

			fw.Hide();
		}

		private async void lbItems_DoubleClick(object sender, EventArgs e)
		{
			string url = ((AlbumEntry)(lbItems.SelectedItem)).photos;
			if (url == null)
			{
				url = ((AlbumEntry)(lbItems.SelectedItem)).self;
				if (!isAlbum && !url.Contains("photo/")) url += "photos/";//возможно, не лучший способ
			}
			Process(url, true);
		}

		public async void Process(bool All=false, bool Close=false) {
			//открыть все выбранные пункты
			foreach(object o in lbItems.SelectedItems) {
				string url = ((AlbumEntry)o).self;
				if (!isAlbum && !url.Contains("photo/")) url += "photos/";
				Process(url, true,"",All,Close);
			}
		}

		public async void Process(string URL, bool IsAlbum, string WinTitle="", bool All=false, bool Close=false) {
			//открыть конкретный пункт
			fWork fw = new fWork();
			fw.Show();
			try
			{
				if(URL.Contains("/photo/"))
				{
					fPhoto fp = new fPhoto();
					fp.Show();
					fp.LoadPhoto(await Program.Open(URL));
					if (Close) fp.Hide();
				}
				else
				{ 
					fList fap = new fList();
					fap.Show();
					if (WinTitle == "") WinTitle = winTitle;
					fap.LoadAlbums(await Program.Open(URL),IsAlbum, WinTitle, All);
					if (Close) fap.Hide();
				}
			}
			catch(Exception ex) {
				MessageBox.Show("Список по адресу\n"+URL+"\nне открывается. "+ex.Message+"\n"+ex.StackTrace);
			}

			fw.Hide();
		}

		private void bSave_Click(object sender, EventArgs e)
		{
			if (!Program.Save)
			{
				if (MessageBox.Show("Сохранение отключено. Работает режим имитации.", "Экспорт Фоток", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel) return;
			}
			if (Program.LocalBase == null)
			{
				MessageBox.Show("Не назначена папка для сохранения.", "Экспорт Фоток", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			Process(true,true);
		}

		private void lbItems_SelectedIndexChanged(object sender, EventArgs e)
		{
			if ((AlbumEntry)lbItems.SelectedItem == null) return;
			lStatus.Text = ((AlbumEntry)lbItems.SelectedItem).self ?? "ВНИМАНИЕ: NULL REFERENCE!";
		}
	}

	public class AlbumEntry {
		public string id;
		public string authorName;
		public string authorFuid;
		public string title;
		public string summary;
		public string self;
		public string photos;
		public string cover;
		public string ymapsml;
		public string published;
		public string edited;
		public string updated;
		public string fProtected;
		public string fTmageCount;

		public string fImgOrig;//можно добавить другие размеры, при желании
		public string editMedia;
		public string fCreated;
		public string access;
		public string xxx;
		public string hideOriginal;
		public string disableComments;
		public List<string> tags = new List<string>();
		public string georss;
		public string fPodDate;
		public string fAddressBinding;

		public override string ToString() {
			return title;
		}
	}
}
