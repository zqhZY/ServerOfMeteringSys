using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;
using System.Threading; 

namespace WindowsForms
{
    //控件中拖入即实例化该类，对象句柄为拖入组件名字
    //服务器为UDPSocket_serv
    //客户端为UDPSocket_clin
    public partial class UDPSocket : Component
    {
        private IPEndPoint ServerEndPoint = null;   //定义网络端点
        private UdpClient UDP_Server = new UdpClient(); //创建网络服务,也就是UDP的Sockets
        public delegate void DataArrivalEventHandler(byte[] Data, IPAddress Ip, int Port);  //定义了一个托管方法
        public event DataArrivalEventHandler DataArrival;   //通过托管理在控件中定义一个事件

        
        private System.Threading.Thread thdUdp; //创建一个线程
        
        /**
        private bool thread_on = false;
        [Browsable(true), Category("Local"), Description("后台接收数据线程")]
        public bool Thread_on
        {
            get { return thread_on; }
            set //该属性读取值
            {
                thread_on = value;
                if (thread_on) //当值为True时
                {
                    thdUdp.Start();   //打开监听
                    MessageBox.Show("daadadad");

                }
                else
                {
                    thdUdp.Abort(); //关闭接收数据线程
                }
            }
        }
        **/
        private string localHost = "127.0.0.1";
        [Browsable(true), Category("Local"), Description("本地IP地址")]   //在“属性”窗口中显示localHost属性
        public string LocalHost
        {
            get { return localHost; }
            set { localHost = value; }
        }

        private int localPort = 11000;
        [Browsable(true), Category("Local"), Description("本地端口号")] //在“属性”窗口中显示localPort属性
        public int LocalPort
        {
            get { return localPort; }
            set { localPort = value; }
        }

        private bool active = false;
        [Browsable(true), Category("Local"), Description("激活监听")]   //在“属性”窗口中显示active属性
        public bool Active
        {
            get { return active; }  
            set //该属性读取值
            { 
                active = value;
                if (active) //当值为True时
                {
                    OpenSocket();   //打开监听
                }
                else
                {
                    CloseSocket();  //关闭监听
                }
            }
        }


        public UDPSocket()
        {
            InitializeComponent();
        }

        public UDPSocket(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /*
         * 服务器监听，
         * 为每一个客户端创建线程
         * 
         * 
         * */
        protected void Listener()   //监听
        {
            ServerEndPoint = new IPEndPoint(IPAddress.Parse(this.localHost), localPort);   //将IP地址和端口号以网络端点存储
            if (UDP_Server != null)
                UDP_Server.Close();
            UDP_Server = new UdpClient(localPort);  //创建一个新的端口号
            UDP_Server.Client.ReceiveBufferSize = 1000000000;   //接收缓冲区大小
            UDP_Server.Client.SendBufferSize = 1000000000;  //发送缓冲区大小
            
            try
            {
                MessageBox.Show("udp监听，创建接收数据线程");
                thdUdp = new Thread(new ThreadStart(GetUDPData));   //创建一个线程，
                //this.thread_on = true;//执行当前线程
                thdUdp.Start(); //执行当前线程
                thdUdp.IsBackground = true;
                //udp程序仅创建一个监听线程，忙则将客户端信息暂存缓存
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());  //显示线程的错误信息
            }
        }

        private void GetUDPData()   //获取当前接收的消息
        {
            while (active)//循环监听客户端连接
            {
                try
                {
                    byte[] Data = UDP_Server.Receive(ref ServerEndPoint);   //将获取的远程消息转换成二进制流

                    if (DataArrival != null)
                    {
                        //MessageBox.Show(ServerEndPoint.Address.ToString() + ServerEndPoint.Port);
                        DataArrival(Data, ServerEndPoint.Address, ServerEndPoint.Port);
                    }
                    Thread.Sleep(0);
                }
                catch { }
            }
        }

        private void CallBackMethod(IAsyncResult ar)
        {
            //从异步状态ar.AsyncState中，获取委托对象
            DataArrivalEventHandler dn = (DataArrivalEventHandler)ar.AsyncState;
            //一定要EndInvoke
            dn.EndInvoke(ar);
        }


        public void Send(System.Net.IPAddress Host, int Port, byte[] Data)
        {
            try
            {
                IPEndPoint server = new IPEndPoint(Host, Port);
                UDP_Server.Send(Data, Data.Length, server);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        } 

        private void OpenSocket()
        {
            Listener();
        }

        private void CloseSocket()
        {
            if (UDP_Server != null)
                UDP_Server.Close();
            if (thdUdp != null)
            {
                Thread.Sleep(30);
                thdUdp.Abort();
            }
        }
    }
}
