using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.IO;

using System.Data.OleDb;

using Datawraper;
using System.Runtime.InteropServices;//INI文件操作引用
//using System.Text;
using InfoGetter;//命令分析
using MsgClass;

using DataModel;

namespace WindowsForms
{
    public partial class F_Server : Form
    {

        //localhost字段待替换
        private string database;
        private string userid;//获取登陆信息
        private string password;
        private string hostip;
        private string serverport;
        private string oracleip;
        private string oracleport = "1521";

        //private DataOp dataOp = null;

        //实例化信息处理类
        infoGetter dataGetter = new infoGetter();



        //根据ip地址保存listview的id值
        private Dictionary<String, int> ViewListHash = new Dictionary<String, int>();




        //记录每个网关节点的心跳计数
        //heartBeatResCounts , 键为ip地址，，值为存储心跳发送，接受状态的字典，
        //该字典中，第一个标识“sendTimes"次数，第二个"recvFlag"表示是否收到响应的标识
        private Dictionary<String, Dictionary<string, int>> heartBeatResCounts = new Dictionary<String, Dictionary<string, int> >();





        
        [DllImport("kernel32")]//定义读取INI文件API
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        
        /**     
         *  服务器初始化
         *  读入配置文件信息，配置数据库与服务器软件ip和port
         * */

        [DllImport("user32.dll")]//注册热键API
        public static extern UInt32 RegisterHotKey(IntPtr hWnd, UInt32 id, UInt32 fsModifiers, UInt32 vk); 
        public F_Server()
        {
            InitializeComponent();
            RegisterHotKey(this.Handle, 247696411, 0, (UInt32)Keys.F11); //注册热键


            StringBuilder temp = new StringBuilder(255);//实例化可变长度的字符串对象

            //读Server.INI文件
         
            GetPrivateProfileString("ServerInfo", "Username", "数据库用户名读取错误。 ", temp, 255, Environment.CurrentDirectory + "\\ServerInfo.ini");
            this.userid = temp.ToString();
            GetPrivateProfileString("ServerInfo", "Password", "数据库用户密码读取错误。 ", temp, 255, Environment.CurrentDirectory + "\\ServerInfo.ini");
            this.password = temp.ToString();
            GetPrivateProfileString("ServerInfo", "Database", "数据库读取错误。 ", temp, 255, Environment.CurrentDirectory + "\\ServerInfo.ini");
            this.database = temp.ToString();
            GetPrivateProfileString("ServerInfo", "OracleIP", "数据库IP读取错误。 ", temp, 255, Environment.CurrentDirectory + "\\ServerInfo.ini");
            this.oracleip = temp.ToString();
            GetPrivateProfileString("ServerInfo", "OraclePort", "数据库端口读取错误。 ", temp, 255, Environment.CurrentDirectory + "\\ServerInfo.ini");
            this.oracleport = temp.ToString();
            GetPrivateProfileString("ServerInfo", "ServIP", "服务器IP读取错误。 ", temp, 255, Environment.CurrentDirectory + "\\ServerInfo.ini");
            this.hostip = temp.ToString();
            GetPrivateProfileString("ServerInfo", "ServPort", "服务器端口读取错误。 ", temp, 255, Environment.CurrentDirectory + "\\ServerInfo.ini");
            this.serverport = temp.ToString();

            UDPSocket_serv.LocalHost = this.hostip;//为服务器指定ip地址，默认为127.0.0.1
            UDPSocket_serv.LocalPort = int.Parse(this.serverport);//指定服务器进程port,默认为11000

            //创建数据库连接句柄
            //this.dataOp = new DataOp(this.hostip , this.oraclePort , this.database , this.userid , this.password);

            //初始刷新列表
            //Load_InfoList();

            //SysUser.Items.Clear();

            //读入大楼选项信息
            //Load_BuildingInfo();

        }

       
        public F_Server(string ip, int port) {

            UDPSocket_serv.LocalHost = ip;//为服务器指定ip地址，默认为127.0.0.1
            UDPSocket_serv.LocalPort = port;//指定服务器进程port,默认为11000
            InitializeComponent();
        }
       

      

        
        private void Tool_Open(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Text == "开始服务")
            {
                ((ToolStripMenuItem)sender).Text = "结束服务";
                UDPSocket_serv.Active = true;

                //启动心跳时钟
                heartBeat.Enabled = true;
                updateAllInfo.Enabled = true;
            }
            else
            {
                ((ToolStripMenuItem)sender).Text = "开始服务";
                UDPSocket_serv.Active = false;

                //关闭心跳时钟
                heartBeat.Enabled = false;
                updateAllInfo.Enabled = false;
            }

