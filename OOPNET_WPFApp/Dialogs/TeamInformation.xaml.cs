using OOPNET_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OOPNET_WPFApp.Dialogs
{
	/// <summary>
	/// Interaction logic for TeamInformation.xaml
	/// </summary>
	public partial class TeamInformation : Window
	{
		public TeamInformation(TeamResults teamResult)
		{
			InitializeComponent();

			this._TeamRes = teamResult;

			this._InitWindow();
		}

		private void _InitWindow()
		{
			this.lbTeamCode.Content = this._TeamRes.FifaCode;
			this.lbTeamName.Content = this._TeamRes.Country;

			this.lbPlayedCount.Content = this._TeamRes.GamesPlayed;
			this.lbWinCount.Content = this._TeamRes.Wins;
			this.lbLossCount.Content = this._TeamRes.Losses;
			this.lbUndecidedCount.Content = this._TeamRes.Draws;

			this.lbGoalsScoredCount.Content = this._TeamRes.GoalsFor;
			this.lbGoalsTakenCount.Content = this._TeamRes.GoalsAgainst;
			this.lbGoalsDiffCount.Content = this._TeamRes.GoalDifferential;
		}

		TeamResults _TeamRes;
	}
}
