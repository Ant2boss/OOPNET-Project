
namespace OOPNET_WinFormsApp
{
	partial class MainForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.label1 = new System.Windows.Forms.Label();
			this.cbTeams = new System.Windows.Forms.ComboBox();
			this.flpAllPlayers = new System.Windows.Forms.FlowLayoutPanel();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tsProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.tslbProgressLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.bgWorkerPlayerLoader = new System.ComponentModel.BackgroundWorker();
			this.flpFavoritePlayers = new System.Windows.Forms.FlowLayoutPanel();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.postavkeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmbtnSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.btnRankings = new System.Windows.Forms.Button();
			this.statusStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// cbTeams
			// 
			resources.ApplyResources(this.cbTeams, "cbTeams");
			this.cbTeams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTeams.FormattingEnabled = true;
			this.cbTeams.Name = "cbTeams";
			this.cbTeams.SelectedIndexChanged += new System.EventHandler(this.cbTeams_SelectedIndexChanged);
			// 
			// flpAllPlayers
			// 
			resources.ApplyResources(this.flpAllPlayers, "flpAllPlayers");
			this.flpAllPlayers.AllowDrop = true;
			this.flpAllPlayers.BackColor = System.Drawing.Color.White;
			this.flpAllPlayers.Name = "flpAllPlayers";
			this.flpAllPlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.flpAllPlayers_DragDrop);
			this.flpAllPlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.flpAllPlayers_DragEnter);
			// 
			// statusStrip1
			// 
			resources.ApplyResources(this.statusStrip1, "statusStrip1");
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsProgressBar,
            this.tslbProgressLabel});
			this.statusStrip1.Name = "statusStrip1";
			// 
			// tsProgressBar
			// 
			resources.ApplyResources(this.tsProgressBar, "tsProgressBar");
			this.tsProgressBar.Name = "tsProgressBar";
			// 
			// tslbProgressLabel
			// 
			resources.ApplyResources(this.tslbProgressLabel, "tslbProgressLabel");
			this.tslbProgressLabel.Name = "tslbProgressLabel";
			// 
			// bgWorkerPlayerLoader
			// 
			this.bgWorkerPlayerLoader.WorkerSupportsCancellation = true;
			this.bgWorkerPlayerLoader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerPlayerLoader_DoWork);
			this.bgWorkerPlayerLoader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerPlayerLoader_RunWorkerCompleted);
			// 
			// flpFavoritePlayers
			// 
			resources.ApplyResources(this.flpFavoritePlayers, "flpFavoritePlayers");
			this.flpFavoritePlayers.AllowDrop = true;
			this.flpFavoritePlayers.BackColor = System.Drawing.Color.White;
			this.flpFavoritePlayers.Name = "flpFavoritePlayers";
			this.flpFavoritePlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.flpFavoritePlayers_DragDrop);
			this.flpFavoritePlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.flpFavoritePlayers_DragEnter);
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
			// menuStrip1
			// 
			resources.ApplyResources(this.menuStrip1, "menuStrip1");
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.postavkeToolStripMenuItem});
			this.menuStrip1.Name = "menuStrip1";
			// 
			// postavkeToolStripMenuItem
			// 
			resources.ApplyResources(this.postavkeToolStripMenuItem, "postavkeToolStripMenuItem");
			this.postavkeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmbtnSettings});
			this.postavkeToolStripMenuItem.Name = "postavkeToolStripMenuItem";
			// 
			// tsmbtnSettings
			// 
			resources.ApplyResources(this.tsmbtnSettings, "tsmbtnSettings");
			this.tsmbtnSettings.Name = "tsmbtnSettings";
			this.tsmbtnSettings.Click += new System.EventHandler(this.tsmbtnSettings_Click);
			// 
			// btnRankings
			// 
			resources.ApplyResources(this.btnRankings, "btnRankings");
			this.btnRankings.Name = "btnRankings";
			this.btnRankings.UseVisualStyleBackColor = true;
			this.btnRankings.Click += new System.EventHandler(this.btnRankings_Click);
			// 
			// MainForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnRankings);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.flpFavoritePlayers);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.flpAllPlayers);
			this.Controls.Add(this.cbTeams);
			this.Controls.Add(this.label1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbTeams;
		private System.Windows.Forms.FlowLayoutPanel flpAllPlayers;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripProgressBar tsProgressBar;
		private System.Windows.Forms.ToolStripStatusLabel tslbProgressLabel;
		private System.ComponentModel.BackgroundWorker bgWorkerPlayerLoader;
		private System.Windows.Forms.FlowLayoutPanel flpFavoritePlayers;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem postavkeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tsmbtnSettings;
		private System.Windows.Forms.Button btnRankings;
	}
}

