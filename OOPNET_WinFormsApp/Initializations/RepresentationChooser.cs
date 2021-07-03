using OOPNET_DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPNET_WinFormsApp.Initializations
{
	public partial class RepresentationChooser : Form
	{
		public RepresentationChooser()
		{
			InitializeComponent();

			this._InitForm();
		}

		private void _InitForm()
		{
			this.lsLanguages.Items.Clear();

			this.lsLanguages.Items.Add("HR");
			this.lsLanguages.Items.Add("EN");

			this.lsLanguages.SelectedIndex = 0;

			this.lsLanguages.DropDownStyle = ComboBoxStyle.DropDownList;

			this.CenterToScreen();
		}

		public string GetCulture()
		{
			return this.lsLanguages.SelectedItem.ToString();
		}

		public string GetCupType()
		{
			if (this.cbMale.Checked)
			{
				return CupType.MaleCup.ToString();
			}
			else
			{
				return CupType.FemaleCup.ToString();
			}
		}

	}
}
