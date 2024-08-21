using System.Data;
using System.Windows.Forms;
using 医院住院药房管理系统.DataAccessLayer;

namespace 医院住院药房管理系统.PresentationLayer
{
    public  class F_Fuction
    {
        /// <summary>
        /// SQL助手
        /// </summary>
        private SQLHepler SqlHelper;

        public void Comshow(ComboBox combo,string No,string Text,DataTable table)
        {
            combo.DataSource = table;
            combo.DisplayMember = Text;
            combo.ValueMember = No;
        }
        public void MessgeShow(int rowAffected,string v1,string v2)
        {
            if (rowAffected == 1)                                                                       //若成功写入1行记录；
            {
                MessageBox.Show($"{v1}", "消息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);															//显示正确提示；
            }
            else                                                                                        //否则；
            {
                MessageBox.Show($"{v2}", "消息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);															//显示错误提示；
            }
        }
        /// <summary>
        /// 创造分页
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="CommandText"></param>
        /// <returns></returns>
        public DataTable LoadPage(int pageNumber,int pageSize,string CommandText)
        {
            this.SqlHelper = new SQLHepler();
            int skipItems = (pageNumber - 1) * pageSize;
            int takeItems = skipItems + pageSize;
            DataTable table = this.SqlHelper.NewCommand(CommandText)
                .NewParameter("@Skip", skipItems + 1).NewParameter("@Take", takeItems)
                .GetTable();
            return table;
        }
        /// <summary>
        /// 加载树节点
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="table"></param>
        public void show_TreeNode(TreeView tree, DataTable table)
        {
            foreach (DataRow Row in table.Rows)                                     //遍历院系数据表中的每一数据行；
            {
                TreeNode Node = new TreeNode();                                               //声明并实例化院系节点，该节点对应当前某个院系；
                Node.Text = Row["Text"].ToString();                                 //院系节点的文本设为当前院系的名称；
                tree.Nodes.Add(Node);
            }
        }
    }
}
