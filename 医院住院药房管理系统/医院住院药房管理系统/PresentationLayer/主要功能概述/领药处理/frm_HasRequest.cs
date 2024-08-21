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
using 医院住院药房管理系统.PresentationLayer;

namespace 医院住院药房管理系统.主要功能概述.领药处理
{
    public partial class frm_HasRequest : Form
    {
        /// <summary>
        /// SQL助手
        /// </summary>
        private SQLHepler SqlHelper;
        /// <summary>
        /// 一般方法
        /// </summary>
        private F_Fuction F_Fuction;
        public frm_HasRequest()
        {
            InitializeComponent();
            this.AcceptButton = this.btn_Ok;
            this.StartPosition = FormStartPosition.CenterScreen;
            // 设置窗体边框样式为FixedSingle，使得窗体大小无法改变  
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.FormClosed += (_, __) =>
            {
                if (Application.OpenForms.Count == 0)
                {
                    Application.Exit();
                }
            };
            this.SqlHelper = new SQLHepler();
            this.F_Fuction = new F_Fuction();
        }

        private string _No;
        /// <summary>
        /// 构造函数；
        /// </summary>
        /// <param name="studentNo">用户名</param>
        public frm_HasRequest(string No) : this()
        {
            this._No = No;
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_HasRequest_Load(object sender, EventArgs e)
        {
            //药品编号
            string MedicineNo = "";
            
            string CommandText =
                $@"SELECT* FROM tb_MedicineRequest WHERE No='{_No}'";
            SqlDataReader sqlDataReader =
                     this.SqlHelper.NewCommand(CommandText)
                    .GetReader();
            if (sqlDataReader.Read())
            {
                this.txb_No.Text = sqlDataReader["No"].ToString();
                MedicineNo = sqlDataReader["MedicineNo"].ToString();
                this.txb_Count.Text = sqlDataReader["Amount"].ToString();

            }   
            
            CommandText =
                $@"SELECT* FROM tb_Medicine WHERE No='{MedicineNo}'";
            sqlDataReader =
                     this.SqlHelper.NewCommand(CommandText)
                    .GetReader();
            if (sqlDataReader.Read())
            {
                this.txb_MedicineName.Text = sqlDataReader["Name"].ToString();
            }
            
            CommandText =
                $@"select * from tb_IsMedicineRequest where ReQuestNo='{txb_No.Text}'";
            sqlDataReader =
                     this.SqlHelper.NewCommand(CommandText)
                    .GetReader();
            if (sqlDataReader.Read())
            {
                this.txb_ReallyCount.Text = sqlDataReader["Amount"].ToString();
                txb_ReallyCount.ReadOnly = true;
                btn_Close.Visible = true;
                btn_Close.Enabled = true;
                btn_Ok.Enabled = false;
                btn_Ok.Visible = false;
            }
        }
        /// <summary>
        /// 点击审批
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            //变量转化
            int Amount = int.Parse(txb_ReallyCount.Text.Trim());
            string CommandText =
                $@"INSERT tb_IsMedicineRequest (Amount ,ReQuestNo ,Date ) 
                VALUES 
                ('{Amount}','{txb_No.Text}',GETDATE())";
            int rowAffected = this.SqlHelper.NewCommand(CommandText).NonQuery();
            this.F_Fuction.MessgeShow(rowAffected, "审批成功。", "审批失败！");
            this.Close();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
