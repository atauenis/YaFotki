using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YaFotki
{
	public partial class fWork : Form
	{
		public fWork()
		{
			InitializeComponent();
		}

		private void fWork_Load(object sender, EventArgs e)
		{
			Program.NoLocal = lNoLocal;
		}

		private void fWork_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
		}
	}
}
