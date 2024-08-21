using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using 医院住院药房管理系统.DataAccessLayer;
using 医院住院药房管理系统.PresentationLayer.主要功能概述.库存汇总;
using 医院住院药房管理系统.PresentationLayer.主要功能概述.报表统计;
using 医院住院药房管理系统.主要功能概述.入房处理;
using 医院住院药房管理系统.主要功能概述.出房处理;
using 医院住院药房管理系统.主要功能概述.库存处理;
using 医院住院药房管理系统.主要功能概述.报销处理;
using 医院住院药房管理系统.主要功能概述.系统设置;
using 医院住院药房管理系统.主要功能概述.药品盘点;
using 医院住院药房管理系统.主要功能概述.领药处理;

namespace 医院住院药房管理系统
{
    public partial class frm_Homepage : Form
    {
        /// <summary>
        /// SQL助手
        /// </summary>
        private SQLHepler SqlHelper;
        public frm_Homepage()
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
        private int _UserType;
        /// <summary>
        /// 构造函数；
        /// </summary>
        /// <param name="studentNo">操作人员</param>
        public frm_Homepage(string No ,int UserType) : this()
        {
            this._No = No;
            this._UserType = UserType;
        }
        //主界面显示个人信息
        private void frm_Homepage_Load(object sender, EventArgs e)
        {
            if (_UserType !=1)
            {
                btn_OutHall.Visible = false;
                btn_EnterStore.Visible = false;
                btn_RequestMedicine.Visible = false;
                btn_Express.Visible = false;
                btn_Enter.Visible = false;
                btn_Inventory.Visible = false;
            }
            string CommandText =
                $@"SELECT * FROM tb_Operator WHERE NO=@No;";
            SqlDataReader sqlDataReader =
                            this.SqlHelper.NewCommand(CommandText)
                            .NewParameter("@No", this._No)
                            .GetReader();
            byte[] photoBytes = null;
            if (sqlDataReader.Read())
            {
                string name=sqlDataReader["No"].ToString()+ sqlDataReader["Name"].ToString();
                this.lblName.Text = name;
                photoBytes =
                    (sqlDataReader["Photo"] == DBNull.Value ? null : (byte[])sqlDataReader["Photo"]);
            }
            else
            {
                this.lblName.Text = "普通用户";
            }
            if (photoBytes != null)
            {
                MemoryStream memoryStream = new MemoryStream(photoBytes);
                this.pct_Img.Image = Image.FromStream(memoryStream);
            }
        }
        /// <summary>
        /// 退出主界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult messageboxResult =                                                 //定义对话框操作结果，用于接收消息框操作结果；
                MessageBox.Show                                                             //消息框的Show方法除了显示消息框，还能在用户完成对消息框的操作后，返回消息框操作结果；
                ("即将退出医院住院药房管理系统，请确认是否关闭！",
                 "警告",
                 MessageBoxButtons.YesNo,                                                   //消息框按钮；
                 MessageBoxIcon.Warning);
            if (messageboxResult == DialogResult.Yes)                                       //若消息框操作结果为是；
            {
                MessageBox.Show("记得给五星好评哦^-^");
                frm_Login logIn = new frm_Login();
                logIn.Show();
                this.Close();
            }
        }
        private void btn_EnterStore_Click(object sender, EventArgs e)
        {
            frm_MedicineStore frm_MedicineStore = new frm_MedicineStore(this._No);
            frm_MedicineStore.Show();
        }

        private void btn_RequestMedicine_Click(object sender, EventArgs e)
        {
            frm_RequestMedicine frm_RequestMedicine = new frm_RequestMedicine(this._No);
            frm_RequestMedicine.Show();
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            frm_EnterHall frm_EnterHall = new frm_EnterHall(this._No);
            frm_EnterHall.Show();
        }

        private void lblName_Click(object sender, EventArgs e)
        {
            frm_ShowPersonal frm_ShowPersonal = new frm_ShowPersonal(this._No);
            frm_ShowPersonal.FormClosed += aFrmContent_FormClosed;
            frm_ShowPersonal.ShowDialog();
        }
        private void aFrmContent_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.frm_Homepage_Load(null, null);
        }

        private void btn_OutHall_Click(object sender, EventArgs e)
        {
            frm_OutHall frm_OutHall = new frm_OutHall(_No);
            frm_OutHall.Show();
        }

        private void btn_Express_Click(object sender, EventArgs e)
        {
            frm_SubmitExpress frm_SubmitExpress = new frm_SubmitExpress(this._No);
            frm_SubmitExpress.Show();
        }

        private void btn_Inventory_Click(object sender, EventArgs e)
        {
            frm_MedicineInventory frm_MedicineInventory = new frm_MedicineInventory(this._No);
            frm_MedicineInventory.Show();
        }

        private void btn_Interface_Click(object sender, EventArgs e)
        {
            frm_MainInterface frm_MainInterface = new frm_MainInterface(this._No);
            frm_MainInterface.FormClosed += aFrmContent_FormClosed;
            frm_MainInterface.Show();
        }
        private void aFrmContent1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.frm_Homepage_Load(null, null);
        }

        private void btn_Report_Click(object sender, EventArgs e)
        {
            frm_ReportMedicine frm_ReportMedicine = new frm_ReportMedicine(this._No);
            frm_ReportMedicine.Show();
        }

        private void btn_Summary_Click(object sender, EventArgs e)
        {
            frm_InventorySummary frm_InventorySummary = new frm_InventorySummary(this._No);
            frm_InventorySummary.Show();
        }
    }
   
}
