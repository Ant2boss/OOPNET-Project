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
using System.Windows.Shapes;

namespace OOPNET_WPFApp.Dialogs
{
	/// <summary>
	/// Interaction logic for Settings.xaml
	/// </summary>
	public partial class Settings : Window
	{
		public Settings()
		{
			InitializeComponent();
		}

		public bool IsMaleCup
		{
			get
			{
				if (this.rbMaleCup.IsChecked.HasValue)
				{
					return this.rbMaleCup.IsChecked.Value;
				}

				throw new NullReferenceException();
			}
		}
		public string Culture => (this.cbLanguage.SelectedValue as ComboBoxItem).Content.ToString();
		public string Resolution => (this.cbResolution.SelectedValue as ComboBoxItem).Content.ToString();

		private void OkButton_Click(object sender, RoutedEventArgs e)
		{
			this.DialogResult = true;
		}

	}
}
