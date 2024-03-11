using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

namespace RiotLauncher
{
    internal class Fortnite
    {
        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(nint h, string m, string c, int type);

        public static void SafeKillProcess(string processName)
        {
            try
            {
                Process[] processesByName = Process.GetProcessesByName(processName);
                for (int i = 0; i < processesByName.Length; i++)
                {
                    processesByName[i].Kill();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);

            }
        }

        internal static void DownloadFile(string URL, string path)
        {
            try
            {
                new WebClient().DownloadFile(URL, path);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        public static void Inject(int pid, string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    Thread.Sleep(3000);
                    Environment.Exit(0);
                    return;
                }

                nint hProcess = Win32.OpenProcess(1082, false, pid);
                nint procAddress = Win32.GetProcAddress(Win32.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
                uint num = checked((uint)((path.Length + 1) * Marshal.SizeOf(typeof(char))));
                nint intPtr = Win32.VirtualAllocEx(hProcess, 0, num, 12288U, 4U);
                nuint uintPtr;
                Win32.WriteProcessMemory(hProcess, intPtr, Encoding.Default.GetBytes(path), num, out uintPtr);
                Win32.CreateRemoteThread(hProcess, 0, 0U, procAddress, intPtr, 0U, 0);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);

            }
        }
        //Twin1Dev
        public static void Launch(string path, string email, string password)
        {
            try
            {
                string Appdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\RiotLauncher";



                if (!File.Exists(Appdata + "\\FortniteClient-Win64-Shipping_BE.exe"))
                {
                    DownloadFile("http://104.194.10.244:6969/download/FortniteClient-Win64-Shipping_BE.exe", Appdata + "\\FortniteClient-Win64-Shipping_BE.exe");
                }
                if (!File.Exists(Appdata + "\\FortniteLauncher.exe"))
                {
                    DownloadFile("http://104.194.10.244:6969/download/FortniteLauncher.exe", Appdata + "\\FortniteLauncher.exe");
                }
                if (!File.Exists(Appdata + "\\Redirect.dll"))
                {
                    DownloadFile("http://104.194.10.244:6969/download/Redirect.dll", Appdata + "\\Redirect.dll");
                }

                string fortniteLauncherFileName = "FortniteLauncher.exe";
                string fortniteClientFileName = "FortniteClient-Win64-Shipping_BE.exe";

                Process[] runningProcesses = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(fortniteLauncherFileName));
                if (runningProcesses.Length == 0)
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = Path.Combine(Appdata, fortniteLauncherFileName),
                        CreateNoWindow = true,
                        UseShellExecute = false
                    });
                }

                runningProcesses = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(fortniteClientFileName));
                if (runningProcesses.Length == 0)
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = Path.Combine(Appdata, fortniteClientFileName),
                        CreateNoWindow = true,
                        UseShellExecute = false
                    });
                }

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = Properties.Settings.Default.Path + "\\FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping.exe",
                    Arguments = $"-epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -noeac -fromfl=be -fltoken=h1cdhchd10150221h130eB56 -skippatchcheck -AUTH_TYPE=EPIC -AUTH_LOGIN={Properties.Settings.Default.Email} -AUTH_PASSWORD={Properties.Settings.Default.Password} -calderas=",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };

                Process proc = new Process
                {
                    StartInfo = startInfo
                };

                proc.Start();
                //Inject(proc.Id, Appdata + "\\Redirect.dll");
                proc.BeginOutputReadLine();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
    }
}