            //
        }

        private void Server(bool IsServer)//开始或停止服务
        {

        }

        private void sockUDP1_DataArrival(byte[] Data, System.Net.IPAddress Ip, int Port)
        {
            DataArrivaldelegate outdelegate = new DataArrivaldelegate(DataArrival);
            this.BeginInvoke(outdelegate, new object[] { Data, Ip, Port }); 
        }
        private delegate void DataArrivaldelegate(byte[] Data, System.Net.IPAddress Ip, int Port);


        /**
         * 托管代码段：当有数据传输到达时进行数据处理
         * 
         * 
         * 
         * */
        private void DataArrival(byte[] Data, System.Net.IPAddress Ip, int Port) //当有数据到达后的处理进程
        {
            Console.WriteLine("IP : " + Ip + " PORT: " + Port);
     
            //UDPSocket_serv.Send(Ip, Port, Data);
            string msg = Encoding.UTF8.GetString(Data);//linux 端用char[],,c#端用utf8解码

            //infoGetter infos = new infoGetter();

            //<head>id</head><data>datas</data>
            //将数字转化成enum类型，，
            try
            {
                MsgCommand msgkind = (MsgCommand)int.Parse(dataGetter.getHead(msg));
                switch (msgkind)
                {


                    case MsgCommand.CONNECT://1
                        {
                            //MessageBox.Show("1  Registering msg has come");
                            byte[] Response = System.Text.Encoding.Default.GetBytes(Conmmend.CONNECTION_RES);//响应链接
                            UDPSocket_serv.Send(Ip, Port, Response);
                            //string data = infos.getData(msg);
                            //RegisterUser(data);
                        }
                        break;

                    case MsgCommand.LOGIN://3
                        {

                            try
                            {
                                UserLogin(msg, Ip, Port);

                                byte[] Response = System.Text.Encoding.Default.GetBytes(Conmmend.LOGIN_MSG_RES);//响应登录
                                UDPSocket_serv.Send(Ip, Port, Response);


                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show("user login : " + ex.Message);
                            }
                                                   
                        }
                        break;

                    case MsgCommand.HEART_BEAT_RES:
                        {
                            //Console.WriteLine("IP : " + Ip + "Heart Beat Response....");
                            heartBeatResCounts[Ip.ToString()]["RecvFlag"] = 1;//修改该ip节点的心跳包响应状态
                        
                        }
                        break;

                    case MsgCommand.UPDATE_NODE_NUM:
                        {
                            Console.WriteLine("IP : " + Ip + " : Node number update....");
                            bool updateFlag = UpdateGatewayOfNode(msg, Ip);//更新电表附属的网关信息
                            if (updateFlag) {

                                
                                byte[] Response = System.Text.Encoding.Default.GetBytes(Conmmend.UPDATE_NODE_NUM_RES);//响应电表更新
                                UDPSocket_serv.Send(Ip, Port, Response);
                            }


                        }
                        break;

                    case MsgCommand.COLLECTER_INFO_RES:
                        {
                            Console.WriteLine("IP : " + Ip + " : " + msg);
                            bool updateFlag = UpdateHistoryOfInfo(msg);//更新电表历史信息表
                        
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            
            }
            
        }



        /**
        * 
        * 初始化显示数据库已有信息列在UserList显示
        * 
        * 
        * 
        * */
        private void Load_InfoList()
        {
            //Dictionary<String, int> ViewListHash = null;
            //List<Dictionary<String, String>> dataList = new List<Dictionary<string, string>>();

            DataOp dataOp = new DataOp(this.oracleip, this.oracleport, this.database, this.userid, this.password);

            List<Collection_t> dataList = new List<Collection_t>();
            //查询所有电表信息
            OleDbDataReader data = dataOp.GetAllRowByTable("COLLECTOR_T");

            while (data.Read())
            {

                //Dictionary<String, String> dataListHash = new Dictionary<string,string>();
                Collection_t collection_t = new Collection_t(data[0].ToString(), data[1].ToString(),
                   data[2].ToString(), data[3].ToString(), data[4].ToString(), data[5].ToString(),
                   data[6].ToString(), data[7].ToString(), data[8].ToString(), data[9].ToString());


                //得到电表所属网关的ip地址
                OleDbDataReader data_gateway = dataOp.GetRowByIndex("GATEWAY_T", "GATEWAY_ID", collection_t.Gateway_id);

                ////根据网关id查ip地址与端口：
                while (data_gateway.Read())
                {
                    collection_t.Address = data_gateway[2].ToString();
                    collection_t.Port = data_gateway[3].ToString();
                    collection_t.Active_net = data_gateway[5].ToString();
                }


                dataList.Add(collection_t);

            }

            UpdateList(dataList);

            dataOp.Close();

        }





        
        /**
         * 
         * 网关登录
         * 网关启动后即登录服务器，更新其在服务器中的信息
         * 如果不存在则注册
         * 
         * 
         * */
        private void UserLogin(string msg , System.Net.IPAddress Ip, int Port)
        {

            DataOp dataOp = new DataOp(this.oracleip, this.oracleport, this.database, this.userid, this.password);

            string ip = Ip.ToString();
            //根据ip地址查询记录
            OleDbDataReader data = dataOp.GetRowByIndex("GATEWAY_T", "ADDRESS", Ip.ToString());


            //如果存在则更新
            if (data.HasRows)
            {
                string newvalue = "set address = '" + Ip.ToString() + "' , port = " + Port;
                int rownum = dataOp.UpdateOneRow("GATEWAY_T" , newvalue ,"ADDRESS" , Ip.ToString() );

                if (rownum != 1) {

                    Console.WriteLine("UpdateOneRow gateway_t error");
                }

                
                //更新列表网关与电表状态
                //Load_InfoList();

            }
            else
            {
                //如果不存在则插入

                //获取最大索引，
                int nextid = dataOp.GetMaxId("GATEWAY_T", "Gateway_id") + 1;

                //插入数据
                string value = nextid + ",'default', '" + Ip.ToString() + "'," + Port + ", 'default' , 'active'";

                int rownum = dataOp.InsertOneRow("GATEWAY_T", value);
            
                //追加记录
                //Load_InfoList();

            }

            dataOp.Close();
            

        }



        

        /**
         * 
         * 
         * 更新电表所在的网关id
         * 
         * 
         * 
         * 
         * */

        private bool UpdateGatewayOfNode(string msg, System.Net.IPAddress Ip) 
        {

            DataOp dataOp = new DataOp(this.oracleip, this.oracleport, this.database, this.userid, this.password);

            bool flag = true;
            //得到数据包中的电表号
            string[] infos = dataGetter.getInfo(msg);
            foreach (string info in infos) 
            {

                Console.WriteLine(info);
                
                //得到该网关ip的id
                string gateway_id = dataOp.GetOneStrTypeByName("gateway_id" , "gateway_t", "address", Ip.ToString());

                //根据电表号更新网关id
                //string newvalue = "set address = '" + Ip.ToString() + "' , port = " + Port;
                string newvalue = "set gateway_id = " + gateway_id;
                int rownum = dataOp.UpdateOneRow("COLLECTOR_T", newvalue, "node_num", info);

                if (rownum != 1) {

                    flag = false;
                    Console.WriteLine("UpdateGatewayOfNode ERROR , ROW NUM AFFECTED IS NOT 1!");
                }

                
            }

            dataOp.Close();
            return flag;

            
        
        }


        /**
         * 
         * 处理单个电表采集到的数据包
         * 更新历史数据表
         * 
         * */
        private bool UpdateHistoryOfInfo(string msg)
        {
            bool flag = true;
            DataOp dataOp = new DataOp(this.oracleip, this.oracleport, this.database, this.userid, this.password);

            //node_ number | VOLTAGE | CURRANT | POWERS
            string[] infos = dataGetter.getInfo(msg);

            //根据电表号插入历史信息
            //获取最大索引，
            int nextid = dataOp.GetMaxId("HISTORY_T", "ID") + 1;

            ;
            //插入数据
            string value = nextid + ",1, " + infos[1] + "," + infos[2] + ", " +
                infos[3] + ",sysdate,'" + infos[0] +"'";

            int rownum = dataOp.InsertOneRow("HISTORY_T", value);
            
            if (rownum != 1)
            {
                flag = false;            
            
            }

            dataOp.Close();
            return flag;
        }




        private void F_Server_FormClosed(object sender, FormClosedEventArgs e)
        {
           

        }

        private void udpSocket1_DataArrival(byte[] Data, IPAddress Ip, int Port)
        {
            DataArrivaldelegate outdelegate = new DataArrivaldelegate(DataEvent);
            this.BeginInvoke(outdelegate, new object[] { Data, Ip, Port }); 

        }

        private void DataEvent(byte[] Data, System.Net.IPAddress Ip, int Port)
        {
            //MessageBox.Show(Encoding.Unicode.GetString(Data));
            //this.Text = Encoding.Unicode.GetString(Data);
            //MessageBox.Show(this.Text);
        }



        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            //System.Environment.Exit(0);//完全退出该进程
            this.Close();

        }

        

        private void 配置ToolStripMenuItem_Click(object sender, EventArgs e)
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
                MessageBox.Show("退出配置");
                //Application.Exit();
            }
        }

        //标记窗体当前是否被隐藏
        bool isHideFlag = true;
        private void 隐藏窗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            isHideFlag = false;
        }


        //重写热键注册消息循环F10
        //构造方法处注册，此处重写按键触发函数
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            // m.WParam.ToInt32() 要和 注册热键时的第2个参数一样
            if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == 247696411) //判断热键
            {
                if (isHideFlag == true)
                {
                    this.Hide();
                    isHideFlag = false;
                }
                else
                {
                    this.Show();
                    isHideFlag = true;
                
                }
            }
            base.WndProc(ref m);
        }


        /**
         * 
         * 网关心跳线程
         * 
         * 
         * 
         * */
        private void heartBeat_Tick(object sender, EventArgs e)
        {

            DataOp dataOp = new DataOp(this.oracleip, this.oracleport, this.database, this.userid, this.password);

            //查询数据库中已注册的网关信息，找到其ip与端口，发送心跳包
            OleDbDataReader data = dataOp.GetAllRowByTable("GATEWAY_T");
            //遍历data,向网关发送心跳包
            try { 
            
            
                while (data.Read()) {

                    string ip = data[2].ToString();
                    string port = data[3].ToString();
                    string msg = Conmmend.HEART_BEAT;//心跳协议

                    byte[] Msg = Encoding.UTF8.GetBytes(msg);

                    System.Net.IPAddress Ip = System.Net.IPAddress.Parse(ip);
                    int Port = int.Parse(port);

                    //Console.WriteLine("send to ip:" + ip + " port: " + port + " " + msg);
                    UDPSocket_serv.Send(Ip, Port, Msg);

                    try { 
                    
                        //heartBeatResCounts.TryGetValue(ip,out count);
                        int nowCount = heartBeatResCounts[ip]["SendTimes"]++;//该ip节点，发送次数加1；

                        if (nowCount >= 5)
                        {
                            if (heartBeatResCounts[ip]["RecvFlag"] == 1)
                            {

                                //节点活着呢，修改状态
                                string newvalue = "set state = 'Active' ";
                                int rownum = dataOp.UpdateOneRow("GATEWAY_T", newvalue, "ADDRESS", ip);

                                if (rownum != 1)
                                {

                                    Console.WriteLine("UpdateOneRow gateway states update error");
                                }

                            }
                            else
                            { 
                            
                                //节点已死，修改状态
                                string newvalue = "set state = 'Dead' ";
                                int rownum = dataOp.UpdateOneRow("GATEWAY_T", newvalue, "ADDRESS", ip);

                                if (rownum != 1)
                                {

                                    Console.WriteLine("UpdateOneRow gateway states update error");
                                }
                            }
                            heartBeatResCounts[ip]["RecvFlag"] = 0;//修改标识，进入下一轮
                            heartBeatResCounts[ip]["SendTimes"] = 1;//重新计数
                        }
                        
                        
                    }
                    catch(KeyNotFoundException ex1){//注意捕获异常顺序,如果第一次无此键， 则初始化

                        Console.WriteLine("ex1 : " + ex1.Message);

                        Dictionary<string, int> beatRes = new Dictionary<string, int>();
                        beatRes["SendTimes"] = 1;
                        beatRes["RecvFlag"] = 0;
                        heartBeatResCounts[ip] = beatRes;//初始化发送次数
              
                    }
                       
                }
            }
            catch(Exception ex){


                Console.WriteLine("ex : " + ex.Message);
            }

            dataOp.Close();

        }



        private void updateInfo_Tick(object sender, EventArgs e)
        {



        }

        /**
         * 
         * 所有电表信息查询线程
         * 查询所有电表信息，并更新数据库
         * 
         * */
        private void updateAllInfo_Tick(object sender, EventArgs e)
        {
            //byte[] Response = System.Text.Encoding.Default.GetBytes(Conmmend.GET_ALL_COLLECTER_INFO);//响应登录
            
            
            //获取所有网关ip与端口号
            DataOp dataOp = new DataOp(this.oracleip, this.oracleport, this.database, this.userid, this.password);

            //查询数据库中已注册的网关信息，找到其ip与端口，
            OleDbDataReader data = dataOp.GetAllRowByTable("GATEWAY_T");
            //遍历data,向网关发送数据包
            try
            {

                while (data.Read())
                {

                    string ip = data[2].ToString();
                    string port = data[3].ToString();
                    string msg = Conmmend.GET_ALL_COLLECTER_INFO;//查询所有电表信息

                    byte[] Msg = Encoding.UTF8.GetBytes(msg);

                    System.Net.IPAddress Ip = System.Net.IPAddress.Parse(ip);
                    int Port = int.Parse(port);

                    //Console.WriteLine("send to ip:" + ip + " port: " + port + " " + msg);
                    UDPSocket_serv.Send(Ip, Port, Msg);

                }
            }
            catch (Exception ex)
            {


                Console.WriteLine("ex : " + ex.Message);
            }

            dataOp.Close();

        }



        private void Load_BuildingInfo() 
        {
        
            //读大楼数据库表building_t
            DataOp dataOp = new DataOp(this.oracleip, this.oracleport, this.database, this.userid, this.password);

            //得到大楼名称（默认不重复）
            OleDbDataReader data = dataOp.GetAllRowByTable("BUILDING_T");

            //清空选项列表
            building.Items.Clear();
            //添加到下拉选项表
            while (data.Read())
            {
                string building_name = data[1].ToString();
                building.Items.Add(building_name);
            }

            dataOp.Close();
            
        }




        /**
         * 
         * 大楼选择，改变房间下拉
         * 
         * 
         * 
         * 
         * */
        private void building_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataOp dataOp = new DataOp(this.oracleip, this.oracleport, this.database, this.userid, this.password);
            
            //获取大楼名
            string building_name = building.Text;

            //获取大楼id
            string building_id = dataOp.GetOneStrTypeByName("BUILDING_ID", "BUILDING_T", "BUILDING_NAME", building_name);

            //根据大楼id查询大楼里的房间
            OleDbDataReader data = dataOp.GetRowByIndex("ROOM_T", "BUILDING_ID", building_id);

            //更新房间下拉列表值
            room.Items.Clear();
            while (data.Read())
            {

                string room_name = data[1].ToString();
                room.Items.Add(room_name);
            }

            dataOp.Close();
        }

        /**
         * 
         * 查询按钮触发事件
         * 
         * 
         * 
         * 
         * */
        private void search_Click(object sender, EventArgs e)
        {
            //根据选项查询一条完整记录并显示，更新列表
            DataOp dataOp = new DataOp(this.oracleip, this.oracleport, this.database, this.userid, this.password);

            //得到大楼号
            string building_name = building.Text;
            string building_id = dataOp.GetOneStrTypeByName("BUILDING_ID", "BUILDING_T", "BUILDING_NAME", building_name);


            //得到房间号
            string room_name = room.Text;
            string room_id = dataOp.GetOneStrTypeByName("ROOM_ID", "ROOM_T", "ROOM_NAME", room_name);

            //得到选择查询的电表状态
            string collect_state = collectState.Text;


            //根据大楼和房间号查询电表信息
            string sql = null;


            //判断楼号与房间号是否为空,以及电表状态，生成合适的sql语句
            if (building_id == null || room_id == null)
            {

                if (building_id == null && room_id == null)
                {
                    if (collect_state == "")
                    {


                        sql = "select * from COLLECTOR_T";
                    }
                    else
                    {

                        sql = "select * from COLLECTOR_T where STATE = '" + collect_state + "'";
                    }



                }
                else if (building_id != null)
                {
                    if (collect_state == "")
                    {


                        sql = "select * from COLLECTOR_T where BUILDING_ID = " + building_id;
                    }
                    else
                    {

                        sql = "select * from COLLECTOR_T where BUILDING_ID = " + building_id + " and STATE = '" + collect_state + "'";
                    }


                }
                else 
                {
                    if (collect_state == "")
                    {


                        sql = "select * from COLLECTOR_T where ROOM_ID = " + room_id;
                    }
                    else
                    {

                        sql = "select * from COLLECTOR_T where ROOM_ID = " + room_id + " and STATE = '" + collect_state + "'";
                    }
                

                
                }

                

            }
            else
            {
                if (collect_state == "")
                {


                    sql = "select * from COLLECTOR_T where BUILDING_ID = " + building_id + " and ROOM_ID = " + room_id;
                }
                else
                {

                    sql = "select * from COLLECTOR_T where BUILDING_ID = " + building_id + " and ROOM_ID = " + room_id +
                        " and STATE = '" + collect_state+"'";
                }
                
            
            }


            //根据sql语句查询电表信息
            OleDbDataReader data = dataOp.GetRowsBySql(sql);

            List<Collection_t> dataList = new List<Collection_t>();//暂存数据库数据
            while (data.Read())
            {

                //Dictionary<String, String> dataListHash = new Dictionary<string,string>();
                Collection_t collection_t = new Collection_t(data[0].ToString(), data[1].ToString(),
                   data[2].ToString(), data[3].ToString(), data[4].ToString(), data[5].ToString(),
                   data[6].ToString(), data[7].ToString(), data[8].ToString(), data[9].ToString());


                //得到电表所属网关的ip地址
                OleDbDataReader data_gateway = dataOp.GetRowByIndex("GATEWAY_T", "GATEWAY_ID", collection_t.Gateway_id);

                ////根据网关id查ip地址与端口：
                while (data_gateway.Read())
                {
                    collection_t.Address = data_gateway[2].ToString();
                    collection_t.Port = data_gateway[3].ToString();
                    collection_t.Active_net = data_gateway[5].ToString();
                }


                dataList.Add(collection_t);

            }


            UpdateList(dataList);//更新显示界面列表

            //更新数据列表
            dataOp.Close();


        }


        /**
         * 
         * 根据电表数据模型列表更新，显示
         * 
         * 
         * 
         * */
        private void UpdateList(List<Collection_t> dataList)
        {
            SysUser.Items.Clear();
            SysUser.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度 


            //更新界面列表
            foreach (Collection_t collec_t in dataList)
            {

                ListViewItem lvi = new ListViewItem();
                int i = dataList.IndexOf(collec_t);

                lvi.ImageIndex = i;
                lvi.Text = i.ToString();

                lvi.SubItems.Add(collec_t.Address);
                lvi.SubItems.Add(collec_t.Port);
                //lvi.SubItems.Add(collec_t.Node_id);//电表序号
                lvi.SubItems.Add(collec_t.Node_num);//电表编号
                lvi.SubItems.Add(collec_t.Node_name);
                lvi.SubItems.Add(collec_t.Room_id);
                lvi.SubItems.Add(collec_t.Building_id);
                lvi.SubItems.Add(collec_t.State);
                lvi.SubItems.Add(collec_t.Active_net);

                SysUser.Items.Add(lvi);

            }

            SysUser.EndUpdate();  //结束数据处理，UI界面一次性绘制。
        
        }


        //关闭前询问
        private void F_Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认要关闭?", "提示 ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }





    }
}