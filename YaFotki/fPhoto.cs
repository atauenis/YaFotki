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
	public partial class fPhoto : Form
	{
		Stream atomStream = null;

		public fPhoto()
		{
			InitializeComponent();
		}

		private void fPhoto_Load(object sender, EventArgs e)
		{

		}

		public async void LoadPhoto(Stream AtomStream)
		{
			atomStream = AtomStream;
			string act = "";
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
						//Автор альбомов, название страницы и дата обновления
						if (xr.Name == "title") Text = "Фото \"" + xr.ReadInnerXml();
						if (xr.Name == "title") lTitle.Text  = xr.ReadInnerXml();
						if (xr.Name == "name")  Text += "\", автор " + xr.ReadInnerXml();
						if (xr.Name == "f:img" && xr.GetAttribute("size") == "orig") { pictureBox1.ImageLocation  = xr.GetAttribute("href"); }
						/*tMeta.Text += xr.ReadOuterXml() + "\r\n";*/
					}
				}

				act = "Okay";
				lStatus.Text = "Готово.";
			}
			catch (Exception ex)
			{
				MessageBox.Show("Не выполнено: " + act + "\n" + ex.Message + "\n" + ex.StackTrace, ex.ToString());
				lStatus.Text = "Ошибка.";

			}
			finally
			{
				Application.UseWaitCursor = false;
			}

		}

	}
	}
