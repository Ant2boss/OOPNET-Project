using OOPNET_DataLayer.Configs;
using OOPNET_DataLayer.Models;
using OOPNET_DataLayer.Models.FavoritePlayers;
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
	/// Interaction logic for MyPlayer.xaml
	/// </summary>
	public partial class MyPlayer : Window
	{
		public MyPlayer(FavoritePlayer PlayerToShow, Match Game)
		{
			InitializeComponent();

			this._Player = PlayerToShow;
			this._Game = Game;

			this._InitWindow();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void _InitWindow()
		{
			this.lbName.Content = this._Player.Player.Name;
			this.lbShirtNumber.Content = this._Player.Player.ShirtNumber;

			Uri imgUri;
			if (!string.IsNullOrEmpty(this._Player.ImagePath))
			{
				imgUri = new Uri(System.IO.Path.GetFullPath(this._Player.ImagePath));
			}
			else
			{
				imgUri = new Uri(System.IO.Path.GetFullPath(ConfigFilePaths.LOCAL_REPO_IMAGES_DIR + "/noimage.jpg"));
			}
			
			this.imgImage.Source = new BitmapImage(imgUri);

			this.lbPosition.Content = this._Player.Player.Position;
			this.lbIsCaptain.Content = (this._Player.Player.Captain) ? (OOPNET_WPFApp.Properties.Resources.OptionYes) : (Properties.Resources.OptionNo);

			this.lbGoalCount.Content = this._CountUpGoals();
			this.lbYellowCount.Content = this._CountUpYellows();

		}

		private object _CountUpYellows()
		{
			IList<MatchTeamEvent> allMatchEvents = this._Game.HomeTeamEvents.Union(this._Game.AwayTeamEvents).ToList();

			return allMatchEvents
				.Where(m => m.Player == this._Player.Player.Name && m.TypeOfEvent == "yellow-card")
				.Count();
		}
		private int _CountUpGoals()
		{
			IList<MatchTeamEvent> allMatchEvents = this._Game.HomeTeamEvents.Union(this._Game.AwayTeamEvents).ToList();

			return allMatchEvents
				.Where(m => m.Player == this._Player.Player.Name && m.TypeOfEvent == "goal")
				.Count();
		}

		FavoritePlayer _Player;
		Match _Game;


	}
}
