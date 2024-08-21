using SmartLinli.DatabaseDevelopement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 医院住院药房管理系统.DataAccessLayer;
using 医院住院药房管理系统.PresentationLayer;

namespace 医院住院药房管理系统.主要功能概述.入房处理
{
    public partial class frm_EnterHall : Form
    {
        ///<summary>
        /// 一般方法
        /// </summary>
        private F_Fuction F_Fuction;
        /// <summary>
        /// SQL助手
        /// </summary>
        private SQLHepler SqlHelper;

        public frm_EnterHall()
        {
            InitializeComponent();
            this.AcceptButton = this.btn_Sure;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosed += (_, __) =>
            {
                if (Application.OpenForms.Count == 0)
                {
                    Application.Exit();
                }
            };
            InitListView();
            this.SqlHelper = new SQLHepler();
            this.F_Fuction = new F_Fuction();
        }
        //窗体属性和构造函数
        private string _No;
        /// <summary>
        /// 构造函数；
        /// </summary>
        /// <param name="studentNo">用户名</param>
        public frm_EnterHall(string No) : this()
        {
            this._No = No;
        }
        /// <summary>
        /// 加载列表
        /// </summary>
        private void InitListView()
        {
            // 设置显示模式
            lv_Medicine.View = View.Details;
            // 整行选中
            lv_Medicine.FullRowSelect = true;

            // 设置列名
            // 宽度值-2表示自动调整宽度
            lv_Medicine.Columns.Add("序号 ", 50, HorizontalAlignment.Center);
            lv_Medicine.Columns.Add("请领单号 ", 150, HorizontalAlignment.Center);
            lv_Medicine.Columns.Add("药品编号", 110, HorizontalAlignment.Left);
            lv_Medicine.Columns.Add("药品名称", 130, HorizontalAlignment.Left);
            lv_Medicine.Columns.Add("药品规格", 130, HorizontalAlignment.Left);
            lv_Medicine.Columns.Add("入房数量", 100, HorizontalAlignment.Left);
            lv_Medicine.Columns.Add("药品单价", 80, HorizontalAlignment.Left);
            lv_Medicine.Columns.Add("出库时间", 150, HorizontalAlignment.Center);
            lv_Medicine.Columns.Add("请领人", 100, HorizontalAlignment.Left);
            lv_Medicine.Columns.Add("操作人员工号", 110, HorizontalAlignment.Left);
            lv_Medicine.Columns.Add("操作人员", 90, HorizontalAlignment.Center);
        }
        // 分页设置
        int pageSize = 10; // 每页显示的项数
        int currentPage = 1; // 当前页码

