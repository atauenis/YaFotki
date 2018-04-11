using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace YaFotki
{
	static class Program
	{
		public static string LocalBase; //D:\yfotki\
		public static string VirtualBase; //https://api-fotki.yandex.ru/api/users/qwerty/
		public static bool Save;
		public static bool LocalOnly;
		public static bool SavePics = false;
		public static Label NoLocal = new Label();

		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			//Application.SetCompatibleTextRenderingDefault(true); //вызывает System.InvalidOperationException
			Application.Run(new fMain());
		}

		public static async Task<Stream> Open(string Address)
		{
			if (LocalOnly)
			{
				string locPath = PreparePath(Address);
				if(File.Exists(locPath)) return new FileStream(locPath, FileMode.Open);
				NoLocal.Text = Address.Replace(VirtualBase, "~/") + " нет в локальной базе.";
				//если файл не скачан, будем брать из интернета
			}

			if (Save && Address.StartsWith("http"))
			{
				string path = PreparePath(Address, true);
				NoLocal.Text = "Скачивание " + path.Replace(LocalBase,"") + "...";
				Application.DoEvents();
				SaveUrl(Address, path);
				NoLocal.Text = "Открытие...";
				return File.OpenRead(path);
			}

			if (Address.StartsWith("http")) return await new System.Net.Http.HttpClient().GetStreamAsync(Address);
			else return new FileStream(Address, FileMode.Open);
		}

		public static string PreparePath(string Address, bool MakePath=false) {
			//подготовка локального пути
			string path = Address.Replace(VirtualBase, LocalBase).Replace("https://img-fotki.yandex.ru/get", LocalBase + "/img-fotki").Replace("/?","!").Replace('/','\\').Replace(':', '$');
			ReplaceCharInString(ref path, 1, ':');
			if (path.EndsWith("\\")) path += "INDEX.XML";
			if (!path.EndsWith(".XML") & !path.EndsWith("orig")) path += ".XML";

			//создание отсутствующих папок
			if(MakePath) {
				string dir = Path.GetDirectoryName(path);
				if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
			}

			return path;
		}

		public static void SaveUrl(string URL, string Where) 
		{
			//скачивание в LocalBase
			Console.WriteLine("Скачивание {1}.", URL, Where);
			try
			{
				WebClient wc = new WebClient();
				wc.DownloadFile(URL, Where);
			}
			catch (Exception ex) {
				if(ex.GetType() != typeof(WebException)) //говнокод, но работает
				MessageBox.Show("Ошибка при скачивании:\n"+URL+"\nВ:\n"+Where+"\n\n"+
				ex.Message+"\n"+ex.StackTrace +"\n\n"+
				ex.InnerException.ToString() ?? "Вложенного исключения нет."
				, ex.GetType().ToString());
				#if DEBUG
				throw;
				#endif
			}
		}

		public static void ReplaceCharInString(ref String str, int index, Char newSymb)
		{
			str = str.Remove(index, 1).Insert(index, newSymb.ToString());
		}
	}
}
