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
			//Thread.Sleep(2000);
			win.Show ();

			
			Application.Run ();
//			Thread T0 = new Thread(new ThreadStart(popup));
//			T0.Start();
//			Thread T = new Thread(new ThreadStart(SpLoader));
//			T.Start();


		}
		
		public static void popup () {

			Application.Run();
//			Thread.Sleep(2000);
//			SpLoader.Hide();
		}
		
//		public static void SpLoader() {
//			SplashScreen SpLoader = new SplashScreen();			
//			SpLoader.Show();		
//			Application.Run();
//		}
	}
}
