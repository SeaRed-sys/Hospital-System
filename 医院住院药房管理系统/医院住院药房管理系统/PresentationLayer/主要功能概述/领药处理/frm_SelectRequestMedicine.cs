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
using 医院住院药房管理系统.DataAccessLayer;
using 医院住院药房管理系统.PresentationLayer;

namespace 医院住院药房管理系统.主要功能概述.领药处理
{
    public partial class frm_SelectRequestMedicine : Form
    {
        /// <summary>
        /// 一般方法
        /// </summary>
        private F_Fuction F_Fuction;
        /// <summary>
        /// SQL助手
        /// </summary>
        private SQLHepler SqlHelper;
        public frm_SelectRequestMedicine()
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
            this.F_Fuction = new F_Fuction();
            this.SqlHelper = new SQLHepler();
        }   

        private string _No;
        /// <summary>
        /// 构造函数；
        /// </summary>
        /// <param name="studentNo">用户名</param>
        public frm_SelectRequestMedicine(string No) : this()
        {
            this._No = No;
        }
        //窗体加载请领单表
        // 分页设置
        int pageSize = 5; // 每页显示的项数
        int currentPage = 1; // 当前页码

        /// <summary>
        /// 创建分页的方法
        /// </summary>
        /// <param name="pageNumber"></param>
        private void LoadPage(int pageNumber)
        {
            // 构造分页查询SQL语句
            string  CommandText = @"
                            SELECT *
                            FROM (
							SELECT 
		                        ROW_NUMBER() OVER (ORDER BY MR.No ASC) AS 序号,
		                        MR.No 请领单编号,M.Name 药品名称,
		                        MR.Amount 请领数量,TM.Name 请领人姓名,MR.Date 请领日期,'已审' as 状态
                                FROM
		                        tb_Medicine AS M ,tb_MedicineRequest AS MR,tb_TakeMedicineMan as TM
		                        WHERE M.NO=MR.MedicineNo AND TM.No=MR.TakeNo AND MR.No IN 
		                        (SELECT IMR.ReQuestNo FROM tb_IsMedicineRequest AS IMR )
                                UNION ALL
                                SELECT 
		                        ROW_NUMBER() OVER (ORDER BY MR.No ASC) AS 序号,
		                        MR.No 请领单编号,M.Name 药品名称,
		                        MR.Amount 请领数量,TM.Name 请领人姓名,MR.Date 请领日期,'未审' as 状态
		                        FROM
		                        tb_Medicine AS M ,tb_MedicineRequest AS MR,tb_TakeMedicineMan as TM
		                        WHERE M.NO=MR.MedicineNo AND TM.No=MR.TakeNo AND MR.No NOT IN
                            	(SELECT IMR.ReQuestNo FROM tb_IsMedicineRequest AS IMR )) AS SubQuery
								WHERE 序号 BETWEEN @Skip AND @Take;";
            DataTable table = this.F_Fuction.LoadPage(pageNumber, pageSize, CommandText);
            dgv_RequestMedicine.DataSource = table;         
        }
        // 上一页按钮点击事件
        private void btn_Pre_Click_1(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadPage(currentPage);
            }
        }
        // 下一页按钮点击事件
        private void btn_Late_Click_1(object sender, EventArgs e)
        {
            currentPage++;
            LoadPage(currentPage);
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_SelectRequestMedicine_Load(object sender, EventArgs e)
        {
            LoadPage(currentPage);
        }
        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 点击审批按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            string RequestNo = dgv_RequestMedicine.CurrentRow.Cells[1].Value.ToString();
            frm_HasRequest frm_HasRequest = new frm_HasRequest(RequestNo);
            frm_HasRequest.FormClosed += aFrmContent_FormClosed;
            frm_HasRequest.ShowDialog();
        }
        private void aFrmContent_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.frm_SelectRequestMedicine_Load(null, null);
        }
        /// <summary>
        /// 显示当天未完成请领
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdb_ShowNoCurrent_Click(object sender, EventArgs e)
        {
            string CommandText = $@"
                                    SELECT 
		                            ROW_NUMBER() OVER (ORDER BY MR.No ASC) AS 序号,
		                            MR.No 请领单编号,M.Name 药品名称,
		                            MR.Amount 请领数量,TM.Name 请领人姓名,MR.Date 请领日期,'未审' as 状态
		                            FROM
		                            tb_Medicine AS M ,tb_MedicineRequest AS MR,tb_TakeMedicineMan as TM
		                            WHERE M.NO=MR.MedicineNo AND MR.Date=CONVERT(DATE, GETDATE()) AND TM.No=MR.TakeNo AND MR.No NOT IN
                            		(SELECT IMR.ReQuestNo FROM tb_IsMedicineRequest AS IMR )
                                            ";
            DataTable dataTable=
                        this.SqlHelper.NewCommand(CommandText).GetTable();
                        dgv_RequestMedicine.DataSource = dataTable;
        }
        /// <summary>
        /// 显示当天完成请领
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdb_ShowCurrent_Click(object sender, EventArgs e)
        {
            string CommandText = $@"SELECT 
		                            ROW_NUMBER() OVER (ORDER BY MR.No ASC) AS 序号,
		                            MR.No 请领单编号,M.Name 药品名称,
		                            MR.Amount 请领数量,TM.Name 请领人姓名,MR.Date 请领日期,'已审' as 状态
                                    FROM
		                            tb_Medicine AS M ,tb_MedicineRequest AS MR,tb_TakeMedicineMan as TM
		                            WHERE M.NO=MR.MedicineNo AND MR.Date=CONVERT(DATE, GETDATE()) AND TM.No=MR.TakeNo AND MR.No  IN 
		                            (SELECT IMR.ReQuestNo FROM tb_IsMedicineRequest AS IMR  )
                                            ";
            DataTable dataTable =
                        this.SqlHelper.NewCommand(CommandText).GetTable();
            dgv_RequestMedicine.DataSource = dataTable;
        }
        /// <summary>
        /// 显示历史未完成请领
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdb_ShowNoHistory_Click(object sender, EventArgs e)
        {
            string CommandText = $@"SELECT 
		                            ROW_NUMBER() OVER (ORDER BY MR.No ASC) AS 序号,
		                            MR.No 请领单编号,M.Name 药品名称,
		                            MR.Amount 请领数量,TM.Name 请领人姓名,MR.Date 请领日期,'未审' as 状态
                                    FROM
		                            tb_Medicine AS M ,tb_MedicineRequest AS MR,tb_TakeMedicineMan as TM
		                            WHERE M.NO=MR.MedicineNo  AND TM.No=MR.TakeNo AND MR.No not IN 
		                            (SELECT IMR.ReQuestNo FROM tb_IsMedicineRequest AS IMR )
                                            ";
            DataTable dataTable =
                        this.SqlHelper.NewCommand(CommandText).GetTable();
            dgv_RequestMedicine.DataSource = dataTable;
        }
        /// <summary>
        /// 显示历史已完成请领
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdb_ShowHistory_Click(object sender, EventArgs e)
        {
            string CommandText = $@"SELECT 
		                            ROW_NUMBER() OVER (ORDER BY MR.No ASC) AS 序号,
		                            MR.No 请领单编号,M.Name 药品名称,
		                            MR.Amount 请领数量,TM.Name 请领人姓名,MR.Date 请领日期,'已审' as 状态
                                    FROM
		                            tb_Medicine AS M ,tb_MedicineRequest AS MR,tb_TakeMedicineMan as TM
		                            WHERE M.NO=MR.MedicineNo AND TM.No=MR.TakeNo AND MR.No IN 
		                            (SELECT IMR.ReQuestNo FROM tb_IsMedicineRequest AS IMR )
                                            ";
            DataTable dataTable =
           this.SqlHelper.NewCommand(CommandText).GetTable();
            dgv_RequestMedicine.DataSource = dataTable;
        }
    }
}
