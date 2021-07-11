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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOPNET_WPFApp.UserControls
{
	/// <summary>
	/// Interaction logic for PlayerUC.xaml
	/// </summary>
	public partial class PlayerUC : UserControl
	{
		public PlayerUC(MatchPlayer player)
		{
			InitializeComponent();

			this._InitUC(player);
		}

		public PlayerUC(MatchPlayer player, string ImgPath) : this(player)
		{
			this.imgPlayerImage.UriSource = new Uri(ImgPath, UriKind.Relative);
		}

		private void _InitUC(MatchPlayer player)
		{
			this._Player = player;

			this.lbShirtNumber.Content = player.ShirtNumber;
			this.tbPlayerName.Text = player.Name;
		}

		private MatchPlayer _Player;

		public event EventHandler<MatchPlayer> OnPlayerClicked;

		private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			this.OnPlayerClicked?.Invoke(this, this._Player);
		}
	}
}
