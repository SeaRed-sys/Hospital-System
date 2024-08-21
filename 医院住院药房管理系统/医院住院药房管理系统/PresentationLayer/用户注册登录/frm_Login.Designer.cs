namespace 医院住院药房管理系统
{
    partial class frm_Login
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Login));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.lblNo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_No = new System.Windows.Forms.TextBox();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.btn_Login = new System.Windows.Forms.Button();
            this.linlbl_SignUp = new System.Windows.Forms.LinkLabel();
            this.linkbtn_SearchPassword = new System.Windows.Forms.LinkLabel();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ckb_LooPassword = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdb_UserType = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, -9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(592, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox5.BackColor = System.Drawing.Color.AliceBlue;
            this.pictureBox5.Location = new System.Drawing.Point(0, 71);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(680, 31);
            this.pictureBox5.TabIndex = 5;
            this.pictureBox5.TabStop = false;
            // 
            // lblNo
            // 
            this.lblNo.AutoSize = true;
            this.lblNo.BackColor = System.Drawing.Color.AliceBlue;
            this.lblNo.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNo.Location = new System.Drawing.Point(106, 135);
            this.lblNo.Name = "lblNo";
            this.lblNo.Size = new System.Drawing.Size(152, 28);
            this.lblNo.TabIndex = 8;
            this.lblNo.Text = "  用户名：";
            this.lblNo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.AliceBlue;
            this.label8.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(106, 178);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(152, 28);
            this.label8.TabIndex = 9;
            this.label8.Text = "    密码：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_No
            // 
            this.txt_No.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_No.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_No.Location = new System.Drawing.Point(280, 132);
            this.txt_No.Name = "txt_No";
            this.txt_No.Size = new System.Drawing.Size(223, 31);
            this.txt_No.TabIndex = 10;
            // 
            // txt_Password
            // 
            this.txt_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Password.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Password.Location = new System.Drawing.Point(280, 177);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.Size = new System.Drawing.Size(223, 31);
            this.txt_Password.TabIndex = 11;
            // 
            // btn_Login
            // 
            this.btn_Login.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_Login.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Login.Location = new System.Drawing.Point(280, 267);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(223, 39);
            this.btn_Login.TabIndex = 5;
            this.btn_Login.Text = "登录";
            this.btn_Login.UseVisualStyleBackColor = false;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // linlbl_SignUp
            // 
            this.linlbl_SignUp.AutoSize = true;
            this.linlbl_SignUp.BackColor = System.Drawing.Color.Transparent;
            this.linlbl_SignUp.LinkColor = System.Drawing.Color.DarkGreen;
            this.linlbl_SignUp.Location = new System.Drawing.Point(594, 316);
            this.linlbl_SignUp.Name = "linlbl_SignUp";
            this.linlbl_SignUp.Size = new System.Drawing.Size(62, 18);
            this.linlbl_SignUp.TabIndex = 20;
            this.linlbl_SignUp.TabStop = true;
            this.linlbl_SignUp.Text = "去注册";
            this.linlbl_SignUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linlbl_SignUp_LinkClicked);
            // 
            // linkbtn_SearchPassword
            // 
            this.linkbtn_SearchPassword.AutoSize = true;
            this.linkbtn_SearchPassword.BackColor = System.Drawing.Color.Transparent;
            this.linkbtn_SearchPassword.LinkColor = System.Drawing.Color.SlateBlue;
            this.linkbtn_SearchPassword.Location = new System.Drawing.Point(508, 316);
            this.linkbtn_SearchPassword.Name = "linkbtn_SearchPassword";
            this.linkbtn_SearchPassword.Size = new System.Drawing.Size(80, 18);
            this.linkbtn_SearchPassword.TabIndex = 21;
            this.linkbtn_SearchPassword.TabStop = true;
            this.linkbtn_SearchPassword.Text = "忘记密码";
            this.linkbtn_SearchPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkbtn_SearchPassword_LinkClicked);
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            this.ErrorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("ErrorProvider.Icon")));
            // 
            // ckb_LooPassword
            // 
            this.ckb_LooPassword.AutoSize = true;
            this.ckb_LooPassword.BackColor = System.Drawing.Color.Transparent;
            this.ckb_LooPassword.Location = new System.Drawing.Point(511, 186);
            this.ckb_LooPassword.Name = "ckb_LooPassword";
            this.ckb_LooPassword.Size = new System.Drawing.Size(106, 22);
            this.ckb_LooPassword.TabIndex = 22;
            this.ckb_LooPassword.Text = "显示密码";
            this.ckb_LooPassword.UseVisualStyleBackColor = false;
            this.ckb_LooPassword.CheckedChanged += new System.EventHandler(this.ckb_LooPassword_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.AliceBlue;
            this.label1.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(106, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 28);
            this.label1.TabIndex = 23;
            this.label1.Text = "用户类别：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // rdb_UserType
            // 
            this.rdb_UserType.AutoSize = true;
            this.rdb_UserType.BackColor = System.Drawing.Color.Transparent;
            this.rdb_UserType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdb_UserType.Location = new System.Drawing.Point(280, 226);
            this.rdb_UserType.Name = "rdb_UserType";
            this.rdb_UserType.Size = new System.Drawing.Size(98, 25);
            this.rdb_UserType.TabIndex = 3;
            this.rdb_UserType.TabStop = true;
            this.rdb_UserType.Text = "管理员";
            this.rdb_UserType.UseVisualStyleBackColor = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.Color.Transparent;
            this.radioButton1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton1.Location = new System.Drawing.Point(384, 226);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(119, 25);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "普通用户";
            this.radioButton1.UseVisualStyleBackColor = false;
            // 
            // frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(668, 338);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.rdb_UserType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ckb_LooPassword);
            this.Controls.Add(this.linkbtn_SearchPassword);
            this.Controls.Add(this.linlbl_SignUp);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.txt_No);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblNo);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_Login";
            this.Text = "仁和医院住院药房管理系统-登录";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label lblNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_No;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.LinkLabel linlbl_SignUp;
        private System.Windows.Forms.LinkLabel linkbtn_SearchPassword;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private System.Windows.Forms.CheckBox ckb_LooPassword;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton rdb_UserType;
        private System.Windows.Forms.Label label1;
    }
}

