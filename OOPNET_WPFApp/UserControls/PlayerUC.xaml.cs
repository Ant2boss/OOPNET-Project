using OOPNET_DataLayer.Models;
using OOPNET_DataLayer.Models.FavoritePlayers;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOPNET_WPFApp.UserControls
{
	/// <summary>
	/// Interaction logic for PlayerUC.xaml
	/// </summary>
	public partial class PlayerUC : UserControl
	{
		public PlayerUC(FavoritePlayer player)
		{
			InitializeComponent();

			this._InitUC(player);
		}

		private void _InitUC(FavoritePlayer player)
		{
			this._Player = player;

			this.lbShirtNumber.Content = player.Player.ShirtNumber;
			this.tbPlayerName.Text = player.Player.Name;


			if (!string.IsNullOrEmpty(player.ImagePath))
			{
				this.img.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath(player.ImagePath), UriKind.Absolute));
			}
		}

		private FavoritePlayer _Player;

		public event EventHandler<FavoritePlayer> OnPlayerClicked;

		private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			this.OnPlayerClicked?.Invoke(this, this._Player);
		}
	}
}
