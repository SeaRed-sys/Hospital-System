using Npgsql;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using 医院住院药房管理系统.DataAccessLayer;
using 医院住院药房管理系统.PresentationLayer;
using static System.Environment;

namespace 医院住院药房管理系统.主要功能概述.系统设置
{
    /// <summary>
	/// 使用（PostgreSQL数据访问）；
	/// </summary>
    public partial class frm_ShowPersonal : Form
    {
        /// <summary>
		/// PostgreSQL助手；
		/// </summary>
		private PgsqlHelper PgsqlHelper { get; set; }
        /// <summary>
        /// SQL助手
        /// </summary>
        private SQLHepler SqlHelper;
        /// <summary>
        /// 一般方法
        /// </summary>
        private F_Fuction F_Fuction;
        public frm_ShowPersonal()
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
            this.PgsqlHelper = new PgsqlHelper();
            this.SqlHelper = new SQLHepler(); 
            this.F_Fuction = new F_Fuction();
        }

        private string _No;
        /// <summary>
        /// 构造函数；
        /// </summary>
        /// <param name="studentNo">用户名</param>
        public frm_ShowPersonal(string No) : this()
        {
            this._No = No;
        }
        
        /// <summary>
        /// 加载个人信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_ShowPersonal_Load(object sender, EventArgs e)
        {
            txb_Address.ReadOnly = true;txb_Name.ReadOnly = true;txb_Phone.ReadOnly = true;
            dtp_Date.Enabled = false;rdb_Female.Enabled = false;rdb_Male.Enabled = false;
            this.lbl_UserNo.Text = this._No;

            //使用PostgreSQL数据访问           
            string CommandText =$@"SELECT * FROM tb_operator WHERE no=@No;";
            NpgsqlDataReader pgsqlDataReader = 
                            this.PgsqlHelper.NewCommand(CommandText)
                            .NewParameter("@No", this._No)
                            .GetReader();
            SqlDataReader sqlDataReader=this.SqlHelper.NewCommand(CommandText)
                            .NewParameter("@No", this._No)
                            .GetReader();
            byte[] photoBytes = null;
            if (pgsqlDataReader.Read())
            {
                if (pgsqlDataReader["Sex"].ToString() == "1")
                { this.rdb_Male.Checked = true; }
                else
                { 
                    this.rdb_Female.Checked = true;           }
                    this.txb_No.Text = pgsqlDataReader["No"].ToString();
                    this.txb_Name.Text = pgsqlDataReader["Name"].ToString();
                    this.dtp_Date.Value = (DateTime)pgsqlDataReader["Birthday"];
                    this.txb_Phone.Text = pgsqlDataReader["Phone"].ToString();
                    this.txb_Address.Text = pgsqlDataReader["Address"].ToString();
                    string str = pgsqlDataReader["Photo"].ToString();
            }
            if (sqlDataReader.Read())
            {
                photoBytes =
                    (sqlDataReader["Photo"] == DBNull.Value ? null : (byte[])sqlDataReader["Photo"]);
            }
            pgsqlDataReader.Close();
            sqlDataReader.Close();
            if (photoBytes != null)
            {
                MemoryStream memoryStream = new MemoryStream(photoBytes);
                this.pcb_Picture.Image = Image.FromStream(memoryStream);
                pcb_Picture.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        
        /// <summary>
        /// 打开照片
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
        /// 提交修改的个人信息
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

            string commandText =
                $@"UPDATE tb_Operator 
                SET Name=@Name ,Sex=@Sex,Birthday=@Birthday,Phone=@Phone,Address=@Address,Photo=@Photo
                WHERE NO='{this.txb_No.Text}';";

            DateTime date = DateTime.Parse(this.dtp_Date.Value.ToString());
            //使用PostgreSQL数据访问   
            int rowAffected = this.PgsqlHelper.NewCommand(commandText)
                .NewParameter("@Name", this.txb_Name.Text.Trim()).NewParameter("@Birthday", date)
                .NewParameter("@Sex", this.rdb_Male.Checked).NewParameter("@Phone", this.txb_Phone.Text.Trim())
                .NewParameter("@Address", this.txb_Address.Text.Trim()).NewParameter("@Photo", photoBytes)
                .NonQuery();

            //使用SQL数据访问   
            this.SqlHelper.NewCommand(commandText)
                .NewParameter("@Name", this.txb_Name.Text.Trim()).NewParameter("@Birthday", dtp_Date.Value.ToString())
                .NewParameter("@Sex", this.rdb_Male.Checked).NewParameter("@Phone", this.txb_Phone.Text.Trim())
                .NewParameter("@Address", this.txb_Address.Text.Trim()).NewParameter("@Photo", photoBytes)
                .NonQuery();

            this.F_Fuction.MessgeShow(rowAffected, "修改成功。", "修改失败！");
            //显示正确提示；
            btn_Sure.Visible = false;
            btn_Update.Visible = true;
            btn_OpenPhoto.Visible = false;
            frm_ShowPersonal_Load(null, null);

        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
