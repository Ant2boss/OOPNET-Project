
namespace OOPNET_WinFormsApp
{
	partial class PlayerRankings
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerRankings));
			this.label1 = new System.Windows.Forms.Label();
			this.bgLoader = new System.ComponentModel.BackgroundWorker();
			this.label2 = new System.Windows.Forms.Label();
			this.dgvGoalTable = new System.Windows.Forms.DataGridView();
			this.dgvYellowCardTable = new System.Windows.Forms.DataGridView();
			this.dgvViewerTable = new System.Windows.Forms.DataGridView();
			this.label3 = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.printDialog = new System.Windows.Forms.PrintDialog();
			this.printDocument = new System.Drawing.Printing.PrintDocument();
			((System.ComponentModel.ISupportInitialize)(this.dgvGoalTable)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvYellowCardTable)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvViewerTable)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// bgLoader
			// 
			this.bgLoader.WorkerReportsProgress = true;
			this.bgLoader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgLoader_DoWork);
			this.bgLoader.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgLoader_ProgressChanged);
			this.bgLoader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgLoader_RunWorkerCompleted);
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// dgvGoalTable
			// 
			this.dgvGoalTable.AllowUserToAddRows = false;
			this.dgvGoalTable.AllowUserToDeleteRows = false;
			resources.ApplyResources(this.dgvGoalTable, "dgvGoalTable");
			this.dgvGoalTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvGoalTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvGoalTable.Name = "dgvGoalTable";
			this.dgvGoalTable.ReadOnly = true;
			// 
			// dgvYellowCardTable
			// 
			this.dgvYellowCardTable.AllowUserToAddRows = false;
			this.dgvYellowCardTable.AllowUserToDeleteRows = false;
			resources.ApplyResources(this.dgvYellowCardTable, "dgvYellowCardTable");
			this.dgvYellowCardTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvYellowCardTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvYellowCardTable.Name = "dgvYellowCardTable";
			this.dgvYellowCardTable.ReadOnly = true;
			// 
			// dgvViewerTable
			// 
			this.dgvViewerTable.AllowUserToAddRows = false;
			this.dgvViewerTable.AllowUserToDeleteRows = false;
			resources.ApplyResources(this.dgvViewerTable, "dgvViewerTable");
			this.dgvViewerTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvViewerTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvViewerTable.Name = "dgvViewerTable";
			this.dgvViewerTable.ReadOnly = true;
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			resources.ApplyResources(this.menuStrip1, "menuStrip1");
			this.menuStrip1.Name = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
			// 
			// printToolStripMenuItem
			// 
			this.printToolStripMenuItem.Name = "printToolStripMenuItem";
			resources.ApplyResources(this.printToolStripMenuItem, "printToolStripMenuItem");
			this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			resources.ApplyResources(this.closeToolStripMenuItem, "closeToolStripMenuItem");
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
			// 
			// printDialog
			// 
			this.printDialog.UseEXDialog = true;
			// 
			// printDocument
			// 
			this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
			// 
			// PlayerRankings
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label3);
			this.Controls.Add(this.dgvViewerTable);
			this.Controls.Add(this.dgvYellowCardTable);
			this.Controls.Add(this.dgvGoalTable);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "PlayerRankings";
			((System.ComponentModel.ISupportInitialize)(this.dgvGoalTable)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvYellowCardTable)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvViewerTable)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label1;
		private System.ComponentModel.BackgroundWorker bgLoader;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridView dgvGoalTable;
		private System.Windows.Forms.DataGridView dgvYellowCardTable;
		private System.Windows.Forms.DataGridView dgvViewerTable;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.PrintDialog printDialog;
		private System.Drawing.Printing.PrintDocument printDocument;
	}
}