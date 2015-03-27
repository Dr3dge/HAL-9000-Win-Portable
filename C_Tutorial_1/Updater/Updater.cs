using IWshRuntimeLibrary;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace Updater_Portable
{
    class Updater
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Downloading and Installing Update...");

                try
                {
                    Process[] proc = Process.GetProcessesByName("HAL-9000 Portable");
                    proc[0].Kill();
                    Thread.Sleep(TimeSpan.FromMilliseconds(300));
                }
                catch
                { }

                Thread update1 = new Thread(updateHAL9000);
                Thread update2 = new Thread(updateWritting);
                Thread update3 = new Thread(updateTrayHandler);
                update1.Start();
                update2.Start();
                update3.Start();

                if (System.IO.File.Exists(@"\HAL-9000\HALSync Portable.exe"))
                {
                    try
                    {
                        Process[] proc2 = Process.GetProcessesByName("HALSync Portable");
                        proc2[0].Kill();
                        Thread.Sleep(TimeSpan.FromMilliseconds(300));
                        System.IO.File.Delete(@"\HAL-9000\HALSync Portable.exe");
                        using (WebClient Client = new WebClient())
                        {
                            Client.DownloadFile("https://dl.dropboxusercontent.com/s/6zjti9mbb1fy0hp/HALSync%20Portable.exe?dl=0",
                                @"\HAL-9000\HALSync Portable.exe");
                        }
                    }
                    catch
                    {
                        System.IO.File.Delete(@"\HALSync Portable.exe");
                        using (WebClient Client = new WebClient())
                        {
                            Client.DownloadFile("https://dl.dropboxusercontent.com/s/6zjti9mbb1fy0hp/HALSync%20Portable.exe?dl=0",
                                @"\HAL-9000\HALSync Portable.exe");
                        }
                    }
                }
                else
                {
                    using (WebClient Client = new WebClient())
                    {
                        Client.DownloadFile("https://dl.dropboxusercontent.com/s/6zjti9mbb1fy0hp/HALSync%20Portable.exe?dl=0",
                            @"\HAL-9000\HALSync Portable.exe");
                    }
                }
            }
            catch
            {
                Console.WriteLine("I'm sorry Dave, I'm afraid I can't do that.");
                Console.ReadKey();
            }
        }
        private static void updateTrayHandler(object obj)
        {
            if (System.IO.File.Exists(@"\HAL-9000\SystemTray Handler Portable.exe"))
            {
                try
                {
                    Process[] proc = Process.GetProcessesByName("SystemTray Handler Portable");
                    proc[0].Kill();
                    Thread.Sleep(TimeSpan.FromMilliseconds(300));
                    System.IO.File.Delete(@"\HAL-9000\SystemTray Handler Portable.exe");
                    using (WebClient Client = new WebClient())
                    {
                        Client.DownloadFile("https://dl.dropboxusercontent.com/s/uvvyqwsyd6sbmzs/SystemTray%20Handler%20Portable.exe?dl=0",
                            @"\HAL-9000\SystemTray Handler Portable.exe");
                    }
                }
                catch
                {
                    System.IO.File.Delete(@"\HAL-9000\SystemTray Handler Portable.exe");
                    using (WebClient Client = new WebClient())
                    {
                        Client.DownloadFile("https://dl.dropboxusercontent.com/s/uvvyqwsyd6sbmzs/SystemTray%20Handler%20Portable.exe?dl=0",
                            @"\HAL-9000\SystemTray Handler Portable.exe");
                    }
                }
            }
            else if (!System.IO.File.Exists(@"\HAL-9000\SystemTray Handler Portable.exe"))
            {
                using (WebClient Client = new WebClient())
                {
                    Client.DownloadFile("https://dl.dropboxusercontent.com/s/uvvyqwsyd6sbmzs/SystemTray%20Handler%20Portable.exe?dl=0",
                            @"\HAL-9000\SystemTray Handler Portable.exe");
                }
            }
        }
        private static void updateWritting(object obj)
        {
            if (System.IO.File.Exists(@"\HAL-9000\Writting Portable.dll"))
            {
                System.IO.File.Delete(@"\HAL-9000\Writting Portable.dll");
                using (WebClient Client = new WebClient())
                {
                    Client.DownloadFile("https://dl.dropboxusercontent.com/s/wjuer5n7fczshxr/Writting%20Portable.dll?dl=0",
                        @"\HAL-9000\Writting Portable.dll");
                }
            }
            else if (!System.IO.File.Exists(@"\HAL-9000\Writting Portable.dll"))
            {
                using (WebClient Client = new WebClient())
                {
                    Client.DownloadFile("https://dl.dropboxusercontent.com/s/wjuer5n7fczshxr/Writting%20Portable.dll?dl=0",
                        @"\HAL-9000\Writting Portable.dll");
                }
            }
        }
        private static void updateHAL9000(object obj)
        {
            if (System.IO.File.Exists(@"\HAL-9000\HAL-9000 Portable.exe"))
            {
                System.IO.File.Delete(@"\HAL-9000\HAL-9000 Portable.exe");
                using (WebClient Client = new WebClient())
                {
                    Client.DownloadFile("https://dl.dropboxusercontent.com/s/mfdr9w0d71ci498/HAL-9000%20Portable.exe?dl=0",
                        @"\HAL-9000\HAL-9000 Portable.exe");
                }
                Thread.Sleep(1000);
                Process.Start(@"HAL-9000 Portable.exe");
            }
        }
    }
}
