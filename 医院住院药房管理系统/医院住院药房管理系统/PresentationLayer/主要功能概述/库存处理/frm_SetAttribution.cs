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

namespace 医院住院药房管理系统.主要功能概述.库存处理
{
    public partial class frm_SetAttribution : Form
    {
        /// <summary>
        /// SQL助手
        /// </summary>
        private SQLHepler SqlHelper;
        private F_Fuction F_Fuction;
        public frm_SetAttribution()
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
        private string _MedicineNo;
        /// <summary>
        /// 构造函数；
        /// </summary>
        /// <param name="studentNo">操作人用户名</param>
        public frm_SetAttribution(string No, string MedicineNo) : this()
        {
            this._No = No;
            this._MedicineNo = MedicineNo;
        }
        /// <summary>
        /// 增加房存属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            string CommandText =
            $@"INSERT tb_MedicineAttribute (MedicineNo ,SaveNo1 ,SaveNo2,
                                            MinNo1 ,MinNo2,
                                            MaxNo1,MaxNo2 ) 
                 VALUES
                ('{this._MedicineNo}','{this.txb_SaveNo1.Text}','{this.txb_SaveNo2.Text}'
                 ,'{this.txb_MinNo1.Text}','{this.txb_MinNo2.Text}'
                 ,'{this.txb_MaxNo1.Text}','{this.txb_Max2.Text}')";
            int rowAffected = this.SqlHelper.NewCommand(CommandText).NonQuery();                                                                        //声明整型变量，用于保存受影响行数；
            this.F_Fuction.MessgeShow(rowAffected, "设置成功。", "设置失败！");
            this.Close();
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_SetAttribution_Load(object sender, EventArgs e)
        {
            string CommandText =
                $@"SELECT * from tb_Medicine WHERE No=@No;";
            SqlDataReader sqlDataReader =
                     this.SqlHelper.NewCommand(CommandText)
                    .NewParameter("@No", this._MedicineNo)
                    .GetReader();
            if (sqlDataReader.Read())
            {
                string name = sqlDataReader["Name"].ToString();
                this.txb_Name.Text = name;
            }
        }
    }
}
