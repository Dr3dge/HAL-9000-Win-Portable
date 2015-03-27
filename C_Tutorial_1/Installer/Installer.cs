using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using IWshRuntimeLibrary;
using System.Diagnostics;
using System.Threading;

namespace Installer
{
    class Installer
    {
        static void Main(string[] args)
        {
            try
            {
                if (System.IO.File.Exists(@"\HAL-9000\HAL-9000.exe"))
                {
                    string userInput = null;
                    Console.WriteLine();
                    Console.WriteLine("HAL-9000 is already installed.");
                    Console.Write("Do you wish to reinstall HAL-9000? [Y/N] ");
                    userInput = Console.ReadLine().ToLower();
                    if (userInput == "y" || userInput == "yes")
                    {
                        Thread install1 = new Thread(installHAL9000);
                        Thread install2 = new Thread(installWritting);
                        Thread install3 = new Thread(installTrayHandler);
                        Thread install4 = new Thread(installUpdater);
                        install1.Start();
                        install2.Start();
                        install3.Start();
                        install4.Start();

                        Console.WriteLine("Downloading and Installing...");

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
                                System.IO.File.Delete(@"\HAL-9000\HALSync Portable.exe");
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
                        Console.WriteLine();
                        Console.WriteLine("This program was successfully installed");
                        Console.WriteLine();
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("HAL-9000 has not been reinstalled");
                        Console.WriteLine();
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Downloading and Installing...");
                    Directory.CreateDirectory(@"\HAL-9000");

                    Thread install1 = new Thread(cleanInstallHAL9000);
                    Thread install2 = new Thread(cleanInstallWritting);
                    Thread install3 = new Thread(cleanInstallTrayHandler);
                    Thread install4 = new Thread(cleanInstallUpdater);
                    install1.Start();
                    install2.Start();
                    install3.Start();
                    install4.Start();

                    using (WebClient Client = new WebClient())
                    {
                        Client.DownloadFile("https://dl.dropboxusercontent.com/s/6zjti9mbb1fy0hp/HALSync%20Portable.exe?dl=0",
                            @"\HAL-9000\HALSync Portable.exe");
                    }
                    Console.WriteLine();
                    Console.WriteLine("This program was successfully installed");
                    Console.WriteLine();
                    Console.ReadKey();
                }
            }
            catch
            {
                Console.WriteLine("I'm sorry Dave, I'm afraid I can't do that.");
            }
        }

        private static void cleanInstallUpdater(object obj)
        {
            using (WebClient Client = new WebClient())
            {
                Client.DownloadFile("https://dl.dropboxusercontent.com/s/mt07h5ju2jd1ksy/Updater%20Portable.exe?dl=0",
                    @"\HAL-9000\Updater Portable.exe");
            }
        }

        private static void cleanInstallTrayHandler(object obj)
        {
            using (WebClient Client = new WebClient())
            {
                Client.DownloadFile("https://dl.dropboxusercontent.com/s/uvvyqwsyd6sbmzs/SystemTray%20Handler%20Portable.exe?dl=0",
                    @"\HAL-9000\SystemTray Handler Portable.exe");
            }
        }

        private static void cleanInstallWritting(object obj)
        {
            using (WebClient Client = new WebClient())
            {
                Client.DownloadFile("https://dl.dropboxusercontent.com/s/yzc8m0gbi1la2zk/Writting.dll?dl=0",
                    @"\HAL-9000\Writting.dll");
            }
        }

        private static void cleanInstallHAL9000(object obj)
        {
            using (WebClient Client = new WebClient())
            {
                Client.DownloadFile("https://dl.dropboxusercontent.com/s/mfdr9w0d71ci498/HAL-9000%20Portable.exe?dl=0",
                    @"\HAL-9000\HAL-9000 Portable.exe");
            }
        }
        private static void installUpdater(object obj)
        {
            try
            {
                System.IO.File.Delete(@"\HAL-9000\Updater Portable.exe");
                using (WebClient Client = new WebClient())
                {
                    Client.DownloadFile("https://dl.dropboxusercontent.com/s/mt07h5ju2jd1ksy/Updater%20Portable.exe?dl=0",
                        @"\HAL-9000\Updater Portable.exe");
                }
            }
            catch
            {
                using (WebClient Client = new WebClient())
                {
                    Client.DownloadFile("https://dl.dropboxusercontent.com/s/mt07h5ju2jd1ksy/Updater%20Portable.exe?dl=0",
                        @"\HAL-9000\Updater Portable.exe");
                }
            }
        }
        private static void installTrayHandler(object obj)
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
        private static void installWritting(object obj)
        {
            try
            {
                System.IO.File.Delete(@"\HAL-9000\Writting.dll");
                using (WebClient Client = new WebClient())
                {
                    Client.DownloadFile("https://dl.dropboxusercontent.com/s/yzc8m0gbi1la2zk/Writting.dll?dl=0",
                        @"\HAL-9000\Writting.dll");
                }
            }
            catch
            {
                using (WebClient Client = new WebClient())
                {
                    Client.DownloadFile("https://dl.dropboxusercontent.com/s/yzc8m0gbi1la2zk/Writting.dll?dl=0",
                        @"\HAL-9000\Writting.dll");
                }
            }
        }
        private static void installHAL9000(object obj)
        {
            try
            {
                Process[] proc = Process.GetProcessesByName("HAL-9000 Portable");
                proc[0].Kill();
                Thread.Sleep(TimeSpan.FromMilliseconds(300));
                System.IO.File.Delete(@"\HAL-9000\HAL-9000 Portable.exe");
                using (WebClient Client = new WebClient())
                {
                    Client.DownloadFile("https://dl.dropboxusercontent.com/s/mfdr9w0d71ci498/HAL-9000%20Portable.exe?dl=0",
                        @"\HAL-9000\HAL-9000 Portable.exe");
                }
            }
            catch
            {
                System.IO.File.Delete(@"\HAL-9000\HAL-9000 Portable.exe");
                using (WebClient Client = new WebClient())
                {
                    Client.DownloadFile("https://dl.dropboxusercontent.com/s/mfdr9w0d71ci498/HAL-9000%20Portable.exe?dl=0",
                        @"\HAL-9000\HAL-9000 Portable.exe");
                }
            }
        }
    }
}
