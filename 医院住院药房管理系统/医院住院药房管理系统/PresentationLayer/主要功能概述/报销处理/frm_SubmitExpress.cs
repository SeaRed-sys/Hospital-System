using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;
using 医院住院药房管理系统.DataAccessLayer;
using 医院住院药房管理系统.PresentationLayer;

namespace 医院住院药房管理系统.主要功能概述.报销处理
{
    public partial class frm_SubmitExpress : Form
    {
        /// <summary>
        /// 一般方法
        /// </summary>
        private F_Fuction F_Fuction;
        /// <summary>
        /// SQL助手
        /// </summary>
        private SQLHepler SqlHelper;

        public frm_SubmitExpress()
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
            this.F_Fuction = new F_Fuction();
            this.SqlHelper = new SQLHepler();
        }
        private string _No;
        private string _EnterNo;
        /// <summary>
        /// 构造函数；
        /// </summary>
        /// <param name="studentNo">用户名</param>
        public frm_SubmitExpress(string No) : this()
        {
            this._No = No;
        }
        /// <summary>
        /// 加载报损人
        /// </summary>
        private void Man_Load()
        {
            string  CommandText =
                    $@"SELECT * FROM tb_Nurse";
            DataTable table =
                        this.SqlHelper.NewCommand(CommandText).GetTable();
            this.F_Fuction.Comshow(cb_Man, "No", "Name",table);           
        }
        /// <summary>
        /// 加载入库号
        /// </summary>
        private void EnterNo_Load()
        {
            string CommandText =
                    $@"SELECT * FROM tb_MedicineInventory";
            DataTable table =
                        this.SqlHelper.NewCommand(CommandText).GetTable();
            this.F_Fuction.Comshow(cb_EnterHall, "No", "No", table);
        }
        /// <summary>
        /// 加载入库号
        /// </summary>
        private void Result_Load()
        {
            string CommandText =
                    $@"SELECT * FROM tb_OutDateResult";
            DataTable table =
                        this.SqlHelper.NewCommand(CommandText).GetTable();
            this.F_Fuction.Comshow(cb_Result, "No", "Text", table);
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_SubmitExpress_Load(object sender, EventArgs e)
        {
            EnterNo_Load();
            Man_Load();
            Result_Load();
            LoadPage(currentPage);
        }
        /// <summary>
        /// 选择入库单号，显示药品信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void cb_EnterHall_SelectedIndexChanged(object sender, EventArgs e)
        {
            txb_ReallyCount.Clear();txb_EnterCount.Clear();
            txb_MedicineName.Clear();txb_OutNo.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = connectionString;
            string CommandText =
                                $@"SELECT M.Name 药品名称,*  FROM 
                                tb_MedicineInventory AS MI,tb_Medicine AS M
                                WHERE MI.MedicineNo=M.No
                                AND MI.No='{this.cb_EnterHall.Text}';";
            SqlDataReader sqlDataReader =
            this.SqlHelper.NewCommand(CommandText)
                          .GetReader();
            if (sqlDataReader.Read())
            {
                txb_MedicineName.Text = sqlDataReader["药品名称"].ToString();
                txb_IsLook.Text = sqlDataReader["isQualified"].ToString();
                txb_IsPass.Text = sqlDataReader["isHasQualified"].ToString();
                txb_EnterTime.Text = sqlDataReader["OperateTime"].ToString();
                txb_BatchNo.Text = sqlDataReader["BatchNo"].ToString();
                txb_BatchUnit.Text = sqlDataReader["BatchUnit"].ToString();
                txb_SignUp.Text = sqlDataReader["LoginUnit"].ToString();
                txb_ProvalNo.Text = sqlDataReader["ApprovalNumber"].ToString();
                txb_TimeSpan.Text = sqlDataReader["LifeSpan"].ToString();
                txb_Supplier.Text= sqlDataReader["Supplier"].ToString();
                txb_UseDate.Text= sqlDataReader["UseDate"].ToString();
                dtp_Birthday.Value = (DateTime)sqlDataReader["BatchDate"];
                dtp_EnterTime.Value = (DateTime)sqlDataReader["PurchaseDate"];
            }
            CommandText =
                        $@"SELECT MI.Amount 库存量,ME.Amount 入房数量,IMR.ReQuestNo 入库单号,ME.No 入房单号
                        FROM 
                        tb_MedicineInventory AS MI,tb_MedicineRequest AS MR,tb_MedicineEnterHall AS ME,tb_IsMedicineRequest AS IMR
                        WHERE MI.No=MR.EnterNo AND MR.No=ME.RequestNo AND IMR.ReQuestNo=MR.NO
                        AND MI.No='{this.cb_EnterHall.Text}';";
            sqlDataReader =
            this.SqlHelper.NewCommand(CommandText)
                          .GetReader();
            if (sqlDataReader.Read())
            {
                txb_EnterCount.Text = sqlDataReader["入房数量"].ToString();
                txb_ReallyCount.Text = sqlDataReader["库存量"].ToString();
                txb_OutNo.Text= sqlDataReader["入库单号"].ToString();
                this._EnterNo= sqlDataReader["入房单号"].ToString();
            }
            if(txb_EnterCount.Text=="")
            {
                CommandText =
                            $@"SELECT MI.Amount-IMR.Amount 库存量,IMR.Amount 入房数量,IMR.ReQuestNo 入库单号
                            FROM 
                            tb_MedicineInventory AS MI,tb_MedicineRequest AS MR,tb_MedicineEnterHall AS ME,tb_IsMedicineRequest AS IMR
                            WHERE 
                            MI.No='{this.cb_EnterHall.Text}';";
                sqlDataReader =
                    this.SqlHelper.NewCommand(CommandText)
                                  .GetReader();
                if (sqlDataReader.Read())
                {
                    txb_EnterCount.Text = "0";
                    txb_ReallyCount.Text = sqlDataReader["库存量"].ToString();
                    txb_OutNo.Text = "无";
                }
            }
        }
        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 添加报销记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            int amount = int.Parse(txb_ReCount.Text);
            string CommandText =
            $@"INSERT tb_MedicineBad (StoreNo ,Amount ,OperatorNo ,Date,Result  ) 
            VALUES 
            ('{cb_EnterHall.Text}',{amount},'{this._No}','{dtp_Time.Value}','{cb_Result.Text}')";
            string updateCommandText =                                                                     //指定SQL命令的命令文本；该命令更新教材订购状态；
                $@"UPDATE tb_MedicineEnterHall 
			SET Amount-='{amount}'
			WHERE No='{_EnterNo}';";
            this.SqlHelper.NewCommand(updateCommandText).NonQuery(); ;
            int rowAffected = this.SqlHelper.NewCommand(CommandText).NonQuery() ;                                                                        //声明整型变量，用于保存受影响行数；
            this.F_Fuction.MessgeShow(rowAffected, "审批成功。", "审批失败！");
            LoadPage(currentPage);

        }
        /// <summary>
        /// 进入报销界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Enter_Click(object sender, EventArgs e)
        {
            frm_ReturnStock frm_ReturnStock = new frm_ReturnStock(this._No);
            frm_ReturnStock.Show();
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
            string CommandText = @"SELECT *
                                    FROM (                   
		                            SELECT 
                                        ROW_NUMBER() OVER (ORDER BY MB.No DESC) AS 序号,MB.StoreNo 入库单号,M.No 药品编号,
                                        M.Name 药品名称,MB.Amount 报损数量,MB.Result 报损原因
                                        ,O.Name 操作人员
                                        FROM 
                                        tb_MedicineBad AS MB,tb_MedicineInventory AS MI,tb_Medicine AS M,tb_Operator AS O
                                        WHERE MB.StoreNo=MI.No AND MI.MedicineNo=M.No AND O.NO=MB.OperatorNo) AS SubQuery
				                    WHERE 序号 BETWEEN @Skip AND @Take ";
            DataTable table = this.F_Fuction.LoadPage(pageNumber, pageSize, CommandText);
            dgv_Medicine.DataSource = table;
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
    }
}
