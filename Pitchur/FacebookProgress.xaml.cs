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
using Pichur;
using Facebook;

namespace Pichur
{
	public partial class FacebookProgress : Window
	{
		private String imgPath;
		private String imgName;
		private FlowDocument imgMsg;
		private FacebookClient fb;
		public FacebookProgress(String p, String at, String iname, FlowDocument msg)
		{
			imgPath = p;
			imgName = iname;
			imgMsg = msg;
			fb = new FacebookClient(at);
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			// upload to facebook
			FacebookMediaObject image = new FacebookMediaObject
			{
				FileName = imgPath,
				ContentType = "image/jpeg"
			};
			byte[] fileBytes = File.ReadAllBytes(imgPath);
			image.SetValue(fileBytes);
			IDictionary<string, object> upload = new Dictionary<string, object>();
			upload.Add("name", imgName);
			upload.Add("message", imgMsg);
			upload.Add("@file.jpg", image);
			fb.UploadProgressChanged += uploadProgressChanged;
			fb.PostAsync("/me/photos", new Dictionary<string, object> {{"source", image}});
		}

		public void uploadProgressChanged(object sender, FacebookUploadProgressChangedEventArgs args)
		{
			uploadPBr.Dispatcher.BeginInvoke(
				System.Windows.Threading.DispatcherPriority.Normal,
				new System.Windows.Threading.DispatcherOperationCallback(delegate {
					if (args.ProgressPercentage == 100)
					{
						cancelBtn.Content = "Close";
					}
					uploadPBr.Value = args.ProgressPercentage;
					return null;
				}), null
			);
		}

		private void cancelBtn_Click(object sender, RoutedEventArgs e)
		{
			fb.CancelAsync();
			this.Close();
		}
	}
}
