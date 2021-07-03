using OOPNET_DataLayer.Models;
using OOPNET_DataLayer.Repository;
using OOPNET_DataLayer.Repository.RepoInternals;
using OOPNET_Utils.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPNET_WinFormsApp
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			IDictionary<string, string> dictionary = ConfigurationParser.ParseConfigFile("parseTest.txt");

			foreach (string key in dictionary.Keys)
			{
				Console.WriteLine($"[{key}] -> '{dictionary[key]}'");
			}
			Console.WriteLine("=====================================");
		}
	}
}
