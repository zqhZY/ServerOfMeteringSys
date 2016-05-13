using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Net;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsForms
{
    public class Publec_Class
    {
        public static string ServerIP = "";
        public static string ServerPort = "";
        public static string ClientIP = "";
        public static string ClientName = "";
        public static string UserName;
        public static string UserID;


        public static void GetServerInfo(){
        

        } 


        [DllImport("kernel32")]
        public static extern void GetWindowsDirectory(StringBuilder WinDir, int count);
        
        public static string Get_windows()
        {
            const int nChars = 255;
            StringBuilder Buff = new StringBuilder(nChars);//‘⁄ƒƒ Õ∑≈
            GetWindowsDirectory(Buff, nChars);
            return Buff.ToString();
        }

    }
}
