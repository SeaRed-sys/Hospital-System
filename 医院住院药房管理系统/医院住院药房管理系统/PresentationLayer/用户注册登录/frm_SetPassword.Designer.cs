namespace 医院住院药房管理系统.用户注册登录
{
    partial class frm_SetPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_SetPassword));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.txb2 = new System.Windows.Forms.TextBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.txb_Password = new System.Windows.Forms.TextBox();
            this.btn_Sure = new System.Windows.Forms.Button();
            this.linkbtn_SearchPassword = new System.Windows.Forms.LinkLabel();
            this.linlbl_SignUp = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-7, -19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(592, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox5.BackColor = System.Drawing.Color.AliceBlue;
            this.pictureBox5.Location = new System.Drawing.Point(-7, 63);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(592, 31);
            this.pictureBox5.TabIndex = 7;
            this.pictureBox5.TabStop = false;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.BackColor = System.Drawing.Color.Snow;
            this.lbl1.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl1.Location = new System.Drawing.Point(101, 129);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(124, 28);
            this.lbl1.TabIndex = 10;
            this.lbl1.Text = "用户名：";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txb2
            // 
            this.txb2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txb2.Location = new System.Drawing.Point(231, 129);
            this.txb2.Name = "txb2";
            this.txb2.Size = new System.Drawing.Size(223, 31);
            this.txb2.TabIndex = 11;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.BackColor = System.Drawing.Color.Snow;
            this.lbl2.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl2.Location = new System.Drawing.Point(101, 166);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(124, 28);
            this.lbl2.TabIndex = 12;
            this.lbl2.Text = "密码：  ";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txb_Password
            // 
            this.txb_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_Password.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txb_Password.Location = new System.Drawing.Point(231, 166);
            this.txb_Password.Name = "txb_Password";
            this.txb_Password.Size = new System.Drawing.Size(223, 31);
            this.txb_Password.TabIndex = 13;
            // 
            // btn_Sure
            // 
            this.btn_Sure.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btn_Sure.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Sure.Location = new System.Drawing.Point(231, 200);
            this.btn_Sure.Name = "btn_Sure";
            this.btn_Sure.Size = new System.Drawing.Size(223, 39);
            this.btn_Sure.TabIndex = 25;
            this.btn_Sure.Text = "确认";
            this.btn_Sure.UseVisualStyleBackColor = false;
            this.btn_Sure.Click += new System.EventHandler(this.btn_Sure_Click);
            // 
            // linkbtn_SearchPassword
            // 
            this.linkbtn_SearchPassword.AutoSize = true;
            this.linkbtn_SearchPassword.LinkColor = System.Drawing.Color.SlateBlue;
            this.linkbtn_SearchPassword.Location = new System.Drawing.Point(423, 254);
            this.linkbtn_SearchPassword.Name = "linkbtn_SearchPassword";
            this.linkbtn_SearchPassword.Size = new System.Drawing.Size(80, 18);
            this.linkbtn_SearchPassword.TabIndex = 26;
            this.linkbtn_SearchPassword.TabStop = true;
            this.linkbtn_SearchPassword.Text = "返回登录";
            this.linkbtn_SearchPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkbtn_SearchPassword_LinkClicked);
            // 
            // linlbl_SignUp
            // 
            this.linlbl_SignUp.AutoSize = true;
            this.linlbl_SignUp.LinkColor = System.Drawing.Color.DarkGreen;
            this.linlbl_SignUp.Location = new System.Drawing.Point(509, 254);
            this.linlbl_SignUp.Name = "linlbl_SignUp";
            this.linlbl_SignUp.Size = new System.Drawing.Size(62, 18);
            this.linlbl_SignUp.TabIndex = 27;
            this.linlbl_SignUp.TabStop = true;
            this.linlbl_SignUp.Text = "去注册";
            this.linlbl_SignUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linlbl_SignUp_LinkClicked);
            // 
            // frm_SetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(583, 281);
            this.Controls.Add(this.linlbl_SignUp);
            this.Controls.Add(this.linkbtn_SearchPassword);
            this.Controls.Add(this.btn_Sure);
            this.Controls.Add(this.txb_Password);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.txb2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_SetPassword";
            this.Text = "仁和医院住院药房管理系统-忘记密码";
            this.Load += new System.EventHandler(this.frm_SetPassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.TextBox txb2;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.TextBox txb_Password;
        private System.Windows.Forms.Button btn_Sure;
        private System.Windows.Forms.LinkLabel linkbtn_SearchPassword;
        private System.Windows.Forms.LinkLabel linlbl_SignUp;
    }
}