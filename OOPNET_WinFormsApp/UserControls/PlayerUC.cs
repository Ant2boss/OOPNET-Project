using OOPNET_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPNET_WinFormsApp.UserControls
{
	public partial class PlayerUC : UserControl
	{
		public PlayerUC(MatchPlayer Player)
		{
			InitializeComponent();

			this.lbName.Text = Player.Name;
			this.lbShirtNumber.Text = Player.ShirtNumber.ToString();
			this.lbPosition.Text = Player.Position;

			this.lbIsCaptain.Text = (Player.Captain) ? ("X") : ("");
			this.lbIsFavorite.Text = "";

			this._Player = Player;
		}

		MatchPlayer _Player;

		public void SetIsFavorite(bool isFavorite)
		{
			this.lbIsFavorite.Text = (isFavorite) ? ("*") : ("");
		}

		private void PlayerUC_MouseDown(object sender, MouseEventArgs e)
		{
			this.DoDragDrop(this._Player, DragDropEffects.Copy);
		}
	}
}
