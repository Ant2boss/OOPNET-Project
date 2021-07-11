using OOPNET_DataLayer.Configs;
using OOPNET_DataLayer.Models;
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

			this._InitForm();
		}

		ITeamsRepo _TeamsRepo;
		IMatchesRepo _MatchesRepo;

		IList<Team> _TeamsList;
		ISet<MatchTeam> _OppositionSet;

		string _SelectedFifaCode;
		string _SelectedOpositionFifaCode;

		private void _InitForm()
		{
			this._TeamsRepo = RepoFactory.GetTeamsRepo();
			this._MatchesRepo = RepoFactory.GetMatchesRepo();

			this._OppositionSet = new HashSet<MatchTeam>();

			this._LoadTeamsList(new MyLoading());

			foreach (Team team in this._TeamsList)
			{
				this.cbFavoriteRep.Items.Add(team);
			}

			IDictionary<string, string> conf = ConfigurationParser.ParseConfigFile(ConfigFilePaths.LOCAL_REPO_LOCAL_CONF_PATH);
			if (conf.Keys.Contains(ConfigKeys.CONFK_FAVORITE_REP) && !string.IsNullOrEmpty(conf[ConfigKeys.CONFK_FAVORITE_REP]))
			{
				this.cbFavoriteRep.SelectedItem = this._TeamsList.FirstOrDefault(t => t.FifaCode == conf[ConfigKeys.CONFK_FAVORITE_REP]);
			}
		}

		private void _LoadTeamsList(MyLoading dialog)
		{
			dialog.Show();
			this._TeamsList = this._TeamsRepo.GetAllTeams();
			dialog.Close();
		}

		private void _LoadCbOponents(MyLoading dialog)
		{
			this.cbOpositionsRep.IsEnabled = true;
			this.cbOpositionsRep.Items.Clear();
			this._OppositionSet.Clear();
			this._SelectedOpositionFifaCode = "";

			dialog.Show();
			foreach (Match match in this._MatchesRepo.GetMatchesOfCountry(this._SelectedFifaCode))
			{
				this._OppositionSet.Add(match.HomeTeam);
				this._OppositionSet.Add(match.AwayTeam);
			}

			this._OppositionSet.Remove(this._OppositionSet.First(el => el.Code == this._SelectedFifaCode));

			foreach (MatchTeam mTeam in this._OppositionSet)
			{
				this.cbOpositionsRep.Items.Add(mTeam);
			}
			dialog.Close();
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

		private void cbFavoriteRep_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			IDictionary<string, string> conf = ConfigurationParser.ParseConfigFile(ConfigFilePaths.LOCAL_REPO_LOCAL_CONF_PATH);

			this._SelectedFifaCode = (this.cbFavoriteRep.SelectedItem as Team).FifaCode;
			conf[ConfigKeys.CONFK_FAVORITE_REP] = this._SelectedFifaCode;

			ConfigurationParser.UpdateConfigFile(ConfigFilePaths.LOCAL_REPO_LOCAL_CONF_PATH, conf);

			this._LoadCbOponents(new MyLoading());
			this._UpdateBigLabel();
		}

		private void _UpdateBigLabel()
		{
			if (!string.IsNullOrEmpty(this._SelectedFifaCode) && !string.IsNullOrEmpty(this._SelectedOpositionFifaCode))
			{ 
				this.lbBigGame.Content = $"{this._SelectedFifaCode} ~VS~ {this._SelectedOpositionFifaCode}";
			}
			else
			{
				this.lbBigGame.Content = "~VS~";
			}
		}

		private void cbOpositionsRep_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this._SelectedOpositionFifaCode = (this.cbOpositionsRep.SelectedItem as MatchTeam)?.Code;

			this._UpdateBigLabel();
		}
	}
}
