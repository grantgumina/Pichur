using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Threading;

namespace Pichur
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private Mutex mutex;
		private void Application_Startup(object sender, StartupEventArgs e)
		{
			bool newInstance = false;
			mutex = new Mutex(true, "Pichur.App", out newInstance);
			if (!newInstance)
			{
				MessageBox.Show("Pichur is alreay running.");
				App.Current.Shutdown();
			}
		}
	}
}
