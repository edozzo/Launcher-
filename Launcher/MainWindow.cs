	using System;
	using Gtk;
	using System.Net.Sockets;
	using System.IO;
	using System.Net.NetworkInformation;
	using System.Threading; 
	
	public partial class MainWindow : Gtk.Window
	{
	// definizioni variabili pubbliche
		public string MacA ="";
		public string pathWoW = "";
	
		public MainWindow () : base(Gtk.WindowType.Toplevel)
		{
			Build();

            //Close Splash
//            SpLoader.Hide();
//			SpLoader.Dispose();

		
			// Old loading form event
//			Control.CheckForIllegalCrossThreadCalls = false;
//            otp();
//            #region Version on Title
//            if (!this.Text.Contains(" Ver.:"))
//            {
//                Version v = Assembly.GetExecutingAssembly().GetName().Version;
//                string About = string.Format(CultureInfo.InvariantCulture, @" Ver.: {0}.{1}.{2}.{3})", v.Major, v.Minor, v.Build, v.Revision);
//                this.Text += About;
//            }
//            #endregion
//        
//
//            //removeFromTaskManager();
//            //this.ShowInTaskbar = true;
//
//            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
//
//            //try
//            //{
//            //    KillCtrlAltDelete();
//            //}
//            //catch (Exception) { } 
//
//            #region button disable
//
//            staff = false;
//            //checkBox1.Visible = false;
//            //label1.Visible = false;
//            //label3.Visible = false;
//            //textBox1.Visible = false;
//            //button2.Visible = false;
//            //textBox6.Visible = false;
//            //textBox4.Visible = false;
//            //textBox3.Visible = false;
//            button1.Enabled = false;
//            //accDest.Visible = false;
//            //charName.Visible = false;
//            //button5.Visible = false;
//            //panel1.Visible = false;
//            panel1.Visible = false;
//            #endregion
//          
//            #region crypt config
//            screenBox.Text += " First Load : Crypt Decrypt Config \r\n";
//            try
//            {
//                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
//                ConfigurationSection section = config.GetSection("appSettings");
//
//                textBoxUser.Text = ConfigurationManager.AppSettings.Get("UserWoW");
//                textBoxPass.Text = ConfigurationManager.AppSettings.Get("PassWoW");
//
//
//                if (section != null)
//                {
//                    string cryt = ConfigurationManager.AppSettings.Get("crypted");
//                    if (cryt == "no")
//                    {
//                        foreach (string key in ConfigurationManager.AppSettings.AllKeys)
//                        {
//                            if (key == "UserWoW" || key == "PassWoW" || key == "PathWoW" || key == "crypted")
//                                continue;
//
//                            string value = config.AppSettings.Settings[key].Value;
//                            config.AppSettings.Settings.Remove(key);
//                            config.AppSettings.Settings.Add(key, EncDec.Encrypt(value, "enturion"));
//                        }
//
//                        config.AppSettings.Settings.Remove("crypted");
//                        config.AppSettings.Settings.Add("crypted", "si");
////                        ConfigurationManager.AppSettings.Set("crypted", "si");
//
//                        //section.SectionInformation.ForceSave = true;
//                        config.Save(ConfigurationSaveMode.Full);
//                        
//                        ConfigurationManager.RefreshSection("appSettings");
//                    }
//                }
//                screenBox.Text += "End: Crypt Decrypt Config \r\n";
//            }
//            catch (Exception ex)
//            {
//                //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
//                //ConfigurationSection section = config.GetSection("appSettings");
//
//                textBoxUser.Text = GetKeyFromFile("UserWoW");
//                textBoxPass.Text = GetKeyFromFile("PassWoW");
//
//
//                   string cryt = GetKeyFromFile("crypted");
//                
//                screenBox.Text += "End: Crypt Decrypt Config \r\n";
//                //MessageBox.Show(ex.Message + "\r\n \r\n" + "Questo Errore potrebbe essere dovuto alla mancanza delle lib del .NET FRAMEWORK 3.5 di Windows ", "ERRORE !", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                
//            }
//
//            #endregion
//
//
//            #region read WoW position path from regedit
//            screenBox.Text += "Lettura Path WoW da Registro \r\n";
//            string WoWVer = "";
//            try
//            {
//                RegistryKey regKey1 = Registry.LocalMachine;
//
//                regKey1 = regKey1.CreateSubKey("Software\\Blizzard Entertainment\\World of Warcraft");
//                pathWoW = regKey1.GetValue("InstallPath").ToString();
//                if (string.IsNullOrEmpty(pathWoW))
//                    throw new ArgumentException("Path null");
//
//                WoWVer = FileVersionInfo.GetVersionInfo(@pathWoW + "WoW.exe").ToString();
//            }
//            catch (Exception)
//            {
//                pathWoW = GetKeyFromFile("PathWoW");
//                if (string.IsNullOrEmpty(pathWoW))
//                {
//                    while (!File.Exists(@pathWoW + @"\WoW.exe") || string.IsNullOrEmpty(pathWoW) || string.IsNullOrEmpty(WoWVer))
//                    {
//                        pathWoW = Microsoft.VisualBasic.Interaction.InputBox("Non Riesco a rilevare il Path WoW \r\n Inserire Path WoW (i.e.: C:\\WoW\\)", "Inserisci Path", "", 300, 300)+ @"\";
//                        try
//                        {
//                            WoWVer = FileVersionInfo.GetVersionInfo(@pathWoW + "WoW.exe").ToString();
//                        } catch (Exception){}
//                    }
//
//                    System.Configuration.Configuration configs = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
//                    configs.AppSettings.Settings.Remove("PathWoW");
//                    configs.AppSettings.Settings.Add("PathWoW", @pathWoW);
//
//                    configs.Save(ConfigurationSaveMode.Full);
//                    ConfigurationManager.RefreshSection("appSettings");
//                }
//            }
//            screenBox.Text += "Path Acquisito :" + pathWoW + "\r\n";
//            #endregion
//
//            Anticheat();
//
//            #region read WoW Version
//            
//
//            screenBox.Text += "Rilevato WoW! \r\nVersione " + WoWVer + ",\r\n Path :" + pathWoW + ",\r\n";
//            #endregion
//
//            #region Load Parser data
//            for (int i = 0; i < 283; i++)
//            {
//                PLAYER_SKILL_INFO_1_1[i] = "0";
//            }
//            FileStream fs = new FileStream(@".\factions.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
//            StreamReader r = new StreamReader(fs);
//            while (!r.EndOfStream)
//            {
//                string tmp = r.ReadLine();
//                string[] ss = tmp.Split(';');
//                if (m_reps.ContainsKey(ss[1]))
//                    continue;
//
//                Reputation re = new Reputation(int.Parse(ss[0]));
//                re.RepListId = Int32.Parse(ss[10]);
//                for (int i = 0; i < 4; i++)
//                {
//                    re.baseRepMask[i] = Int32.Parse(ss[i + 2]);
//                    re.baseRepValue[i] = Int32.Parse(ss[i + 6]);
//                }
//                re.name = ss[1];
//                re.parentFaction = Int32.Parse(ss[11]);
//                m_reps.Add(re.name, re);
//            }
//            r.Close();
//
//            fs = new FileStream(@".\skills.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
//            r = new StreamReader(fs);
//            while (!r.EndOfStream)
//            {
//                string tmp = r.ReadLine();
//                string[] ss = tmp.Split(';');
//                if (m_skills.ContainsKey(ss[1]))
//                    continue;
//
//                SkillLine se = new SkillLine();
//                se.ID = int.Parse(ss[0]);
//                se.name = ss[1];
//                se.type = uint.Parse(ss[2]);
//
//                m_skills.Add(se.name, se);
//            }
//            r.Close();
//            #endregion
//
//            doUpdate();
//
//            UpdateRealm();
//
//            timero1.Interval = 5000;
//            timero1.Elapsed += new System.Timers.ElapsedEventHandler(ticker);
//            timero1.Start();
//
//            System.Security.Principal.WindowsIdentity user = System.Security.Principal.WindowsIdentity.GetCurrent();
//            string User = user.Name;			
//			
		}
	
		protected void OnDeleteEvent (object sender, DeleteEventArgs a)
		{
			Application.Quit ();
			a.RetVal = true;
		}
		protected virtual void OnPlayBtnClicked (object sender, System.EventArgs e)
		{
			String Valore = UsernameTxt.Buffer.Text;
			MessageDialog msdSame = new MessageDialog(this,
	          DialogFlags.DestroyWithParent,
	          MessageType.Error,
	          ButtonsType.Close, GetMACAddress());
			msdSame.Run();
		}
		
//        public string SessionID = "";
//        public void otp()
//        {
//            SessionID = DateTime.Now + "Enturi0n";
//            SessionID = EncDec.Encrypt(SessionID,"sbr1cc0lo");
//        }
//	
		public string GetMACAddress()
	    {
	            if (!string.IsNullOrEmpty(MacA))
	                return MacA;
	
	            string address = String.Empty;
	            if (File.Exists(pathWoW + "Data\\Omac.nfo"))
	                File.Delete(pathWoW + "Data\\Omac.nfo");
	
	            string filePath = pathWoW + "Data\\mac.nfo";
	            if (System.IO.File.Exists(filePath))
	            {
	                StreamReader streamReader = new StreamReader(filePath);
	                address = streamReader.ReadToEnd();
	                streamReader.Close();
	                return address;
	            }
	
	            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
	            {
	                PhysicalAddress mac = nic.GetPhysicalAddress();
	                if (nic.NetworkInterfaceType.ToString().Contains("Wireless") ||
	                     nic.NetworkInterfaceType.ToString().Contains("Ethernet")  ) 
		                        address = mac.ToString().Replace(":", "");
	//                Console.WriteLine("{0} {1}", nic.Name, mac.ToString());
	            }
	            
	            FileInfo f = new FileInfo(filePath);
	            StreamWriter w = f.CreateText();
	            w.Write(address);
	            w.Close();
	
	            //return the mac address
	            return address;
	     }
	
		private void ThereadSplash() {

			
			
		}
		
	}

