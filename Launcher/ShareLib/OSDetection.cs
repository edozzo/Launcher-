using System;
using System.Diagnostics;

namespace ShareLib
{
	public class OSDetection
	{
		public OSDetection ()
		{
			
		}
		
		public static string OsType() {
			if (!IsWindows) {
				if(IsOSX) return "OSX";
				else return "linux";

			} else {
				return "Windows";	
			}
		}

        static public bool IsWindows
        {
            get
            {
                return Environment.OSVersion.Platform != PlatformID.Unix;
            }
        }

        static public bool IsOSX
        {
            get
            {
                bool retVal = false;
                if (!IsWindows)
                {
                    ProcessStartInfo si = new ProcessStartInfo("uname", "-s");
                    si.RedirectStandardOutput = true;
                    si.UseShellExecute = false;

                    string outputString = string.Empty;
                    using (Process p = Process.Start(si))
                    {
                        p.Start();
                        outputString = p.StandardOutput.ReadLine();
                        p.WaitForExit();
                    }

                    retVal = string.Compare(outputString, "darwin", true) == 0;
                }

                return retVal;
            }
        }

        static public bool IsLinux
        {
            get
            {
                bool retVal = false;
                if (!IsWindows)
                {
                    ProcessStartInfo si = new ProcessStartInfo("uname", "-s");
                    si.RedirectStandardOutput = true;
                    si.UseShellExecute = false;

                    string outputString = string.Empty;
                    using (Process p = Process.Start(si))
                    {
                        p.Start();
                        outputString = p.StandardOutput.ReadLine();
                        p.WaitForExit();
                    }

                    retVal = string.Compare(outputString, "linux", true) == 0;
                }

                return retVal;
            }
        }		
		
	}
}

