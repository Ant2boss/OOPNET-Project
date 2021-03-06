using OOPNET_DataLayer.Configs;
using OOPNET_DataLayer.Models;
using OOPNET_DataLayer.Models.FavoritePlayers;
using OOPNET_DataLayer.Repository;
using OOPNET_DataLayer.Repository.RepoInternals;
using OOPNET_Utils.Configuration;
using OOPNET_WinFormsApp.Configs;
using OOPNET_WinFormsApp.Initializations;
using OOPNET_WinFormsApp.Models;
using OOPNET_WinFormsApp.UserControls;
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

			this._InitForm();

			this.CenterToScreen();
		}

		private readonly string CONFIG_FILE_PATH = GlobalConfig.CONFIG_PATH;
		private readonly string USER_CONFIG_FILE_PATH = LocalConfig.LOCAL_CONFIG_PATH;

		private const string CONFK_CULTURE = GlobalConfig.CONFK_CULTURE;
		private const string CONFK_CUP_TYPE = GlobalConfig.CONFK_CUP_TYPE;

		private const string CONFK_FAVORITE = LocalConfig.CONFK_FAVORITE_REPRESENT;

		private readonly string FAVORITE_PLAYERS_PATH = $"{ConfigFilePaths.LOCAL_REPO_DIR}/FavoritePlayers.txt";
		private const char FAVORITE_PLAYERS_DELIM = '|';

		private void cbTeams_SelectedIndexChanged(object sender, EventArgs e)
		{
			IDictionary<string, string> config = ConfigurationParser.ParseConfigFile(USER_CONFIG_FILE_PATH);
			config[CONFK_FAVORITE] = (this.cbTeams.SelectedItem as Team).FifaCode;
			ConfigurationParser.UpdateConfigFile(USER_CONFIG_FILE_PATH, config);

			this._AsyncUpdateTeamPlayers(config[CONFK_FAVORITE]);
		}

		private void PlayerUC_OnMoveToFavorites(object sender, FavoritePlayer e)
		{
			this._AddFavoritePlayerToList(e);
			this._FillPlayerUserControls();
		}
		private void PlayerUC_OnRemoveFromFavorites(object sender, FavoritePlayer e)
		{
			_RemoveFavoritePlayerFromList(e);
			this._FillPlayerUserControls();
		}
		private void PlayerUC_OnPlayerImageUpdated(object sender, EventArgs e)
		{
			this._UpdateFile();
		}

		private void bgWorkerPlayerLoader_DoWork(object sender, DoWorkEventArgs e)
		{
			IMatchesRepo matchesRepo = RepoFactory.GetMatchesRepo();

			Match firstMatchOfTeam = matchesRepo.GetMatchesOfCountry(e.Argument.ToString()).First();

			if (firstMatchOfTeam.HomeTeam.Code == e.Argument.ToString())
			{
				this._Players = firstMatchOfTeam.HomeTeamStatistics.StartingEleven.Union(firstMatchOfTeam.HomeTeamStatistics.Substitutes)
					.Select(el => new FavoritePlayer(el))
					.ToHashSet();
			}
			else
			{
				this._Players = firstMatchOfTeam.AwayTeamStatistics.StartingEleven.Union(firstMatchOfTeam.AwayTeamStatistics.Substitutes)
					.Select(el => new FavoritePlayer(el))
					.ToHashSet();
			}
		}
		private void bgWorkerPlayerLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this._FillPlayerUserControls();
			this.tsProgressBar.Value = 100;
			this.tslbProgressLabel.Text = "Done!";
		}

		private void flpFavoritePlayers_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Copy;
		}
		private void flpFavoritePlayers_DragDrop(object sender, DragEventArgs e)
		{
			FavoritePlayer PlayerToAdd = e.Data.GetData(typeof(FavoritePlayer)) as FavoritePlayer;

			this._AddFavoritePlayerToList(PlayerToAdd);
			this._FillPlayerUserControls();
		}

		private void flpAllPlayers_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Copy;
		}
		private void flpAllPlayers_DragDrop(object sender, DragEventArgs e)
		{
			FavoritePlayer PlayerToRemove = e.Data.GetData(typeof(FavoritePlayer)) as FavoritePlayer;

			this._RemoveFavoritePlayerFromList(PlayerToRemove);
			this._FillPlayerUserControls();
		}

		private void btnRankings_Click(object sender, EventArgs e)
		{
			IDictionary<string, string> config = ConfigurationParser.ParseConfigFile(USER_CONFIG_FILE_PATH);

			new PlayerRankings(config[CONFK_FAVORITE], FAVORITE_PLAYERS_PATH, FAVORITE_PLAYERS_DELIM).Show();
		}

		private void tsmbtnSettings_Click(object sender, EventArgs e)
		{
			IDictionary<string, string> config = ConfigurationParser.ParseConfigFile(CONFIG_FILE_PATH);

			if (this._GlobalConfigChooser(config))
			{
				MessageBox.Show("You must restrat the app for these changes to take effect!", "Success");
				Application.Exit();
			}
		}
		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogResult confirmResult = MessageBox.Show("Realy?", "Exit", MessageBoxButtons.OKCancel);
			if (confirmResult == DialogResult.OK)
			{
				Application.Exit();
			}
		}

		private bool _InitSettings()
		{
			if (!_InitCupTypeAndCulture())
			{
				return false;
			}

			IDictionary<string, string> config = ConfigurationParser.ParseConfigFile(CONFIG_FILE_PATH);

			Thread.CurrentThread.CurrentCulture = new CultureInfo(config[CONFK_CULTURE]);
			Thread.CurrentThread.CurrentUICulture = new CultureInfo(config[CONFK_CULTURE]);

			this._FavoritePlayers = this._LoadFavoritePlayers();

			return true;
		}
		private bool _InitCupTypeAndCulture()
		{
			try
			{
				//Try to open file
				IDictionary<string, string> config = ConfigurationParser.ParseConfigFile(CONFIG_FILE_PATH);

				//Check the two settings if they are empty
				if (string.IsNullOrEmpty(config[CONFK_CULTURE]) || string.IsNullOrEmpty(config[CONFK_CUP_TYPE]))
				{
					//Get the information from the Chooser
					return this._GlobalConfigChooser(config);
				}

				return true;
			}
			catch (Exception ex)
			{
				if (ex is FileNotFoundException || ex is KeyNotFoundException)
				{
					MessageBox.Show("Error reading config, creating new config file!", "Error");
					GlobalConfig.CreateEmptyConfigFile();
					LocalConfig.CreateEmptyConfigFile();
					return this._InitCupTypeAndCulture();
				}

				throw;
			}
		}
		private void _InitForm()
		{
			IList<Team> teams = RepoFactory.GetTeamsRepo().GetAllTeams();

			teams.ToList().ForEach(t => this.cbTeams.Items.Add(t));

			IDictionary<string, string> config = ConfigurationParser.ParseConfigFile(USER_CONFIG_FILE_PATH);

			if (!string.IsNullOrEmpty(config[CONFK_FAVORITE]) && teams.FirstOrDefault(t => t.FifaCode == config[CONFK_FAVORITE]) != null)
			{
				string favTeamCode = config[CONFK_FAVORITE];

				Team favoriteTeam = teams.First(t => t.FifaCode == favTeamCode);

				this.cbTeams.SelectedItem = favoriteTeam;
			}
		}

		private ISet<FavoritePlayer> _LoadFavoritePlayers()
		{
			ISet<FavoritePlayer> Result = new HashSet<FavoritePlayer>();

			if (!File.Exists(FAVORITE_PLAYERS_PATH))
			{
				File.Create(FAVORITE_PLAYERS_PATH).Close();
			}

			string[] fileLines = File.ReadAllLines(FAVORITE_PLAYERS_PATH);

			foreach (string line in fileLines)
			{
				Result.Add(FavoritePlayer.ParseFileLine(line, FAVORITE_PLAYERS_DELIM));
			}

			return Result;
		}
		private void _FillPlayerUserControls()
		{
			this.flpAllPlayers.Controls.Clear();
			this.flpFavoritePlayers.Controls.Clear();

			foreach (FavoritePlayer favPlayer in this._FavoritePlayers)
			{
				this._Players.Remove(favPlayer);
				favPlayer.IsFavorite = true;

				PlayerUC playerUC = new PlayerUC(favPlayer);

				playerUC.SetIsFavorite(true);

				playerUC.OnPlayerImageUpdated += PlayerUC_OnPlayerImageUpdated;
				playerUC.OnRemoveFromFavorites += PlayerUC_OnRemoveFromFavorites;

				this.flpFavoritePlayers.Controls.Add(playerUC);
			}

			foreach (FavoritePlayer player in this._Players)
			{
				PlayerUC playerUC = new PlayerUC(player);

				playerUC.OnMoveToFavorites += PlayerUC_OnMoveToFavorites;

				this.flpAllPlayers.Controls.Add(playerUC);
			}

		}

		private void _AsyncUpdateTeamPlayers(string FifaCode)
		{
			this.flpAllPlayers.Controls.Clear();

			this.tsProgressBar.Value = 0;
			this.tslbProgressLabel.Text = "Loading players...";

			if (!this.bgWorkerPlayerLoader.IsBusy)
			{ 
				this.bgWorkerPlayerLoader.RunWorkerAsync(FifaCode);
			}
		}
		private void _UpdateFile()
		{
			IList<string> fileLines = new List<string>();
			foreach (FavoritePlayer favPlayer in this._FavoritePlayers)
			{
				fileLines.Add(favPlayer.FormatForFileLine(FAVORITE_PLAYERS_DELIM));
			}

			File.WriteAllLines(FAVORITE_PLAYERS_PATH, fileLines);
		}
		

		private void _AddFavoritePlayerToList(FavoritePlayer playerToAdd)
		{
			this._FavoritePlayers.Add(playerToAdd);

			this._UpdateFile();
		}
		private void _RemoveFavoritePlayerFromList(FavoritePlayer e)
		{
			e.IsFavorite = false;

			this._FavoritePlayers.Remove(e);
			this._Players.Add(e);

			if (!string.IsNullOrEmpty(e.ImagePath))
			{
				File.Delete(e.ImagePath);
				e.ImagePath = "";
			}

			this._UpdateFile();
		}

		private bool _GlobalConfigChooser(IDictionary<string, string> config)
		{
			CupChooser repChooser = new CupChooser();
			if (repChooser.ShowDialog() == DialogResult.OK)
			{
				config[CONFK_CULTURE] = repChooser.GetCulture();
				config[CONFK_CUP_TYPE] = repChooser.GetCupType();

				//Update information
				ConfigurationParser.UpdateConfigFile(CONFIG_FILE_PATH, config);

				return true;
			}
			else
			{
				return false;
			}
		}

		private ISet<FavoritePlayer> _Players;
		private ISet<FavoritePlayer> _FavoritePlayers;
	}
}
