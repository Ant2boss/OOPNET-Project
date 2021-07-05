﻿using OOPNET_DataLayer.Models;
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

namespace OOPNET_WinFormsApp.UserControls
{
	public partial class PlayerUC : UserControl
	{
		public PlayerUC(LocalPlayerView Player)
		{
			InitializeComponent();

			this.lbName.Text = Player.Player.Name;
			this.lbShirtNumber.Text = Player.Player.ShirtNumber.ToString();
			this.lbPosition.Text = Player.Player.Position;

			this.lbIsCaptain.Text = (Player.Player.Captain) ? ("X") : ("");
			this.SetIsFavorite(Player.IsFavorite);

			if (!string.IsNullOrEmpty(Player.ImagePath))
			{
				this.pbPicture.ImageLocation = Player.ImagePath;
			}

			this.btnEdit.Visible = Player.IsFavorite;

			this._Player = Player;
		}

		LocalPlayerView _Player;

		public void SetIsFavorite(bool isFavorite)
		{
			this.lbIsFavorite.Text = (isFavorite) ? ("*") : ("");
		}

		public event EventHandler OnPlayerImageUpdated;

		public event EventHandler<LocalPlayerView> OnMoveToFavorites;
		public event EventHandler<LocalPlayerView> OnRemoveFromFavorites;

		private void PlayerUC_MouseDown(object sender, MouseEventArgs e)
		{
			this.DoDragDrop(this._Player, DragDropEffects.Copy);
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			OpenFileDialog fileDialog = new OpenFileDialog();

			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				string copyLocation = $"./LocalRepo/Images/{Guid.NewGuid()}.{fileDialog.FileName.Substring(fileDialog.FileName.LastIndexOf('.') + 1)}";

				File.Copy(fileDialog.FileName, copyLocation);

				this._Player.ImagePath = copyLocation;

				this.pbPicture.ImageLocation = this._Player.ImagePath;

				this.OnPlayerImageUpdated?.Invoke(this, new EventArgs());
			}
		}

		private void tsbtnAddToFavorites_Click(object sender, EventArgs e)
		{
			this.OnMoveToFavorites?.Invoke(this, this._Player);
		}
		private void tsbtnRemoveFromFavorites_Click(object sender, EventArgs e)
		{
			this.OnRemoveFromFavorites?.Invoke(this, this._Player);
		}
	}
}