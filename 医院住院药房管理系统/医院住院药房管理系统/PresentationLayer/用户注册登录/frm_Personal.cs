using SmartLinli.DatabaseDevelopement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using 医院住院药房管理系统.DataAccessLayer;

namespace 医院住院药房管理系统
{
    public partial class frm_Personal : Form
    {
        /// <summary>
        /// SQL助手
        /// </summary>
        private SQLHepler SqlHelper;
        public frm_Personal()
        {
            InitializeComponent();
            this.AcceptButton = this.btn_Sure;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosed += (_, __) =>
            {
                if (Application.OpenForms.Count == 0)
                {
                    Application.Exit();
                }
            };
            this.SqlHelper = new SQLHepler();
        }      
        private string _No;
        /// <summary>
        /// 构造函数；
        /// </summary>
        /// <param name="studentNo">用户名</param>
        public frm_Personal(string No) : this()
        {
            this._No = No;
        }
        /// <summary>
        /// 确认添加个人信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Sure_Click(object sender, EventArgs e)
        {
            string NO = this.txt_UserNo.Text.Trim();
            string UserNo = this._No;
            string Name = this.tb_Name.Text.Trim();
            string Sex = cb_Sex.Text.Trim();
            string Birthday = this.dtp_Birth.Value.ToString();
            string Phone = this.tb_Phone.Text.Trim();
            string Address = this.tb_Address.Text.Trim();
            string CommandText =
                $@"INSERT tb_Operator(NO ,UserNo,Name,Sex ,Birthday,Phone ,Address)
					VALUES
					(@No,@UserNo,@Name,@Sex ,@Birthday,@Phone ,@Address);";
            int rowCount =
             this.SqlHelper.NewCommand(CommandText)
                .NewParameter("@No", NO).NewParameter("@UserNo", UserNo).NewParameter("@Name",Name)
                .NewParameter("@Sex",Sex).NewParameter("@Birthday",Birthday).NewParameter("@Phone",Phone)
                .NewParameter("@Address",Address)
                .NonQuery();                                                          //打开SQL连接；
            if (rowCount>0)
            {
                MessageBox.Show("保存成功。");
                frm_Login logIn = new frm_Login();
                logIn.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("保存失败！");
            }
        }

        private void frm_Personal_Load(object sender, EventArgs e)
        {
            txt_No.Text = this._No;
        }
    }
}
