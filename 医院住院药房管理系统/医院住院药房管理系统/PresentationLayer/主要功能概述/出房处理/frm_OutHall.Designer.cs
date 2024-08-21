namespace 医院住院药房管理系统.主要功能概述.出房处理
{
    partial class frm_OutHall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_OutHall));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Select = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.dtp_TakeTime = new System.Windows.Forms.DateTimePicker();
            this.chb_Standard = new System.Windows.Forms.CheckBox();
            this.chb_Print = new System.Windows.Forms.CheckBox();
            this.cb_Hall = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_Late = new System.Windows.Forms.Button();
            this.btn_Pre = new System.Windows.Forms.Button();
            this.dgv_Medicine = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_Late1 = new System.Windows.Forms.Button();
            this.btn_Pre1 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_Sure = new System.Windows.Forms.Button();
            this.txb_Count = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_SickMan = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_Medicine = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv_MedicineDe = new System.Windows.Forms.DataGridView();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Enter = new System.Windows.Forms.Button();
            this.btn_Back = new System.Windows.Forms.Button();
            this.dtp_Time = new System.Windows.Forms.DateTimePicker();
            this.cb_Nurse = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Medicine)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MedicineDe)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Ivory;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(43, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1273, 85);
            this.panel1.TabIndex = 8;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.BackColor = System.Drawing.Color.Ivory;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(133, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(91, 76);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pictureBox1.BackColor = System.Drawing.Color.Ivory;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(140, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(974, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel2.Controls.Add(this.btn_Select);
            this.panel2.Controls.Add(this.btn_close);
            this.panel2.Controls.Add(this.dtp_TakeTime);
            this.panel2.Controls.Add(this.chb_Standard);
            this.panel2.Controls.Add(this.chb_Print);
            this.panel2.Controls.Add(this.cb_Hall);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(38, 170);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1247, 90);
            this.panel2.TabIndex = 9;
            // 
            // btn_Select
            // 
            this.btn_Select.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Select.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_Select.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Select.Location = new System.Drawing.Point(1112, 5);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(118, 42);
            this.btn_Select.TabIndex = 23;
            this.btn_Select.Text = "查询";
            this.btn_Select.UseVisualStyleBackColor = false;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_close.BackgroundImage")));
            this.btn_close.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_close.Location = new System.Drawing.Point(1114, 45);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(116, 42);
            this.btn_close.TabIndex = 22;
            this.btn_close.Text = "关闭";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // dtp_TakeTime
            // 
            this.dtp_TakeTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_TakeTime.Location = new System.Drawing.Point(457, 9);
            this.dtp_TakeTime.Name = "dtp_TakeTime";
            this.dtp_TakeTime.Size = new System.Drawing.Size(200, 31);
            this.dtp_TakeTime.TabIndex = 5;
            // 
            // chb_Standard
            // 
            this.chb_Standard.AutoSize = true;
            this.chb_Standard.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chb_Standard.Location = new System.Drawing.Point(268, 55);
            this.chb_Standard.Name = "chb_Standard";
            this.chb_Standard.Size = new System.Drawing.Size(78, 25);
            this.chb_Standard.TabIndex = 4;
            this.chb_Standard.Text = "剂型";
            this.chb_Standard.UseVisualStyleBackColor = true;
            // 
            // chb_Print
            // 
            this.chb_Print.AutoSize = true;
            this.chb_Print.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chb_Print.Location = new System.Drawing.Point(268, 13);
            this.chb_Print.Name = "chb_Print";
            this.chb_Print.Size = new System.Drawing.Size(183, 25);
            this.chb_Print.TabIndex = 3;
            this.chb_Print.Text = "领药单打印时间";
            this.chb_Print.UseVisualStyleBackColor = true;
            // 
            // cb_Hall
            // 
            this.cb_Hall.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cb_Hall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cb_Hall.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_Hall.FormattingEnabled = true;
            this.cb_Hall.Location = new System.Drawing.Point(83, 9);
            this.cb_Hall.Name = "cb_Hall";
            this.cb_Hall.Size = new System.Drawing.Size(155, 29);
            this.cb_Hall.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "病区:";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(38, 266);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1247, 326);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tabPage1.Controls.Add(this.btn_Late);
            this.tabPage1.Controls.Add(this.btn_Pre);
            this.tabPage1.Controls.Add(this.dgv_Medicine);
            this.tabPage1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1239, 294);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "药品累计总数";
            // 
            // btn_Late
            // 
            this.btn_Late.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Late.BackColor = System.Drawing.Color.NavajoWhite;
            this.btn_Late.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Late.Image = ((System.Drawing.Image)(resources.GetObject("btn_Late.Image")));
            this.btn_Late.Location = new System.Drawing.Point(1129, 220);
            this.btn_Late.Name = "btn_Late";
            this.btn_Late.Size = new System.Drawing.Size(82, 46);
            this.btn_Late.TabIndex = 69;
            this.btn_Late.Text = ">>";
            this.btn_Late.UseVisualStyleBackColor = false;
            this.btn_Late.Click += new System.EventHandler(this.btn_Late_Click);
            // 
            // btn_Pre
            // 
            this.btn_Pre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Pre.BackColor = System.Drawing.Color.NavajoWhite;
            this.btn_Pre.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Pre.Image = ((System.Drawing.Image)(resources.GetObject("btn_Pre.Image")));
            this.btn_Pre.Location = new System.Drawing.Point(1039, 220);
            this.btn_Pre.Name = "btn_Pre";
            this.btn_Pre.Size = new System.Drawing.Size(84, 46);
            this.btn_Pre.TabIndex = 68;
            this.btn_Pre.Text = "<<";
            this.btn_Pre.UseVisualStyleBackColor = false;
            this.btn_Pre.Click += new System.EventHandler(this.btn_Pre_Click);
            // 
            // dgv_Medicine
            // 
            this.dgv_Medicine.AllowUserToAddRows = false;
            this.dgv_Medicine.AllowUserToDeleteRows = false;
            this.dgv_Medicine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Medicine.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Medicine.BackgroundColor = System.Drawing.Color.MintCream;
            this.dgv_Medicine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Medicine.Location = new System.Drawing.Point(13, 19);
            this.dgv_Medicine.Name = "dgv_Medicine";
            this.dgv_Medicine.ReadOnly = true;
            this.dgv_Medicine.RowHeadersWidth = 62;
            this.dgv_Medicine.RowTemplate.Height = 30;
            this.dgv_Medicine.Size = new System.Drawing.Size(1213, 256);
            this.dgv_Medicine.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tabPage2.Controls.Add(this.btn_Late1);
            this.tabPage2.Controls.Add(this.btn_Pre1);
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Controls.Add(this.dgv_MedicineDe);
            this.tabPage2.Controls.Add(this.treeView1);
            this.tabPage2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1239, 294);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "病人药品明细";
            // 
            // btn_Late1
            // 
            this.btn_Late1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Late1.BackColor = System.Drawing.Color.NavajoWhite;
            this.btn_Late1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Late1.Image = ((System.Drawing.Image)(resources.GetObject("btn_Late1.Image")));
            this.btn_Late1.Location = new System.Drawing.Point(1129, 238);
            this.btn_Late1.Name = "btn_Late1";
            this.btn_Late1.Size = new System.Drawing.Size(82, 46);
            this.btn_Late1.TabIndex = 70;
            this.btn_Late1.Text = ">>";
            this.btn_Late1.UseVisualStyleBackColor = false;
            this.btn_Late1.Click += new System.EventHandler(this.btn_Late1_Click);
            // 
            // btn_Pre1
            // 
            this.btn_Pre1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Pre1.BackColor = System.Drawing.Color.NavajoWhite;
            this.btn_Pre1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Pre1.Image = ((System.Drawing.Image)(resources.GetObject("btn_Pre1.Image")));
            this.btn_Pre1.Location = new System.Drawing.Point(1039, 238);
            this.btn_Pre1.Name = "btn_Pre1";
            this.btn_Pre1.Size = new System.Drawing.Size(84, 46);
            this.btn_Pre1.TabIndex = 69;
            this.btn_Pre1.Text = "<<";
            this.btn_Pre1.UseVisualStyleBackColor = false;
            this.btn_Pre1.Click += new System.EventHandler(this.btn_Pre1_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btn_Sure);
            this.panel4.Controls.Add(this.txb_Count);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.lbl_SickMan);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.lbl_Medicine);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(231, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(251, 282);
            this.panel4.TabIndex = 3;
            // 
            // btn_Sure
            // 
            this.btn_Sure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Sure.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_Sure.Location = new System.Drawing.Point(151, 235);
            this.btn_Sure.Name = "btn_Sure";
            this.btn_Sure.Size = new System.Drawing.Size(95, 42);
            this.btn_Sure.TabIndex = 27;
            this.btn_Sure.Text = "确定";
            this.btn_Sure.UseVisualStyleBackColor = false;
            this.btn_Sure.Click += new System.EventHandler(this.btn_Sure_Click);
            // 
            // txb_Count
            // 
            this.txb_Count.Location = new System.Drawing.Point(103, 99);
            this.txb_Count.Name = "txb_Count";
            this.txb_Count.Size = new System.Drawing.Size(100, 31);
            this.txb_Count.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 21);
            this.label7.TabIndex = 5;
            this.label7.Text = "药品量:";
            // 
            // lbl_SickMan
            // 
            this.lbl_SickMan.AutoSize = true;
            this.lbl_SickMan.Location = new System.Drawing.Point(100, 60);
            this.lbl_SickMan.Name = "lbl_SickMan";
            this.lbl_SickMan.Size = new System.Drawing.Size(0, 21);
            this.lbl_SickMan.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 21);
            this.label6.TabIndex = 3;
            this.label6.Text = "病人姓名:";
            // 
            // lbl_Medicine
            // 
            this.lbl_Medicine.AutoSize = true;
            this.lbl_Medicine.Location = new System.Drawing.Point(100, 16);
            this.lbl_Medicine.Name = "lbl_Medicine";
            this.lbl_Medicine.Size = new System.Drawing.Size(0, 21);
            this.lbl_Medicine.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 21);
            this.label5.TabIndex = 1;
            this.label5.Text = "药品名称:";
            // 
            // dgv_MedicineDe
            // 
            this.dgv_MedicineDe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_MedicineDe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_MedicineDe.BackgroundColor = System.Drawing.Color.MintCream;
            this.dgv_MedicineDe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_MedicineDe.Location = new System.Drawing.Point(488, 6);
            this.dgv_MedicineDe.Name = "dgv_MedicineDe";
            this.dgv_MedicineDe.ReadOnly = true;
            this.dgv_MedicineDe.RowHeadersWidth = 62;
            this.dgv_MedicineDe.RowTemplate.Height = 30;
            this.dgv_MedicineDe.Size = new System.Drawing.Size(738, 282);
            this.dgv_MedicineDe.TabIndex = 2;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.Location = new System.Drawing.Point(6, 6);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(219, 282);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.btn_Enter);
            this.panel3.Controls.Add(this.btn_Back);
            this.panel3.Controls.Add(this.dtp_Time);
            this.panel3.Controls.Add(this.cb_Nurse);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(38, 598);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1247, 57);
            this.panel3.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lavender;
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(708, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 42);
            this.button1.TabIndex = 25;
            this.button1.Text = "显示出药清单";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(290, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 21);
            this.label3.TabIndex = 24;
            this.label3.Text = "出房时间:";
            // 
            // btn_Enter
            // 
            this.btn_Enter.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_Enter.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Enter.Location = new System.Drawing.Point(607, 6);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(95, 42);
            this.btn_Enter.TabIndex = 23;
            this.btn_Enter.Text = "出房";
            this.btn_Enter.UseVisualStyleBackColor = false;
            this.btn_Enter.Click += new System.EventHandler(this.btn_Enter_Click);
            // 
            // btn_Back
            // 
            this.btn_Back.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Back.BackgroundImage")));
            this.btn_Back.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Back.Location = new System.Drawing.Point(884, 6);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(95, 42);
            this.btn_Back.TabIndex = 22;
            this.btn_Back.Text = "返回";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // dtp_Time
            // 
            this.dtp_Time.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtp_Time.Location = new System.Drawing.Point(401, 10);
            this.dtp_Time.Name = "dtp_Time";
            this.dtp_Time.Size = new System.Drawing.Size(200, 31);
            this.dtp_Time.TabIndex = 5;
            // 
            // cb_Nurse
            // 
            this.cb_Nurse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cb_Nurse.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_Nurse.FormattingEnabled = true;
            this.cb_Nurse.Location = new System.Drawing.Point(117, 14);
            this.cb_Nurse.Name = "cb_Nurse";
            this.cb_Nurse.Size = new System.Drawing.Size(155, 29);
            this.cb_Nurse.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "领药护士:";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox5.BackColor = System.Drawing.Color.LightBlue;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(-135, 107);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(1622, 48);
            this.pictureBox5.TabIndex = 24;
            this.pictureBox5.TabStop = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.MintCream;
            this.label4.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(882, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 28);
            this.label4.TabIndex = 25;
            this.label4.Text = "药品出房";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frm_OutHall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1316, 667);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_OutHall";
            this.Text = "仁和医院住院药房管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_OutHall_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Medicine)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_MedicineDe)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtp_TakeTime;
        private System.Windows.Forms.CheckBox chb_Standard;
        private System.Windows.Forms.CheckBox chb_Print;
        private System.Windows.Forms.ComboBox cb_Hall;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Enter;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.DateTimePicker dtp_Time;
        private System.Windows.Forms.ComboBox cb_Nurse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.DataGridView dgv_Medicine;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridView dgv_MedicineDe;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbl_Medicine;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_SickMan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txb_Count;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_Sure;
        private System.Windows.Forms.Button btn_Pre;
        private System.Windows.Forms.Button btn_Late;
        private System.Windows.Forms.Button btn_Late1;
        private System.Windows.Forms.Button btn_Pre1;
    }
}