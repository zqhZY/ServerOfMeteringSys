using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//以下添加
using Datawraper;
using System.Runtime.InteropServices;//INI文件操作引用
using System.Net;

namespace WindowsForms
{
    public partial class Login_Form : Form
    {
        //定义写INI文件API
        [DllImport("kernel32")]//定义读取INI文件API
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        public Login_Form()
        {
            InitializeComponent();

            //读入配置信息
            StringBuilder temp = new StringBuilder(255);//实例化可变长度的字符串对象

            //读Server.INI文件
            string error_str = "配置文件读取错误";
            GetPrivateProfileString("ServerInfo", "Username", "配置文件读取错误", temp, 255, Environment.CurrentDirectory + "\\ServerInfo.ini");
            Username.Text = temp.ToString();
            if (temp.ToString().Equals(error_str))
            {

                Username.Text = "";
            }

            GetPrivateProfileString("ServerInfo", "Password", "配置文件读取错误", temp, 255, Environment.CurrentDirectory + "\\ServerInfo.ini");
            Password.Text = temp.ToString();
            if (temp.ToString().Equals(error_str))
            {

                Password.Text = "";
            }

            GetPrivateProfileString("ServerInfo", "Database", "配置文件读取错误", temp, 255, Environment.CurrentDirectory + "\\ServerInfo.ini");
            Database.Text = temp.ToString();
            if (temp.ToString().Equals(error_str))
            {

                Database.Text = "";
            }

            GetPrivateProfileString("ServerInfo", "OracleIP", "配置文件读取错误", temp, 255, Environment.CurrentDirectory + "\\ServerInfo.ini");
            OracleIP.Text = temp.ToString();
            if (temp.ToString().Equals(error_str))
            {

                OracleIP.Text = "";
            }

            GetPrivateProfileString("ServerInfo", "OraclePort", "配置文件读取错误", temp, 255, Environment.CurrentDirectory + "\\ServerInfo.ini");
            OraclePort.Text = temp.ToString();
            if (temp.ToString().Equals(error_str))
            {

                OraclePort.Text = "";
            }

            GetPrivateProfileString("ServerInfo", "ServIP", "配置文件读取错误", temp, 255, Environment.CurrentDirectory + "\\ServerInfo.ini");
            ServIP.Text = temp.ToString();
            if (temp.ToString().Equals(error_str))
            {

                ServIP.Text = "";
            }

            GetPrivateProfileString("ServerInfo", "ServPort", "配置文件读取错误", temp, 255, Environment.CurrentDirectory + "\\ServerInfo.ini");
            ServPort.Text = temp.ToString();
            if (temp.ToString().Equals(error_str))
            {

                ServPort.Text = "";
            }

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //定义写INI文件API
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        private void Login_Confirm(object sender, EventArgs e)
        {
            //MessageBox.Show(Publec_Class.Get_windows());
            DataOp database = new DataOp(OracleIP.Text, OraclePort.Text , Database.Text, Username.Text, Password.Text);
            //database会自己回收资源吗。
            IPAddress ip;
            bool isIP;//判断ip是否合法
            int port_oracle = 0;
            int port_serv = 0;
            try
            {

                port_oracle = int.Parse(OraclePort.Text);
                port_serv = int.Parse(ServPort.Text);
            }
            catch {

                isIP = false;
            }
            isIP = (IPAddress.TryParse(OracleIP.Text, out ip) && (port_oracle > 1024 && port_oracle < 65536)
                && IPAddress.TryParse(ServIP.Text, out ip) && (port_serv > 1024 && port_serv < 65536)) ? true : false;
            
            if (database.IfConnect && isIP)
            {
                //写INI配置文件
                WritePrivateProfileString("ServerInfo", "Username", Username.Text, Environment.CurrentDirectory + "\\ServerInfo.ini");
                WritePrivateProfileString("ServerInfo", "Password", Password.Text, Environment.CurrentDirectory + "\\ServerInfo.ini");
                WritePrivateProfileString("ServerInfo", "Database", Database.Text, Environment.CurrentDirectory + "\\ServerInfo.ini");
                WritePrivateProfileString("ServerInfo", "OracleIP", OracleIP.Text, Environment.CurrentDirectory + "\\ServerInfo.ini");
                WritePrivateProfileString("ServerInfo", "OraclePort", OraclePort.Text, Environment.CurrentDirectory + "\\ServerInfo.ini");
                WritePrivateProfileString("ServerInfo", "ServIP", ServIP.Text, Environment.CurrentDirectory + "\\ServerInfo.ini");
                WritePrivateProfileString("ServerInfo", "ServPort", ServPort.Text, Environment.CurrentDirectory + "\\ServerInfo.ini");
                
                DialogResult = DialogResult.OK;//完成登陆，返回ok
            }
            else if (isIP)
            {

                Username.Clear();
                Password.Clear();
                Database.Clear();
                MessageBox.Show("数据库配置错误，重新配置！");

            }
            else if (database.IfConnect)
            {

                OracleIP.Clear();
                OraclePort.Clear();
                ServIP.Clear();
                ServPort.Clear();
                MessageBox.Show("IP地址不合法，或端口号不在1024~65535之间。");
            }
            else {

                Username.Clear();
                Password.Clear();
                Database.Clear();
                OracleIP.Clear();
                OraclePort.Clear();
                MessageBox.Show("数据库配置错误，IP地址不合法，或端口号不在1024~65535之间。");
            }

        }

        private void Login_Cancel(object sender, EventArgs e)
        {
            //MessageBox.Show("放弃登陆。");
            //this.Close();
            DialogResult = DialogResult.No;
        }



 

      
    }
}
