using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using Facebook;

namespace Pichur
{
	/// <summary>
	/// Interaction logic for FacebookUpload.xaml
	/// </summary>
	public partial class FacebookUpload : Window
	{
		private String token;
		public FacebookUpload(String accessToken)
		{
			token = accessToken;
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
		}

		private void browseBtn_Click(object sender, RoutedEventArgs e)
		{
			Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
			dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
			dlg.Filter = "Jpg|*.jpg";
			if (dlg.ShowDialog() == true)
			{
				pathTxt.Text = dlg.FileName;
				BitmapImage b = new BitmapImage(new Uri(dlg.FileName));
				previewImg.Source = b; 
			}
		}

		private void uploadBtn_Click(object sender, RoutedEventArgs e)
		{
			if (pathTxt.Text == "" && imgNameTxt.Text == "")
			{
				imgNameTxt.BorderBrush = Brushes.Red;
				pathTxt.BorderBrush = Brushes.Red;
				MessageBox.Show("Please choose a file to upload and choose a name for the photo.");

			}
			else if (pathTxt.Text == "")
			{
				pathTxt.BorderBrush = Brushes.Red;
				MessageBox.Show("Please choose a file to upload");
			}
			else if (imgNameTxt.Text == "")
			{
				imgNameTxt.BorderBrush = Brushes.Red;
				MessageBox.Show("Please enter a name for this photo.");
			}
			else
			{
				FacebookProgress progDlg = new FacebookProgress(pathTxt.Text, token, imgNameTxt.Text, messageRTxt.Document);
				progDlg.Show();
			}
		}

		private void logoutBtn_Click(object sender, RoutedEventArgs e)
		{
			FacebookWindow logoutWindow = new FacebookWindow();
			logoutWindow.Show();
			this.Close();
		}
	}
}
