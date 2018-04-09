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
		public static string SaveTo; //D:\yfo\
		public static string VirtualBase; //https://api-fotki.yandex.ru/api/users/qwerty/
		public static bool Save;

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
			if (Address.StartsWith("http")) return await new System.Net.Http.HttpClient().GetStreamAsync(Address);
			else return null; //UNDONE: добавить возврат потока с локального файла
							  //UNDONE: сделать закачку из Stream в файл если Save=true, и восстановление Stream в исходный вид.
							  //UNDONE: при работе в локальном режиме, надо подменять HTTP адреса VirtualBase на локальные SaveTo.
		}
	}
}
