using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using 医院住院药房管理系统.DataAccessLayer;
using 医院住院药房管理系统.PresentationLayer;

namespace 医院住院药房管理系统.主要功能概述.药品盘点
{
    public partial class frm_MedicineInventory : Form
    {
        /// <summary>
        /// 一般方法
        /// </summary>
        private F_Fuction F_Fuction;
        /// <summary>
        /// SQL助手
        /// </summary>
        private SQLHepler SqlHelper;
        public frm_MedicineInventory()
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
        private string _checkNo;
        /// <summary>
        /// 构造函数；
        /// </summary>
        /// <param name="studentNo">用户名</param>
        public frm_MedicineInventory(string No) : this()
        {
            this._No = No;
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_MedicineInventory_Load(object sender, EventArgs e)
        {
            showInvetoryForm(); showMedicineForm();
            showInvetoryType(); showMedicineType(); showMedicineProperty();

        }
        /// <summary>
        /// 加载盘点方法
        /// </summary>
        private void showInvetoryForm()
        {
            string CommandText =
                $@"SELECT * FROM tb_InventoryForm;";
            DataTable dataTable =
            this.SqlHelper.NewCommand(CommandText).GetTable();
            this.F_Fuction.Comshow(cb_Fangshi, "No", "Text", dataTable);
        }
        /// <summary>
        /// 加载盘点方式
        /// </summary>
        private void showInvetoryType()
        {
            string CommandText =
                $@"SELECT * FROM tb_InventoryType;";
            DataTable dataTable =
            this.SqlHelper.NewCommand(CommandText).GetTable();
            this.F_Fuction.Comshow(cb_Type, "No", "Text", dataTable);
        }
        /// <summary>
        /// 加载药品类别
        /// </summary>
        private void showMedicineType()
        {
            string CommandText =
                $@"SELECT * FROM tb_MedicineType;";
            DataTable dataTable =
            this.SqlHelper.NewCommand(CommandText).GetTable();
            this.F_Fuction.Comshow(cb_MedicineType, "No", "Text", dataTable);
        }
        /// <summary>
        /// 加载药品性质
        /// </summary>
        private void showMedicineProperty()
        {
            string CommandText =
                $@"SELECT * FROM tb_MedicineProperty;";
            DataTable dataTable =
                this.SqlHelper.NewCommand(CommandText).GetTable();
            this.F_Fuction.Comshow(cb_MedicineProperty, "No", "Text", dataTable);
        }
        /// <summary>
        /// 加载药品剂型
        /// </summary>
        private void showMedicineForm()
        {
            string CommandText =
                $@"SELECT * FROM tb_MedicineForm;";
            DataTable dataTable =
                this.SqlHelper.NewCommand(CommandText).GetTable();
            this.F_Fuction.Comshow(cb_DosageForm, "No", "Text", dataTable);
        }
        /// <summary>
        /// 关闭窗体
        /// </summary>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 根据选择导出盘点单
        /// </summary>
        private void btn_Look_Click(object sender, EventArgs e)
        {
            // 遍历DataGridView的所有列  
            foreach (DataGridViewColumn column in dgv_Medicine.Columns)
            {
                // 检查列名，并设置ReadOnly属性  
                if (column.Name == "Amount" || column.Name == "Remark" || column.Name == "isCheckColumn")
                {
                    // 对于你想要编辑的列，设置为可编辑  
                    column.Visible=false;
                }
                else
                {
                    // 对于其他列，设置为只读  
                    column.Visible = true;
                }
            }
            btn_Print.Visible = true;            
            LoadPage(currentPage);
        }
        // 分页设置
        int pageSize = 10; // 每页显示的项数
        int currentPage = 1; // 当前页码

        // 创建分页的方法
        private void LoadPage(int pageNumber)
        {
            string commandText = "";
            if (cb_Store.Text.Trim() == "药库" && cb_MedicineType.Text.Trim() == "全部" && cb_MedicineProperty.Text.Trim() == "全部" && cb_DosageForm.Text.Trim() == "全部")
            {
                commandText =
                $@" SELECT *
                        FROM (
                        SELECT
                        ROW_NUMBER() OVER (ORDER BY MI.NO ASC) AS 序号,MI.No 入库单号,M.Name 药品名称,M.Type 药品类型,M.MedicinePropert 药品性质,M.Standard 药品规格,M.MedicineForm 剂型,M.Price3 药品单价, MI.Amount 预计数量
                        FROM
                        tb_Medicine AS M,tb_MedicineInventory AS MI
                        WHERE MI.MedicineNo=M.No) AS SubQuery";
                //WHERE 序号 BETWEEN @Skip AND @Take
            }
            else if (cb_Store.Text.Trim() == "药库" && cb_MedicineType.Text.Trim() != "全部" && cb_MedicineProperty.Text.Trim() == "全部" && cb_DosageForm.Text.Trim() == "全部")
            {
                commandText =
                    $@"SELECT *
                        FROM (
                        SELECT
                        ROW_NUMBER() OVER (ORDER BY MI.NO ASC) AS 序号,MI.No 入库单号,M.Name 药品名称,M.Type 药品类型,M.MedicinePropert 药品性质,M.Standard 药品规格,M.MedicineForm 剂型,M.Price3 药品单价, MI.Amount 预计数量
                        FROM
                        tb_Medicine AS M,tb_MedicineInventory AS MI
                        WHERE MI.MedicineNo=M.No AND M.Type LIKE '%{this.cb_MedicineType.Text.Trim()}%') AS SubQuery
			            ";//WHERE 序号 BETWEEN @Skip AND @Take";
            }
            else if (cb_Store.Text.Trim() == "药库" && cb_MedicineType.Text.Trim() == "全部" && cb_MedicineProperty.Text.Trim() != "全部" && cb_DosageForm.Text.Trim() == "全部")
            {
                commandText =
                    $@"SELECT *
                        FROM (
                        SELECT
                        ROW_NUMBER() OVER (ORDER BY MI.NO ASC) AS 序号,MI.No 入库单号,M.Name 药品名称,M.Type 药品类型,M.MedicinePropert 药品性质,M.Standard 药品规格,M.MedicineForm 剂型,M.Price3 药品单价, MI.Amount 预计数量
                        FROM
                        tb_Medicine AS M,tb_MedicineInventory AS MI
                        WHERE MI.MedicineNo=M.No AND M.MedicinePropert LIKE '%{cb_MedicineProperty.Text.Trim()}%'
                        ) AS SubQuery
			            ";//WHERE 序号 BETWEEN @Skip AND @Take";
            }
            else if (cb_Store.Text.Trim() == "药库" && cb_MedicineType.Text.Trim() == "全部" && cb_MedicineProperty.Text.Trim() == "全部" && cb_DosageForm.Text.Trim() != "全部")
            {
                commandText =
                    $@"SELECT *
                        FROM (
                        SELECT
                        ROW_NUMBER() OVER (ORDER BY MI.NO ASC) AS 序号,MI.No 入库单号,M.Name 药品名称,M.Type 药品类型,M.MedicinePropert 药品性质,M.Standard 药品规格,M.MedicineForm 剂型,M.Price3 药品单价, MI.Amount 预计数量
                        FROM
                        tb_Medicine AS M,tb_MedicineInventory AS MI
                        WHERE MI.MedicineNo=M.No AND M.MedicineForm LIKE '%{cb_DosageForm.Text.Trim()}%'
                        ) AS SubQuery
			            ";//WHERE 序号 BETWEEN @Skip AND @Take";
            }
            else if (cb_Store.Text.Trim() == "药库" && cb_MedicineType.Text.Trim() != "全部" && cb_MedicineProperty.Text.Trim() == "全部" && cb_DosageForm.Text.Trim() != "全部")
            {
                commandText =
                    $@"SELECT *
                        FROM (
                        SELECT
                        ROW_NUMBER() OVER (ORDER BY MI.NO ASC) AS 序号,MI.No 入库单号,M.Name 药品名称,M.Type 药品类型,M.MedicinePropert 药品性质,M.Standard 药品规格,M.MedicineForm 剂型,M.Price3 药品单价, MI.Amount 预计数量
                        FROM
                        tb_Medicine AS M,tb_MedicineInventory AS MI
                        WHERE MI.MedicineNo=M.No AND M.MedicineForm LIKE '%{cb_DosageForm.Text.Trim()}%' AND M.Type LIKE '%{this.cb_MedicineType.Text.Trim()}%' ) AS SubQuery
			            ";//WHERE 序号 BETWEEN @Skip AND @Take";
            }
            else if (cb_Store.Text.Trim() == "药库" && cb_MedicineType.Text.Trim() == "全部" && cb_MedicineProperty.Text.Trim() != "全部" && cb_DosageForm.Text.Trim() != "全部")
            {
                commandText =
                    $@"SELECT *
                        FROM (
                        SELECT
                        ROW_NUMBER() OVER (ORDER BY MI.NO ASC) AS 序号,MI.No 入库单号,M.Name 药品名称,M.Type 药品类型,M.MedicinePropert 药品性质,M.Standard 药品规格,M.MedicineForm 剂型,M.Price3 药品单价, MI.Amount 预计数量
                        FROM
                        tb_Medicine AS M,tb_MedicineInventory AS MI
                        WHERE MI.MedicineNo=M.No AND M.MedicineForm LIKE '%{cb_DosageForm.Text.Trim()}%' AND M.MedicinePropert LIKE '%{cb_MedicineProperty.Text.Trim()}%') AS SubQuery
			            ";//WHERE 序号 BETWEEN @Skip AND @Take";
            }
            else if (cb_Store.Text.Trim() == "药库" && cb_MedicineType.Text.Trim() != "全部" && cb_MedicineProperty.Text.Trim() != "全部" && cb_DosageForm.Text.Trim() == "全部")
            {
                commandText =
                    $@"SELECT *
                        FROM (
                        SELECT
                        ROW_NUMBER() OVER (ORDER BY MI.NO ASC) AS 序号,MI.No 入库单号,M.Name 药品名称,M.Type 药品类型,M.MedicinePropert 药品性质,M.Standard 药品规格,M.MedicineForm 剂型,M.Price3 药品单价, MI.Amount 预计数量
                        FROM
                        tb_Medicine AS M,tb_MedicineInventory AS MI
                        WHERE MI.MedicineNo=M.No AND M.Type LIKE '%{this.cb_MedicineType.Text.Trim()}%' AND M.MedicinePropert LIKE '%{cb_MedicineProperty.Text.Trim()}%') AS SubQuery
			            ";//WHERE 序号 BETWEEN @Skip AND @Take";
            }
            else
            {
                commandText =
                    $@"SELECT *
                        FROM (
                        SELECT
                        ROW_NUMBER() OVER (ORDER BY MI.NO ASC) AS 序号,MI.No 入库单号,M.Name 药品名称,M.Type 药品类型,M.MedicinePropert 药品性质,M.Standard 药品规格,M.MedicineForm 剂型,M.Price3 药品单价, MI.Amount 预计数量
                        FROM
                        tb_Medicine AS M,tb_MedicineInventory AS MI
                        WHERE MI.MedicineNo=M.No AND M.Type LIKE '%{this.cb_MedicineType.Text.Trim()}%' AND M.MedicineForm LIKE '%{cb_DosageForm.Text.Trim()}%' AND M.MedicinePropert LIKE '%{cb_MedicineProperty.Text.Trim()}%') AS SubQuery
			            ";//WHERE 序号 BETWEEN @Skip AND @Take";
            }

            DataTable table = this.F_Fuction.LoadPage(pageNumber, pageSize, commandText);
            // 将DataTable中的数据绑定到DataGridView
            dgv_Medicine.DataSource = table;
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Pre_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadPage(currentPage);
            }
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Late_Click(object sender, EventArgs e)
        {
            currentPage++;
            LoadPage(currentPage);
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn AmountColumn = new DataGridViewTextBoxColumn();
            dgv_Medicine.Columns.Add(AmountColumn);
            AmountColumn.Name = "Amount";
            AmountColumn.HeaderText = "实际数量";
            dgv_Medicine.ReadOnly = false;
            DataGridViewTextBoxColumn RemarkColumn = new DataGridViewTextBoxColumn();
            dgv_Medicine.Columns.Add(RemarkColumn);
            RemarkColumn.Name = "Remark";
            RemarkColumn.HeaderText = "备注";
            dgv_Medicine.ReadOnly = false;
            DataGridViewCheckBoxColumn isCheckColumn = new DataGridViewCheckBoxColumn();
            isCheckColumn.HeaderText = "结存"; // 列标题  
            isCheckColumn.Name = "isCheckColumn"; // 列名  
            isCheckColumn.DataPropertyName = "IsSelected"; // 如果绑定到数据源，这是数据源中的属性名  
            dgv_Medicine.Columns.Add(isCheckColumn); // 将列添加到DataGridView中
            // 遍历DataGridView的所有列  
            foreach (DataGridViewColumn column in dgv_Medicine.Columns)
            {
                // 检查列名，并设置ReadOnly属性  
                if (column.Name == "Amount"||column.Name== "Remark" || column.Name == "isCheckColumn")
                {
                    // 对于你想要编辑的列，设置为可编辑  
                    column.ReadOnly = false;
                }
                else
                {
                    // 对于其他列，设置为只读  
                    column.ReadOnly = true;
                }
            }
            _checkNo = AddNo();

            string CommandText = $@"INSERT tb_MedicineCheck(No,CheckType,CheckForm ,Date,OperatorNo)
                VALUES('{_checkNo}','{cb_Type.Text.Trim()}','{cb_Fangshi.Text.Trim()}','{dtp_Time.Value}','{this._No}');";
            this.SqlHelper.NewCommand(CommandText).GetCom();
           
            MessageBox.Show($"打印盘点单{_checkNo}成功，请及时盘点。", "消息",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
            int affect=Add_CheckPro();
            lblName.Text = $"盘点单：{_checkNo}        共{affect}条记录";
        }
        /// <summary>
        /// 添加盘点单
        /// </summary>
        /// <returns></returns>
        private int Add_CheckPro()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = connectionString;
            string CommandText =
                $@"INSERT tb_MedicineCheckPro(CheckNo ,StoreNo )
                    VALUES(@CheckNo,@StoreNo);";
            SqlCommand insertCommand = new SqlCommand(CommandText, sqlConnection);
            insertCommand.Parameters.AddWithValue("@CheckNo", _checkNo);
            insertCommand.Parameters.Add("@StoreNo", SqlDbType.VarChar);
            sqlConnection.Open();
            int rowAffected = 0;
            foreach (DataGridViewRow row in dgv_Medicine.Rows)
            {
                
                insertCommand.Parameters["@StoreNo"].Value = row.Cells[1].Value ?? DBNull.Value;
                if (insertCommand.Parameters["@StoreNo"].Value==null)
                {
                    // 为storeNo分配一个默认值或从某个地方获取一个值  
                    insertCommand.Parameters["@StoreNo"].Value = "";
                }  
                insertCommand.ExecuteNonQuery();
                 rowAffected++;
            }
            
            sqlConnection.Close();
            MessageBox.Show($"盘点{rowAffected}条药品记录成功", "消息",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
            return rowAffected;
        }
        /// <summary>
        /// 设置入库单号
        /// </summary>
        /// <returns></returns>
        private string  AddNo()
        {
            string checkNo = "";
            string CommandText =
             $@"declare  
                @x1 int,  
                @y1 char(8)
                select @x1= COUNT(No) from tb_MedicineCheck where CAST(Date as date)=CAST(GETDATE() as date)
                if(@x1=0)  
                begin  
                select @y1=convert(char(8),getdate(),112)  
                Select distinct 'C'+@y1+'0001' No from tb_MedicineCheck
                end
                else  
                begin  
                Select 'C'+cast((select MAX(CAST( SUBSTRING(No,2,11) as bigint))+1 from tb_MedicineCheck where CAST(Date as date)=CAST(GETDATE() as date))as varchar(50)) No  from tb_MedicineCheck      
                end ";
            SqlDataReader sqlDataReader =
                         this.SqlHelper.NewCommand(CommandText).GetReader();
            if (sqlDataReader.Read())
            {
                checkNo = sqlDataReader["No"].ToString();
            }
            return checkNo;
        }
        /// <summary>
        /// 显示药品具体功效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Medicine_Click(object sender, EventArgs e)
        {
            string EnterNo = dgv_Medicine.CurrentRow.Cells[1].Value.ToString();
            string CommandText =
             $@"SELECT M.FunctionWork FROM tb_Medicine AS M,tb_MedicineInventory AS MI
            WHERE MI.MedicineNo=M.No AND MI.No='{EnterNo}';";
            SqlDataReader sqlDataReader =
                        this.SqlHelper.NewCommand(CommandText).GetReader();
            if (sqlDataReader.Read())
            {
                this.rtb_Describe.Text = sqlDataReader["FunctionWork"].ToString();
            }
        }
        /// <summary>
        /// 添加盘点单细则
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = connectionString;
            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = sqlConnection;
            string CommandText =
                $@"UPDATE tb_MedicineCheckPro
                    SET Amount=@Amount,Remark=@Remark  
                    WHERE CheckNo=@CheckNo AND StoreNo=@StoreNo";
            insertCommand.CommandText = CommandText;
            insertCommand.Parameters.AddWithValue("@CheckNo", _checkNo);
            insertCommand.Parameters.Add("@StoreNo", SqlDbType.VarChar).Value = DBNull.Value; ;
            insertCommand.Parameters.Add("@Amount", SqlDbType.VarChar).Value = DBNull.Value; ;
            insertCommand.Parameters.Add("@Remark", SqlDbType.VarChar).Value = DBNull.Value; ;
            sqlConnection.Open();
            int rowAffected = 0;
            foreach (DataGridViewRow row in dgv_Medicine.Rows)
            {
                if ((bool)row.Cells[11].Value)
                {
                    insertCommand.Parameters["@StoreNo"].Value = row.Cells[1].Value ?? DBNull.Value;
                    insertCommand.Parameters["@Amount"].Value = row.Cells[9].Value ?? DBNull.Value;
                    insertCommand.Parameters["@Remark"].Value = row.Cells[10].Value ?? DBNull.Value;
                    insertCommand.ExecuteNonQuery();
                    rowAffected++;
                }
            }
            sqlConnection.Close();
            MessageBox.Show($"盘点{rowAffected}条药品记录成功", "消息",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
            DataGridViewColumn columnToRemove = dgv_Medicine.Columns["Amount"];
            dgv_Medicine.Columns.Remove(columnToRemove);
            DataGridViewColumn columnToRemove1 = dgv_Medicine.Columns["Remark"];
            dgv_Medicine.Columns.Remove(columnToRemove1);
            DataGridViewColumn columnToRemove2 = dgv_Medicine.Columns["isCheckColumn"];
            dgv_Medicine.Columns.Remove(columnToRemove2);
            dgv_Medicine.DataSource=null;
        }
    }
}
