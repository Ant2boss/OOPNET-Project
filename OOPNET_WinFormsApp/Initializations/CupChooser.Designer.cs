
namespace OOPNET_WinFormsApp.Initializations
{
	partial class CupChooser
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CupChooser));
			this.lsLanguages = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnContiniue = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cbMale = new System.Windows.Forms.RadioButton();
			this.cbFemale = new System.Windows.Forms.RadioButton();
			this.btnClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lsLanguages
			// 
			resources.ApplyResources(this.lsLanguages, "lsLanguages");
			this.lsLanguages.FormattingEnabled = true;
			this.lsLanguages.Items.AddRange(new object[] {
            resources.GetString("lsLanguages.Items")});
			this.lsLanguages.Name = "lsLanguages";
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// btnContiniue
			// 
			resources.ApplyResources(this.btnContiniue, "btnContiniue");
			this.btnContiniue.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnContiniue.Name = "btnContiniue";
			this.btnContiniue.UseVisualStyleBackColor = true;
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
			// cbMale
			// 
			resources.ApplyResources(this.cbMale, "cbMale");
			this.cbMale.Checked = true;
			this.cbMale.Name = "cbMale";
			this.cbMale.TabStop = true;
			this.cbMale.UseVisualStyleBackColor = true;
			// 
			// cbFemale
			// 
			resources.ApplyResources(this.cbFemale, "cbFemale");
			this.cbFemale.Name = "cbFemale";
			this.cbFemale.UseVisualStyleBackColor = true;
			// 
			// btnClose
			// 
			resources.ApplyResources(this.btnClose, "btnClose");
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Name = "btnClose";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// CupChooser
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.cbFemale);
			this.Controls.Add(this.cbMale);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnContiniue);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lsLanguages);
			this.Name = "CupChooser";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox lsLanguages;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnContiniue;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.RadioButton cbMale;
		private System.Windows.Forms.RadioButton cbFemale;
		private System.Windows.Forms.Button btnClose;
	}
}