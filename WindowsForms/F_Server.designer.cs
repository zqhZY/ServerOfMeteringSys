namespace WindowsForms
{
    partial class F_Server
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Server));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.控制台ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始服务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.隐藏窗体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.heartBeat = new System.Windows.Forms.Timer(this.components);
            this.SysUser = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.updateInfo = new System.Windows.Forms.Timer(this.components);
            this.updateAllInfo = new System.Windows.Forms.Timer(this.components);
            this.search = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.building = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.collectState = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.room = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.UDPSocket_serv = new WindowsForms.UDPSocket(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStrip1.BackgroundImage")));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.控制台ToolStripMenuItem,
            this.系统ToolStripMenuItem,
            this.用户ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(926, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 控制台ToolStripMenuItem
            // 
            this.控制台ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始服务ToolStripMenuItem,
            this.隐藏窗体ToolStripMenuItem});
            this.控制台ToolStripMenuItem.Name = "控制台ToolStripMenuItem";
            this.控制台ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.控制台ToolStripMenuItem.Text = "控制台";
            // 
            // 开始服务ToolStripMenuItem
            // 
            this.开始服务ToolStripMenuItem.Name = "开始服务ToolStripMenuItem";
            this.开始服务ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.开始服务ToolStripMenuItem.Text = "开始服务";
            this.开始服务ToolStripMenuItem.Click += new System.EventHandler(this.Tool_Open);
            // 
            // 隐藏窗体ToolStripMenuItem
            // 
            this.隐藏窗体ToolStripMenuItem.Name = "隐藏窗体ToolStripMenuItem";
            this.隐藏窗体ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.隐藏窗体ToolStripMenuItem.Text = "隐藏窗体(F11)";
            this.隐藏窗体ToolStripMenuItem.Click += new System.EventHandler(this.隐藏窗体ToolStripMenuItem_Click);
            // 
            // 系统ToolStripMenuItem
            // 
            this.系统ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem,
            this.配置ToolStripMenuItem});
            this.系统ToolStripMenuItem.Name = "系统ToolStripMenuItem";
            this.系统ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.系统ToolStripMenuItem.Text = "系统";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 配置ToolStripMenuItem
            // 
            this.配置ToolStripMenuItem.Name = "配置ToolStripMenuItem";
            this.配置ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.配置ToolStripMenuItem.Text = "配置";
            this.配置ToolStripMenuItem.Click += new System.EventHandler(this.配置ToolStripMenuItem_Click);
            // 
            // 用户ToolStripMenuItem
            // 
            this.用户ToolStripMenuItem.Name = "用户ToolStripMenuItem";
            this.用户ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.用户ToolStripMenuItem.Text = "用户";
            // 
            // heartBeat
            // 
            this.heartBeat.Interval = 1000;
            this.heartBeat.Tick += new System.EventHandler(this.heartBeat_Tick);
            // 
            // SysUser
            // 
            this.SysUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.SysUser.FullRowSelect = true;
            this.SysUser.GridLines = true;
            this.SysUser.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.SysUser.Location = new System.Drawing.Point(0, 46);
            this.SysUser.Name = "SysUser";
            this.SysUser.Size = new System.Drawing.Size(890, 450);
            this.SysUser.TabIndex = 15;
            this.SysUser.UseCompatibleStateImageBehavior = false;
            this.SysUser.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "";
            this.columnHeader2.Width = 123;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "";
            this.columnHeader3.Width = 107;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "";
            this.columnHeader4.Width = 109;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "";
            this.columnHeader5.Width = 116;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "";
            this.columnHeader6.Width = 82;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "";
            this.columnHeader7.Width = 85;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "";
            this.columnHeader8.Width = 92;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "";
            this.columnHeader9.Width = 91;
            // 
            // updateInfo
            // 
            this.updateInfo.Tick += new System.EventHandler(this.updateInfo_Tick);
            // 
            // updateAllInfo
            // 
            this.updateAllInfo.Tick += new System.EventHandler(this.updateAllInfo_Tick);
            // 
            // search
            // 
            this.search.BackColor = System.Drawing.Color.LightGray;
            this.search.Location = new System.Drawing.Point(820, 0);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(37, 25);
            this.search.TabIndex = 16;
            this.search.Text = "查询";
            this.search.UseVisualStyleBackColor = false;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(447, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "电表状态";
            // 
            // building
            // 
            this.building.FormattingEnabled = true;
            this.building.Location = new System.Drawing.Point(609, 3);
            this.building.Name = "building";
            this.building.Size = new System.Drawing.Size(101, 20);
            this.building.TabIndex = 20;
            this.building.SelectedIndexChanged += new System.EventHandler(this.building_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(574, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "楼栋";
            // 
            // collectState
            // 
            this.collectState.FormattingEnabled = true;
            this.collectState.Items.AddRange(new object[] {
            "Active",
            "Dead"});
            this.collectState.Location = new System.Drawing.Point(506, 3);
            this.collectState.Name = "collectState";
            this.collectState.Size = new System.Drawing.Size(62, 20);
            this.collectState.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LightGray;
            this.label4.Location = new System.Drawing.Point(716, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 23;
            this.label4.Text = "房间";
            // 
            // room
            // 
            this.room.FormattingEnabled = true;
            this.room.Location = new System.Drawing.Point(751, 3);
            this.room.Name = "room";
            this.room.Size = new System.Drawing.Size(63, 20);
            this.room.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(12, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 25;
            this.label5.Text = "ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(84, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 26;
            this.label6.Text = "IP地址";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(804, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 28;
            this.label8.Text = "网关状态";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(707, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 29;
            this.label9.Text = "电表状态";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(627, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 30;
            this.label10.Text = "大楼";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(541, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 31;
            this.label11.Text = "房间";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(421, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 32;
            this.label12.Text = "电表项";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(320, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 33;
            this.label13.Text = "电表";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(212, 31);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 34;
            this.label14.Text = "端口";
            // 
            // UDPSocket_serv
            // 
            this.UDPSocket_serv.Active = false;
            this.UDPSocket_serv.LocalHost = "127.0.0.1";
            this.UDPSocket_serv.LocalPort = 11000;
            this.UDPSocket_serv.DataArrival += new WindowsForms.UDPSocket.DataArrivalEventHandler(this.sockUDP1_DataArrival);
            // 
            // F_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(926, 508);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.room);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.collectState);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.building);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.search);
            this.Controls.Add(this.SysUser);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "F_Server";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "电表计量系统管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.F_Server_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.F_Server_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 控制台ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开始服务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Timer heartBeat;
        private WindowsForms.UDPSocket UDPSocket_serv;
        private System.Windows.Forms.ToolStripMenuItem 配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 隐藏窗体ToolStripMenuItem;
        private System.Windows.Forms.Timer updateInfo;
        internal System.Windows.Forms.ListView SysUser;
        private System.Windows.Forms.Timer updateAllInfo;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox building;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox collectState;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox room;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ToolStripMenuItem 用户ToolStripMenuItem;
    }
}

