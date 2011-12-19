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
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Facebook;
using Pichur;

namespace Pichur
{
	/// <summary>
	/// Interaction logic for FacebookWindow.xaml
	/// </summary>
	public partial class FacebookWindow : Window
	{
		private string appId = "204899734342";
		private string[] extendedPermissions = new[] { "publish_stream", "offline_access", "user_photos" };
		private FacebookOAuthClient client;
		private Dictionary<string, object> parameters;
		private Uri navigateUrl;

		public FacebookWindow()
		{

			client = new FacebookOAuthClient { AppId = appId };
			parameters = new Dictionary<string, object>
			{
				{ "response_type", "token" },
				{ "display", "popup" }
			};

			if (extendedPermissions != null && extendedPermissions.Length > 0)
			{
				var scope = new StringBuilder();
				scope.Append(string.Join(",", extendedPermissions));
				parameters["scope"] = scope.ToString();
			}
			var loginUrl = client.GetLoginUrl(parameters);
			this.navigateUrl = loginUrl;
			
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			formWebBrowser.Navigate(this.navigateUrl);
		}
		public FacebookOAuthResult FacebookOAuthResult { get; private set; }

		private void formWebBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
		{
			FacebookOAuthResult result;
			if (FacebookOAuthResult.TryParse(e.Url, out result))
			{
				this.FacebookOAuthResult = result;
				if (result.IsSuccess)
				{
					FacebookUpload fbDlg = new FacebookUpload(this.FacebookOAuthResult.AccessToken);
					fbDlg.Show();
					this.Close();
				}
				else
				{
					System.Windows.MessageBox.Show("Failed to login. Please try again. Error:\n" + result.ErrorDescription);
					this.Close();
				}
			}
			else
			{
				this.FacebookOAuthResult = null;
			}

		}
	}
}
