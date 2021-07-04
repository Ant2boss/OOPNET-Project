
namespace OOPNET_WinFormsApp.UserControls
{
	partial class PlayerUC
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerUC));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lbName = new System.Windows.Forms.Label();
			this.lbShirtNumber = new System.Windows.Forms.Label();
			this.lbPosition = new System.Windows.Forms.Label();
			this.lbIsCaptain = new System.Windows.Forms.Label();
			this.lbIsFavorite = new System.Windows.Forms.Label();
			this.btnEdit = new System.Windows.Forms.Button();
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsbtnAddToFavorites = new System.Windows.Forms.ToolStripMenuItem();
			this.tsbtnRemoveFromFavorites = new System.Windows.Forms.ToolStripMenuItem();
			this.pbPicture = new System.Windows.Forms.PictureBox();
			this.contextMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbPicture)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// label4
			// 
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			// 
			// label5
			// 
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
			// 
			// lbName
			// 
			resources.ApplyResources(this.lbName, "lbName");
			this.lbName.Name = "lbName";
			// 
			// lbShirtNumber
			// 
			resources.ApplyResources(this.lbShirtNumber, "lbShirtNumber");
			this.lbShirtNumber.Name = "lbShirtNumber";
			// 
			// lbPosition
			// 
			resources.ApplyResources(this.lbPosition, "lbPosition");
			this.lbPosition.Name = "lbPosition";
			// 
			// lbIsCaptain
			// 
			resources.ApplyResources(this.lbIsCaptain, "lbIsCaptain");
			this.lbIsCaptain.Name = "lbIsCaptain";
			// 
			// lbIsFavorite
			// 
			resources.ApplyResources(this.lbIsFavorite, "lbIsFavorite");
			this.lbIsFavorite.Name = "lbIsFavorite";
			// 
			// btnEdit
			// 
			resources.ApplyResources(this.btnEdit, "btnEdit");
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// contextMenu
			// 
			resources.ApplyResources(this.contextMenu, "contextMenu");
			this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnAddToFavorites,
            this.tsbtnRemoveFromFavorites});
			this.contextMenu.Name = "contextMenu";
			// 
			// tsbtnAddToFavorites
			// 
			resources.ApplyResources(this.tsbtnAddToFavorites, "tsbtnAddToFavorites");
			this.tsbtnAddToFavorites.Name = "tsbtnAddToFavorites";
			this.tsbtnAddToFavorites.Click += new System.EventHandler(this.tsbtnAddToFavorites_Click);
			// 
			// tsbtnRemoveFromFavorites
			// 
			resources.ApplyResources(this.tsbtnRemoveFromFavorites, "tsbtnRemoveFromFavorites");
			this.tsbtnRemoveFromFavorites.Name = "tsbtnRemoveFromFavorites";
			this.tsbtnRemoveFromFavorites.Click += new System.EventHandler(this.tsbtnRemoveFromFavorites_Click);
			// 
			// pbPicture
			// 
			resources.ApplyResources(this.pbPicture, "pbPicture");
			this.pbPicture.Image = global::OOPNET_WinFormsApp.Properties.Resources.noimage;
			this.pbPicture.Name = "pbPicture";
			this.pbPicture.TabStop = false;
			// 
			// PlayerUC
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ContextMenuStrip = this.contextMenu;
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.pbPicture);
			this.Controls.Add(this.lbIsFavorite);
			this.Controls.Add(this.lbIsCaptain);
			this.Controls.Add(this.lbPosition);
			this.Controls.Add(this.lbShirtNumber);
			this.Controls.Add(this.lbName);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "PlayerUC";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlayerUC_MouseDown);
			this.contextMenu.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbPicture)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lbName;
		private System.Windows.Forms.Label lbShirtNumber;
		private System.Windows.Forms.Label lbPosition;
		private System.Windows.Forms.Label lbIsCaptain;
		private System.Windows.Forms.Label lbIsFavorite;
		private System.Windows.Forms.PictureBox pbPicture;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.ContextMenuStrip contextMenu;
		private System.Windows.Forms.ToolStripMenuItem tsbtnAddToFavorites;
		private System.Windows.Forms.ToolStripMenuItem tsbtnRemoveFromFavorites;
	}
}
