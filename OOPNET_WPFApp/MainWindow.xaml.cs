using OOPNET_DataLayer.Configs;
using OOPNET_DataLayer.Models;
using OOPNET_DataLayer.Models.FavoritePlayers;
using OOPNET_DataLayer.Repository;
using OOPNET_Utils.Configuration;
using OOPNET_WPFApp.Dialogs;
using OOPNET_WPFApp.UserControls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

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

		private void cbFavoriteRep_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			IDictionary<string, string> conf = ConfigurationParser.ParseConfigFile(ConfigFilePaths.LOCAL_REPO_LOCAL_CONF_PATH);

			this._SelectedFifaCode = (this.cbFavoriteRep.SelectedItem as Team).FifaCode;
			conf[ConfigKeys.CONFK_FAVORITE_REP] = this._SelectedFifaCode;

			ConfigurationParser.UpdateConfigFile(ConfigFilePaths.LOCAL_REPO_LOCAL_CONF_PATH, conf);

			this._LoadCbOponents(new MyLoading());
			this._UpdateGameShowcase();
		}
		private void cbOpositionsRep_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this._SelectedOpositionFifaCode = (this.cbOpositionsRep.SelectedItem as MatchTeam)?.Code;

			this._UpdateGameShowcase();
		}

		private void PlayerUserControl_OnPlayerClicked(object sender, FavoritePlayer e)
		{
			MyPlayer playerDialog = new MyPlayer(e, this._Game);
			playerDialog.ShowDialog();
		}

		private void btnFavTeam_Click(object sender, RoutedEventArgs e)
		{
			new TeamInformation(this._TeamsList.First(t => t.FifaCode == this._SelectedFifaCode)).ShowDialog();
		}
		private void btnOppTeam_Click(object sender, RoutedEventArgs e)
		{
			new TeamInformation(this._TeamsList.First(t => t.FifaCode == this._SelectedOpositionFifaCode)).ShowDialog();
		}

		private void btnSettings_Click(object sender, RoutedEventArgs e)
		{
			Settings settingsDialog = new Settings();

			bool? isOk = settingsDialog.ShowDialog();

			if (isOk.HasValue && isOk.Value)
			{
				IDictionary<string, string> conf = ConfigurationParser.ParseConfigFile(this.GLOBAL_CONFIG);

				conf[GlobalConfig.CONFK_CULTURE] = settingsDialog.Culture;
				conf[GlobalConfig.CONFK_CUP_TYPE] = (settingsDialog.IsMaleCup) ? (CupType.MaleCup.ToString()) : (CupType.FemaleCup.ToString());
				conf[GlobalConfig.CONFK_RESOLUTION] = settingsDialog.Resolution;

				ConfigurationParser.UpdateConfigFile(this.GLOBAL_CONFIG, conf);

				MessageBox.Show(Properties.InfoMessages.SettingsCloseMessage, Properties.InfoMessages.SettingsCloseTitle, MessageBoxButton.OK, MessageBoxImage.Information);

				this.Close();
			}

		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (MessageBox.Show(Properties.InfoMessages.AppCloseMessage, Properties.InfoMessages.AppCloseTitle, MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.Cancel)
			{
				e.Cancel = true;
			}

		}

		ITeamsRepo _TeamsRepo;
		IMatchesRepo _MatchesRepo;

		IList<TeamResults> _TeamsList;
		ISet<MatchTeam> _OppositionSet;

		string _SelectedFifaCode;
		string _SelectedOpositionFifaCode;

		WindowStyle? _OriginalStyle = null;
		WindowState? _OriginalState = null;

		private Match _Game;

		private void _InitForm()
		{
			this._TeamsRepo = RepoFactory.GetTeamsRepo();
			this._MatchesRepo = RepoFactory.GetMatchesRepo();

			this._OppositionSet = new HashSet<MatchTeam>();

			this._LoadTeamsAndMatchesList(new MyLoading());

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
				MessageBox.Show(OOPNET_WPFApp.Properties.InfoMessages.ErrorReadingConfig, Properties.InfoMessages.ErrorTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
				File.Delete(this.GLOBAL_CONFIG);
				this._InitSettings();
			}
		}

		private void _LoadTeamsAndMatchesList(MyLoading dialog)
		{
			dialog.Show();
			this._TeamsList = this._TeamsRepo.GetAllTeamResults();
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
		private IEnumerable<FavoritePlayer> _LoadFavoritePlayers()
		{
			string[] fileLines = File.ReadAllLines(ConfigFilePaths.LOCAL_REPO_DIR + "/FavoritePlayers.txt");

			foreach (string line in fileLines)
			{
				yield return FavoritePlayer.ParseFileLine(line, FavoritePlayer.FAVORITE_PLAYERS_DELIM);
			}
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
		private void _ParseResolution(string resolution)
		{
			string[] res = resolution.Split('x');

			if (res.Length != 2)
			{
				this._OriginalStyle = this.WindowStyle;
				this._OriginalState = this.WindowState;

				this.WindowStyle = WindowStyle.None;
				this.WindowState = WindowState.Maximized;

				return;
			}

			if (this._OriginalState.HasValue)
			{
				this.WindowStyle = this._OriginalStyle.Value;
				this.WindowState = this._OriginalState.Value;
			}

			this.Width = int.Parse(res[0]);
			this.Height = int.Parse(res[1]);
		}

		private void _UpdateGameShowcase()
		{
			if (!string.IsNullOrEmpty(this._SelectedFifaCode) && !string.IsNullOrEmpty(this._SelectedOpositionFifaCode))
			{
				this.lbBigGame.Content = $"{this._SelectedFifaCode} ~VS~ {this._SelectedOpositionFifaCode}";

				this._Game = this._MatchesRepo
					.GetMatchesOfCountry(this._SelectedFifaCode)
					.FirstOrDefault(m => m.HomeTeam.Code == this._SelectedOpositionFifaCode || m.AwayTeam.Code == this._SelectedOpositionFifaCode);

				long favTeamGoal = (this._Game.HomeTeam.Code == this._SelectedFifaCode) ? (this._Game.HomeTeam.Goals) : (this._Game.AwayTeam.Goals);
				long OppTeamGoal = (this._Game.HomeTeam.Code == this._SelectedOpositionFifaCode) ? (this._Game.HomeTeam.Goals) : (this._Game.AwayTeam.Goals);

				this.lbGameScore.Content = $"{favTeamGoal} : {OppTeamGoal}";

				MatchTeamStatistics favTeam = (this._Game.HomeTeam.Code == this._SelectedFifaCode) ? (this._Game.HomeTeamStatistics) : (this._Game.AwayTeamStatistics);
				MatchTeamStatistics oppTeam = (this._Game.HomeTeam.Code == this._SelectedOpositionFifaCode) ? (this._Game.HomeTeamStatistics) : (this._Game.AwayTeamStatistics);

				this._HandlePlayersPannel(this.GridSelectedTeam, favTeam);
				this._HandlePlayersPannel(this.GridOppositionTeam, oppTeam);

			}
			else
			{
				this.lbBigGame.Content = "~VS~";
				this.lbGameScore.Content = "";
				this._Game = null;

				this._ClearField(this.GridSelectedTeam);
				this._ClearField(this.GridOppositionTeam);
			}

			this._HandleButton(this.btnFavTeam, this._SelectedFifaCode);
			this._HandleButton(this.btnOppTeam, this._SelectedOpositionFifaCode);

		}

		private void _HandlePlayersPannel(Grid grid, MatchTeamStatistics teamStats)
		{
			IList<MatchPlayer> startingEleven = teamStats.StartingEleven;
			IList<FavoritePlayer> favPlayer = this._LoadFavoritePlayers().ToList();

			this._ClearField(grid);

			foreach (MatchPlayer player in startingEleven)
			{
				FavoritePlayer favoritePlayerWithImage = favPlayer.FirstOrDefault(p => p.Player.Name == player.Name);

				PlayerUC playerUserControl = new PlayerUC(favoritePlayerWithImage ?? new FavoritePlayer(player));

				playerUserControl.OnPlayerClicked += PlayerUserControl_OnPlayerClicked;

				switch (player.Position)
				{
					case "Goalie":
						(grid.Children[0] as StackPanel).Children.Add(playerUserControl);
						break;
					case "Defender":
						(grid.Children[1] as StackPanel).Children.Add(playerUserControl);
						break;
					case "Midfield":
						(grid.Children[2] as StackPanel).Children.Add(playerUserControl);
						break;
					case "Forward":
						(grid.Children[3] as StackPanel).Children.Add(playerUserControl);
						break;
				}
			}
		}

		private void _ClearField(Grid grid)
		{
			for (int i = 0; i < 4; ++i)
			{
				(grid.Children[i] as StackPanel).Children.Clear();
			}
		}

		private void _HandleButton(Button buttonToHandle, string data)
		{
			if (!string.IsNullOrEmpty(data))
			{
				buttonToHandle.Content = data;
				buttonToHandle.Visibility = Visibility.Visible;
			}
			else
			{
				buttonToHandle.Visibility = Visibility.Hidden;
			}
		}

	}
}
