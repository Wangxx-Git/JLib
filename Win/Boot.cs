using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JLib.Win
{
    /// <summary>
    /// 设置开机启动
    /// </summary>
    public class Boot
    {
        //开机启动
        public static void SetStart(string name,string ExePath)
        {
            RegistryKey HKCU = Registry.CurrentUser;
            RegistryKey Run = HKCU.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            try
            {
                Run.SetValue("SmsCovert", Application.StartupPath + "\\SmsCovert.exe");
            }
            catch
            {

            }
            HKCU.Close();
        }

        //开机不启动
        public static void CancelStart(string name)
        {
            RegistryKey HKCU = Registry.CurrentUser;
            RegistryKey Run = HKCU.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            try
            {
                Run.DeleteValue("SmsCovert", false);
            }
            catch
            {

            }
            HKCU.Close();
        }
    }
}
