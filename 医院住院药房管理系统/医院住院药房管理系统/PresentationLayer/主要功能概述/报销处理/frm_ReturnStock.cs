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
    public partial class frm_ReturnStock : Form
    {
        /// <summary>
        /// 课程数据表；
        /// </summary>
        private DataTable CourseTable;
        /// <summary>
        /// 已选课程数据表；
        /// </summary>
        /// <summary>
        /// 一般方法
        /// </summary>
        private F_Fuction F_Fuction;
        /// <summary>
        /// SQL助手
        /// </summary>
        private SQLHepler SqlHelper;

        private DataTable SelectedCourseTable;
        public frm_ReturnStock()
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
        /// <summary>
        /// 构造函数；
        /// </summary>
        /// <param name="studentNo">用户名</param>
        public frm_ReturnStock(string No) : this()
        {
            this._No = No;
        }
        /// <summary>
        /// 加载报销人
        /// </summary>
        private void Man_Load()
        {
            string CommandText =
                    $@"SELECT * FROM tb_Nurse";
            DataTable dataTable =
            this.SqlHelper.NewCommand(CommandText).GetTable();
            this.F_Fuction.Comshow(cb_Man,"No", "Name", dataTable);
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_ReturnStock_Load(object sender, EventArgs e)
        {
            Man_Load();
            string CommandText =
                @"SELECT * FROM tb_MedicineBad AS MB
                    WHERE MB.No NOT IN (SELECT MBS.RestoreNo FROM tb_MedicineBackStore AS MBS);";                  //指定SQL命令的命令文本；该命令查询学生尚未选修的课程，以用作数据网格视图数据源；
                                                    //将SQL数据适配器的查询命令属性指向SQL命令；
            this.CourseTable = this.SqlHelper.NewCommand(CommandText).GetTable();                                                             //实例化本窗体的课程数据表，用于保存所有课程，以用作数据网格视图数据源；
                                                                  //实例化本窗体的已选课程数据表，用于保存学生已选修课程，以用作数据网格视图数据源；
                                                        //SQL数据适配器读取数据，并填充课程数据表；
            CommandText =
                @"SELECT MBS.NO 序号,MB.No,MB.StoreNo,MB.Amount,MB.Result,MBS.Date
                    FROM tb_MedicineBackStore AS MBS ,tb_MedicineBad AS MB
                    WHERE MBS.RestoreNo=MB.No ";                                                        //指定SQL命令的命令文本；该命令查询学生已选修的课程，以用作数据网格视图数据源；
            this.SelectedCourseTable = this.SqlHelper.NewCommand(CommandText).GetTable();

            this.dgv_OldMedicine.Columns.Clear();                                                                //课程数据网格视图的列集合清空；
            this.dgv_OldMedicine.DataSource = this.CourseTable;                                                  //将数据网格视图的数据源设为学生数据表；
            this.dgv_OldMedicine.Columns["No"].HeaderText = "编号";                                              //将数据网格视图的指定列的表头文本设为中文；
            this.dgv_OldMedicine.Columns["StoreNo"].HeaderText = "入库单号";
            this.dgv_OldMedicine.Columns["Amount"].HeaderText = "数量";
            this.dgv_OldMedicine.Columns["OperatorNo"].Visible = false;
            this.dgv_OldMedicine.Columns["Date"].HeaderText = "报损日期";
            this.dgv_OldMedicine.Columns["Result"].HeaderText = "报损原因";
            
            this.dgv_OldMedicine.Columns[this.dgv_OldMedicine.Columns.Count - 1].AutoSizeMode =                       //数据网格视图的最后一列的自动调整列宽模式设为填充（至数据网格视图右侧边缘）；
                DataGridViewAutoSizeColumnMode.Fill;
            this.dgv_NewMedicine.Columns.Clear();                                                        //已选课程数据网格视图的列集合清空；
            this.dgv_NewMedicine.DataSource = this.SelectedCourseTable;                                  //将数据网格视图的数据源设为学生数据表；
            this.dgv_NewMedicine.Columns["No"].HeaderText = "报损单号";                                      //将数据网格视图的指定列的表头文本设为中文；
            this.dgv_NewMedicine.Columns["StoreNo"].HeaderText = "入库单号";
            this.dgv_NewMedicine.Columns["Amount"].HeaderText = "数量";
            this.dgv_NewMedicine.Columns["Date"].HeaderText = "报损日期";
            this.dgv_NewMedicine.Columns["Result"].HeaderText = "报损原因";
            this.dgv_NewMedicine.Columns[this.dgv_NewMedicine.Columns.Count - 1].AutoSizeMode =       //数据网格视图的最后一列的自动调整列宽模式设为填充（至数据网格视图右侧边缘）；
                DataGridViewAutoSizeColumnMode.Fill;
            this.txb_ReCount.Text =                                                                       //在标签中显示已选课程的学分总和；
                $"{this.SelectedCourseTable.Compute("SUM(Amount)", "")}";
        }
        /// <summary>
        /// 添加退库记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddNew_Click(object sender, EventArgs e)
        {
            if (this.dgv_OldMedicine.RowCount == 0)                                                              //若课程数据网格视图内的行计数等于0；
                return;                                                                                     //返回；
            DataRowView currentCourseRowView =
                this.dgv_OldMedicine.CurrentRow.DataBoundItem as DataRowView;                                    //将课程数据网格视图的当前行的数据绑定项，转换为数据行视图；
            DataRow                                                                                         //声明数据行；
                currentCourseRow = currentCourseRowView.Row													//通过当前的数据行视图，获取其相应的数据行；
                , selectedCourseRow = this.SelectedCourseTable.NewRow();									//已选课程数据行则通过已选课程数据表的方法NewRow来新建；随后该行的状态为分离；
            selectedCourseRow["No"] = currentCourseRow["No"];												//逐一将当前课程数据行的各列值，赋予已选课程数据行的相应列；
            selectedCourseRow["Amount"] = currentCourseRow["Amount"];
            selectedCourseRow["StoreNo"] = currentCourseRow["StoreNo"];
            selectedCourseRow["Result"] = currentCourseRow["Result"];
            selectedCourseRow["Date"] = dtp_Time.Value;
            this.SelectedCourseTable.Rows.Add(selectedCourseRow);											//已选课程数据行加入已选课程数据表；随后该行的状态为添加；此处不可用数据表的ImportRow方法替代，后者无法改变行的分离状态；
            currentCourseRow.Delete();																		//当前课程数据行删除；随后该行的状态为删除；
            this.txb_ReCount.Text =																		//在标签中显示已选课程的学分总和；
                $"{this.SelectedCourseTable.Compute("SUM(Amount)", "")}";
        }
        /// <summary>
        /// 退回退库记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_BackOld_Click(object sender, EventArgs e)
        {
            if (this.dgv_NewMedicine.RowCount == 0)                                                      //若已选课程数据网格视图内的行计数等于0；
                return;                                                                                     //返回；
            DataRowView selectedCourseRowView =
                this.dgv_NewMedicine.CurrentRow.DataBoundItem as DataRowView;                            //将已选课程数据网格视图的当前行的数据绑定项，转换为数据行视图；
            DataRow selectedCourseRow = selectedCourseRowView.Row;                                          //通过当前的数据行视图，获取其相应的数据行；
            if (selectedCourseRow.RowState != DataRowState.Added)                                           //若已选课程数据行的行状态并非添加；
                return;                                                                                     //返回；
            string courseNo = selectedCourseRow["No"].ToString();											//获取当前课程数据行的课程编号；
            DataRow deletedCourseRow =																		//声明已删课程数据行（即先前从课程数据表中删除的数据行）；
                this.CourseTable.Select($"No='{courseNo}'", "", DataViewRowState.Deleted)[0];			    //已删课程数据行可通过课程数据表的方法Select查得，该方法接受查询条件、排序条件、行状态条件等参数，并返回数据行数组；
            deletedCourseRow.RejectChanges();																//已删课程数据行拒绝更改，即回滚先前对其执行的删除；随后该行的状态为未更改；
            this.SelectedCourseTable.Rows.Remove(selectedCourseRow);										//从已选课程数据表的行集合中移除当前课程数据行；随后该行的状态为分离；
            this.txb_ReCount.Text =																		//在标签中显示已选课程的学分总和；
                $"{this.SelectedCourseTable.Compute("SUM(Amount)", "")}";
        }
        private void Medicine(string EnterNo)
        {
            string CommandText =
                            $@"SELECT M.Name 药品名称,*  FROM 
                                tb_MedicineInventory AS MI,tb_Medicine AS M
                                WHERE MI.MedicineNo=M.No
                                AND MI.No='{EnterNo}';";
            SqlDataReader sqlDataReader =
            this.SqlHelper.NewCommand(CommandText)
                          .GetReader();
            if (sqlDataReader.Read())
            {
                txb_OutNo.Text = EnterNo;
                txb_Medicine.Text = sqlDataReader["药品名称"].ToString();
                txb_IsLook.Text = sqlDataReader["isQualified"].ToString();
                txb_IsPass.Text = sqlDataReader["isHasQualified"].ToString();
                txb_EnterTime.Text = sqlDataReader["OperateTime"].ToString();
                txb_BatchNo.Text = sqlDataReader["BatchNo"].ToString();
                txb_BatchUnit.Text = sqlDataReader["BatchUnit"].ToString();
                txb_SignUp.Text = sqlDataReader["LoginUnit"].ToString();
                txb_ProvalNo.Text = sqlDataReader["ApprovalNumber"].ToString();
                txb_TimeSpan.Text = sqlDataReader["LifeSpan"].ToString();
                txb_Supplier.Text = sqlDataReader["Supplier"].ToString();
                txb_UseDate.Text = sqlDataReader["UseDate"].ToString();
                dtp_Birthday.Value = (DateTime)sqlDataReader["BatchDate"];
                dtp_EnterTime.Value = (DateTime)sqlDataReader["PurchaseDate"];
            }       
        }
        /// <summary>
        /// 点击表格显示药品信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_OldMedicine_Click(object sender, EventArgs e)
        {
            string EnterNo = dgv_OldMedicine.CurrentRow.Cells[1].Value.ToString();
            Medicine(EnterNo);
        }
        /// <summary>
        /// 点击表格显示药品信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_NewMedicine_Click_1(object sender, EventArgs e)
        {
            string EnterNo = dgv_NewMedicine.CurrentRow.Cells[2].Value.ToString();
            Medicine(EnterNo);
        }
        /// <summary>
        /// 添加按钮函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = connectionString;                            //在字符串变量中，描述连接字符串所需的服务器地址、数据库名称、集成安全性（即是否使用Windows验证）；
            SqlCommand insertCommand = new SqlCommand();                                                    //声明并实例化用于插入的SQL命令；
            insertCommand.Connection = sqlConnection;                                                       //将SQL命令的连接属性指向SQL连接；
            insertCommand.CommandText =
                @"INSERT tb_MedicineBackStore(RestoreNo ,Amount ,OperatorNo ,Date)
					VALUES(@RestoreNo,@Amount,@OperatorNo,@Date);;";                                              //指定SQL命令的命令文本；该命令插入选课记录；
            insertCommand.Parameters.AddWithValue("@OperatorNo", this._No);                            //向SQL命令的参数集合添加参数的名称、SQL Server数据类型、长度（仅用于定长类型）、所绑定的数据表中的列名；
            insertCommand.Parameters.Add("@Date", SqlDbType.Date, 4, "Date");
            insertCommand.Parameters.Add("@RestoreNo", SqlDbType.Char, 0, "No");
            insertCommand.Parameters.Add("@Amount", SqlDbType.Int, 0, "Amount");
            SqlCommand updateCommand = new SqlCommand();                                                    //声明并实例化用于更新（教材订购状态）的SQL命令；
            updateCommand.Connection = sqlConnection;                                                       //将SQL命令的连接属性指向SQL连接；
            string updateCommandText =                                                                     //指定SQL命令的命令文本；该命令更新教材订购状态；
                @"UPDATE tb_MedicineEnterHall 
			        SET Amount-=@Amount
			        WHERE RequestNo=(SELECT No FROM tb_MedicineRequest WHERE EnterNo=@RestoreNo;";                      //向SQL命令的参数集合添加参数的名称、SQL Server数据类型、长度（仅用于定长类型）、所绑定的数据表中的列名；
            updateCommand.CommandText = updateCommandText;
            updateCommand.Parameters.Add("@RestoreNo", SqlDbType.Char, 0, "No");
            updateCommand.Parameters.Add("@Amount", SqlDbType.Int, 0, "Amount");
            //声明并实例化用于插入的SQL命令；
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();                                           //声明并实例化SQL数据适配器；
            sqlDataAdapter.InsertCommand = insertCommand;                                                   //将SQL数据适配器的插入命令属性指向SQL命令；
            sqlDataAdapter.UpdateCommand = updateCommand;
            //将SQL数据适配器的插入命令属性指向SQL命令；
            sqlConnection.Open();           
            int rowAffected = sqlDataAdapter.Update(this.SelectedCourseTable);                              //SQL数据适配器根据学生数据表提交更新，并返回受影响行数；
            sqlConnection.Close();                                                                          //关闭SQL连接；
            MessageBox.Show($"提交{rowAffected}行。");
        }
        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
