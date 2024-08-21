using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Forms;
using 医院住院药房管理系统.用户注册登录;
using 医院住院药房管理系统.BusinessLogicLayer;
using 医院住院药房管理系统.Model;
using 医院住院药房管理系统.DataAccessLayer;

namespace 医院住院药房管理系统
{
    public partial class frm_Login : Form
    {
        /// <summary>
		/// 用户；
		/// </summary>
		private User User { get; set; }
        /// <summary>
        /// 用户（业务逻辑层）；
        /// </summary>
        private IUserBll UserBll { get; set; }
        private SQLHepler SqlHelper;
        /// <summary>
        /// 构造函数；
        /// </summary>
        public frm_Login()
        {
            InitializeComponent();
            this.AcceptButton = this.btn_Login;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosed += (_, __) =>
            {
                if (Application.OpenForms.Count == 0)
                {
                    Application.Exit();
                }
            };
            this.UserBll = new UserBll();
            this.txt_No.Validating += this.ValidateUserNo;
            this.txt_Password.Validating += this.ValidatePassword;
            this.ErrorProvider.BlinkRate = 500;
            this.SqlHelper = new SQLHepler();
        }
        /// <summary>
        /// 验证用户号；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValidateUserNo(object sender, CancelEventArgs e)
        {
            string userNo = this.txt_No.Text;
            bool isEmpty = string.IsNullOrEmpty(userNo);
            if (isEmpty)
            {
                this.ErrorProvider.SetError(this.txt_No, "用户号不能为空");
                return;
            }
            bool isLengthValid =
                userNo.Length >= this.UserBll.UserNoMinLength
                && userNo.Length <= this.UserBll.UserNoMaxLength;
            if (!isLengthValid)
            {
                this.ErrorProvider.SetError
                    (this.txt_No,
                    $"用户号长度应为{this.UserBll.UserNoMinLength}~{this.UserBll.UserNoMaxLength}");
                return;
            }
            bool isExisting = this.UserBll.CheckExist(userNo);
            if (!isExisting)
            {
                this.ErrorProvider.SetError(this.txt_No, "用户号不存在");
                return;
            }
            this.ErrorProvider.SetError(this.txt_No, "");
        }
        /// <summary>
        /// 验证密码；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValidatePassword(object sender, CancelEventArgs e)
        {
            string password = this.txt_Password.Text;
            bool isEmpty = string.IsNullOrEmpty(password);
            if (isEmpty)
            {
                this.ErrorProvider.SetError(this.txt_Password, "密码不能为空");
                return;
            }
            this.ErrorProvider.SetError(this.txt_Password, "");
        }
        /// <summary>
        /// 点击登录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Login_Click(object sender, EventArgs e)
        {
            int userType=1;
            if (!rdb_UserType.Checked)
            {
                userType = 0;
            }
            MD5Encryption mD5Encryption = new MD5Encryption();
            string Password = mD5Encryption.ComputeMD5Hash(this.txt_Password.Text.Trim());
            string IDName = this.txt_No.Text.Trim();
            string CommandText =
                $@"SELECT 1 
					FROM tb_User
					WHERE IDName=@IDName AND Password=@Password;";
            SqlDataReader sqlDataReade=
             this.SqlHelper.NewCommand(CommandText)
                .NewParameter("@IDName", IDName).NewParameter("@Password", Password)
                .GetReader();
            if (sqlDataReade.Read())
            {
                MessageBox.Show("登录成功。");
                frm_Homepage homePage = new frm_Homepage(this.txt_No.Text.Trim(),userType);
                homePage.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("用户号/密码有误，请重新输入！");
                this.txt_Password.Focus();
                this.txt_Password.SelectAll();
            }
        }
        /// <summary>
        /// 点击注册按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linlbl_SignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_SignUp signUp = new frm_SignUp();
            signUp.Show();
            this.Close();
        }
        /// <summary>
        /// 点击忘记密码按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkbtn_SearchPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_GetPassword frm_GetPassword = new frm_GetPassword();
            frm_GetPassword.Show();
            this.Close();
        }
        /// <summary>
        /// 是否显示密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckb_LooPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_LooPassword.Checked)
            {
                txt_Password.PasswordChar = '\0';
            }
            else
            {
                txt_Password.PasswordChar = '*';
            }
        }
    }
}
