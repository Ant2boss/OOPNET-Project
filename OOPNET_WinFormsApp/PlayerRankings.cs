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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPNET_WinFormsApp
{
	internal delegate string TableStringHandler<T>(T Data);
	internal delegate Bitmap TableBitmapHandler<T>(T Data);

	internal struct TableColumnsDescriptor<T>
	{
		public string ColumnName { get; set; }
		public bool IsImage { get; set; }

		public TableStringHandler<T> StringHandler { get; set; }
		public TableBitmapHandler<T> ImageHandler { get; set; }
	}

	public partial class PlayerRankings : Form
	{
		public PlayerRankings(string FifaCode, string FavoritePlayersPath, char FavoritePlayersDelim)
		{
			InitializeComponent();

			this.FAVORITE_PATH = FavoritePlayersPath;
			this.FAVORITE_DELIM = FavoritePlayersDelim;

			this._InitForm(FifaCode);
		}

		private readonly string FAVORITE_PATH;
		private readonly char FAVORITE_DELIM;

		private void bgLoader_DoWork(object sender, DoWorkEventArgs e)
		{
			string fifaCode = e.Argument.ToString();

			(sender as BackgroundWorker).ReportProgress(50);

			this._RankingsRepo = RepoFactory.GetPlayerRankingsRepo(fifaCode);

			this._FavortitePlayers = this._ParseFavoritePlayersFile();

			this._PlayerStatistics = new List<PlayerStatistics>();

			foreach (LocalPlayerView player in this._FavortitePlayers)
			{
				PlayerStatistics ps = this._RankingsRepo.GetStatisticsForPlayer(player.Player.Name, player.ImagePath);

				this._PlayerStatistics.Add(ps);
			}

			(sender as BackgroundWorker).ReportProgress(75);
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

		private void printToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.printDialog.ShowDialog() == DialogResult.OK)
			{
				this.printDocument.PrinterSettings = this.printDialog.PrinterSettings;
				this._PageNumber = 0;

				this.printDocument.Print();
			}
		}
		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
		{
			switch (this._PageNumber)
			{
				case 0:
					this._DrawTableFor(e, this._PlayersGoals,
							new TableColumnsDescriptor<PlayerGoalView>
							{
								ColumnName = "Player name",
								IsImage = false,
								StringHandler = (player) => player.PlayerName
							},
							new TableColumnsDescriptor<PlayerGoalView>
							{
								ColumnName = "Goal count",
								IsImage = false,
								StringHandler = (player) => player.GoalCount.ToString()
							},
							new TableColumnsDescriptor<PlayerGoalView>
							{
								ColumnName = "Player image",
								IsImage = true,
								ImageHandler = (player) => this._ExtractBitmapImage(player.PlayerImage, new Size(16, 16))
							}
						);
					e.HasMorePages = true;
					break;
				case 1:
					this._DrawTableFor(e, this._PlayersYellowCards,
							new TableColumnsDescriptor<PlayerYellowCardView>
							{
								ColumnName = "Player name",
								IsImage = false,
								StringHandler = (player) => player.PlayerName
							},
							new TableColumnsDescriptor<PlayerYellowCardView>
							{
								ColumnName = "Goal count",
								IsImage = false,
								StringHandler = (player) => player.YellowCardCount.ToString()
							},
							new TableColumnsDescriptor<PlayerYellowCardView>
							{
								ColumnName = "Player image",
								IsImage = true,
								ImageHandler = (player) => this._ExtractBitmapImage(player.PlayerImage, new Size(16, 16))
							}
						);
					e.HasMorePages = true;
					break;
				case 2:
					this._DrawTableFor(e, this._MatchStatistics,
							new TableColumnsDescriptor<MatchStatistics>
							{
								ColumnName = "Location",
								IsImage = false,
								StringHandler = (match) => match.Location
							},
							new TableColumnsDescriptor<MatchStatistics>
							{
								ColumnName = "Visitor count",
								IsImage = false,
								StringHandler = (match) => match.VisitorCount.ToString()
							},
							new TableColumnsDescriptor<MatchStatistics>
							{
								ColumnName = "Home team",
								IsImage = false,
								StringHandler = (match) => match.HomeTeam
							},
							new TableColumnsDescriptor<MatchStatistics>
							{
								ColumnName = "Away team",
								IsImage = false,
								StringHandler = (match) => match.AwayTeam
							}
						);
					break;
				default:
					e.HasMorePages = false;
					break;
			}

			this._PageNumber++;
		}

		private void _InitForm(string FifaCode)
		{
			this._ProgressDialog = new ProgressDialog();

			this._FifaCode = FifaCode;

			this._AsyncGetPlayers();
		}

		private void _AsyncGetPlayers()
		{
			this.bgLoader.RunWorkerAsync(this._FifaCode);
			this._ProgressDialog.ShowDialog();
		}
		private ISet<LocalPlayerView> _ParseFavoritePlayersFile()
		{
			ISet<LocalPlayerView> Result = new HashSet<LocalPlayerView>();

			string[] fileLines = File.ReadAllLines(FAVORITE_PATH);

			foreach (string line in fileLines)
			{
				Result.Add(LocalPlayerView.ParseFileLine(line, FAVORITE_DELIM));
			}

			return Result;
		}
		
		private void _FillForm()
		{
			List<PlayerStatistics> playerGoalCount = this._PlayerStatistics.ToList();
			playerGoalCount.Sort((ps1, ps2) => -ps1.GoalCount.CompareTo(ps2.GoalCount));
			this._PlayersGoals = PlayerGoalView.ListToYellowCardView(playerGoalCount).ToList();

			foreach (PlayerGoalView playerGoal in this._PlayersGoals)
			{
				this.dgvGoalTable.Rows.Add();
				int rowIndex = this.dgvGoalTable.RowCount - 1;


				Bitmap image = this._ExtractBitmapImage(playerGoal.PlayerImage, new Size(35, 35));

				this.dgvGoalTable.Rows[rowIndex]
					.SetValues(playerGoal.PlayerName, playerGoal.GoalCount, image);
			}


			playerGoalCount.Sort((ps1, ps2) => -ps1.YellowCardCount.CompareTo(ps2.YellowCardCount));
			this._PlayersYellowCards = PlayerYellowCardView.ListToYellowCardView(playerGoalCount).ToList();

			foreach (PlayerYellowCardView playerYellow in this._PlayersYellowCards)
			{
				this.dgvYellowCardTable.Rows.Add();
				int rowIndex = this.dgvYellowCardTable.RowCount - 1;

				Bitmap image = this._ExtractBitmapImage(playerYellow.PlayerImage, new Size(35, 35));

				this.dgvYellowCardTable.Rows[rowIndex]
					.SetValues(playerYellow.PlayerName, playerYellow.YellowCardCount, image);
			}


			this._MatchStatistics = RepoFactory.GetVisitorRankingsRepo(this._FifaCode).GetMatchStatistics();
			this.dgvViewerTable.DataSource = this._MatchStatistics;
		}

		private Bitmap _ExtractBitmapImage(string imagePath, Size imgSize)
		{
			Bitmap image = null;

			if (string.IsNullOrEmpty(imagePath))
			{
				image = new Bitmap(OOPNET_WinFormsApp.Properties.Resources.noimage, imgSize);
			}
			else
			{
				image = new Bitmap(new Bitmap(imagePath), imgSize);
			}

			return image;
		}
		
		private void _DrawTableFor<T>(PrintPageEventArgs pageArgs, IList<T> tableContent, params TableColumnsDescriptor<T>[] tableColumns)
		{
			int columnCount = tableColumns.Length;
			int rowCount = tableContent.Count;

			int columnWidth = pageArgs.MarginBounds.Width / columnCount;
			int columnHeight = 35;

			string fontName = "Arial";
			int fontSize = 12;

			int stringLeftPadding = 5;
			int stringTopPadding = (int)((columnHeight - fontSize) * 0.4);

			Graphics g = pageArgs.Graphics;
			Rectangle rect = new Rectangle(0, 0, columnWidth, columnHeight);

			for (int i = 0; i < tableColumns.Length; ++i)
			{
				rect.Location = new Point(pageArgs.MarginBounds.Left + columnWidth * i, pageArgs.MarginBounds.Top);

				g.FillRectangle(Brushes.LightGray, rect);
				g.DrawRectangle(Pens.Black, rect);

				rect.Location = new Point(rect.Location.X + stringLeftPadding, rect.Location.Y + stringTopPadding);
				g.DrawString(tableColumns[i].ColumnName, new Font(fontName, fontSize), Brushes.Black, rect.Location);

			}

			for (int row = 0; row < tableContent.Count; ++row)
			{
				for (int col = 0; col < tableColumns.Length; ++col)
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
					if (tableColumns[col].IsImage)
					{
						g.DrawImage(tableColumns[col].ImageHandler?.Invoke(tableContent[row]), rect.Location);
					}
					else
					{ 
						g.DrawString(tableColumns[col].StringHandler?.Invoke(tableContent[row]), new Font(fontName, (int)(fontSize * 0.8)), Brushes.Black, rect.Location);
					}
				}
			}


		}

		private ISet<LocalPlayerView> _FavortitePlayers;
		private IList<PlayerStatistics> _PlayerStatistics;

		private IList<PlayerYellowCardView> _PlayersYellowCards;
		private IList<PlayerGoalView> _PlayersGoals;
		private IList<MatchStatistics> _MatchStatistics;

		private IPlayerRankingsRepo _RankingsRepo;

		private ProgressDialog _ProgressDialog;

		private string _FifaCode;

		private int _PageNumber = 0;
	}
}
