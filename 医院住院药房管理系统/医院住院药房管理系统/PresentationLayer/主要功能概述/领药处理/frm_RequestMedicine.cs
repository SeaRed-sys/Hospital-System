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
    public partial class frm_RequestMedicine : Form
    {
        /// <summary>
        /// SQL助手
        /// </summary>
        private SQLHepler SqlHelper;
        /// <summary>
        /// 一般方法
        /// </summary>
        private F_Fuction F_Fuction;
        public frm_RequestMedicine()
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
        public frm_RequestMedicine(string No) : this()
        {
            this._No = No;
        }
        /// <summary>
        /// 设置入库单号
        /// </summary>
        private void AddNo()
        {
            string CommandText =
             $@"declare  
                @x1 int,  
                @y1 char(8)
                select @x1= COUNT(No) from tb_MedicineRequest where CAST(Date as date)=CAST(GETDATE() as date)
                if(@x1=0)  
                begin  
                select @y1=convert(char(8),getdate(),112)  
                Select distinct 'R'+@y1+'0001' No from tb_MedicineRequest  
                end
                else  
                begin  
                Select 'R'+cast((select MAX(CAST( SUBSTRING(No,2,11) as bigint))+1 from tb_MedicineRequest where CAST(Date as date)=CAST(GETDATE() as date))as varchar(50)) No  from tb_MedicineRequest      
                end ;";
            SqlDataReader sqlDataReader =
                        this.SqlHelper.NewCommand(CommandText)
                        .GetReader();
            if (sqlDataReader.Read())
            {
                txb_RequestNo.Text = sqlDataReader["No"].ToString();
            }
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_RequestMedicine_Load(object sender, EventArgs e)
        {
            LoadPage(currentPage);
            string commandText =
                $@"SELECT MI.No ,M.Name   
                    FROM tb_Medicine AS M,tb_MedicineInventory AS MI 
                    WHERE M.No=MI.MedicineNo;";
            DataTable MedicneT = this.SqlHelper.NewCommand(commandText).GetTable();
            this.F_Fuction.Comshow(cb_MedicineName, "No", "Name", MedicneT);
            commandText = $@"SELECT *FROM tb_TakeMedicineMan;";
            DataTable RequestNameT = this.SqlHelper.NewCommand(commandText).GetTable();
            this.F_Fuction.Comshow(cb_RequestName, "No", "Name", RequestNameT);            
        }
        /// <summary>
        /// 跳转到查询请领单窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Select_Click(object sender, EventArgs e)
        {
            frm_SelectRequestMedicine frm_SelectRequestMedicine = new frm_SelectRequestMedicine(this._No);
            frm_SelectRequestMedicine.Show();
        }
        /// <summary>
        /// 关闭窗体回到主界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 增加请领单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            //文本框的变量类型转换
            string MedicineNo="",TakeNo="";
            string MedicineName= this.cb_MedicineName.Text.Trim();
            string RequestName = this.cb_RequestName.Text.Trim();
            int count = int.Parse(this.txb_EnterCount.Text.Trim());

            string CommandText = $@"SELECT * FROM tb_Medicine where Name=@Name";
            SqlDataReader sqlDataReader =
                    this.SqlHelper.NewCommand(CommandText)
                    .NewParameter("@Name", MedicineName)
                    .GetReader();
            if (sqlDataReader.Read())
            {
                MedicineNo = sqlDataReader["No"].ToString(); 
            }

            CommandText = $@"SELECT * FROM tb_TakeMedicineMan WHERE Name=@Name;";
            sqlDataReader =
                    this.SqlHelper.NewCommand(CommandText)
                    .NewParameter("@Name", RequestName)
                    .GetReader();
            if (sqlDataReader.Read())
            {
                TakeNo = sqlDataReader["No"].ToString();
            }

            CommandText =
             $@"INSERT tb_MedicineRequest 
                (No,EnterNo,MedicineNo ,TakeNo ,Amount ,Date ,OperatorNo) 
                VALUES 
                ('{this.txb_RequestNo.Text}','{cb_MedicineName.SelectedValue}','{MedicineNo}','{TakeNo}'
                ,{count},'{dtp_Time.Value.ToString()}','{_No}')";
            int rowAffected = this.SqlHelper.NewCommand(CommandText).NonQuery();
            this.F_Fuction.MessgeShow(rowAffected, "请领成功。", "请领失败！");
            frm_RequestMedicine_Load(null, null);
            
            //清除文本框
            this.txb_EnterCount.Clear(); this.txb_RequestNo.Clear();
            this.cb_MedicineName.SelectedIndex = -1; this.cb_RequestName.SelectedIndex = -1;
        }
        // 分页设置
        int pageSize = 14; // 每页显示的项数
        int currentPage = 1; // 当前页码
        /// <summary>
        /// 创建分页
        /// </summary>
        /// <param name="pageNumber"></param>
        private void LoadPage(int pageNumber)
        {
            // 构造分页查询SQL语句
            string CommandText = @"SELECT *
                            FROM (
							SELECT 
                                ROW_NUMBER() OVER (ORDER BY MR.Date deSC) AS 序号,
                                MR.No 请领单编号,M.No 药品编号,M.Name 药品名称,M.Standard 药品规格,MH.No 医药机构编号,MR.Amount 请领数量,TM.Name 请领人姓名,MR.OperatorNo 操作员工号, MR.Date 操作日期
                                FROM
                                tb_Medicine AS M ,tb_MedicineRequest AS MR,tb_MedicineHall as MH,tb_TakeMedicineMan as TM
                                WHERE M.NO=MR.MedicineNo AND TM.No=MR.TakeNo) AS SubQuery
								WHERE 序号 BETWEEN @Skip AND @Take ";
            DataTable table = this.F_Fuction.LoadPage(pageNumber, pageSize, CommandText);
            dgv_RequestMedicine.DataSource = table;
                      
        }
        // 上一页按钮点击事件
        private void btn_Pre_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadPage(currentPage);
            }
        }
        // 下一页按钮点击事件
        private void btn_Late_Click(object sender, EventArgs e)
        {
            currentPage++;
            LoadPage(currentPage);
        }
        /// <summary>
        ///自动获取请领单流水号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_RequestNo_Click(object sender, EventArgs e)
        {
            AddNo();
        }
    }
}
