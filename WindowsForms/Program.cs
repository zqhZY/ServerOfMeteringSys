using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
//using Datawraper;
using System.Runtime.InteropServices;//INI文件操作引用
using System.Text;

namespace WindowsForms
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread, DllImport("kernel32")]//定义读取INI文件API
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            //读ini文件如果存在且正确，直接进入server,否则转入登陆
            if (System.IO.File.Exists(Environment.CurrentDirectory + "\\ServerInfo.ini") == false)
            {
                //创建配置窗口
                Login_Form login_forn = new Login_Form();
                login_forn.Text = "服务器配置";

                if (login_forn.ShowDialog() == DialogResult.OK){

                    login_forn.Dispose();//释放login_form的所有资源
                    Wellcome wellcom_form = new Wellcome();
                    if (wellcom_form.ShowDialog() == DialogResult.OK)
                    {
                        //wellcom_form.
                        wellcom_form.Dispose();//释放login_form的所有资源
                        Application.Run(new F_Server());
                    }
                    else
                    {

                        wellcom_form.Dispose();
                        //MessageBox.Show("退出服务器");
                        Application.Exit();
                    }
                }
                else {

                    login_forn.Dispose();
                    //MessageBox.Show("退出服务器");
                    Application.Exit();   
                }
            }
            else {//当前目录下已存在INI文件

                Wellcome wellcom_form = new Wellcome();
                if (wellcom_form.ShowDialog() == DialogResult.OK)
                {

                    wellcom_form.Dispose();//释放login_form的所有资源
                    Application.Run(new F_Server());
                }
                else
                {

                    wellcom_form.Dispose();
                    //MessageBox.Show("退出服务器");
                    Application.Exit();
                }
                //Application.Run(new F_Server());
                //Application.Run(new Wellcome());
            }
                        
        }
    }
}
