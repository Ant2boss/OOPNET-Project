using OOPNET_DataLayer.Configs;
using OOPNET_DataLayer.Repository;
using OOPNET_Utils.Configuration;
using OOPNET_WPFApp.Dialogs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOPNET_WPFApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly string GLOBAL_CONFIG = ConfigFilePaths.LOCAL_REPO_GLOBAL_CONF_PATH;

		public MainWindow()
		{
			this._InitSettings();

			InitializeComponent();

		}

		private void _InitSettings()
		{
			if (!File.Exists(this.GLOBAL_CONFIG))
			{
				this._CreateNewSettings();
			}

			IDictionary<string, string> conf = ConfigurationParser.ParseConfigFile(this.GLOBAL_CONFIG);

			try
			{
				Thread.CurrentThread.CurrentCulture = new CultureInfo(conf[GlobalConfig.CONFK_CULTURE]);
				Thread.CurrentThread.CurrentUICulture = new CultureInfo(conf[GlobalConfig.CONFK_CULTURE]);

				this._ParseResolution(conf[GlobalConfig.CONFK_RESOLUTION]);
			}
			catch (Exception)
			{
				MessageBox.Show("Error reading settings!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
				File.Delete(this.GLOBAL_CONFIG);
				this._InitSettings();
			}
		}

		WindowStyle? _OriginalStyle = null;
		WindowState? _OriginalState = null;

		private void _ParseResolution(string resolution)
		{
			string[] res = resolution.Split('x');

			if (res.Length != 2)
			{
				this._OriginalStyle = this.WindowStyle;
				this._OriginalState = this.WindowState;

				this.WindowStyle = WindowStyle.None;
				this.WindowState = WindowState.Maximized;
			}

			if (this._OriginalState.HasValue)
			{
				this.WindowStyle = this._OriginalStyle.Value;
				this.WindowState = this._OriginalState.Value;
			}

			this.Width = int.Parse(res[0]);
			this.Height = int.Parse(res[1]);
		}

		private void _CreateNewSettings()
		{
			GlobalConfig.CreateEmptyConfigFile();

			Settings settingsDialog = new Settings();
			bool? isOk = settingsDialog.ShowDialog();

			if (isOk.HasValue && isOk.Value == true)
			{
				IDictionary<string, string> conf = ConfigurationParser.ParseConfigFile(this.GLOBAL_CONFIG);

				conf[GlobalConfig.CONFK_CULTURE] = settingsDialog.Culture;
				conf[GlobalConfig.CONFK_CUP_TYPE] = (settingsDialog.IsMaleCup) ? (CupType.MaleCup.ToString()) : (CupType.FemaleCup.ToString());
				conf[GlobalConfig.CONFK_RESOLUTION] = settingsDialog.Resolution;

				ConfigurationParser.UpdateConfigFile(this.GLOBAL_CONFIG, conf);
			}
		}
	}
}
