	using System;
	using Gtk;
	using System.Net.Sockets;
	using System.IO;
	using System.Net;
	using System.Net.NetworkInformation;
	using System.Threading; 
	using System.Reflection;
	using System.Globalization;
	using ShareLib;
	using System.Diagnostics;
	using System.Collections;
	using System.Collections.Generic;
	using System.Configuration;
	
	using Microsoft.Win32;
	using Microsoft.VisualBasic;

	public partial class MainWindow : Gtk.Window
	{
	// definizioni variabili pubbliche
		public string MacA ="";
		public string pathWoW = "";
		public string SessionID = "";	
		public string OSType = "";
		//private Dictionary<string, int> processList = new Dictionary<string, int>();
		bool staff = false;
		private string ProductVersion = "";
		
		public MainWindow () : base(Gtk.WindowType.Toplevel)
		{
			Build();

		
			// Old loading form event

              otp();
            #region Version on Title
			ProductVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
		
            if (!this.Title.Contains(" Ver.:"))
            {
                Version v = Assembly.GetExecutingAssembly().GetName().Version;
                string About = string.Format(CultureInfo.InvariantCulture, @" Ver.: {0}.{1}.{2}.{3})", v.Major, v.Minor, v.Build, v.Revision);
                this.Title += About;
            }
            #endregion
			OSDetection OSDetection = new OSDetection();
			OSType = OSDetection.OsType();

              #region button disable

              staff = false;

//            button1.Enabled = false;

//            panel1.Visible = false;
              #endregion
//          
//            #region crypt config
              screenBox.Buffer.Text += " First Load : Crypt Decrypt Config \r\n";
            	try
            	{
                	Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                	ConfigurationSection section = config.GetSection("appSettings");

                	UsernameTxt.Buffer.Text = ConfigurationManager.AppSettings.Get("UserWoW");
                	PasswordTxt.Buffer.Text = ConfigurationManager.AppSettings.Get("PassWoW");


                	if (section != null)
                	{
                    	string cryt = ConfigurationManager.AppSettings.Get("crypted");
                    	if (cryt == "no")
                    	{
                        	foreach (string key in ConfigurationManager.AppSettings.AllKeys)
                        	{
                            	if (key == "UserWoW" || key == "PassWoW" || key == "PathWoW" || key == "crypted")
                                	continue;

                            	string value = config.AppSettings.Settings[key].Value;
                            	config.AppSettings.Settings.Remove(key);
                            	config.AppSettings.Settings.Add(key, EncDec.Encrypt(value, "enturion"));
                        	}

                        	config.AppSettings.Settings.Remove("crypted");
                        	config.AppSettings.Settings.Add("crypted", "si");
                        	ConfigurationManager.AppSettings.Set("crypted", "si");

                        	config.Save(ConfigurationSaveMode.Full);
                        
                        	ConfigurationManager.RefreshSection("appSettings");
                    	}
                	}
                	screenBox.Buffer.Text += "End: Crypt Decrypt Config \r\n";
            	}
            	catch (Exception ex)
            	{
                	//Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                	//ConfigurationSection section = config.GetSection("appSettings");

                	UsernameTxt.Buffer.Text = GetKeyFromFile("UserWoW");
                	PasswordTxt.Buffer.Text = GetKeyFromFile("PassWoW");


                   string cryt = GetKeyFromFile("crypted");
                
                	screenBox.Buffer.Text += "End: Crypt Decrypt Config \r\n";
                	//MessageBox.Show(ex.Message + "\r\n \r\n" + "Questo Errore potrebbe essere dovuto alla mancanza delle lib del .NET FRAMEWORK 3.5 di Windows ", "ERRORE !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            	}


              	#region read WoW position path from regedit
              	screenBox.Buffer.Text += "Lettura Path WoW da Registro \r\n";
              	string WoWVer = "";
				switch(OSType) {
					case "WINDOWS":
		              	try
		              	{
		                	RegistryKey regKey1 = Registry.LocalMachine;
		
		                	regKey1 = regKey1.CreateSubKey("Software\\Blizzard Entertainment\\World of Warcraft");
		                	pathWoW = regKey1.GetValue("InstallPath").ToString();
		                	if (string.IsNullOrEmpty(pathWoW))
		                    	throw new ArgumentException("Path null");
		
		                	WoWVer = FileVersionInfo.GetVersionInfo(@pathWoW + "WoW.exe").ToString();
		            	}
		            	catch (Exception)
		            	{
		                	pathWoW = GetKeyFromFile("PathWoW");
		                	if (string.IsNullOrEmpty(pathWoW))
		                	{
		                    	while (!File.Exists(@pathWoW + @"\WoW.exe") || string.IsNullOrEmpty(pathWoW) || string.IsNullOrEmpty(WoWVer))
		                    	{
		                        	pathWoW = Microsoft.VisualBasic.Interaction.InputBox("Non Riesco a rilevare il Path WoW \r\n Inserire Path WoW (i.e.: C:\\WoW\\)", "Inserisci Path", "", 300, 300)+ @"\";
		                       	 	try
		                        		{
		                            		WoWVer = FileVersionInfo.GetVersionInfo(@pathWoW + "WoW.exe").ToString();
		                        		} catch (Exception){}
		                    	}
							}
						}
					break;
					case "OSX":
						
					break; 
				}
                 System.Configuration.Configuration configs = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    configs.AppSettings.Settings.Remove("PathWoW");
                    configs.AppSettings.Settings.Add("PathWoW", @pathWoW);

                    configs.Save(ConfigurationSaveMode.Full);
                    ConfigurationManager.RefreshSection("appSettings");
                	
				

            screenBox.Buffer.Text += "Path Acquisito :" + pathWoW + "\r\n";

              #endregion
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
              doUpdate();
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
	
		private string GetKeyFromFile(string p)
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader("Launcher.exe.Config");
            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
                if (line.Contains(p))
                {
                    string[] words = line.Replace("\" ","\"^").Split('^');
                    string value= "";
                    foreach (string word in words)
                    {
                        if (word.ToUpper().Contains("VALUE"))
                        { 
                            value = word.Replace("value=","");
                            value = value.Replace("\"","");
                            value = value.Replace("\\>", "");
                            file.Close();

//                            Console.ReadLine();

                            return value;
                        }
                    }

                }
                counter++;
            }

            file.Close();

            // Suspend the screen.
            Console.ReadLine();
            return null;
        }
		
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
	
        public void otp()
        {
            SessionID = DateTime.Now + "Enturi0n";
            SessionID = EncDec.Encrypt(SessionID,"sbr1cc0lo");
        }
	
        private void CloseWows()
        {
			string[] splittedCmd = new string[100];;
			string Cmd = null; 
			switch(OSType) {
			case "WINDOWS":
            	Process[] processlist = Process.GetProcesses(".");
            	//Process WoWProcess = null;
            	foreach (Process theprocess in processlist)
            	{
                	//if (theprocess.ProcessName.ToUpper().Contains("WORLD OF WARCRAFT"))
					if (theprocess.ProcessName == "WOW")
                	{
                  	while(!theprocess.HasExited)
                    	try
                    	{
                      	theprocess.Kill();
                        	screenBox.Buffer.Text += "WOW Close!" + theprocess.StartTime + "\r\n";
                    	}
                    	catch (Exception)
                    	{
                    	}
                    
                	}
            	}
				break;
			case "OSX":
				    ProcessStartInfo si = new ProcessStartInfo("ps", "x");
                    si.RedirectStandardOutput = true;
                    si.UseShellExecute = false;

                    string outputString = string.Empty;
                    using (Process p = Process.Start(si))
                    {
                        p.Start();
                        while ((outputString = p.StandardOutput.ReadLine()) != null) {
							splittedCmd = null;
							splittedCmd = outputString.Split(' ');
//							if (splittedCmd.Length >= 14 ) 
//							Cmd = splittedCmd[14];
							if (outputString.Contains("Warcraft")) {
								killProcess(int.Parse(splittedCmd[2]));
							}
						}
                        p.WaitForExit();
                    }

				break;	
		}

        }
		
		private bool killProcess(int PID) {
			if (PID != 0) {
					ProcessStartInfo si = new ProcessStartInfo("kill", "-9 " + PID.ToString());
                    si.RedirectStandardOutput = true;
                    si.UseShellExecute = false;

                    string outputString = string.Empty;
                    using (Process p = Process.Start(si))
                    {
                        p.Start();
                        outputString = p.StandardOutput.ReadLine();
                        p.WaitForExit();
					if (outputString != null) {
							return true;
						} else {
							return false;
							// add error output to logger
						}	
                    }
			}	else {
				return false;
			}
		}
	
        private void CloseControllers()
        {
            Process[] processlist = Process.GetProcesses(".");
            foreach (Process theprocess in processlist)
            {
                if (theprocess.ProcessName.ToUpper().Contains("CONTROLLER"))
                {
                    theprocess.Kill();
                    screenBox.Buffer.Text += "Controller Close!" + theprocess.StartTime + "\r\n";
                }
            }
        }
		
        private void doUpdate()
        {
            string currentVer = ProductVersion;
            string onLineVer = "";
            try
            {
                onLineVer = GetOnlinever();
            }
            catch (Exception ex)
            {
                screenBox.Buffer.Text += "\r\n Non è possibile reperire la versione online";
                return;
            }
            
            if (currentVer != onLineVer)
                {
                    DialogResult DigR = MessageBox.Show("Rilevata Nuova Versione !!\r\n Update ?","WARN !!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                    if (DigR.ToString() == "Yes")
                    {
                    Directory.CreateDirectory(@".\updates\");
                    download("http://www.enturion.com/Launcher_Installer/Launcher" + onLineVer + ".zip", @".\updates\Launcher" + onLineVer + ".zip");
                    ZipTool zip = new ZipTool();
                    bool result = zip.UnZipFile(@".\updates\Launcher" + onLineVer + ".zip");
                    if (result)
                    {
                        MessageBox.Show("File Estratti !");
                        ProcessStartInfo PI = new ProcessStartInfo();
                        
                        string CopyArgs = @".\updates\update.bat";
                        PI.FileName = "cmd.exe";
                        PI.Arguments = " /c " + CopyArgs;
                        //PI.CreateNoWindow = true;
                        //PI.RedirectStandardOutput = true;
                        //PI.UseShellExecute = false;
                        MessageBox.Show("Processo di Update in avvvio !");
                        Process newProc = Process.Start(PI);
                        
                        Application.Exit();
                    }
                    } 
                }

        }
	
        private string GetOnlinever()
        {
            string URL = "http://www.enturion.com/Launcher_Installer/index.htm";
            WebClient client = new WebClient();
            Stream data = null;
            try
            {
                  data = client.OpenRead(URL);
            }
            catch (Exception ex)
            {
//                  WebProxy webproxy = new WebProxy("host proxy", porta);
//                  client.Proxy = webproxy;
//                  client.Proxy.Credentials = new NetworkCredential("user", "pass");
//                  data = client.OpenRead(URL);
            }
            
            StreamReader reader = new StreamReader(data);
            string html = reader.ReadToEnd();
            string onLineRev = html.Split('§')[1];
            onLineRev = onLineRev.Replace("Launcher","");
            onLineRev = onLineRev.Replace(".zip","");

            return onLineRev;
        }
		
        protected virtual void OnUnrealized (object sender, System.EventArgs e)
		{
            CloseWows();
            CloseControllers();
            //throw new NotImplementedException();
		}
		
        protected virtual void OnButton2Clicked (object sender, System.EventArgs e)
		{
			CloseWows();			
		}
		
		
		
	}

