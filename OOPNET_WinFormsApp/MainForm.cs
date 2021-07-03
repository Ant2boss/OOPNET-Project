using OOPNET_DataLayer.ConfigurationManager;
using OOPNET_DataLayer.Models;
using OOPNET_DataLayer.Repository;
using OOPNET_DataLayer.Repository.RepoInternals;
using OOPNET_Utils.Configuration;
using OOPNET_WinFormsApp.Initializations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPNET_WinFormsApp
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			if (!this._InitSettings())
			{
				MessageBox.Show("Inital setup not completed!", "Error");
				this.Dispose();
			}

			InitializeComponent();

			this.CenterToScreen();
		}

		private const string CONFIG_FILE_PATH = DAL_ApplicationConfig.CONFIG_PATH;

		private const string CONFIG_CULTURE = "Culture";
		private const string CONFIG_CUP_TYPE = "CupType";

		private bool _InitSettings()
		{
			if (!_InitCupTypeAndCulture())
			{
				return false;
			}

			IDictionary<string, string> config = ConfigurationParser.ParseConfigFile(CONFIG_FILE_PATH);

			Thread.CurrentThread.CurrentCulture = new CultureInfo(config[CONFIG_CULTURE]);
			Thread.CurrentThread.CurrentUICulture = new CultureInfo(config[CONFIG_CULTURE]);

			return true;
		}

		private bool _InitCupTypeAndCulture()
		{
			try
			{
				//Try to open file
				IDictionary<string, string> config = ConfigurationParser.ParseConfigFile(CONFIG_FILE_PATH);

				//Check the two settings if they are empty
				if (string.IsNullOrEmpty(config[CONFIG_CULTURE]) || string.IsNullOrEmpty(config[CONFIG_CUP_TYPE]))
				{
					//Get the information from the Chooser
					RepresentationChooser repChooser = new RepresentationChooser();
					if (repChooser.ShowDialog() == DialogResult.OK)
					{
						config[CONFIG_CULTURE] = repChooser.GetCulture();
						config[CONFIG_CUP_TYPE] = repChooser.GetCupType();

						//Update information
						ConfigurationParser.UpdateConfigFile(CONFIG_FILE_PATH, config);
					}
					else
					{
						return false;
					}
				}

				return true;
			}
			catch (Exception ex)
			{
				if (ex is FileNotFoundException || ex is KeyNotFoundException)
				{ 
					MessageBox.Show("Error reading config, creating new config file!", "Error");
					DAL_ApplicationConfig.CreateEmptyConfigFile();
					return this._InitCupTypeAndCulture();
				}

				throw;
			}
		}
	}
}
