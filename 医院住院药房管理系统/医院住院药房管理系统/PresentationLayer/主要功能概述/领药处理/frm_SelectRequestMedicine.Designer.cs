namespace 医院住院药房管理系统.主要功能概述.领药处理
{
    partial class frm_SelectRequestMedicine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_SelectRequestMedicine));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.dgv_RequestMedicine = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdb_ShowHistory = new System.Windows.Forms.RadioButton();
            this.rdb_ShowCurrent = new System.Windows.Forms.RadioButton();
            this.rdb_ShowNoHistory = new System.Windows.Forms.RadioButton();
            this.rdb_ShowNoCurrent = new System.Windows.Forms.RadioButton();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.btn_Late = new System.Windows.Forms.Button();
            this.btn_Pre = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RequestMedicine)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(1055, 85);
            this.panel1.TabIndex = 8;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.BackColor = System.Drawing.Color.Ivory;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(24, 13);
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
            this.pictureBox1.Location = new System.Drawing.Point(31, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(974, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox5.BackColor = System.Drawing.Color.LightBlue;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(-4, 120);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(1107, 48);
            this.pictureBox5.TabIndex = 9;
            this.pictureBox5.TabStop = false;
            // 
            // dgv_RequestMedicine
            // 
            this.dgv_RequestMedicine.AllowUserToAddRows = false;
            this.dgv_RequestMedicine.AllowUserToDeleteRows = false;
            this.dgv_RequestMedicine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_RequestMedicine.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_RequestMedicine.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_RequestMedicine.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv_RequestMedicine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_RequestMedicine.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_RequestMedicine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_RequestMedicine.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_RequestMedicine.Location = new System.Drawing.Point(12, 190);
            this.dgv_RequestMedicine.Name = "dgv_RequestMedicine";
            this.dgv_RequestMedicine.ReadOnly = true;
            this.dgv_RequestMedicine.RowHeadersWidth = 62;
            this.dgv_RequestMedicine.RowTemplate.Height = 30;
            this.dgv_RequestMedicine.Size = new System.Drawing.Size(1047, 248);
            this.dgv_RequestMedicine.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.MintCream;
            this.label4.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(822, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 28);
            this.label4.TabIndex = 18;
            this.label4.Text = "药品请领";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.rdb_ShowHistory);
            this.groupBox1.Controls.Add(this.rdb_ShowCurrent);
            this.groupBox1.Controls.Add(this.rdb_ShowNoHistory);
            this.groupBox1.Controls.Add(this.rdb_ShowNoCurrent);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 456);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(619, 153);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选项";
            // 
            // rdb_ShowHistory
            // 
            this.rdb_ShowHistory.AutoSize = true;
            this.rdb_ShowHistory.Location = new System.Drawing.Point(324, 99);
            this.rdb_ShowHistory.Name = "rdb_ShowHistory";
            this.rdb_ShowHistory.Size = new System.Drawing.Size(227, 28);
            this.rdb_ShowHistory.TabIndex = 3;
            this.rdb_ShowHistory.TabStop = true;
            this.rdb_ShowHistory.Text = "显示历史完成请领";
            this.rdb_ShowHistory.UseVisualStyleBackColor = true;
            this.rdb_ShowHistory.Click += new System.EventHandler(this.rdb_ShowHistory_Click);
            // 
            // rdb_ShowCurrent
            // 
            this.rdb_ShowCurrent.AutoSize = true;
            this.rdb_ShowCurrent.Location = new System.Drawing.Point(324, 44);
            this.rdb_ShowCurrent.Name = "rdb_ShowCurrent";
            this.rdb_ShowCurrent.Size = new System.Drawing.Size(227, 28);
            this.rdb_ShowCurrent.TabIndex = 2;
            this.rdb_ShowCurrent.TabStop = true;
            this.rdb_ShowCurrent.Text = "显示当天完成请领";
            this.rdb_ShowCurrent.UseVisualStyleBackColor = true;
            this.rdb_ShowCurrent.Click += new System.EventHandler(this.rdb_ShowCurrent_Click);
            // 
            // rdb_ShowNoHistory
            // 
            this.rdb_ShowNoHistory.AutoSize = true;
            this.rdb_ShowNoHistory.Location = new System.Drawing.Point(24, 99);
            this.rdb_ShowNoHistory.Name = "rdb_ShowNoHistory";
            this.rdb_ShowNoHistory.Size = new System.Drawing.Size(251, 28);
            this.rdb_ShowNoHistory.TabIndex = 1;
            this.rdb_ShowNoHistory.TabStop = true;
            this.rdb_ShowNoHistory.Text = "显示历史未完成请领";
            this.rdb_ShowNoHistory.UseVisualStyleBackColor = true;
            this.rdb_ShowNoHistory.Click += new System.EventHandler(this.rdb_ShowNoHistory_Click);
            // 
            // rdb_ShowNoCurrent
            // 
            this.rdb_ShowNoCurrent.AutoSize = true;
            this.rdb_ShowNoCurrent.Location = new System.Drawing.Point(24, 44);
            this.rdb_ShowNoCurrent.Name = "rdb_ShowNoCurrent";
            this.rdb_ShowNoCurrent.Size = new System.Drawing.Size(251, 28);
            this.rdb_ShowNoCurrent.TabIndex = 0;
            this.rdb_ShowNoCurrent.TabStop = true;
            this.rdb_ShowNoCurrent.Text = "显示当天未完成请领";
            this.rdb_ShowNoCurrent.UseVisualStyleBackColor = true;
            this.rdb_ShowNoCurrent.Click += new System.EventHandler(this.rdb_ShowNoCurrent_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.BackColor = System.Drawing.Color.NavajoWhite;
            this.btn_Close.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Close.Image = ((System.Drawing.Image)(resources.GetObject("btn_Close.Image")));
            this.btn_Close.Location = new System.Drawing.Point(890, 544);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(169, 52);
            this.btn_Close.TabIndex = 69;
            this.btn_Close.Text = "关闭";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Ok
            // 
            this.btn_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Ok.BackColor = System.Drawing.Color.NavajoWhite;
            this.btn_Ok.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Ok.Image = ((System.Drawing.Image)(resources.GetObject("btn_Ok.Image")));
            this.btn_Ok.Location = new System.Drawing.Point(715, 544);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(169, 52);
            this.btn_Ok.TabIndex = 70;
            this.btn_Ok.Text = "审批";
            this.btn_Ok.UseVisualStyleBackColor = false;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // btn_Late
            // 
            this.btn_Late.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Late.BackColor = System.Drawing.Color.NavajoWhite;
            this.btn_Late.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Late.Image = ((System.Drawing.Image)(resources.GetObject("btn_Late.Image")));
            this.btn_Late.Location = new System.Drawing.Point(964, 383);
            this.btn_Late.Name = "btn_Late";
            this.btn_Late.Size = new System.Drawing.Size(82, 45);
            this.btn_Late.TabIndex = 71;
            this.btn_Late.Text = ">>";
            this.btn_Late.UseVisualStyleBackColor = false;
            this.btn_Late.Click += new System.EventHandler(this.btn_Late_Click_1);
            // 
            // btn_Pre
            // 
            this.btn_Pre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Pre.BackColor = System.Drawing.Color.NavajoWhite;
            this.btn_Pre.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Pre.Image = ((System.Drawing.Image)(resources.GetObject("btn_Pre.Image")));
            this.btn_Pre.Location = new System.Drawing.Point(874, 383);
            this.btn_Pre.Name = "btn_Pre";
            this.btn_Pre.Size = new System.Drawing.Size(84, 45);
            this.btn_Pre.TabIndex = 72;
            this.btn_Pre.Text = "<<";
            this.btn_Pre.UseVisualStyleBackColor = false;
            this.btn_Pre.Click += new System.EventHandler(this.btn_Pre_Click_1);
            // 
            // frm_SelectRequestMedicine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1077, 621);
            this.Controls.Add(this.btn_Pre);
            this.Controls.Add(this.btn_Late);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgv_RequestMedicine);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_SelectRequestMedicine";
            this.Text = "药品请领单查询";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_SelectRequestMedicine_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RequestMedicine)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.DataGridView dgv_RequestMedicine;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdb_ShowNoCurrent;
        private System.Windows.Forms.RadioButton rdb_ShowHistory;
        private System.Windows.Forms.RadioButton rdb_ShowCurrent;
        private System.Windows.Forms.RadioButton rdb_ShowNoHistory;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Late;
        private System.Windows.Forms.Button btn_Pre;
    }
}