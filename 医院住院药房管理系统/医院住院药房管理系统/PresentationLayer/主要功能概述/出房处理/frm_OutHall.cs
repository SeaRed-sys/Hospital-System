using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using 医院住院药房管理系统.DataAccessLayer;
using 医院住院药房管理系统.PresentationLayer;

namespace 医院住院药房管理系统.主要功能概述.出房处理
{
    public partial class frm_OutHall : Form
    {
        private TreeNode rootNode;
        /// <summary>
        /// 一般方法
        /// </summary>
        private F_Fuction F_Fuction;
        /// <summary>
        /// SQL助手
        /// </summary>
        private SQLHepler SqlHelper;

        public frm_OutHall()
        {
            InitializeComponent();
            rootNode = new TreeNode("病区");
            treeView1.Nodes.Add(rootNode); // 假设你的TreeView控件名为treeView1  
            
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
        private string _ParentNode;
        private string _GrandNode;
        private string _No;
        /// <summary>
        /// 构造函数；
        /// </summary>
        /// <param name="studentNo">用户名</param>
        public frm_OutHall(string No) : this()
        {
            this._No = No;
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_OutHall_Load(object sender, EventArgs e)
        {
            LoadTree();
            LoadPage(currentPage);
            LoadPage1(currentPage);
            string CommandText =
                    $@"SELECT * FROM tb_Nurse";
            DataTable dataTable =
            this.SqlHelper.NewCommand(CommandText).GetTable();
            this.F_Fuction.Comshow(cb_Nurse,"No","Name",dataTable);
            
            CommandText =
                    $@"SELECT * FROM tb_Ward";
            dataTable = this.SqlHelper.NewCommand(CommandText).GetTable();
            this.F_Fuction.Comshow(cb_Hall, "No", "Name", dataTable);
        }
        //设置Treeview控件
        public void LoadTree()
        {                                                   //将SQL命令的连接属性指向SQL连接；
            string CommandText =                                                                    //指定SQL命令的命令文本；
                @" SELECT * FROM tb_Ward;
                  SELECT * FROM tb_SickRoom;
                  SELECT * FROM tb_SickMan;";
            SqlDataAdapter sqlDataAdapter = SqlHelper.NewCommand(CommandText).GetAdapter();        
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);                                                             //声明并实例化数据集，用于保存查得的多张表；                                                                              //关闭SQL连接；
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
        /// 点击出房按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Enter_Click(object sender, EventArgs e)
        {
            // 假设你想跳转到第二个TabPage（索引为1，因为索引是从0开始的）  
            tabControl1.SelectedIndex = 1;

            lbl_Medicine.Text = dgv_Medicine.CurrentRow.Cells[2].Value.ToString();
        }
        /// <summary>
        /// 点击树节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                
                // 获取并显示选中节点的文本值  
                string selectedNodeValue = treeView1.SelectedNode.Text;
                lbl_SickMan.Text=selectedNodeValue;
                // 获取父节点的值  
                TreeNode parentNode = treeView1.SelectedNode.Parent;
                _ParentNode = (parentNode != null) ? parentNode.Text : "无父节点";
                

                // 获取祖父节点的值  
                TreeNode grandparentNode = (parentNode != null) ? parentNode.Parent : null;
                _GrandNode = (grandparentNode != null) ? grandparentNode.Text : "无祖父节点";
                
            }
        }
        /// <summary>
        /// 确认出房，增加记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Sure_Click(object sender, EventArgs e)
        {
            string CommandText =
            $@"INSERT tb_MedicineOutHall(MedicineName,WardName,RoomName ,ManName ,OperateNo ,Date,Amount,Nurse) 
            VALUES ('{lbl_Medicine.Text}','{_GrandNode}','{_ParentNode}',
            '{lbl_SickMan.Text}','{_No}','{this.dtp_Time.Value}',
            '{txb_Count.Text}','{cb_Nurse.Text}');";

            int rowAffected = this.SqlHelper.NewCommand(CommandText).NonQuery();                                                                        //声明整型变量，用于保存受影响行数；
            this.F_Fuction.MessgeShow(rowAffected, "出房成功。", "出房失败！");
            //显示正确提示；
            UpdateTable();
            txb_Count.Clear(); lbl_Medicine.Text = ""; lbl_SickMan.Text = "";
        }/// <summary>
        /// 更改药房药品数量
        /// </summary>
        private void UpdateTable()
        {
            string No= dgv_Medicine.CurrentRow.Cells[0].Value.ToString();
            int sub = int.Parse(txb_Count.Text);
            string CommandText = $@"update tb_MedicineEnterHall 
                                    set Amount=Amount-{sub}
                                    where No={No}";

            int rowAffected = this.SqlHelper.NewCommand(CommandText).NonQuery();
            if (rowAffected == 1)                                                                       //若成功写入1行记录；
            {
                frm_OutHall_Load(null,null);
                         
            }
            else                                                                                        //否则；
            {
                MessageBox.Show("审批失败！", "消息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);                                                            //显示错误提示；
            }

        }
        /// <summary>
        /// /返回按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Back_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Select_Click(object sender, EventArgs e)
        {
            string ward = cb_Hall.Text;
            bool isDate = chb_Print.Checked;
            bool isYes = chb_Standard.Checked;
            frm_PrintSelect frm_PrintSelect = new frm_PrintSelect(ward,isDate,isYes);
            frm_PrintSelect.Show();
        }
        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // 分页设置
        int pageSize = 10; // 每页显示的项数
        int currentPage = 1; // 当前页码
        // 创建分页的方法
        private void LoadPage(int pageNumber)
        {
            string CommandText = @"
                SELECT *
                FROM (                   
		        SELECT
						ROW_NUMBER() OVER (ORDER BY ME.NO) AS 序号,
                        ME.No 入房编号,
                        M.Name 药品名称,M.Standard 药品规格,M.Type 药品类型,M.Unit 药品单位,ME.Amount 药品数量 
                        from tb_MedicineEnterHall as ME,tb_Medicine AS M
                        WHERE ME.MedicineNo=M.No AND ME.Amount>0) AS SubQuery
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
        private void LoadPage1(int pageNumber)
        {
            string CommandText = @"
                SELECT *
                FROM (                   
		        SELECT ROW_NUMBER() OVER (ORDER BY MO.No DESC) AS 序号,
                MO.ManName 病人姓名,MO.MedicineName 药品名称,M.Standard 药品规格,MO.Amount 总量,M.Unit 单位,M.Price3*MO.Amount 总价,MO.Date 时间
                from 
                tb_MedicineOutHall AS MO,tb_Medicine AS M
                WHERE MO.MedicineName=M.Name) AS SubQuery
				WHERE 序号 BETWEEN @Skip AND @Take ";
            DataTable table = this.F_Fuction.LoadPage(pageNumber, pageSize, CommandText);
            dgv_MedicineDe.DataSource = table;

        }

        private void btn_Pre1_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadPage1(currentPage);
            }
        }

        private void btn_Late1_Click(object sender, EventArgs e)
        {
            currentPage++;
            LoadPage1(currentPage);
        }
    }
}


