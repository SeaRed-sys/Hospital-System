using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using static System.Environment;
using Image = System.Drawing.Image;
using System.IO;
using 医院住院药房管理系统.DataAccessLayer;
using System.Xml.Linq;

namespace 医院住院药房管理系统.PresentationLayer.主要功能概述.报表统计
{
    public partial class frm_ReportMedicine : Form
    {
        /// <summary>
        /// 一般方法
        /// </summary>
        private F_Fuction F_Fuction;
        /// <summary>
        /// SQL助手
        /// </summary>
        private SQLHepler SqlHelper;

        public frm_ReportMedicine()
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
            LoadTree();
            InitListView();
        }
        /// <summary>
        /// 药品表；
        /// </summary>
        private DataTable CourseTable;
        private DataTable CourseTable1;
        private DataTable CourseTable2;
        private DataTable CourseTable3;
        private DataTable CourseTable4;

        private string _No;
        /// <summary>
        /// 构造函数；
        /// </summary>
        /// <param name="studentNo">用户名</param>
        public frm_ReportMedicine(string No) : this()
        {
            this._No = No;
        }
        /// <summary>
        /// 选项卡格式设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //调整选项卡文字方向
            SolidBrush lightPink = new SolidBrush(Color.LightBlue);//创建一个淡绿色画刷
            SolidBrush lightPink1 = new SolidBrush(Color.White);//创建一个淡粉色画刷
            SolidBrush _Brush = new SolidBrush(Color.Black);//单色画刷
            RectangleF _TabTextArea = (RectangleF)tabControl1.GetTabRect(e.Index);//绘制区域
            StringFormat _sf = new StringFormat();//封装文本布局格式信息
            _sf.LineAlignment = StringAlignment.Center;
            _sf.Alignment = StringAlignment.Center;
            Rectangle Rec = tabControl1.GetTabRect(e.Index);//返回选项卡控件中指定选项卡的边框
            Rectangle rectangle = new Rectangle(tabControl1.Left, tabControl1.Top, tabControl1.Width, tabControl1.Height);
            e.Graphics.FillRectangle(lightPink, Rec);//用画刷将选项卡内部边框填满
            Region region = new Region(rectangle);
            // e.Graphics.FillRegion(lightPink1, region);//用画刷将选项卡内部边框填满
            e.Graphics.DrawString(tabControl1.Controls[e.Index].Text, SystemInformation.MenuFont, _Brush, _TabTextArea, _sf);
        }
        /// <summary>
        /// 列表加载
        /// </summary>
        private void InitListView()
        {
            // 设置显示模式
            lv_Medicine.View = View.Details;
            // 整行选中
            lv_Medicine.FullRowSelect = true;

            // 设置列名
            // 宽度值-2表示自动调整宽度
            lv_Medicine.Columns.Add("盘点单号 ", 130, HorizontalAlignment.Center);
            lv_Medicine.Columns.Add("盘点类型", 110, HorizontalAlignment.Left);
            lv_Medicine.Columns.Add("盘点方式", 110, HorizontalAlignment.Left);
            lv_Medicine.Columns.Add("盘点日期", 150, HorizontalAlignment.Left);
            lv_Medicine.Columns.Add("盘点人工号", 110, HorizontalAlignment.Left);
            Select_List(null, null);
        }
        private void Select_List(string CheckType, string Date)
        {
            string CommandText = "";
            if (CheckType == null && Date == null)
            {
                CommandText =                                                                    //指定SQL命令的命令文本；
                                @"SELECT * FROM tb_MedicineCheck";
            }
            else if (CheckType != null && Date == null)
            {
                CommandText =                                                                    //指定SQL命令的命令文本；
                                $@"SELECT * FROM tb_MedicineCheck where CheckType='{CheckType}'";
            }
            else if (CheckType == null && Date != null)
            {
                CommandText =                                                                    //指定SQL命令的命令文本；
                                $@"SELECT * FROM tb_MedicineCheck where CAST(Date AS DATE) = CAST('{Date}' AS DATE);";
            }
            else
            {
                CommandText =                                                                    //指定SQL命令的命令文本；
                                $@"SELECT * FROM tb_MedicineCheck where CheckType='{CheckType}' AND
                                  CAST(Date AS DATE) = CAST('{Date}' AS DATE);";
            }
            DataTable dt =
            this.SqlHelper.NewCommand(CommandText).GetTable();
            string[] str = new string[1000];
            foreach (DataRow dr in dt.Rows)
            {
                str[0] = dr["No"].ToString();
                str[1] = dr["CheckType"].ToString();
                str[2] = dr["CheckForm"].ToString();
                str[3] = dr["Date"].ToString();
                str[4] = dr["OperatorNo"].ToString();

                ListViewItem item = new ListViewItem(str[0]);
                item.SubItems.Add(str[1]);
                item.SubItems.Add(str[2]);
                item.SubItems.Add(str[3]);
                item.SubItems.Add(str[4]);
                lv_Medicine.Items.Add(item);
            }
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_ReportMedicine_Load_1(object sender, EventArgs e)
        {
            //showMedicineForm();
            string connectionString = ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = connectionString;                         //在字符串变量中，描述连接字符串所需的服务器地址、数据库名称、集成安全性（即是否使用Windows验证）；
            SqlCommand sqlCommand = new SqlCommand();                                                   //声明并实例化SQL命令；
            sqlCommand.Connection = sqlConnection;                                                      //将SQL命令的连接属性指向SQL连接；
            string CommandText =                                                                    //指定SQL命令的命令文本；
                @"SELECT * FROM tb_MedicineType;
                  SELECT * FROM tb_MedicineProperty;
                  SELECT * FROM tb_MedicineForm;
                
                SELECT ME.No 入房单号,ME.MedicineNo 药品编号,M.Name 药品名称,M.NamePinyin 药品拼音,ME.Amount 入房数量,ME.Date 入房时间, M.Type 药品类型,M.MedicinePropert 药品性质,M.MedicineForm 药品剂型,M.Standard 药品规格,ME.OperatorNo 操作人工号
                FROM 
                tb_MedicineEnterHall AS ME,tb_IsMedicineRequest AS IMR,tb_Medicine AS M
                WHERE ME.RequestNo=IMR.ReQuestNo AND ME.MedicineNo=M.No;
                
                SELECT 
                MB.No 报损单号,MB.StoreNo 入库单号,M.NO 药品编号,M.Name 药品名称,MB.Amount 报损数量,MB.Result 报损原因,MB.Date 报损日期,M.NamePinyin 药品拼音,M.Type 药品类型,M.MedicinePropert 药品性质,M.MedicineForm 药品剂型
                FROM 
                tb_MedicineBad AS MB,tb_Medicine AS M,tb_MedicineInventory AS MI
                WHERE MB.StoreNo=MI.No AND MI.MedicineNo=M.No;
                
                SELECT ROW_NUMBER() OVER (ORDER BY MO.No asc) AS 序号,
                MO.WardName 病区,MO.RoomName 病房,
                MO.ManName 病人,MO.MedicineName 药品名称,M.Standard 药品规格,MO.Amount 总量,M.Unit 单位,M.Price3*MO.Amount 总价,MO.Date 时间
                 ,MO.Nurse 领药护士,O.Name 操作人员,M.NamePinyin 药品拼音
			    FROM 
                tb_MedicineOutHall AS MO,tb_Medicine AS M,tb_Operator AS O
                WHERE MO.MedicineName=M.Name  AND MO.OperateNo=O.NO;
                
                SELECT MBS.No 退库单号,ME.No 入房单号,M.Name 药品名称,MBS.Amount 数量,M.Price3 单价,M.Price3*MBS.Amount 退库总金额,MB.Result 退库原因,MBS.OperatorNo 操作人员,M.NamePinyin 药品拼音
                FROM 
                tb_MedicineBackStore AS MBS,tb_MedicineBad AS MB,tb_Medicine AS M,tb_MedicineInventory AS MI,tb_MedicineEnterHall AS ME
                WHERE MB.No=MBS.RestoreNo AND MB.StoreNo=MI.No AND MI.MedicineNo=M.No AND M.No=ME.MedicineNo
                ORDER BY MBS.No;
                
                SELECT * FROM tb_OutDateResult;
                
                SELECT M.No 药品编号,M.Name 药品名称,M.Standard 药品标准,M.Type 药品类型,M.Unit 单位,M.MedicinePropert 药品性质,M.MedicineForm 药品剂型,M.BatchNo 生产批号,M.LoginUnit 注册单位,M.Price1 实际价,M.Price2 零售价,M.Price3 销售价,M.NamePinyin 药品拼音,M.FunctionWork 功效 FROM tb_Medicine AS M;
                
                SELECT * FROM tb_InventoryType";

            SqlDataAdapter sqlDataAdapter = SqlHelper.NewCommand(CommandText).GetAdapter();
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
                                                             //SQL数据适配器读取数据，并填充数据集；                                                                   //关闭SQL连接；
            DataTable departmentTable = dataSet.Tables[0];                                              //声明院系数据表，对应数据集的表集合中的第1张数据表；
            DataTable majorTable = dataSet.Tables[1];                                                   //声明专业数据表，对应数据集的表集合中的第2张数据表；
            DataTable classTable = dataSet.Tables[2];
            DataTable EnterMedicine = dataSet.Tables[3];
            DataTable BadMedicine = dataSet.Tables[4];
            DataTable OuthallMedicine = dataSet.Tables[5];
            DataTable BackStore = dataSet.Tables[6];
            DataTable OutResult = dataSet.Tables[7];
            DataTable MedicineCatory = dataSet.Tables[8];
            DataTable CheckType = dataSet.Tables[9];

            this.dgv_Medicine.DataSource = EnterMedicine;
            this.dgv_BadMedicine.DataSource = BadMedicine;
            this.dgv_OuthallMedicine.DataSource = OuthallMedicine;
            this.dgv_BackStore.DataSource = BackStore;
            this.dgv_MedicineCatagory.DataSource = MedicineCatory;
            this.CourseTable = EnterMedicine;                                                 //借助本窗体的课程数据表的方法Copy来复制数据表，并赋予本窗体的先修课程数据表，用作先修课程下拉框的数据源；
            this.CourseTable1 = BadMedicine;
            this.CourseTable2 = OuthallMedicine;
            this.CourseTable3 = BackStore;
            this.CourseTable4 = MedicineCatory;

            this.F_Fuction.show_TreeNode(treeView2, departmentTable);
            this.F_Fuction.show_TreeNode(treeView3, majorTable);
            this.F_Fuction.show_TreeNode(treeView4, classTable);

            //加载下拉列表

            this.F_Fuction.Comshow(cb_Result,"No","Text" ,OutResult);
            this.F_Fuction.Comshow(cb_DosageForm, "No", "Text", classTable);
            this.F_Fuction.Comshow(cb_DosageForm1, "No", "Text", classTable);
            this.F_Fuction.Comshow(cb_MedicineType, "No", "Text", departmentTable);
            this.F_Fuction.Comshow(cb_MedicineType1, "No", "Text", departmentTable);
            this.F_Fuction.Comshow(cb_MedicineProperty, "No", "Text", majorTable);
            this.F_Fuction.Comshow(cb_MedicineProperty1, "No", "Text", majorTable);
            this.F_Fuction.Comshow(cb_Type, "No", "Text", CheckType);
            sqlConnection.Close();
        }

        private void show_TreeContent(TreeView tree,string txt)
        {
            string Subject = tree.SelectedNode.Text.Trim();
            if (Subject != "全部")
            {
                string Case = txt;    
                Select_Case(CourseTable4, Case, Subject, dgv_MedicineCatagory);
            }
            else
            {
                dgv_MedicineCatagory.DataSource = CourseTable4;
            }           
        }

        private void Select_Case(DataTable table,string Case ,string Subject,DataGridView dataGrid)
        {
            DataRow[] searchResultRows =
               table.Select($"{Case} LIKE '%{Subject}%'");					//借助本窗体的课程数据表的方法Select，并提供与SQL类似的谓词表达式作为查询条件，根据拼音缩写进行模糊查询（仅支持%通配符）；查询将返回数据行数组；
            DataTable searchResultTable = table.Clone();                                         //借助本窗体的课程数据表的方法Clone，创建相同架构的空表，用于保存搜索结果所在数据行；
            foreach (DataRow row in searchResultRows)                                                       //遍历搜索结果所在数据行数组；
            {
                searchResultTable.ImportRow(row);                                                           //数据行导入数据表；
            }
            dataGrid.DataSource = searchResultTable;
        }

        //第一个页面

        /// <summary>
        /// 药品拼音查询（第一个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_MedicinePinyin_TextChanged(object sender, EventArgs e)
        {
            string Case= "药品拼音";
            string Subject = this.txb_MedicinePinyin.Text.Trim();
            Select_Case(CourseTable,Case,Subject,dgv_Medicine);    
         }

        /// <summary>
        /// 药品编号查询（第一个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_MedicineNo_TextChanged(object sender, EventArgs e)
        {
            string Case = "药品编号";
            string Subject = this.txb_MedicineNo.Text.Trim();
            Select_Case(CourseTable, Case, Subject, dgv_Medicine);                                    //将数据网格视图的数据源设为搜索结果数据表；
        }
        /// <summary>
        /// 药品名称查询（第一个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_MedicineName_TextChanged(object sender, EventArgs e)
        {
            string Case = "药品名称";
            string Subject = this.txb_MedicineName.Text.Trim();
            Select_Case(CourseTable, Case, Subject, dgv_Medicine);
        }
        /// <summary>
        /// 药品类型查询（第一个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_MedicineType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_MedicineType.Text.Trim() != "全部")
            {
                string Case = "药品类型";
                string Subject = this.cb_MedicineType.Text.Trim();
                Select_Case(CourseTable, Case, Subject, dgv_Medicine);
            }
            else
            {
                dgv_Medicine.DataSource = CourseTable;
            }
        }
        /// <summary>
        /// 药品性质查询（第一个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_MedicineProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_MedicineProperty.Text.Trim()!="全部")
            {
                string Case = "药品性质";
                string Subject = this.cb_MedicineProperty.Text.Trim();
                Select_Case(CourseTable, Case, Subject, dgv_Medicine);
            }
            else
            {
                dgv_Medicine.DataSource = CourseTable;
            }
        }
        /// <summary>
        /// 药品剂型查询（第一个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_DosageForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_DosageForm.Text.Trim()!="全部")
            {
                string Case = "药品剂型";
                string Subject = this.cb_DosageForm.Text.Trim();
                Select_Case(CourseTable, Case, Subject, dgv_Medicine);
            }
            else
            {
                dgv_Medicine.DataSource = CourseTable;
            }          
        }
        /// <summary>
        /// 清空（第一个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            cb_DosageForm.SelectedIndex = 0;
            cb_MedicineProperty.SelectedIndex = 0;
            cb_MedicineType.SelectedIndex = 0;
            txb_MedicineName.Clear();txb_MedicineNo.Clear();txb_MedicinePinyin.Clear();      
        }
        //第二个页面

        /// <summary>
        /// 药品拼音查询（第二个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_MedicineNo1_TextChanged(object sender, EventArgs e)
        {
            string Case = "药品拼音";
            string Subject = this.txb_MedicineNo1.Text.Trim();
            Select_Case(CourseTable1, Case, Subject, dgv_BadMedicine);
        }

        /// <summary>
        /// 入库单号查询（第二个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_EnterNo_TextChanged(object sender, EventArgs e)
        {
            string Case = "入库单号";
            string Subject = this.txb_EnterNo.Text.Trim();
            Select_Case(CourseTable1, Case, Subject, dgv_BadMedicine);
        }

        /// <summary>
        /// 报损单号查询（第二个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_BadNo_TextChanged(object sender, EventArgs e)
        {
            DataRow[] searchResultRows =
                this.CourseTable1.Select($"报损单号 = {int.Parse(this.txb_BadNo.Text.Trim())}");					//借助本窗体的课程数据表的方法Select，并提供与SQL类似的谓词表达式作为查询条件，根据拼音缩写进行模糊查询（仅支持%通配符）；查询将返回数据行数组；
            DataTable searchResultTable = this.CourseTable1.Clone();                                         //借助本窗体的课程数据表的方法Clone，创建相同架构的空表，用于保存搜索结果所在数据行；
            foreach (DataRow row in searchResultRows)                                                       //遍历搜索结果所在数据行数组；
            {
                searchResultTable.ImportRow(row);                                                           //数据行导入数据表；
            }
            this.dgv_BadMedicine.DataSource = searchResultTable;
        }
        /// <summary>
        /// 药品类别查询（第二个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_MedicineType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_MedicineType1.Text.Trim() != "全部")
            {
                string Case = "药品类型";
                string Subject = this.cb_MedicineType1.Text.Trim();
                Select_Case(CourseTable1, Case, Subject, dgv_BadMedicine);
            }
            else
            {
                dgv_BadMedicine.DataSource = CourseTable1;
            }
        }
         /// <summary>
         /// 药品性质查询（第二个页面）
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        private void cb_MedicineProperty1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_MedicineProperty1.Text.Trim() != "全部")
            {
                string Case = "药品性质";
                string Subject = this.cb_MedicineProperty1.Text.Trim();
                Select_Case(CourseTable1, Case, Subject, dgv_BadMedicine);              
            }
            else
            {
                dgv_BadMedicine.DataSource = CourseTable1;
            }
        }
        /// <summary>
        /// 药品剂型查询（第二个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_DosageForm1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_DosageForm1.Text.Trim() != "全部")
            {
                string Case = "药品剂型";
                string Subject = this.cb_DosageForm1.Text.Trim();
                Select_Case(CourseTable1, Case, Subject, dgv_BadMedicine);
            }
            else
            {
                dgv_BadMedicine.DataSource = CourseTable1;
            }
        }
        /// <summary>
        /// 清空查询条件（第二个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Clear1_Click(object sender, EventArgs e)
        {
            cb_DosageForm1.SelectedIndex = 0;
            cb_MedicineProperty1.SelectedIndex = 0;
            cb_MedicineType1.SelectedIndex = 0;
            txb_BadNo.Clear();txb_EnterNo.Clear();txb_MedicineNo1.Clear();
        }
        /// <summary>
        /// 关闭窗体（第一个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btn_Close1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 关闭窗体（第二个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //第三个页面

        /// <summary>
        /// 加载树形控件（第三个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadTree()
        {                                                                 //将SQL命令的连接属性指向SQL连接；
            string CommandText =                                                                    //指定SQL命令的命令文本；
                @"SELECT * FROM tb_Ward;
                  SELECT * FROM tb_SickRoom;
                  SELECT * FROM tb_SickMan;";
            SqlDataAdapter sqlDataAdapter = SqlHelper.NewCommand(CommandText).GetAdapter();
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);  

            DataTable departmentTable = dataSet.Tables[0];                                              //声明院系数据表，对应数据集的表集合中的第1张数据表；
            DataTable majorTable = dataSet.Tables[1];                                                   //声明专业数据表，对应数据集的表集合中的第2张数据表；
            DataTable classTable = dataSet.Tables[2];                                                   //声明班级数据表，对应数据集的表集合中的第3张数据表；
            DataRelation[] dataRelations =                                                              //声明数据关系数组；
            {
                new DataRelation                                                                        //实例化数据关系，实现院系表、专业表之间的层次关系；
                    ("Department_Major",                                                                //数据关系名称；
                     departmentTable.Columns["No"],                                                     //父表的被参照列为院系表的编号列；
                     majorTable.Columns["WardNo"]),                                               //子表的参照列为专业表的院系编号列；不要求后端数据库在子表的参照列上创建外键约束；
                new DataRelation                                                                        //实例化数据关系，实现专业表、班级表之间的层次关系；
                    ("Major_Class",                                                                     //数据关系名称；
                     majorTable.Columns["No"],                                                          //父表的被参照列为专业表的编号列；
                     classTable.Columns["RoomNo"])                                                     //子表的参照列为班级表的专业编号列；
            };

            dataSet.Relations.AddRange(dataRelations);                                                  //将数据关系数组批量加入数据集的关系集合中；
            this.treeView1.Nodes.Clear();                                                       //树形视图的节点集合清空；
            foreach (DataRow departmentRow in departmentTable.Rows)                                     //遍历院系数据表中的每一数据行；
            {
                TreeNode departmentNode = new TreeNode();                                               //声明并实例化院系节点，该节点对应当前某个院系；
                departmentNode.Text = departmentRow["Name"].ToString();                                 //院系节点的文本设为当前院系的名称；
                this.treeView1.Nodes.Add(departmentNode);                                       //将院系节点加入树形视图的（根）节点集合；
                foreach (DataRow majorRow in departmentRow.GetChildRows("Department_Major"))            //借助先前定义的数据关系，遍历当前院系所在数据行的子行，即下属所有专业；
                {
                    TreeNode majorNode = new TreeNode();                                                //声明并实例化专业节点，该节点对应当前某个专业；
                    majorNode.Text = majorRow["Name"].ToString();                                       //专业节点的文本设为当前专业的名称；
                    departmentNode.Nodes.Add(majorNode);                                                //专业节点加入当前院系节点的节点集合，成为第1级节点之一；
                    foreach (DataRow classRow in majorRow.GetChildRows("Major_Class"))                  //借助先前定义的数据关系，遍历当前专业所在数据行的子行，即下属所有班级；
                    {
                        TreeNode classNode = new TreeNode();                                            //声明并实例化班级节点，该节点对应当前某个班级；
                        classNode.Text = classRow["Name"].ToString();                                   //班级节点的文本设为当前班级的名称；
                        classNode.Tag = classRow["No"];													//班级节点的标签设为当前班级的编号；
                        majorNode.Nodes.Add(classNode);                                                 //班级节点加入当前专业节点的节点集合，成为第2级节点之一；
                    }
                }
            }
        }
        /// <summary>
        /// 根据树形节点选值（第三个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = connectionString;
            if (this.treeView1.SelectedNode.Level == 0)
            {
                string Case = "病区";
                string Subject = this.treeView1.SelectedNode.Text.Trim();
                Select_Case(CourseTable2, Case, Subject, dgv_OuthallMedicine);
            }
            if (this.treeView1.SelectedNode.Level == 1)
            {
                string Case = "病房";
                string Subject = this.treeView1.SelectedNode.Text.Trim();
                Select_Case(CourseTable2, Case, Subject, dgv_OuthallMedicine);
            }
            if (this.treeView1.SelectedNode.Level == 2)
            {
                string Case = "病人";
                string Subject = this.treeView1.SelectedNode.Text.Trim();
                Select_Case(CourseTable2, Case, Subject, dgv_OuthallMedicine);
            }
        }
        /// <summary>
        /// 药品拼音查询（第三个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_MedicinePinyi2_TextChanged(object sender, EventArgs e)
        {
            string Case = "药品拼音";
            string Subject = this.txb_MedicinePinyi2.Text.Trim();
            Select_Case(CourseTable2, Case, Subject, dgv_OuthallMedicine);
        }
        /// <summary>
        /// 药品名称查询（第三个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_MedicineName2_TextChanged(object sender, EventArgs e)
        {
            string Case = "药品名称";
            string Subject = this.txb_MedicineName2.Text.Trim();
            Select_Case(CourseTable2, Case, Subject, dgv_OuthallMedicine);
        }
        //第四个页面

        /// <summary>
        /// 药品拼音查询（第四个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_MedicinePinyin3_TextChanged(object sender, EventArgs e)
        {
            string Case = "药品拼音";
            string Subject = this.txb_MedicinePinyin3.Text.Trim();
            Select_Case(CourseTable3, Case, Subject, dgv_BackStore);
        }
        /// <summary>
        /// 药品名称查询（第四个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_MedicineName3_TextChanged(object sender, EventArgs e)
        {
            string Case = "药品名称";
            string Subject = this.txb_MedicineName3.Text.Trim();
            Select_Case(CourseTable3, Case, Subject, dgv_BackStore);
        }
        /// <summary>
        /// 退库原因查询（第四个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_Result_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Result.Text.Trim() != "全部")
            {
                string Case = "退库原因";
                string Subject = this.cb_Result.Text.Trim();
                Select_Case(CourseTable3, Case, Subject, dgv_BackStore);
            }
            else
            {
                dgv_BackStore.DataSource = CourseTable1;
            }
        }
        //第五个页面

        /// <summary>
        /// 药品拼音查询（第五个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_MedicinePinyin4_TextChanged(object sender, EventArgs e)
        {
            string Case = "药品拼音";
            string Subject = this.txb_MedicinePinyin4.Text.Trim();
            Select_Case(CourseTable4, Case, Subject, dgv_MedicineCatagory);
        }
        /// <summary>
        /// 药品编号查询（第五个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_MedinceNo4_TextChanged(object sender, EventArgs e)
        {
            string Case = "药品编号";
            string Subject = this.txb_MedinceNo4.Text.Trim();
            Select_Case(CourseTable4, Case, Subject, dgv_MedicineCatagory);
        }
        /// <summary>
        /// 药品名称查询（第五个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_MedicineName4_TextChanged(object sender, EventArgs e)
        {
            string Case = "药品名称";
            string Subject = this.txb_MedicineName4.Text.Trim();
            Select_Case(CourseTable4, Case, Subject, dgv_MedicineCatagory);
        }

        /// <summary>
        /// 树形节点1查询（第五个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            show_TreeContent(treeView2, lblType.Text.Trim());
        }
        /// <summary>
        /// 树形节点2查询（第五个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView3_AfterSelect(object sender, TreeViewEventArgs e)
        {
            show_TreeContent(treeView3, lblProperty.Text.Trim());
        }
        /// <summary>
        /// 树形节点3查询（第五个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView4_AfterSelect(object sender, TreeViewEventArgs e)
        {
            show_TreeContent(treeView4, lblForm.Text.Trim());
        }
        /// <summary>
        /// 为药品显示照片（第五个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_MedicineCatagory_Click(object sender, EventArgs e)
        {
            Image originalImage;
            string originalImagePath = "C:\\Users\\JXDN\\OneDrive\\桌面\\图片素材\\药品.png";
            byte[] imageBytes = File.ReadAllBytes(originalImagePath);
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                originalImage = Image.FromStream(ms);
            }

            // 设置PictureBox的图片  
            pcb_Picture.Image = originalImage;
            lbl_MedicineNo.Text = this.dgv_MedicineCatagory.CurrentRow.Cells[0].Value.ToString();
            lbl_MedicineName.Text = this.dgv_MedicineCatagory.CurrentRow.Cells[1].Value.ToString();
            rtb_Fuction.Text=this.dgv_MedicineCatagory.CurrentRow.Cells[13].Value.ToString();
            btn_OpenPhoto.Visible = true;
            
            string CommandText = $@"SELECT * FROM tb_Medicine WHERE NO='{lbl_MedicineNo.Text.Trim()}';";
            SqlDataReader sqlDataReader =
                         this.SqlHelper.NewCommand(CommandText)
                                       .GetReader();

            byte[] photoBytes = null;
            if (sqlDataReader.Read())
            {
                photoBytes =
                    (sqlDataReader["Photo"] == DBNull.Value ? null : (byte[])sqlDataReader["Photo"]);
            }
            if (photoBytes != null)
            {
                MemoryStream memoryStream = new MemoryStream(photoBytes);
                this.pcb_Picture.Image = Image.FromStream(memoryStream);
                pcb_Picture.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        /// <summary>
        /// 添加照片（第五个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OpenPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openPhotoDialog = new OpenFileDialog()
            {
                Title = "打开照片文件"
                ,
                Filter = "图像文件|*.bmp;*.jpg;*.png"
                ,
                InitialDirectory = GetFolderPath(SpecialFolder.MyPictures)
            };
            if (openPhotoDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openPhotoDialog.FileName;
                this.pcb_Picture.Image = Image.FromFile(fileName);
                pcb_Picture.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            btn_Sure.Visible = true;
        }
        /// <summary>
        /// 确认添加照片（第五个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Sure_Click(object sender, EventArgs e)
        {
            //照片的处理
            MemoryStream memoryStream = new MemoryStream();
            this.pcb_Picture.Image.Save(memoryStream, ImageFormat.Bmp);
            byte[] photoBytes = new byte[memoryStream.Length];
            memoryStream.Seek(0, SeekOrigin.Begin);
            memoryStream.Read(photoBytes, 0, photoBytes.Length);

            string CommandText =
                $@"UPDATE tb_Medicine
                SET Photo=@Photo
                WHERE No='{this.lbl_MedicineNo.Text.Trim()}';";
            int rowAffected = this.SqlHelper.NewCommand(CommandText).NewParameter("@Photo", memoryStream).NonQuery();
            this.F_Fuction.MessgeShow(rowAffected, "添加成功。", "添加失败！");
            
             btn_Sure.Visible = false;
             frm_ReportMedicine_Load_1(null, null);

        }

        //第六个页面

        /// <summary>
        /// 盘点方式选择（第六个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            lv_Medicine.Items.Clear();
            Select_List(cb_Type.Text.Trim(),null);
        }
        /// <summary>
        /// 盘点时间选择（第六个页面）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePicker8_ValueChanged(object sender, EventArgs e)
        {
            lv_Medicine.Items.Clear();
            Select_List(null,dtp_Timer.Value.ToString() );
        }
        /// <summary>
        /// 显示盘点单细则
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lv_Medicine_Click(object sender, EventArgs e)
        {
            string CheckNo = this.lv_Medicine.SelectedItems[0].SubItems[0].Text;
            string CheckType = this.lv_Medicine.SelectedItems[0].SubItems[1].Text;

            string CommandText =                                                                    //指定SQL命令的命令文本；
                                @"SELECT MC.CheckNo 盘点单号,ROW_NUMBER() OVER (ORDER BY MC.StoreNo asc) AS 序号,
                                    MC.StoreNo 入库单号,M.Name 药品名称,MI.Amount 预计数量, MC.Amount 盘点数量,
                                    CASE   
                                    WHEN MC.Amount < MI.Amount THEN '库存盈亏，亏损'+CAST(MI.Amount-MC.Amount AS varchar)  
                                    WHEN MC.Amount > MI.Amount THEN '库存盈余，盈余'+CAST(MC.Amount-MI.Amount AS varchar)   
                                    WHEN MC.Amount = MI.Amount THEN '库存平衡'  
                                    ELSE '无' 
                                    END AS 盘点情况  ,MC.Remark 盘点备注
                                    FROM tb_MedicineCheckPro AS MC,tb_MedicineInventory AS MI,tb_Medicine AS M
                                    WHERE MI.MedicineNo=M.No AND MC.StoreNo=MI.No AND CheckNo=@CheckNo";
            DataTable dt =
                      this.SqlHelper.NewCommand(CommandText).NewParameter("@CheckNo", CheckNo).GetTable();
            int affectrow= this.SqlHelper.NewCommand(CommandText).NewParameter("@CheckNo", CheckNo).NonQuery();
            dgv_CheckMedicine.DataSource = dt;
            lblName.Text = $"盘点单：{CheckNo}   盘点方式：{CheckType}   共{affectrow}条记录";
        }  
    }
}
