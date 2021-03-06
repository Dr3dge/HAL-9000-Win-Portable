﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemTray
{
    public partial class SystemTray : Form
    {
        NotifyIcon halTrayIcon;
        public SystemTray()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

            halTrayIcon = new NotifyIcon();
            halTrayIcon.Icon = new Icon(this.Icon, 32, 32);
            halTrayIcon.Visible = true;

            ContextMenu contextMenu = new ContextMenu();
            MenuItem runHAL = new MenuItem("Open HAL-9000");
            MenuItem closeHAL = new MenuItem("Close HAL-9000");
            MenuItem closeHALSync = new MenuItem("Close HALSync");
            MenuItem closeHalTray = new MenuItem("Close HAL-9000 Tray App");
            MenuItem closeHalFull = new MenuItem("Close HAL-9000 Completely");

            contextMenu.MenuItems.Add(runHAL);
            contextMenu.MenuItems.Add(closeHAL);
            contextMenu.MenuItems.Add(closeHALSync);
            contextMenu.MenuItems.Add(closeHalTray);
            contextMenu.MenuItems.Add(closeHalFull);
            halTrayIcon.ContextMenu = contextMenu;

            runHAL.Click += runHAL_click;
            closeHAL.Click += closeHAL_click;
            closeHALSync.Click += closeHALSync_Click;
            closeHalTray.Click += closeHalTray_click;
            closeHalFull.Click += closeHalFull_click;
        }
        private void closeHALSync_Click(object sender, EventArgs e)
        {
            Process[] proc = Process.GetProcessesByName("HALSync Portable");
            if (proc.Length != 0)
            {
                proc[0].Kill();
            }
        }
        void closeHalTray_click(object sender, EventArgs e)
        {
            halTrayIcon.Dispose();
            this.Close();
        }
        void runHAL_click(object sender, EventArgs e)
        {
            Process.Start(@"HAL-9000.exe");
        }
        void closeHalFull_click(object sender, EventArgs e)
        {
            try
            {
                Process[] proc = Process.GetProcessesByName("HAL-9000 Portable");
                Process[] proc2 = Process.GetProcessesByName("HALSync Portable");
                if (proc.Length != 0)
                {
                    proc[0].Kill();
                }
                if (proc2.Length != 0)
                {
                    proc2[0].Kill();
                }
            }
            catch
            {
                MessageBox.Show("HAL-9000 is not running.");
            }
            halTrayIcon.Dispose();
            this.Close();
        }
        void closeHAL_click(object sender, EventArgs e)
        {
            try
            {
                Process[] proc = Process.GetProcessesByName("HAL-9000 Portable");
                proc[0].Kill();
            }
            catch
            {
                MessageBox.Show("HAL-9000 is not running.");
            }
        }
    }
}
