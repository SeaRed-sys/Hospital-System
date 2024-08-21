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
    public partial class frm_GetPassword : Form
    {
        /// <summary>
        /// SQL助手
        /// </summary>
        private SQLHepler SqlHelper;
        public frm_GetPassword()
        {
            InitializeComponent();
            //this.AcceptButton = this.btn_Login;
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
        /// 根据工号信息，设置密保问题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Login_Click(object sender, EventArgs e)
        {
            string No = txb2.Text.Trim();
            string UserNo = txb1.Text.Trim();
            string CommandText =
             $@"SELECT * FROM tb_Operator
                WHERE NO=@No AND UserNo=@UserNo;";
            SqlDataReader sqlDataReade =
            this.SqlHelper.NewCommand(CommandText)
            .NewParameter("@No", No).NewParameter("@UserNo", UserNo)
            .GetReader();
            if (sqlDataReade.Read())
            {
                sqlDataReade.Close();
                _No = txb2.Text;
                btn_Sure.Visible = true;
                btn_Login.Visible = false;
                btn_Login.Enabled = false;
                txb1.Clear();txb2.Clear();
                CommandText =
                $@"SELECT * FROM tb_ChangeInformation WHERE NO=@No;";
                sqlDataReade =
                this.SqlHelper.NewCommand(CommandText)
                .NewParameter("@No", _No)
                .GetReader();
                if (sqlDataReade.Read())
                {
                    lbl1.Text = sqlDataReade["PasswordQuestional1"].ToString();
                    lbl2.Text = sqlDataReade["PasswordQuestional2"].ToString();
                }
                else
                {
                    frm_SetPassword frm_SetPassword = new frm_SetPassword(this._No);
                    frm_SetPassword.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("用户/工号有误，请重新输入！");
                this.txb1.Focus();
                this.txb1.SelectAll();
            }

        }
        /// <summary>
        /// 根据密保修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Sure_Click(object sender, EventArgs e)
        {
            string Answer1 = this.txb1.Text.Trim();
            string Answer2 = this.txb2.Text.Trim();
            string CommandText =
             $@"SELECT * FROM tb_ChangeInformation 
            WHERE NO=@No AND Answer1=@Answer1 AND Answer2=@Answer2";
            SqlDataReader sqlDataReader =
            this.SqlHelper.NewCommand(CommandText)
            .NewParameter("@No", this._No)
            .NewParameter("@Answer1", Answer1).NewParameter("@Answer2", Answer2)
            .GetReader();
            if (sqlDataReader.Read())
            {
                frm_SetPassword frm_SetPassword = new frm_SetPassword(this._No);
                frm_SetPassword.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("密保有误，请重新输入！");
                this.txb1.Focus();
                this.txb1.SelectAll();
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
    }
}
