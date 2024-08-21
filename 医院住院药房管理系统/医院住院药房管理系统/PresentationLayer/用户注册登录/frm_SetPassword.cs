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

namespace 医院住院药房管理系统.用户注册登录
{
    public partial class frm_SetPassword : Form
    {
        /// <summary>
        /// SQL助手
        /// </summary>
        private SQLHepler SqlHelper;
        public frm_SetPassword()
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
            this.SqlHelper = new SQLHepler();
        }   
        private string _No;
        /// <summary>
        /// 构造函数；
        /// </summary>
        /// <param name="studentNo">用户名</param>
        public frm_SetPassword(string No) : this()
        {
            this._No = No;
        }
        private void frm_SetPassword_Load(object sender, EventArgs e)
        {
            this.txb2.Text = this._No;
            txb2.ReadOnly = true;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Sure_Click(object sender, EventArgs e)
        {
            MD5Encryption mD5Encryption = new MD5Encryption();
            string Password = mD5Encryption.ComputeMD5Hash(this.txb_Password.Text.Trim());
            string CommandText =
             $@" UPDATE tb_User SET Password=@Password
                    WHERE IDName =@IDName";
            int rowAffected =
                this.SqlHelper.NewCommand(CommandText)
                .NewParameter("@IDName", this._No).NewParameter("@Password", Password)
                .NonQuery();
            if (rowAffected == 1)                                                                       //若成功写入1行记录；
            {
                MessageBox.Show("密码修改成功。", "消息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                //显示正确提示；
                frm_Login frm_Login = new frm_Login();
                frm_Login.Show();
                this.Close();
            }
            else                                                                                        //否则；
            {
                MessageBox.Show("密码修改失败！", "消息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);                                                            //显示错误提示；
            }
        }
        /// <summary>
        /// 跳转到登录界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkbtn_SearchPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_Login frm_Login = new frm_Login();
            frm_Login.Show();
            this.Close();
        }
        /// <summary>
        /// 跳转到注册界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linlbl_SignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_SignUp frm_SignUp = new frm_SignUp();
            frm_SignUp.Show();
            this.Close();
        }
    }
}
