
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.Notebook notebook1;
	private global::Gtk.Fixed fixed1;
	private global::Gtk.ScrolledWindow GtkScrolledWindow;
	private global::Gtk.TextView UsernameTxt;
	private global::Gtk.Label UserLbl;
	private global::Gtk.Frame LoginFrame;
	private global::Gtk.Alignment GtkAlignment;
	private global::Gtk.Fixed fixed5;
	private global::Gtk.ScrolledWindow GtkScrolledWindow1;
	private global::Gtk.TextView PasswordTxt;
	private global::Gtk.Label Login;
	private global::Gtk.Label label3;
	private global::Gtk.Button PlayBtn;
	private global::Gtk.Label MainLbl;
	private global::Gtk.Fixed fixed4;
	private global::Gtk.ScrolledWindow GtkScrolledWindow2;
	private global::Gtk.TextView screenBox;
	private global::Gtk.Button button2;
	private global::Gtk.Label CharCopyLbl;
	private global::Gtk.Fixed fixed3;
	private global::Gtk.Label label1;
	private global::Gtk.Fixed fixed2;
	private global::Gtk.Label label2;
    
	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
		this.Icon = new global::Gdk.Pixbuf (global::System.IO.Path.Combine (global::System.AppDomain.CurrentDomain.BaseDirectory, "./image/12.ico"));
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.notebook1 = new global::Gtk.Notebook ();
		this.notebook1.CanFocus = true;
		this.notebook1.Name = "notebook1";
		this.notebook1.CurrentPage = 0;
		// Container child notebook1.Gtk.Notebook+NotebookChild
		this.fixed1 = new global::Gtk.Fixed ();
		this.fixed1.Name = "fixed1";
		this.fixed1.HasWindow = false;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow.WidthRequest = 200;
		this.GtkScrolledWindow.HeightRequest = 20;
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.VscrollbarPolicy = ((global::Gtk.PolicyType)(2));
		this.GtkScrolledWindow.HscrollbarPolicy = ((global::Gtk.PolicyType)(2));
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.UsernameTxt = new global::Gtk.TextView ();
		this.UsernameTxt.WidthRequest = 200;
		this.UsernameTxt.HeightRequest = 50;
		this.UsernameTxt.CanFocus = true;
		this.UsernameTxt.Name = "UsernameTxt";
		this.UsernameTxt.WrapMode = ((global::Gtk.WrapMode)(3));
		this.GtkScrolledWindow.Add (this.UsernameTxt);
		this.fixed1.Add (this.GtkScrolledWindow);
		global::Gtk.Fixed.FixedChild w2 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.GtkScrolledWindow]));
		w2.X = 117;
		w2.Y = 349;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.UserLbl = new global::Gtk.Label ();
		this.UserLbl.WidthRequest = 100;
		this.UserLbl.Name = "UserLbl";
		this.UserLbl.LabelProp = global::Mono.Unix.Catalog.GetString ("Username");
		this.fixed1.Add (this.UserLbl);
		global::Gtk.Fixed.FixedChild w3 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.UserLbl]));
		w3.X = 3;
		w3.Y = 354;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.LoginFrame = new global::Gtk.Frame ();
		this.LoginFrame.WidthRequest = 400;
		this.LoginFrame.HeightRequest = 150;
		this.LoginFrame.Name = "LoginFrame";
		this.LoginFrame.ShadowType = ((global::Gtk.ShadowType)(1));
		this.LoginFrame.BorderWidth = ((uint)(1));
		// Container child LoginFrame.Gtk.Container+ContainerChild
		this.GtkAlignment = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
		this.GtkAlignment.Name = "GtkAlignment";
		this.GtkAlignment.LeftPadding = ((uint)(12));
		// Container child GtkAlignment.Gtk.Container+ContainerChild
		this.fixed5 = new global::Gtk.Fixed ();
		this.fixed5.Name = "fixed5";
		this.fixed5.HasWindow = false;
		// Container child fixed5.Gtk.Fixed+FixedChild
		this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow1.WidthRequest = 200;
		this.GtkScrolledWindow1.HeightRequest = 20;
		this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
		this.GtkScrolledWindow1.VscrollbarPolicy = ((global::Gtk.PolicyType)(2));
		this.GtkScrolledWindow1.HscrollbarPolicy = ((global::Gtk.PolicyType)(2));
		this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
		this.PasswordTxt = new global::Gtk.TextView ();
		this.PasswordTxt.CanFocus = true;
		this.PasswordTxt.Name = "PasswordTxt";
		this.GtkScrolledWindow1.Add (this.PasswordTxt);
		this.fixed5.Add (this.GtkScrolledWindow1);
		global::Gtk.Fixed.FixedChild w5 = ((global::Gtk.Fixed.FixedChild)(this.fixed5 [this.GtkScrolledWindow1]));
		w5.X = 101;
		w5.Y = 33;
		this.GtkAlignment.Add (this.fixed5);
		this.LoginFrame.Add (this.GtkAlignment);
		this.Login = new global::Gtk.Label ();
		this.Login.Name = "Login";
		this.Login.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Login</b>");
		this.Login.UseMarkup = true;
		this.LoginFrame.LabelWidget = this.Login;
		this.fixed1.Add (this.LoginFrame);
		global::Gtk.Fixed.FixedChild w8 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.LoginFrame]));
		w8.Y = 330;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.label3 = new global::Gtk.Label ();
		this.label3.WidthRequest = 100;
		this.label3.HeightRequest = 20;
		this.label3.Name = "label3";
		this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Password");
		this.fixed1.Add (this.label3);
		global::Gtk.Fixed.FixedChild w9 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.label3]));
		w9.X = 4;
		w9.Y = 378;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.PlayBtn = new global::Gtk.Button ();
		this.PlayBtn.CanFocus = true;
		this.PlayBtn.Name = "PlayBtn";
		this.PlayBtn.UseUnderline = true;
		this.PlayBtn.Label = global::Mono.Unix.Catalog.GetString ("Play");
		this.fixed1.Add (this.PlayBtn);
		global::Gtk.Fixed.FixedChild w10 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.PlayBtn]));
		w10.X = 517;
		w10.Y = 378;
		this.notebook1.Add (this.fixed1);
		// Notebook tab
		this.MainLbl = new global::Gtk.Label ();
		this.MainLbl.Name = "MainLbl";
		this.MainLbl.LabelProp = global::Mono.Unix.Catalog.GetString ("Main");
		this.notebook1.SetTabLabel (this.fixed1, this.MainLbl);
		this.MainLbl.ShowAll ();
		// Container child notebook1.Gtk.Notebook+NotebookChild
		this.fixed4 = new global::Gtk.Fixed ();
		this.fixed4.Name = "fixed4";
		this.fixed4.HasWindow = false;
		// Container child fixed4.Gtk.Fixed+FixedChild
		this.GtkScrolledWindow2 = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow2.WidthRequest = 700;
		this.GtkScrolledWindow2.HeightRequest = 400;
		this.GtkScrolledWindow2.Name = "GtkScrolledWindow2";
		this.GtkScrolledWindow2.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow2.Gtk.Container+ContainerChild
		this.screenBox = new global::Gtk.TextView ();
		this.screenBox.CanFocus = true;
		this.screenBox.Name = "screenBox";
		this.GtkScrolledWindow2.Add (this.screenBox);
		this.fixed4.Add (this.GtkScrolledWindow2);
		global::Gtk.Fixed.FixedChild w13 = ((global::Gtk.Fixed.FixedChild)(this.fixed4 [this.GtkScrolledWindow2]));
		w13.Y = 100;
		// Container child fixed4.Gtk.Fixed+FixedChild
		this.button2 = new global::Gtk.Button ();
		this.button2.CanFocus = true;
		this.button2.Name = "button2";
		this.button2.UseUnderline = true;
		this.button2.Label = global::Mono.Unix.Catalog.GetString ("GtkButton");
		this.fixed4.Add (this.button2);
		global::Gtk.Fixed.FixedChild w14 = ((global::Gtk.Fixed.FixedChild)(this.fixed4 [this.button2]));
		w14.X = 433;
		w14.Y = 49;
		this.notebook1.Add (this.fixed4);
		global::Gtk.Notebook.NotebookChild w15 = ((global::Gtk.Notebook.NotebookChild)(this.notebook1 [this.fixed4]));
		w15.Position = 1;
		// Notebook tab
		this.CharCopyLbl = new global::Gtk.Label ();
		this.CharCopyLbl.Name = "CharCopyLbl";
		this.CharCopyLbl.LabelProp = global::Mono.Unix.Catalog.GetString ("Character Copy");
		this.notebook1.SetTabLabel (this.fixed4, this.CharCopyLbl);
		this.CharCopyLbl.ShowAll ();
		// Container child notebook1.Gtk.Notebook+NotebookChild
		this.fixed3 = new global::Gtk.Fixed ();
		this.fixed3.Name = "fixed3";
		this.fixed3.HasWindow = false;
		this.notebook1.Add (this.fixed3);
		global::Gtk.Notebook.NotebookChild w16 = ((global::Gtk.Notebook.NotebookChild)(this.notebook1 [this.fixed3]));
		w16.Position = 2;
		// Notebook tab
		this.label1 = new global::Gtk.Label ();
		this.label1.Name = "label1";
		this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Shoutbox");
		this.notebook1.SetTabLabel (this.fixed3, this.label1);
		this.label1.ShowAll ();
		// Container child notebook1.Gtk.Notebook+NotebookChild
		this.fixed2 = new global::Gtk.Fixed ();
		this.fixed2.Name = "fixed2";
		this.fixed2.HasWindow = false;
		this.notebook1.Add (this.fixed2);
		global::Gtk.Notebook.NotebookChild w17 = ((global::Gtk.Notebook.NotebookChild)(this.notebook1 [this.fixed2]));
		w17.Position = 3;
		// Notebook tab
		this.label2 = new global::Gtk.Label ();
		this.label2.Name = "label2";
		this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Gm Panel");
		this.notebook1.SetTabLabel (this.fixed2, this.label2);
		this.label2.ShowAll ();
		this.Add (this.notebook1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 706;
		this.DefaultHeight = 532;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.Unrealized += new global::System.EventHandler (this.OnUnrealized);
		this.PlayBtn.Clicked += new global::System.EventHandler (this.OnPlayBtnClicked);
		this.button2.Clicked += new global::System.EventHandler (this.OnButton2Clicked);
	}
}
