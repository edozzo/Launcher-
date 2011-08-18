using System;
namespace Launcher
{
	public partial class SplashScreen : Gtk.Window
	{
		public SplashScreen () : base(Gtk.WindowType.Popup)
		{
			this.Build ();
		}
	}
}

