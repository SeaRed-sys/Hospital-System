using SmartLinli.DatabaseDevelopement;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using 医院住院药房管理系统.DataAccessLayer;
using 医院住院药房管理系统.PresentationLayer;
using static System.Environment;

namespace 医院住院药房管理系统.主要功能概述.系统设置
{
    public partial class frm_MainInterface : Form
    {
        /// <summary>
        /// 一般方法
        /// </summary>
        private F_Fuction F_Fuction;
        /// <summary>
        /// SQL助手
        /// </summary>
        private SQLHepler SqlHelper;

        public frm_MainInterface()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosed += (_, __) =>
            {
                if (Application.OpenForms.Count == 0)
                {
                    Application.Exit();
                }
            };
            this.F_Fuction = new F_Fuction();
            this.SqlHelper = new SQLHepler();
        }
        private string _No;
        /// <summary>
        /// 构造函数；
        /// </summary>
        /// <param name="studentNo">用户名</param>
        public frm_MainInterface(string No) : this()
        {
            this._No = No;
        }

        /// <summary>
        /// 调整选项卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //调整选项卡文字方向
            SolidBrush lightPink = new SolidBrush(Color.LightBlue);//创建一个淡粉色画刷
            SolidBrush lightPink1 = new SolidBrush(Color.White);//创建一个淡粉色画刷
            SolidBrush _Brush = new SolidBrush(Color.Black);//单色画刷
            RectangleF _TabTextArea = (RectangleF)tabControl1.GetTabRect(e.Index);//绘制区域
            StringFormat _sf = new StringFormat();//封装文本布局格式信息
            _sf.LineAlignment = StringAlignment.Center;
            _sf.Alignment = StringAlignment.Center;
            Rectangle Rec = tabControl1.GetTabRect(e.Index);//返回选项卡控件中指定选项卡的边框
            Rectangle rectangle = new Rectangle(tabControl1.Left, tabControl1.Top, tabControl1.Width, tabControl1.Height);
            e.Graphics.FillRectangle(lightPink, Rec);//用画刷将选项卡内部边框填满
            Region region = new Region(rectangle);
            e.Graphics.FillRegion(lightPink1, region);//用画刷将选项卡内部边框填满
            e.Graphics.DrawString(tabControl1.Controls[e.Index].Text, SystemInformation.MenuFont, _Brush, _TabTextArea, _sf);
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_MainInterface_Load(object sender, EventArgs e)
        {     
            txt_No.Text = this._No;
            txt_No1.Text = this._No;
            txb_Address.ReadOnly = true; txb_Name.ReadOnly = true; txb_Phone.ReadOnly = true;
            dtp_Date.Enabled = false; rdb_Female.Enabled = false; rdb_Male.Enabled = false;
            this.lbl_UserNo.Text = this._No;


            string CommandText = $@"SELECT * FROM tb_Operator WHERE NO='{this._No}';";
            SqlDataReader sqlDataReader =this.SqlHelper.NewCommand(CommandText)
                                                       .GetReader();
            byte[] photoBytes = null;
            if (sqlDataReader.Read())
            {
                if (sqlDataReader["Sex"].ToString() == "1")
                { this.rdb_Male.Checked = true; }
                else
                { this.rdb_Female.Checked = true; }
                this.txb_No.Text = sqlDataReader["No"].ToString();
                this.txb_Name.Text = txt_Name1.Text=sqlDataReader["Name"].ToString();
                this.dtp_Date.Value = (DateTime)sqlDataReader["Birthday"];
                this.txb_Phone.Text = sqlDataReader["Phone"].ToString();
                this.txb_Address.Text = sqlDataReader["Address"].ToString();
                photoBytes =
                    (sqlDataReader["Photo"] == DBNull.Value ? null : (byte[])sqlDataReader["Photo"]);
            }

            if (photoBytes != null)
            {
                MemoryStream memoryStream = new MemoryStream(photoBytes);
                this.pcb_Picture.Image = Image.FromStream(memoryStream);
                pcb_Picture.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        /// <summary>
        /// 打卡图片按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OpenPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openPhotoDialog = new OpenFileDialog()
            {
                Title = "打开照片文件"
                ,
                Filter = "图像文件|*.bmp;*.jpg"
                ,
                InitialDirectory = GetFolderPath(SpecialFolder.MyPictures)
            };
            if (openPhotoDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openPhotoDialog.FileName;
                this.pcb_Picture.Image = Image.FromFile(fileName);
                pcb_Picture.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        /// <summary>
        /// 更新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Update_Click(object sender, EventArgs e)
        {
            txb_Address.ReadOnly = false;
            txb_Name.ReadOnly = false;
            txb_Phone.ReadOnly = false;
            dtp_Date.Enabled = true;
            btn_Update.Visible = false;
            btn_Sure.Visible = true;
            btn_Sure.Enabled = true;
            btn_OpenPhoto.Enabled = true;
            btn_OpenPhoto.Visible = true;
            rdb_Female.Enabled = true;
            rdb_Male.Enabled = true;
            txb_Name.Focus();
        }
        /// <summary>
        /// 确认修改按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Sure_Click(object sender, EventArgs e)
        {
            //照片的处理
            MemoryStream memoryStream = new MemoryStream();
            this.pcb_Picture.Image.Save(memoryStream, ImageFormat.Bmp);
            byte[] photoBytes = new byte[memoryStream.Length];
            memoryStream.Seek(0, SeekOrigin.Begin);
            memoryStream.Read(photoBytes, 0, photoBytes.Length);

            //连接数据库
            string commandText =
                $@"UPDATE tb_Operator 
                SET Name=@Name ,Sex=@Sex,Birthday=@Birthday,Phone=@Phone,Address=@Address,Photo=@Photo
                WHERE NO='{this.txb_No.Text}';";

            //使用SQL数据访问   
            int rowAffected=this.SqlHelper.NewCommand(commandText)
                .NewParameter("@Name", this.txb_Name.Text.Trim()).NewParameter("@Birthday", dtp_Date.Value.ToString())
                .NewParameter("@Sex", this.rdb_Male.Checked).NewParameter("@Phone", this.txb_Phone.Text.Trim())
                .NewParameter("@Address", this.txb_Address.Text.Trim()).NewParameter("@Photo", photoBytes)
                .NonQuery();

            this.F_Fuction.MessgeShow(rowAffected, "修改成功。", "修改失败！");
            //显示正确提示；
            btn_Sure.Visible = false;
            btn_Update.Visible = true;
            btn_OpenPhoto.Visible = false;
            frm_MainInterface_Load(null, null);
        }
        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 打开开发文档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // 网页文件路径，需要替换为您的网页文件路径
            string filePath = "D:\\大二课程\\大二下\\数据库技术与应用\\课程设计\\课程设计详情\\医院住院药房管理系统说明书.docx";

            // 检查文件是否存在
            if (File.Exists(filePath))
            {
                // 启动系统默认程序来打开文件
                Process.Start(filePath);
            }
            else
            {
                MessageBox.Show("文件不存在。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 重置按钮1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Restart_Click(object sender, EventArgs e)
        {
            this.txt_Pwd1.Clear();
            this.txt_Pwd2.Clear();
            this.txt_Answer2.Clear();
            this.txt_Aswer.Clear();
        }

        /// <summary>
        /// 提交按钮1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            string commandText = $@"SELECT * FROM tb_ChangeInformation WHERE NO='{this._No}';";

            SqlDataReader sqlDataReader = this.SqlHelper.NewCommand(commandText).GetReader();
            if (sqlDataReader.Read())
            {               
                commandText = $@" UPDATE tb_ChangeInformation 
                                          SET PasswordQuestional1 = '{this.txt_Pwd1.Text}', 
                                          Answer1 =  '{this.txt_Aswer.Text}',
                                          PasswordQuestional2 = '{this.txt_Pwd2.Text}',
                                          Answer2 = '{this.txt_Answer2.Text}'
                                          WHERE NO = '{this._No}'";

                int rowAffected = this.SqlHelper.NewCommand(commandText).NonQuery();
                this.F_Fuction.MessgeShow(rowAffected, "保存数据成功。", "保存数据失败。");
                btn_Restart_Click(null,null);
            }
            else
            {
                commandText = $@"INSERT tb_ChangeInformation
                                        (NO,PasswordQuestional1,Answer1 ,PasswordQuestional2,Answer2)
                                        VALUES
                                        ('{this._No}','{this.txt_Pwd1.Text}','{this.txt_Aswer.Text}'
                                        ,'{this.txt_Pwd2.Text}','{this.txt_Answer2.Text}')";

                int rowAffected = this.SqlHelper.NewCommand(commandText).NonQuery();
                this.F_Fuction.MessgeShow(rowAffected, "保存数据成功。", "保存数据失败。");
            }
        }
        /// <summary>
        /// 重置按钮2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Restart1_Click(object sender, EventArgs e)
        {
            this.txt_OldPassword.Clear();
            this.txt_NewPassword.Clear();
            this.txt_PasswordAgain.Clear();
        }
        /// <summary>
        /// 提交按钮2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Submit_Click(object sender, EventArgs e)
        {
            MD5Encryption mD5Encryption = new MD5Encryption();
            string Password = mD5Encryption.ComputeMD5Hash(this.txt_OldPassword.Text.Trim());

            string commandText =
               $"SELECT 1 FROM tb_User AS U WHERE U.IDName='{this._No}'AND U.Password=@Password";
           
            SqlDataReader sqlDataReader = this.SqlHelper.NewCommand(commandText).NewParameter("Password", Password).GetReader();
            if (sqlDataReader.Read())
            {
                Password = mD5Encryption.ComputeMD5Hash(this.txt_NewPassword.Text.Trim());
                commandText = $"UPDATE tb_User SET Password=@Password WHERE IDName='{this._No}'";

                int rowAffected = this.SqlHelper.NewCommand(commandText).NewParameter("Password", Password).NonQuery();
                this.F_Fuction.MessgeShow(rowAffected, $"密码修改为{txt_NewPassword.Text}成功。", "保存数据失败。");
                this.btn_Restart1_Click(null, null);
            }
            else
            {
                MessageBox.Show("用户号/密码有误，请重新输入！");
                this.txt_OldPassword.Focus();
                this.txt_OldPassword.SelectAll();
            }
        }

    }
}
