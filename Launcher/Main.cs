using System;
using Gtk;
using System.Threading; 

namespace Launcher
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			SplashScreen SpLoader = new SplashScreen();
			SpLoader.Show();
			Thread.Sleep(2000);
			SpLoader.Hide();
			win.Show ();
			Application.Run ();
		}
	}
}

