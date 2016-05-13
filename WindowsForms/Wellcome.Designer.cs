namespace WindowsForms
{
    partial class Wellcome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Wellcome));
            this.userName = new System.Windows.Forms.TextBox();
            this.passWord = new System.Windows.Forms.TextBox();
            this.login = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.reset = new System.Windows.Forms.Button();
            this.config = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(461, 298);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(157, 21);
            this.userName.TabIndex = 0;
            this.userName.TextChanged += new System.EventHandler(this.userName_TextChanged);
            // 
            // passWord
            // 
            this.passWord.Location = new System.Drawing.Point(461, 337);
            this.passWord.Name = "passWord";
            this.passWord.PasswordChar = '*';
            this.passWord.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.passWord.Size = new System.Drawing.Size(157, 21);
            this.passWord.TabIndex = 1;
            // 
            // login
            // 
            this.login.BackColor = System.Drawing.Color.Transparent;
            this.login.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("login.BackgroundImage")));
            this.login.FlatAppearance.BorderSize = 0;
            this.login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.login.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.login.Location = new System.Drawing.Point(418, 409);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(84, 23);
            this.login.TabIndex = 2;
            this.login.Text = "登录";
            this.login.UseVisualStyleBackColor = false;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(395, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 128);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("华文行楷", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(7, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "电表管理系统";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(518, 462);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "张庆恒   南京工程学院";
            // 
            // reset
            // 
            this.reset.BackColor = System.Drawing.Color.Transparent;
            this.reset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("reset.BackgroundImage")));
            this.reset.FlatAppearance.BorderSize = 0;
            this.reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reset.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.reset.Location = new System.Drawing.Point(534, 409);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(84, 23);
            this.reset.TabIndex = 7;
            this.reset.Text = "重置";
            this.reset.UseVisualStyleBackColor = false;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // config
            // 
            this.config.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("config.BackgroundImage")));
            this.config.FlatAppearance.BorderSize = 0;
            this.config.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.config.Location = new System.Drawing.Point(655, 457);
            this.config.Name = "config";
            this.config.Size = new System.Drawing.Size(75, 23);
            this.config.TabIndex = 8;
            this.config.Text = ">>Config";
            this.config.UseVisualStyleBackColor = true;
            this.config.Click += new System.EventHandler(this.config_Click);
            // 
            // Wellcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(797, 572);
            this.Controls.Add(this.config);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.login);
            this.Controls.Add(this.passWord);
            this.Controls.Add(this.userName);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Wellcome";
            this.Text = "Wellcome";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.TextBox passWord;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button config;
    }
}