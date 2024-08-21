namespace 医院住院药房管理系统.主要功能概述.入房处理
{
    partial class frm_EnterHall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_EnterHall));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lv_Medicine = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_SelcectRecord = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.dtp_Date = new System.Windows.Forms.DateTimePicker();
            this.label27 = new System.Windows.Forms.Label();
            this.btn_Sure = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txb_UseDate = new System.Windows.Forms.TextBox();
            this.cb_isQualified = new System.Windows.Forms.ComboBox();
            this.cb_isHaveQualified = new System.Windows.Forms.ComboBox();
            this.txb_LifeSpan = new System.Windows.Forms.TextBox();
            this.txb_EnterDate = new System.Windows.Forms.TextBox();
            this.txb_BatchDate = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txb_EnterCount = new System.Windows.Forms.TextBox();
            this.txb_Supplier = new System.Windows.Forms.TextBox();
            this.txb_BatchUnit = new System.Windows.Forms.TextBox();
            this.txb_LoginUnit = new System.Windows.Forms.TextBox();
            this.txb_ApprovalNumber = new System.Windows.Forms.TextBox();
            this.txb_BatchNo = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.btn_Late = new System.Windows.Forms.Button();
            this.btn_Pre = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1447, 85);
            this.panel1.TabIndex = 8;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.BackColor = System.Drawing.Color.Ivory;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(220, 13);
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
            this.pictureBox1.Location = new System.Drawing.Point(227, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(974, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // lv_Medicine
            // 
            this.lv_Medicine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_Medicine.BackColor = System.Drawing.Color.Snow;
            this.lv_Medicine.BackgroundImageTiled = true;
            this.lv_Medicine.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lv_Medicine.HideSelection = false;
            this.lv_Medicine.Location = new System.Drawing.Point(24, 180);
            this.lv_Medicine.Name = "lv_Medicine";
            this.lv_Medicine.Size = new System.Drawing.Size(1417, 485);
            this.lv_Medicine.TabIndex = 15;
            this.lv_Medicine.UseCompatibleStateImageBehavior = false;
            this.lv_Medicine.Click += new System.EventHandler(this.lv_Medicine_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.BackgroundImage")));
            this.groupBox1.Controls.Add(this.btn_SelcectRecord);
            this.groupBox1.Controls.Add(this.btn_Close);
            this.groupBox1.Controls.Add(this.dtp_Date);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.btn_Sure);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txb_UseDate);
            this.groupBox1.Controls.Add(this.cb_isQualified);
            this.groupBox1.Controls.Add(this.cb_isHaveQualified);
            this.groupBox1.Controls.Add(this.txb_LifeSpan);
            this.groupBox1.Controls.Add(this.txb_EnterDate);
            this.groupBox1.Controls.Add(this.txb_BatchDate);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.txb_EnterCount);
            this.groupBox1.Controls.Add(this.txb_Supplier);
            this.groupBox1.Controls.Add(this.txb_BatchUnit);
            this.groupBox1.Controls.Add(this.txb_LoginUnit);
            this.groupBox1.Controls.Add(this.txb_ApprovalNumber);
            this.groupBox1.Controls.Add(this.txb_BatchNo);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(24, 684);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1417, 262);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "药品基本信息";
            // 
            // btn_SelcectRecord
            // 
            this.btn_SelcectRecord.BackColor = System.Drawing.Color.NavajoWhite;
            this.btn_SelcectRecord.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SelcectRecord.Image = ((System.Drawing.Image)(resources.GetObject("btn_SelcectRecord.Image")));
            this.btn_SelcectRecord.Location = new System.Drawing.Point(891, 206);
            this.btn_SelcectRecord.Name = "btn_SelcectRecord";
            this.btn_SelcectRecord.Size = new System.Drawing.Size(208, 45);
            this.btn_SelcectRecord.TabIndex = 75;
            this.btn_SelcectRecord.Text = "入房记录查询";
            this.btn_SelcectRecord.UseVisualStyleBackColor = false;
            this.btn_SelcectRecord.Click += new System.EventHandler(this.btn_SelcectRecord_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.NavajoWhite;
            this.btn_Close.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Close.Image = ((System.Drawing.Image)(resources.GetObject("btn_Close.Image")));
            this.btn_Close.Location = new System.Drawing.Point(761, 206);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(124, 45);
            this.btn_Close.TabIndex = 74;
            this.btn_Close.Text = "关闭";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // dtp_Date
            // 
            this.dtp_Date.Location = new System.Drawing.Point(168, 208);
            this.dtp_Date.Name = "dtp_Date";
            this.dtp_Date.Size = new System.Drawing.Size(199, 35);
            this.dtp_Date.TabIndex = 70;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(32, 215);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(130, 24);
            this.label27.TabIndex = 71;
            this.label27.Text = "入房时间：";
            // 
            // btn_Sure
            // 
            this.btn_Sure.BackColor = System.Drawing.Color.NavajoWhite;
            this.btn_Sure.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Sure.Image = ((System.Drawing.Image)(resources.GetObject("btn_Sure.Image")));
            this.btn_Sure.Location = new System.Drawing.Point(631, 206);
            this.btn_Sure.Name = "btn_Sure";
            this.btn_Sure.Size = new System.Drawing.Size(124, 45);
            this.btn_Sure.TabIndex = 72;
            this.btn_Sure.Text = "确认";
            this.btn_Sure.UseVisualStyleBackColor = false;
            this.btn_Sure.Click += new System.EventHandler(this.btn_Sure_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(745, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 26);
            this.label8.TabIndex = 73;
            this.label8.Text = "  使用期：";
            // 
            // txb_UseDate
            // 
            this.txb_UseDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txb_UseDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txb_UseDate.Location = new System.Drawing.Point(891, 154);
            this.txb_UseDate.Name = "txb_UseDate";
            this.txb_UseDate.Size = new System.Drawing.Size(216, 31);
            this.txb_UseDate.TabIndex = 72;
            // 
            // cb_isQualified
            // 
            this.cb_isQualified.FormattingEnabled = true;
            this.cb_isQualified.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cb_isQualified.Location = new System.Drawing.Point(523, 157);
            this.cb_isQualified.Name = "cb_isQualified";
            this.cb_isQualified.Size = new System.Drawing.Size(199, 32);
            this.cb_isQualified.TabIndex = 71;
            this.cb_isQualified.Text = "-请选择-";
            // 
            // cb_isHaveQualified
            // 
            this.cb_isHaveQualified.FormattingEnabled = true;
            this.cb_isHaveQualified.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cb_isHaveQualified.Location = new System.Drawing.Point(192, 157);
            this.cb_isHaveQualified.Name = "cb_isHaveQualified";
            this.cb_isHaveQualified.Size = new System.Drawing.Size(139, 32);
            this.cb_isHaveQualified.TabIndex = 70;
            this.cb_isHaveQualified.Text = "-请选择-";
            // 
            // txb_LifeSpan
            // 
            this.txb_LifeSpan.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txb_LifeSpan.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txb_LifeSpan.Location = new System.Drawing.Point(891, 117);
            this.txb_LifeSpan.Name = "txb_LifeSpan";
            this.txb_LifeSpan.Size = new System.Drawing.Size(216, 31);
            this.txb_LifeSpan.TabIndex = 68;
            // 
            // txb_EnterDate
            // 
            this.txb_EnterDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txb_EnterDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txb_EnterDate.Location = new System.Drawing.Point(891, 74);
            this.txb_EnterDate.Name = "txb_EnterDate";
            this.txb_EnterDate.ReadOnly = true;
            this.txb_EnterDate.Size = new System.Drawing.Size(216, 31);
            this.txb_EnterDate.TabIndex = 67;
            // 
            // txb_BatchDate
            // 
            this.txb_BatchDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txb_BatchDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txb_BatchDate.Location = new System.Drawing.Point(891, 28);
            this.txb_BatchDate.Name = "txb_BatchDate";
            this.txb_BatchDate.ReadOnly = true;
            this.txb_BatchDate.Size = new System.Drawing.Size(216, 31);
            this.txb_BatchDate.TabIndex = 66;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label26.Location = new System.Drawing.Point(337, 160);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(180, 26);
            this.label26.TabIndex = 65;
            this.label26.Text = "外观是否符合：";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label25.Location = new System.Drawing.Point(745, 119);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(132, 26);
            this.label25.TabIndex = 64;
            this.label25.Text = "  有效期：";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label24.Location = new System.Drawing.Point(745, 76);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(132, 26);
            this.label24.TabIndex = 63;
            this.label24.Text = "进货日期：";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label23.Location = new System.Drawing.Point(745, 33);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(132, 26);
            this.label23.TabIndex = 62;
            this.label23.Text = "生产日期：";
            // 
            // txb_EnterCount
            // 
            this.txb_EnterCount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txb_EnterCount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txb_EnterCount.Location = new System.Drawing.Point(523, 117);
            this.txb_EnterCount.Name = "txb_EnterCount";
            this.txb_EnterCount.Size = new System.Drawing.Size(199, 31);
            this.txb_EnterCount.TabIndex = 60;
            // 
            // txb_Supplier
            // 
            this.txb_Supplier.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txb_Supplier.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txb_Supplier.Location = new System.Drawing.Point(523, 74);
            this.txb_Supplier.Name = "txb_Supplier";
            this.txb_Supplier.ReadOnly = true;
            this.txb_Supplier.Size = new System.Drawing.Size(199, 31);
            this.txb_Supplier.TabIndex = 59;
            // 
            // txb_BatchUnit
            // 
            this.txb_BatchUnit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txb_BatchUnit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txb_BatchUnit.Location = new System.Drawing.Point(523, 28);
            this.txb_BatchUnit.Name = "txb_BatchUnit";
            this.txb_BatchUnit.ReadOnly = true;
            this.txb_BatchUnit.Size = new System.Drawing.Size(199, 31);
            this.txb_BatchUnit.TabIndex = 58;
            // 
            // txb_LoginUnit
            // 
            this.txb_LoginUnit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txb_LoginUnit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txb_LoginUnit.Location = new System.Drawing.Point(168, 74);
            this.txb_LoginUnit.Name = "txb_LoginUnit";
            this.txb_LoginUnit.ReadOnly = true;
            this.txb_LoginUnit.Size = new System.Drawing.Size(199, 31);
            this.txb_LoginUnit.TabIndex = 56;
            // 
            // txb_ApprovalNumber
            // 
            this.txb_ApprovalNumber.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txb_ApprovalNumber.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txb_ApprovalNumber.Location = new System.Drawing.Point(168, 117);
            this.txb_ApprovalNumber.Name = "txb_ApprovalNumber";
            this.txb_ApprovalNumber.Size = new System.Drawing.Size(199, 31);
            this.txb_ApprovalNumber.TabIndex = 55;
            // 
            // txb_BatchNo
            // 
            this.txb_BatchNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txb_BatchNo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txb_BatchNo.Location = new System.Drawing.Point(168, 33);
            this.txb_BatchNo.Name = "txb_BatchNo";
            this.txb_BatchNo.ReadOnly = true;
            this.txb_BatchNo.Size = new System.Drawing.Size(199, 31);
            this.txb_BatchNo.TabIndex = 54;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label20.Location = new System.Drawing.Point(30, 76);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(132, 26);
            this.label20.TabIndex = 28;
            this.label20.Text = "注册单位：";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label19.Location = new System.Drawing.Point(30, 119);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(132, 26);
            this.label19.TabIndex = 27;
            this.label19.Text = "批准文号：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label17.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(385, 33);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(132, 26);
            this.label17.TabIndex = 25;
            this.label17.Text = "生产单位：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Location = new System.Drawing.Point(385, 76);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(132, 26);
            this.label16.TabIndex = 24;
            this.label16.Text = "供货单位：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Location = new System.Drawing.Point(385, 119);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(132, 26);
            this.label15.TabIndex = 23;
            this.label15.Text = "入房数量：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Location = new System.Drawing.Point(30, 159);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(156, 26);
            this.label14.TabIndex = 22;
            this.label14.Text = "有无合格证：";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label21.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(30, 33);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(132, 26);
            this.label21.TabIndex = 21;
            this.label21.Text = "生产批号：";
            // 
            // btn_Late
            // 
            this.btn_Late.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Late.BackColor = System.Drawing.Color.NavajoWhite;
            this.btn_Late.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Late.Image = ((System.Drawing.Image)(resources.GetObject("btn_Late.Image")));
            this.btn_Late.Location = new System.Drawing.Point(1347, 617);
            this.btn_Late.Name = "btn_Late";
            this.btn_Late.Size = new System.Drawing.Size(82, 45);
            this.btn_Late.TabIndex = 68;
            this.btn_Late.Text = ">>";
            this.btn_Late.UseVisualStyleBackColor = false;
            this.btn_Late.Click += new System.EventHandler(this.btn_Late_Click);
            // 
            // btn_Pre
            // 
            this.btn_Pre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Pre.BackColor = System.Drawing.Color.NavajoWhite;
            this.btn_Pre.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Pre.Image = ((System.Drawing.Image)(resources.GetObject("btn_Pre.Image")));
            this.btn_Pre.Location = new System.Drawing.Point(1257, 617);
            this.btn_Pre.Name = "btn_Pre";
            this.btn_Pre.Size = new System.Drawing.Size(84, 45);
            this.btn_Pre.TabIndex = 69;
            this.btn_Pre.Text = "<<";
            this.btn_Pre.UseVisualStyleBackColor = false;
            this.btn_Pre.Click += new System.EventHandler(this.btn_Pre_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox5.BackColor = System.Drawing.Color.LightBlue;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(-130, 113);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(1796, 48);
            this.pictureBox5.TabIndex = 70;
            this.pictureBox5.TabStop = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.MintCream;
            this.label4.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(803, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 28);
            this.label4.TabIndex = 71;
            this.label4.Text = "药品入房";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frm_EnterHall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1469, 954);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.btn_Pre);
            this.Controls.Add(this.btn_Late);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lv_Medicine);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_EnterHall";
            this.Text = "仁和医院住院药房管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_EnterHall_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView lv_Medicine;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtp_Date;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button btn_Sure;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txb_UseDate;
        private System.Windows.Forms.ComboBox cb_isQualified;
        private System.Windows.Forms.ComboBox cb_isHaveQualified;
        private System.Windows.Forms.TextBox txb_LifeSpan;
        private System.Windows.Forms.TextBox txb_EnterDate;
        private System.Windows.Forms.TextBox txb_BatchDate;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txb_EnterCount;
        private System.Windows.Forms.TextBox txb_Supplier;
        private System.Windows.Forms.TextBox txb_BatchUnit;
        private System.Windows.Forms.TextBox txb_LoginUnit;
        private System.Windows.Forms.TextBox txb_ApprovalNumber;
        private System.Windows.Forms.TextBox txb_BatchNo;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_SelcectRecord;
        private System.Windows.Forms.Button btn_Late;
        private System.Windows.Forms.Button btn_Pre;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label4;
    }
}