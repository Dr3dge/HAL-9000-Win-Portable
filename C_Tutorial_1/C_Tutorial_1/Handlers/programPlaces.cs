using HAL_9000_Writting_Portable;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace HAL_9000_Portable
{
    class programPlaces
    {
        public static void Chrome()
        {
            try
            {
                Process.Start(@"\Google\Chrome\Application\chrome.exe");
            }
            catch
            {
                try
                {
                    Process.Start(@" (x86)\Google\Chrome\Application\chrome.exe");
                }
                catch
                {
                    Writting.sorryDave();
                }
            }
        }
        public static void Firefox()
        {
            try
            {
                Process.Start(@"\Mozilla Firefox\firefox.exe");
            }
            catch
            {
                try
                {
                    Process.Start(@" (x86)\Mozilla Firefox\firefox.exe");
                }
                catch
                {
                    Writting.sorryDave();
                }
            }
        }
        public static void Word()
        {
            try
            {
                Process.Start(@"\Microsoft Office\Office14\WINWORD.exe");
                Console.WriteLine("Word launched");
            }
            catch
            {
                Writting.sorryDave();
            }
        }
        public static void powerPoint()
        {
            try
            {
                Process.Start(@"\Microsoft Office\Office14\POWERPNT.exe");
                Console.WriteLine("PowerPoint launched");
            }
            catch
            {
                Writting.sorryDave();
            }
        }
        public static void oneNote()
        {
            try
            {
                Process.Start(@"\Microsoft Office\Office14\ONENOTE.exe");
                Console.WriteLine("OneNote launched");
            }
            catch
            {
                Writting.sorryDave();
            }
        }
        public static void Excel()
        {
            try
            {
                Process.Start(@"\Microsoft Office\Office14\EXCEL.exe");
                Console.WriteLine("Excel launched");
            }
            catch
            {
                Writting.sorryDave();
            }
        }
        public static void notepadPP()
        {
            try
            {
                Process.Start(@"\Notepad++\notepad++.exe");
                Console.WriteLine("Notepad++ launched");
            }
            catch
            {
                Writting.sorryDave();
            }
        }
        public static void Notepad()
        {
            try
            {
                Process.Start(@"C:\Windows\System32\notepad.exe");
                Console.WriteLine("Notepad launched");
            }
            catch
            {
                Writting.sorryDave();
            }
        }
        public static void CMD()
        {
            try
            {
                Process.Start(@"C:\\Windows\\System32\\cmd.exe");
                Console.WriteLine("CMD launched");
            }
            catch
            {
                Writting.sorryDave();
            }
        }
        public static void Steam()
        {
            try
            {
                Process.Start(@"C:\\Program Files (x86)\\Steam\\Steam.exe");
                Console.WriteLine("Steam launched");
            }
            catch
            {
                Writting.sorryDave();
            }
        }
    }
}
