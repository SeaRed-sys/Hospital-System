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
using 医院住院药房管理系统.DataAccessLayer;
using 医院住院药房管理系统.PresentationLayer;

namespace 医院住院药房管理系统.主要功能概述
{
    public partial class frm_AddMedicine : Form
    {
        /// <summary>
        /// SQL助手
        /// </summary>
        private SQLHepler SqlHelper;
        /// <summary>
        /// 一般方法
        /// </summary>
        private F_Fuction F_Fuction;
        public frm_AddMedicine()
        {
            InitializeComponent();
            this.AcceptButton = this.btn_Add;
            this.StartPosition = FormStartPosition.CenterScreen;
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
        public frm_AddMedicine(string No) : this()
        {
            this._No = No;
        }
        private string AddMedicineNo()
        {
            string MedicineNo="";
            string CommandText = @"declare @x1 int  
                select @x1= COUNT(No) from tb_Medicine 
                if(@x1=0)  
                begin  
                Select distinct 'M001' No from tb_Medicine
                end
                else  
                begin  
                Select 'M0'+cast((select MAX(CAST( SUBSTRING(No,2,4) as bigint))+1 from tb_Medicine ) as varchar(20)) 编号  
                end ";
            SqlDataReader sqlDataReader = this.SqlHelper.NewCommand(CommandText).GetReader();
            if (sqlDataReader.Read())
            {
                MedicineNo= sqlDataReader["编号"].ToString();
            }
            return MedicineNo;
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            string CommandText =
                $@"INSERT tb_Medicine (No ,Name ,NamePinyin ,Standard ,Type ,Unit ,BatchNo ,BatchUnit ,BatchDate ,LifeSpan ,UseDate ,LoginUnit ,
                                       Price1 ,Price2,Price3 ) 
                VALUES('{this.txb_No.Text}','{this.txb_Name.Text}','{this.txb_NamePinyin.Text}',
                        '{this.cb_Standard.Text}','{this.cb_Type.Text}','{this.cb_Unit.Text}',
                        '{this.txb_BatchNo.Text}','{this.cb_Batch.Text}','{this.dtp_Bir.Value.ToString()}',
                        '{this.txb_LifeSoan.Text}','{this.dtp_Use.Value.ToString()}','{this.cb_Login.Text}',
                        '{this.txb_Price1.Text}','{this.txb_Price2.Text}','{this.txb_Price3.Text}')";
            int rowAffected = this.SqlHelper.NewCommand(CommandText).NonQuery();
            this.F_Fuction.MessgeShow(rowAffected, "添加成功.", "添加失败！");
            
        }

        private void txb_No_Click(object sender, EventArgs e)
        {
            txb_No.Text=AddMedicineNo();
        }
    }
}