        /// <summary>
        /// 创建分页的方法
        /// </summary>
        /// <param name="pageNumber"></param>
        private void LoadPage(int pageNumber)
        {
            // 构造分页查询SQL语句
            string CommandText = @"
            SELECT *
            FROM (
            SELECT 
                ROW_NUMBER() OVER (ORDER BY MR.No ASC) AS 序号,
                IMR.ReQuestNo 请领单号, M.No 药品编号,M.Name 药品名称,M.Standard 药品规格,
                IMR.Amount 入房数量,M.Price3 药品单价,TM.Name 请领人,
                o.NO 操作人员工号,o.Name 操作人员,IMR.Date 出库时间
                FROM
                tb_Medicine AS M,tb_IsMedicineRequest AS IMR,
                tb_Operator AS O,tb_TakeMedicineMan AS TM,
                tb_MedicineRequest AS MR
                WHERE M.No=MR.MedicineNo AND IMR.ReQuestNo=MR.No 
                AND MR.OperatorNo=O.NO AND MR.TakeNo =TM.No
                AND IMR.ReQuestNo NOT IN
				(SELECT ME.RequestNo FROM tb_MedicineEnterHall AS ME)
            ) AS SubQuery
            WHERE 序号 BETWEEN @Skip AND @Take ";
            DataTable table = this.F_Fuction.LoadPage(pageNumber, pageSize, CommandText);
            // 清除ListView中的现有项
            lv_Medicine.Items.Clear();
            // 将DataTable中的数据绑定到ListView
            foreach (DataRow row in table.Rows){

                ListViewItem item = new ListViewItem(row["序号"].ToString());
                // 添加其他列
                item.SubItems.Add(row["请领单号"].ToString());
                item.SubItems.Add(row["药品编号"].ToString());
                item.SubItems.Add(row["药品名称"].ToString());
                item.SubItems.Add(row["药品规格"].ToString());
                item.SubItems.Add(row["入房数量"].ToString());
                item.SubItems.Add(row["药品单价"].ToString());
                item.SubItems.Add(row["出库时间"].ToString());
                item.SubItems.Add(row["请领人"].ToString());
                item.SubItems.Add(row["操作人员工号"].ToString());
                item.SubItems.Add(row["操作人员"].ToString());
                lv_Medicine.Items.Add(item);
            }     
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
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_EnterHall_Load(object sender, EventArgs e)
        {
            LoadPage(currentPage);
        }
        /// <summary>
        /// 点击列表，显示具体信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lv_Medicine_Click(object sender, EventArgs e)
        {
            string MedicineNo = this.lv_Medicine.SelectedItems[0].SubItems[2].Text;
            this.txb_EnterCount.Text = this.lv_Medicine.SelectedItems[0].SubItems[5].Text; 

            string CommandText =
                $@"SELECT 
                M.BatchDate,M.BatchUnit,M.BatchNo,M.LoginUnit
                ,M.UseDate ,M.LifeSpan,MI.ApprovalNumber,MI.isHasQualified
                ,MI.isQualified,MI.PurchaseDate,MI.Supplier
                FROM tb_Medicine AS M
                ,tb_MedicineInventory AS MI
                WHERE M.No=MI.MedicineNo AND M.No='{MedicineNo} ';";
            this.SqlHelper = new SQLHepler();
            SqlDataReader sqlDataReader =
             this.SqlHelper.NewCommand(CommandText).GetReader();
            if (sqlDataReader.Read())
            {
                this.txb_ApprovalNumber.Text = sqlDataReader["ApprovalNumber"].ToString();
                this.txb_BatchDate.Text = sqlDataReader["BatchDate"].ToString();
                this.txb_BatchNo.Text = sqlDataReader["BatchNo"].ToString();
                this.txb_BatchUnit.Text = sqlDataReader["BatchUnit"].ToString();
                this.txb_EnterDate.Text = sqlDataReader["PurchaseDate"].ToString();
                this.txb_LifeSpan.Text = sqlDataReader["LifeSpan"].ToString();
                this.txb_LoginUnit.Text = sqlDataReader["LoginUnit"].ToString();
                this.txb_Supplier.Text = sqlDataReader["Supplier"].ToString();
                this.txb_UseDate.Text = sqlDataReader["UseDate"].ToString();
            }
            CommandText=
                $@"Select * from tb_YesNo";
            DataTable YesNoTable = this.SqlHelper.NewCommand(CommandText).GetTable();
            this.F_Fuction.Comshow(cb_isQualified, "No","Text",YesNoTable);
            this.F_Fuction.Comshow(cb_isHaveQualified, "No","Text",YesNoTable);
        }
        /// <summary>
        /// 确认入房
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Sure_Click(object sender, EventArgs e)
        {
            //变量
            string RequreNo = this.lv_Medicine.SelectedItems[0].SubItems[1].Text;
            string MedicineNo = this.lv_Medicine.SelectedItems[0].SubItems[2].Text;
            int Count = int.Parse(this.lv_Medicine.SelectedItems[0].SubItems[5].Text);
            
            string CommandText =
                     $@"INSERT tb_MedicineEnterHall (RequestNo,MedicineNo,OperatorNo,Date,Amount) 
                        VALUES 
                        ('{RequreNo}','{MedicineNo}','{this._No}','{dtp_Date.Value.ToString()}',{Count})";
            int rowAffected = this.SqlHelper.NewCommand(CommandText).NonQuery();
            this.F_Fuction.MessgeShow(rowAffected, "入房成功。", "入房失败！");
            CommandText =
                     $@"UPDATE tb_MedicineInventory
                        SET AMOUNT-='{Count}' ,UpdateTime=GETDATE()
                        WHERE No=(SELECT EnterNo FROM tb_MedicineRequest WHERE No='{RequreNo}')";
            this.SqlHelper.NewCommand(CommandText).GetCom();
            this.frm_EnterHall_Load(null, null);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_SelcectRecord_Click(object sender, EventArgs e)
        {
            frm_SelcectEnterHall frm_SelcectEnterHall = new frm_SelcectEnterHall(this._No);
            frm_SelcectEnterHall.ShowDialog();

        }
    }
}

