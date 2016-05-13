using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using System.Runtime.InteropServices;//INI文件操作引用
using Datawraper;

namespace WindowsForms
{
    public partial class Wellcome : Form
    {


        public Wellcome()
        {
            InitializeComponent();
        }

        /**
         * 点击登录
         * 
         * 
         * */
        //定义写INI文件API
        [DllImport("kernel32")]//定义读取INI文件API
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        private void login_Click(object sender, EventArgs e)
        {
            //查询用户表，匹配用户名与密码
            
            string name_in = userName.Text;
            string password_in = passWord.Text;
            if (name_in == "" || password_in == "")
            {
                MessageBox.Show("用户名和密码不能为空！");
            }
            else 
            {
                //根据用户名查询用户密码
                //读入配置信息
                StringBuilder temp = new StringBuilder(255);//实例化可变长度的字符串对象

                //读Server.INI文件

                GetPrivateProfileString("ServerInfo", "Username", "数据库用户名读取错误。 ", temp, 255, Environment.CurrentDirectory + "\\ServerInfo.ini");
                string username = temp.ToString();
                GetPrivateProfileString("ServerInfo", "Password", "数据库用户密码读取错误。 ", temp, 255, Environment.CurrentDirectory + "\\ServerInfo.ini");
                string password = temp.ToString();
                GetPrivateProfileString("ServerInfo", "Database", "数据库读取错误。 ", temp, 255, Environment.CurrentDirectory + "\\ServerInfo.ini");
                string database = temp.ToString();
                GetPrivateProfileString("ServerInfo", "OracleIP", "数据库IP读取错误。 ", temp, 255, Environment.CurrentDirectory + "\\ServerInfo.ini");
                string oracleip = temp.ToString();
                GetPrivateProfileString("ServerInfo", "OraclePort", "数据库端口读取错误。 ", temp, 255, Environment.CurrentDirectory + "\\ServerInfo.ini");
                string oracleport = temp.ToString();
                GetPrivateProfileString("ServerInfo", "ServIP", "服务器IP读取错误。 ", temp, 255, Environment.CurrentDirectory + "\\ServerInfo.ini");
                string hostip = temp.ToString();
                GetPrivateProfileString("ServerInfo", "ServPort", "服务器端口读取错误。 ", temp, 255, Environment.CurrentDirectory + "\\ServerInfo.ini");
                string serverport = temp.ToString();

                DataOp dataOp = new DataOp(oracleip, oracleport, database, username, password);

                string password_to_cmp = dataOp.GetOneStrTypeByName("PASSWORD", "USER_T", "USER_NAME", name_in);


                if (password_to_cmp == null)
                {
                    MessageBox.Show("该用户不存在！");
                }
                else 
                {
                    if (password_to_cmp.Equals(password_in))
                    {

                        //登录成功,进入管理界面
                        DialogResult = DialogResult.OK;//完成登陆，返回ok
                        //F_Server f_server =  new F_Server();

                    }
                    else
                    {

                        MessageBox.Show("用户名或密码错误！");
                        //清空文本框内容
                        //userName.Text = "";
                        //passWord.Text = "";

                    }
                
                }

                dataOp.Close();

                

            }


        }

        

        /*
         * 
         * 点击配置，弹出配置窗口
         * 
         * 
         * */
        private void config_Click(object sender, EventArgs e)
        {
            //创建配置窗口
            Login_Form login_forn = new Login_Form();
            login_forn.Text = "服务器配置";

            if (login_forn.ShowDialog() == DialogResult.OK)
            {

                login_forn.Dispose();//释放login_form的所有资源
                MessageBox.Show("配置成功，重启生效！");
                //Application.Run(new F_Server());
            }
            else
            {

                login_forn.Dispose();
                //MessageBox.Show("退出配置");
                //Application.Exit();
            }

        }

        private void reset_Click(object sender, EventArgs e)
        {
            //清空文本框内容
            userName.Text = "";
            passWord.Text = "";
        }

        private void userName_TextChanged(object sender, EventArgs e)
        {

        }       
    }
}
