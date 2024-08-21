using SmartLinli.DatabaseDevelopement;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using 医院住院药房管理系统.DataAccessLayer;
using 医院住院药房管理系统.PresentationLayer;

namespace 医院住院药房管理系统.主要功能概述.库存处理
{
    public partial class frm_MedicineStore : Form
    {
        /// <summary>
        /// SQL助手
        /// </summary>
        private SQLHepler SqlHelper;
        /// <summary>
        /// 常用方法
        /// </summary>
        private F_Fuction Cb_Fuction;
        public frm_MedicineStore()
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
            InitListView();
            this.SqlHelper = new SQLHepler();
            this.Cb_Fuction = new F_Fuction();
        }
        /// <summary>
        /// 学生数据表；
        /// </summary>
        private DataTable MedicineD;
        /// <summary>
        /// 当前页的数据视图；
        /// </summary>
        private DataView CurrentPageView;
        /// <summary>
        /// 每页大小；
        /// </summary>
        private int PageSize;
        /// <summary>
        /// 当前页号；
        /// </summary>
        private int CurrentPageNo;
        /// <summary>
        /// 最大页号；
        /// </summary>
        private int MaxPageNo;
        /// <summary>
        /// 用户名
        /// </summary>
        private string _No;
        /// <summary>
        /// 构造函数；
        /// </summary>
        /// <param name="studentNo">操作人员</param>
        public frm_MedicineStore(string No) : this()
        {
            this._No = No;
        }
        /// <summary>
        /// 刷新行筛选条件；
        /// </summary>
        private void RefreshRowFilter()
        => this.CurrentPageView.RowFilter =                                                                //设置学生数据视图的行筛选条件，即筛选当前页的记录；
                $"RowID >{(this.CurrentPageNo - 1) * this.PageSize} " +
                $"" +
            $"AND RowID <={this.CurrentPageNo * this.PageSize}";                                        //根据当前页号、每页大小，计算相应的行编号范围，并作为行筛选条件；
        /// <summary>
        /// 加载listview显示所有药品
        /// </summary>
        private void InitListView()
        {
            // 设置显示模式
            lv_Medicine.View = View.Details;
            // 整行选中
            lv_Medicine.FullRowSelect = true;

            // 设置列名
            // 宽度值-2表示自动调整宽度
            lv_Medicine.Columns.Add("编号 ", 80, HorizontalAlignment.Center);
            lv_Medicine.Columns.Add("名称", 110, HorizontalAlignment.Left);
            lv_Medicine.Columns.Add("名称拼音", 130, HorizontalAlignment.Left);
            lv_Medicine.Columns.Add("规格", 100, HorizontalAlignment.Left);
            lv_Medicine.Columns.Add("药剂类别", 80, HorizontalAlignment.Left);
            lv_Medicine.Columns.Add("生产批号", 150, HorizontalAlignment.Center);
            lv_Medicine.Columns.Add("生产单位", 150, HorizontalAlignment.Left);
            lv_Medicine.Columns.Add("注册单位", 180, HorizontalAlignment.Center);
            lv_Medicine.Columns.Add("实际价", 80, HorizontalAlignment.Left);
            lv_Medicine.Columns.Add("批发价", 80, HorizontalAlignment.Left);
            lv_Medicine.Columns.Add("零售价", -2, HorizontalAlignment.Left);
        }
        /// <summary>
        /// 设置选项卡的样式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //调整选项卡文字方向
            //创建颜色画刷
            SolidBrush lightPink = new SolidBrush(Color.Snow);
            SolidBrush lightPink1 = new SolidBrush(Color.White);
            SolidBrush _Brush = new SolidBrush(Color.Black);
            //RectangleF _TabTextArea = (RectangleF)tabControl1.GetTabRect(e.Index);//绘制区域
            //封装文本布局格式信息，并设置文本格式
            StringFormat _sf = new StringFormat();
            _sf.LineAlignment = StringAlignment.Center;
            _sf.Alignment = StringAlignment.Center;
            //用画刷将选项卡外边填满
            Rectangle rectangle = new Rectangle(tabControl1.Left, tabControl1.Top, tabControl1.Width, tabControl1.Height);
            Region region = new Region(rectangle);
            e.Graphics.FillRegion(lightPink1, region);
            //用画刷将选项卡内部边框填满
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                Rectangle Rec = tabControl1.GetTabRect(i);//返回选项卡控件中指定选项卡的边框
                e.Graphics.FillRectangle(lightPink, Rec);//用画刷将选项卡内部边框填满
                e.Graphics.DrawString(tabControl1.Controls[i].Text, SystemInformation.MenuFont, _Brush, Rec, _sf);//绘制指定文本字符串
            }
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
                select @x1= COUNT(No) from tb_MedicineInventory where CAST(PurchaseDate as date)=CAST(GETDATE() as date)
                if(@x1=0)  
                begin  
                select @y1=convert(char(8),getdate(),112)  
                Select distinct 'A'+@y1+'0001' No from tb_MedicineInventory  
                end
                else  
                begin  
                Select 'A'+cast((select MAX(CAST( SUBSTRING(No,2,11) as bigint))+1 from tb_MedicineInventory where CAST(PurchaseDate as date)=CAST(GETDATE() as date))as varchar(50)) No  from tb_MedicineInventory       
                end ;";
            SqlDataReader sqlDataReader =
                        this.SqlHelper.NewCommand(CommandText)
                        .GetReader();
            if (sqlDataReader.Read())
            {
                txb_EnterNo.Text = sqlDataReader["No"].ToString();
            }
        }
        // 分页设置
        int pageSize = 10; // 每页显示的项数
        int currentPage = 1; // 当前页码
        // 创建分页的方法
        private void LoadPage(int pageNumber)
        {
            int skipItems = (pageNumber - 1) * pageSize; 
            int takeItems = skipItems + pageSize;// 计算Take的值
            string CommandText = @"
                SELECT *
                FROM (
                SELECT ROW_NUMBER() OVER (ORDER BY NO) AS RowNum, *
                FROM tb_Medicine
                ) AS SubQuery
                WHERE RowNum BETWEEN @Skip AND @Take ";
            DataTable dataTable=
                this.SqlHelper.NewCommand(CommandText)
                .NewParameter("@Skip", skipItems + 1).NewParameter("@Take", takeItems)
                .GetTable();          
            lv_Medicine.Items.Clear();
            // 将DataTable中的数据绑定到ListView
            foreach (DataRow row in dataTable.Rows)
            {
                ListViewItem item = new ListViewItem(row["No"].ToString());
                // 添加其他列
                item.SubItems.Add(row["Name"].ToString());
                item.SubItems.Add(row["NamePinyin"].ToString());
                item.SubItems.Add(row["Standard"].ToString());
                item.SubItems.Add(row["Type"].ToString());
                item.SubItems.Add(row["BatchNo"].ToString());
                item.SubItems.Add(row["BatchUnit"].ToString());
                item.SubItems.Add(row["LoginUnit"].ToString());
                item.SubItems.Add(row["Price1"].ToString());
                item.SubItems.Add(row["Price2"].ToString());
                item.SubItems.Add(row["Price3"].ToString());
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
        //窗体打开时触发的函数值
        private void frm_MedicineStore_Load(object sender, EventArgs e)
        {
            LoadPage(currentPage);
            string commandText =
                $@"SELECT * FROM tb_Medicine;";
            string commandText2 =
                $@"Select * from tb_Supplier;";
            DataTable MedicineT = this.SqlHelper.NewCommand(commandText).GetTable();
            this.Cb_Fuction.Comshow(cb_Medicine, "No", "Name", MedicineT);            
            DataTable SupplierT = this.SqlHelper.NewCommand(commandText2).GetTable();
            this.Cb_Fuction.Comshow(cb_Supplier, "No", "Text", SupplierT);
            this.PageSize = 7;                                                                             //设置每页大小为10（行记录）；
            this.CurrentPageNo = 1;                                                                         //设置当前页号为1；
            commandText = $@"SELECT 
                            ROW_NUMBER() OVER (ORDER BY MI.NO DESC) AS 序号, 
                            MI.NO 入库编号,M.No 药品编号,M.Name 药品名称,
                            M.Standard 药品规格,MI.Amount 入库数量,M.Price3 零售价,
                            MI.PurchaseDate 进货时间,MI.Supplier 供货商,MI.ApprovalNumber 生产批号,MI.OperatorNo 操作人员工号,MI.OperateTime 操作时间
                            FROM
                            tb_Medicine AS M,tb_MedicineInventory AS MI
                            WHERE M.NO=MI.MedicineNo";
            this.MedicineD = new DataTable();
            this.MedicineD.TableName = "MedicineD";                                                 //设置学生数据表的表名；由于该查询对表进行投影，数据适配器无法自动指定表名，故需手动指定表名，以便后续创建数据视图；
            DataColumn rowIdColumn = new DataColumn();                                                      //声明并实例化数据列，用于保存行编号；
            rowIdColumn.ColumnName = "RowID";                                                               //设置数据列的名称；
            rowIdColumn.DataType = typeof(int);                                                             //设置数据列的类型；类型需借助typeof获取；
            rowIdColumn.AutoIncrement = true;                                                               //设置数据列为自增列；
            rowIdColumn.AutoIncrementSeed = 1;                                                              //设置数据列的自增种子为1；
            rowIdColumn.AutoIncrementStep = 1;                                                              //设置数据列的自增步长为1；
            this.MedicineD.Columns.Add(rowIdColumn);  
            SqlDataAdapter sqlData=
            this.SqlHelper.NewCommand(commandText).GetAdapter();
            sqlData.Fill(this.MedicineD);
            this.MaxPageNo =
                (int)Math.Ceiling((double)this.MedicineD.Rows.Count / (double)this.PageSize);            //根据学生数据表的行集合的计数与每页大小，计算最大页号；
            this.CurrentPageView = new DataView();                                                          //实例化本窗体的学生数据视图，用于筛选当前页的记录；
            this.CurrentPageView.Table = MedicineD;                                                 //设置学生数据视图对应的数据表；
            this.CurrentPageView.Sort = "RowID ASC";      
            this.RefreshRowFilter();																		//刷新行筛选条件，即筛选当前页的记录；
            this.dgv_EnterStore.DataSource = this.CurrentPageView;
            this.dgv_EnterStore.Columns["RowID"].Visible = false;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            frm_AddMedicine addMedicine = new frm_AddMedicine(this._No);
            addMedicine.ShowDialog();
        }
        //跳转到房存设置窗体
        private void btn_Set_Click(object sender, EventArgs e)
        {
            string MedicineNo = this.lv_Medicine.SelectedItems[0].SubItems[0].Text;
            frm_SetAttribution frm_SetAttribution = new frm_SetAttribution(this._No, MedicineNo);
            frm_SetAttribution.ShowDialog();
        }
        //单击表格一行，出现药品库存属性
        private void lv_Medicine_Click(object sender, EventArgs e)
        {
            txb_Name.Clear(); txb_SaveNo1.Clear(); txb_SaveNo2.Clear();
            txb_MinNo1.Clear(); txb_MinNo2.Clear(); txb_MaxNo1.Clear();
            txb_Max2.Clear();
            string MedicineNo = this.lv_Medicine.SelectedItems[0].SubItems[0].Text;
            txb_Name.Text = this.lv_Medicine.SelectedItems[0].SubItems[1].Text;
            string connectionString = ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string commandText =
                $@"SELECT * from tb_MedicineAttribute WHERE MedicineNo='{MedicineNo}';";
            SqlCommand command = new SqlCommand(commandText, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = command.ExecuteReader();
            if (sqlDataReader.Read())
            {
                this.txb_SaveNo1.Text = sqlDataReader["SaveNo1"].ToString();
                this.txb_SaveNo2.Text = sqlDataReader["SaveNo2"].ToString();
                this.txb_MaxNo1.Text = sqlDataReader["MaxNo1"].ToString();
                this.txb_MinNo2.Text = sqlDataReader["MinNo2"].ToString();
                this.txb_MinNo1.Text = sqlDataReader["MinNo1"].ToString();
                this.txb_Max2.Text = sqlDataReader["MaxNo2"].ToString();
            }
        }
        /// <summary>
        /// 点击选项清空其余数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_Medicine_SelectedIndexChanged(object sender, EventArgs e)
        {
            //先清除文本框值
            this.txb_MedicineNo.Clear(); this.txb_MedicineName.Clear(); this.txb_BatchUnit.Clear();
            this.txb_BatchDate.Clear(); this.txb_TimeSpan.Clear(); this.txb_UseDate.Clear();
            this.txb_EnterCount.Clear(); this.txb_EnterNo.Clear(); 
            //this.cb_Supplier.Items.Clear();
            this.cb_isHaveQualified.SelectedIndex=-1; this.cb_isQualified.SelectedIndex = -1;
            this.txb_ApprovalNumber.Clear();
            //连接数据库，选中下拉列表值，显示数据
            string Name = this.cb_Medicine.Text.Trim();
            string CommandText = $@"SELECT * FROM tb_Medicine where Name=@Name;";
            SqlDataReader sqlDataReader =
                    this.SqlHelper.NewCommand(CommandText)
                    .NewParameter("@Name", Name)
                    .GetReader();
            if (sqlDataReader.Read())
            {
                this.txb_MedicineNo.Text = sqlDataReader["No"].ToString();
                this.txb_MedicineName.Text = sqlDataReader["Name"].ToString();
                this.txb_BatchUnit.Text = sqlDataReader["BatchUnit"].ToString();
                this.txb_BatchDate.Text = sqlDataReader["BatchDate"].ToString();
                this.txb_TimeSpan.Text = sqlDataReader["LifeSpan"].ToString();
                this.txb_UseDate.Text = sqlDataReader["UseDate"].ToString();
            }
        }
        /// <summary>
        /// 增加入库记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Sure_Click(object sender, EventArgs e)
        {   //变量转化类型
            int count = int.Parse(this.txb_EnterCount.Text.Trim());
            string connectionString = ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;
            DateTime selectedDate = dtp_Date.Value;
            string formattedDate = selectedDate.ToString("d");
            DateTime enterDate = dtp_EnterTime.Value;
            string EnterDate = enterDate.ToString("d");
            //连接数据库
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = connectionString;
            string CommandText =
             $@"INSERT tb_MedicineInventory
                (No ,MedicineNo ,Amount ,PurchaseDate ,
                Supplier ,ApprovalNumber ,isHasQualified ,
                isQualified,OperateTime,OperatorNo ) 
                VALUES 
                ('{this.txb_EnterNo.Text}','{this.txb_MedicineNo.Text.Trim()}',{count}
                ,'{EnterDate}','{this.cb_Supplier.Text}','{this.txb_ApprovalNumber.Text}'
                ,'{this.cb_isHaveQualified.Text}','{this.cb_isQualified.Text}','{formattedDate}','{this._No}')";
           
            int rowAffected = this.SqlHelper.NewCommand(CommandText).NonQuery();                                                                        //声明整型变量，用于保存受影响行数；
            if (rowAffected == 1)                                                                       //若成功写入1行记录；
            {
                MessageBox.Show("入库成功。", "消息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                //显示正确提示；
                frm_MedicineStore_Load(null, null);
            }
            else                                                                                        //否则；
            {
                MessageBox.Show("入库失败！", "消息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);                                                            //显示错误提示；
            }
        }
        private void Frm_MedicineStore_Load(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void aFrmContent_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.frm_MedicineStore_Load(null, null);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txb_EnterNo_Click(object sender, EventArgs e)
        {
            AddNo();
        }

        private void btn_Up_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageNo > 1)                                                                     //若当前页号大于1；
                this.CurrentPageNo--;                                                                       //则当前页号递减；
            this.RefreshRowFilter();                                                                        //刷新行筛选条件，即筛选当前页的记录；

        }

        private void btn_down_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageNo < this.MaxPageNo)                                                        //若当前页号尚未超出最大页号；
                this.CurrentPageNo++;                                                                       //则当前页号递增；
            this.RefreshRowFilter();                                                                        //刷新行筛选条件，即筛选当前页的记录；      
         }

        private void btn_Close1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
