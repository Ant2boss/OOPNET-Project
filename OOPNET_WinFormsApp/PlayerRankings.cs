using OOPNET_DataLayer.Models;
using OOPNET_DataLayer.Repository;
using OOPNET_WinFormsApp.Dialogs;
using OOPNET_WinFormsApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPNET_WinFormsApp
{
	public partial class PlayerRankings : Form
	{
		public PlayerRankings(string FifaCode, string FavoritePlayersPath, char FavoritePlayersDelim)
		{
			InitializeComponent();

			this.FAVORITE_PATH = FavoritePlayersPath;
			this.FAVORITE_DELIM = FavoritePlayersDelim;

			this._InitForm(FifaCode);
		}

		ISet<LocalPlayerView> _FavortitePlayers;
		IList<PlayerStatistics> _PlayerStatistics;
		IPlayerRankingsRepo _RankingsRepo;

		ProgressDialog _ProgressDialog;

		private readonly string FAVORITE_PATH;
		private readonly char FAVORITE_DELIM;

		private void _InitForm(string FifaCode)
		{
			this._ProgressDialog = new ProgressDialog();

			this._LoadPlayers(FifaCode);
		}

		private void _LoadPlayers(string FifaCode)
		{
			this.bgLoader.RunWorkerAsync(FifaCode);
			this._ProgressDialog.ShowDialog();
		}

		private ISet<LocalPlayerView> _LoadFavoritePlayers()
		{
			ISet<LocalPlayerView> Result = new HashSet<LocalPlayerView>();

			string[] fileLines = File.ReadAllLines(FAVORITE_PATH);

			foreach (string line in fileLines)
			{
				Result.Add(LocalPlayerView.ParseFileLine(line, FAVORITE_DELIM));
			}

			return Result;
		}

		private void bgLoader_DoWork(object sender, DoWorkEventArgs e)
		{
			string fifaCode = e.Argument.ToString();

			this._RankingsRepo = RepoFactory.GetPlayerRankingsRepo(fifaCode);

			(sender as BackgroundWorker).ReportProgress(50);

			this._FavortitePlayers = this._LoadFavoritePlayers();

			this._PlayerStatistics = new List<PlayerStatistics>();

			foreach (LocalPlayerView player in this._FavortitePlayers)
			{
				PlayerStatistics ps = this._RankingsRepo.GetStatisticsForPlayer(player.Player.Name, player.ImagePath);

				this._PlayerStatistics.Add(ps);
			}
		}

		private void bgLoader_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			this._ProgressDialog.SetPorgress(e.ProgressPercentage);
		}

		private void bgLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this._FillForm();

			this._ProgressDialog.Close();
		}

		private void _FillForm()
		{
			this.flpGoalCount.Controls.Clear();
			this.flpYellowCards.Controls.Clear();

			List<PlayerStatistics> playerGoalCount = this._PlayerStatistics.ToList();
			playerGoalCount.Sort((ps1, ps2) => -ps1.GoalCount.CompareTo(ps2.GoalCount));

			playerGoalCount.ForEach(
					ps => {
						this.flpGoalCount.Controls.Add(this._CreatePanel(ps, ps.GoalCount));
					}
				);

			playerGoalCount.Sort((ps1, ps2) => -ps1.YellowCardCount.CompareTo(ps2.YellowCardCount));

			playerGoalCount.ForEach(
					ps => {
						this.flpYellowCards.Controls.Add(this._CreatePanel(ps, ps.YellowCardCount));
					}
				);

		}

		private Control _CreatePanel(PlayerStatistics ps, int count)
		{
			FlowLayoutPanel panel = new FlowLayoutPanel();

			panel.Width = 200;
			panel.Height = 150;

			panel.BackColor = Color.AliceBlue;

			panel.FlowDirection = FlowDirection.TopDown;

			panel.Controls.Add(new Label { Text = $"{ps.PlayerName} [{count}]", AutoSize = true });
			panel.Controls.Add(new PictureBox { Width = 160, Height = 90, ImageLocation = ps.PlayerImage, SizeMode = PictureBoxSizeMode.StretchImage });

			return panel;
		}
	}
}
