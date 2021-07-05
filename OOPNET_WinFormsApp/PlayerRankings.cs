using OOPNET_DataLayer.Models;
using OOPNET_DataLayer.Repository;
using OOPNET_WinFormsApp.Dialogs;
using OOPNET_WinFormsApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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

		string _FifaCode;

		private readonly string FAVORITE_PATH;
		private readonly char FAVORITE_DELIM;

		private void _InitForm(string FifaCode)
		{
			this._ProgressDialog = new ProgressDialog();

			this._FifaCode = FifaCode;

			this._LoadPlayers();
		}

		private void _LoadPlayers()
		{
			this.bgLoader.RunWorkerAsync(this._FifaCode);
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

		private IList<PlayerYellowCardView> _PlayersYellowCards;
		private IList<PlayerGoalView> _PlayersGoals;
		private IList<MatchStatistics> _MatchStatistics;

		private void _FillForm()
		{
			List<PlayerStatistics> playerGoalCount = this._PlayerStatistics.ToList();
			playerGoalCount.Sort((ps1, ps2) => -ps1.GoalCount.CompareTo(ps2.GoalCount));
			this._PlayersGoals = PlayerGoalView.ListToYellowCardView(playerGoalCount).ToList();
			this.dgvGoalTable.DataSource = this._PlayersGoals;

			playerGoalCount.Sort((ps1, ps2) => -ps1.YellowCardCount.CompareTo(ps2.YellowCardCount));
			this._PlayersYellowCards = PlayerYellowCardView.ListToYellowCardView(playerGoalCount).ToList();
			this.dgvYellowCardTable.DataSource = this._PlayersYellowCards;

			this._MatchStatistics = RepoFactory.GetVisitorRankingsRepo(this._FifaCode).GetMatchStatistics();
			this.dgvViewerTable.DataSource = this._MatchStatistics;
		}

		private void printToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.printDialog.ShowDialog();

			this.printDocument.PrinterSettings = this.printDialog.PrinterSettings;
			this._PageNumber = 0;

			this.printDocument.Print();
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		int _PageNumber = 0;

		private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			switch (this._PageNumber)
			{
			case 0:
				this._DrawTableFor(e, this._PlayersGoals,
					new List<string>
					{
					"PlayerName",
					"GoalCount",
					"PlayerImage",
					},
					new List<Func<PlayerGoalView, string>>
					{
					(player) => player.PlayerName,
					(player) => player.GoalCount.ToString(),
					(player) => player.PlayerImage,
					});
				e.HasMorePages = true;
				break;
			case 1:
				this._DrawTableFor(e, this._PlayersYellowCards,
					new List<string>
					{
					"PlayerName",
					"Yellow cards",
					"PlayerImage",
					},
					new List<Func<PlayerYellowCardView, string>>
					{
					(player) => player.PlayerName,
					(player) => player.YellowCardCount.ToString(),
					(player) => player.PlayerImage,
					});
				e.HasMorePages = true;
				break;
			case 2:
				this._DrawTableFor(e, this._MatchStatistics,
					new List<string>
					{
					"Location",
					"Visitior count",
					"Home team",
					"Away team",
					},
					new List<Func<MatchStatistics, string>>
					{
					(match) => match.Location,
					(match) => match.VisitorCount.ToString(),
					(match) => match.HomeTeam,
					(match) => match.AwayTeam,
					});
				break;
			default:
					e.HasMorePages = false;
				break;
			}

			this._PageNumber++;
			//this._DrawTableFor(graphics, this._PlayersGoals, "PlayerName", "PlayerImage", "YellowCardCount");
			//this._DrawTableFor(graphics, this._PlayersGoals, "Location", "VisitorCount", "HomeTeam", "AwayTeam");

		}

		private void _DrawTableFor<T>(PrintPageEventArgs pageArgs, IList<T> tableContent, IList<string> tableColumns, IList<Func<T, string>> tableData)
		{
			int columnCount = tableColumns.Count;
			int rowCount = tableContent.Count;

			int columnWidth = pageArgs.MarginBounds.Width / columnCount;
			int columnHeight = 35;

			string fontName = "Arial";
			int fontSize = 12;

			int stringLeftPadding = 5;
			int stringTopPadding = (int)((columnHeight - fontSize) * 0.4);

			Graphics g = pageArgs.Graphics;
			Rectangle rect = new Rectangle(0, 0, columnWidth, columnHeight);

			for (int i = 0; i < tableColumns.Count; ++i)
			{
				rect.Location = new Point(pageArgs.MarginBounds.Left + columnWidth * i, pageArgs.MarginBounds.Top);

				g.FillRectangle(Brushes.LightGray, rect);
				g.DrawRectangle(Pens.Black, rect);

				rect.Location = new Point(rect.Location.X + stringLeftPadding, rect.Location.Y + stringTopPadding);
				g.DrawString(tableColumns[i], new Font(fontName, fontSize), Brushes.Black, rect.Location);

			}

			for (int row = 0; row < tableContent.Count; ++row)
			{
				for (int col = 0; col < tableColumns.Count; ++col)
				{
					rect.Location = new Point(
						pageArgs.MarginBounds.Left + columnWidth * col,
						pageArgs.MarginBounds.Top + columnHeight * (row + 1)
						);

					if (row % 2 != 0)
					{
						g.FillRectangle(Brushes.LightGray, rect);
					}
					g.DrawRectangle(Pens.Black, rect);

					rect.Location = new Point(rect.Location.X + stringLeftPadding, rect.Location.Y + stringTopPadding);
					g.DrawString(tableData[col]?.Invoke(tableContent[row]), new Font(fontName, (int)(fontSize * 0.8)), Brushes.Black, rect.Location);
				}
			}


		}
	}
}
