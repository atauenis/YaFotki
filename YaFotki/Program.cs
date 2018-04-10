using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace YaFotki
{
	static class Program
	{
		public static string LocalBase; //D:\yfotki\
		public static string VirtualBase; //https://api-fotki.yandex.ru/api/users/qwerty/
		public static bool Save;
		public static bool LocalOnly;

		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new fMain());
		}

		public static async Task<Stream> Open(string Address)
		{
			if(Save && Address.StartsWith("http"))
			{
				//todo: скачать в LocalBase;
				Console.WriteLine("Можно качать {0} в {1}.",Address,LocalBase);
			}
			if (LocalOnly) return new FileStream(Address.Replace(VirtualBase, LocalBase), FileMode.Open);

			if (Address.StartsWith("http")) return await new System.Net.Http.HttpClient().GetStreamAsync(Address);
			else return new FileStream(Address, FileMode.Open);
		}
	}
}
