using SmartLinli.DatabaseDevelopement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using 医院住院药房管理系统.DataAccessLayer;
using 医院住院药房管理系统.Repository;

namespace 医院住院药房管理系统
{
    public partial class frm_SignUp : Form
    {
        /// <summary>
		/// SQL助手；
		/// </summary>
		private SQLHepler SqlHelper { get; set; }
        public frm_SignUp()
        {
            InitializeComponent();
            this.AcceptButton = this.btn_SignUp;
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
        /// <summary>
        /// 实现注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SignUp_Click(object sender, EventArgs e)
        {
            string Type = "1";
            if (cb_UserType.Text == "操作人员")
            {
                Type = "2";
            }            
            string IDName= this.txt_No.Text.Trim();
            MD5Encryption mD5Encryption = new MD5Encryption();
            string Password = mD5Encryption.ComputeMD5Hash(this.txt_Password.Text.Trim());

            //MedicineSystem medicineSystem = new MedicineSystem();
            //User user = new User()
            //{
            //    TypeNo = Type,
            //    IDName = IDName,
            //    Password = Password,
            //    IsActivated = true
            //};
            //if (medicineSystem.User.Add(user) != null)
            //{
            //    if (cb_UserType.Text == "操作人员")
            //    {
            //        MessageBox.Show("注册成功。");
            //        frm_Personal person = new frm_Personal(txt_No.Text);
            //        person.Show();
            //        this.Close();

            //    }
            //    else
            //    {
            //        MessageBox.Show("注册成功。");
            //        frm_Login frm_Login = new frm_Login();
            //        frm_Login.Show();
            //        this.Close();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("注册失败，请检查输入信息。");
            //}
            //;


            string CommandText =
                            $@"INSERT tb_User(TypeNo,IDName,Password,IsActivated)
                            VALUES
                            (@Type,@IDName,@Password,1);";
            int rowsAffected = this.SqlHelper.NewCommand(CommandText)
                .NewParameter("Type", Type).NewParameter("@IDName", IDName).NewParameter("@Password", Password)
                .NonQuery();
            if (rowsAffected > 0)
            {
                if (cb_UserType.Text == "操作人员")
                {
                    MessageBox.Show("注册成功。");
                    frm_Personal person = new frm_Personal(txt_No.Text);
                    person.Show();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("注册成功。");
                    frm_Login frm_Login = new frm_Login();
                    frm_Login.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("注册失败，请检查输入信息。");
            }
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_SignUp_Load(object sender, EventArgs e)
        {
            string CommandText =
                $@"SELECT * FROM tb_UserType";
            DataTable userType =this.SqlHelper.NewCommand(CommandText).GetTable();
            if (userType != null)
            {
                cb_UserType.DataSource = userType;
                cb_UserType.DisplayMember = "TypeName";
                cb_UserType.ValueMember= "No";
            }
        }
        /// <summary>
        /// 跳转到登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linlbl_SignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_Login frm_Login = new frm_Login();
            frm_Login.Show();
            Close();
        }
    }
}
