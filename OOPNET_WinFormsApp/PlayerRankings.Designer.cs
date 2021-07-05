
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
			this.flpGoalCount = new System.Windows.Forms.FlowLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.bgLoader = new System.ComponentModel.BackgroundWorker();
			this.label2 = new System.Windows.Forms.Label();
			this.flpYellowCards = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// flpGoalCount
			// 
			this.flpGoalCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.flpGoalCount.AutoScroll = true;
			this.flpGoalCount.BackColor = System.Drawing.Color.White;
			this.flpGoalCount.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flpGoalCount.Location = new System.Drawing.Point(12, 29);
			this.flpGoalCount.Name = "flpGoalCount";
			this.flpGoalCount.Size = new System.Drawing.Size(227, 409);
			this.flpGoalCount.TabIndex = 0;
			this.flpGoalCount.WrapContents = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Broj golova";
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
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(288, 13);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(83, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Broj žutih karata";
			// 
			// flpYellowCards
			// 
			this.flpYellowCards.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.flpYellowCards.AutoScroll = true;
			this.flpYellowCards.BackColor = System.Drawing.Color.White;
			this.flpYellowCards.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flpYellowCards.Location = new System.Drawing.Point(287, 29);
			this.flpYellowCards.Name = "flpYellowCards";
			this.flpYellowCards.Size = new System.Drawing.Size(227, 409);
			this.flpYellowCards.TabIndex = 2;
			this.flpYellowCards.WrapContents = false;
			// 
			// PlayerRankings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.flpYellowCards);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.flpGoalCount);
			this.Name = "PlayerRankings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "PlayerRankings";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flpGoalCount;
		private System.Windows.Forms.Label label1;
		private System.ComponentModel.BackgroundWorker bgLoader;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.FlowLayoutPanel flpYellowCards;
	}
}