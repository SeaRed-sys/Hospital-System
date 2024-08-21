using System;
using System.Data;
using System.Windows.Forms;
using 医院住院药房管理系统.DataAccessLayer;
using 医院住院药房管理系统.PresentationLayer;

namespace 医院住院药房管理系统.主要功能概述.入房处理
{
    public partial class frm_SelcectEnterHall : Form
    {
        ///<summary>
        /// 一般方法
        /// </summary>
        private F_Fuction F_Fuction;
        /// <summary>
        /// SQL助手
        /// </summary>
        private SQLHepler SqlHelper;
        public frm_SelcectEnterHall()
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
        //.窗体属性和构造函数
        private string _No;
        /// <summary>
        /// 构造函数；
        /// </summary>
        /// <param name="studentNo">用户名</param>
        public frm_SelcectEnterHall(string No) : this()
        {
            this._No = No;
        }
        // 分页设置
        int pageSize = 8; // 每页显示的项数
        int currentPage = 1; // 当前页码


        // 创建分页的方法
        private void LoadPage(int pageNumber)
        {
            // 构造分页查询SQL语句
            string CommandText = @"
            SELECT *
            FROM (                   
		    SELECT
			ROW_NUMBER() OVER (ORDER BY ME.Date deSC) AS 序号,
            ME.No 入房单号,ME.RequestNo 请领单号,ME.MedicineNo 药品编号,M.Name 药品名称
            ,M.Standard 药品规格,ME.Amount 入房数量,ME.Date 入房时间,ME.OperatorNo 操作人员工号
            FROM tb_MedicineEnterHall AS ME,tb_Medicine AS M
            WHERE ME.MedicineNo=M.No) AS SubQuery
			WHERE 序号 BETWEEN @Skip AND @Take";
            DataTable table = this.F_Fuction.LoadPage(pageNumber, pageSize, CommandText);
            dgv_Select.DataSource = table;            
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
        private void frm_SelcectEnterHall_Load(object sender, EventArgs e)
        {
            LoadPage(currentPage);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
