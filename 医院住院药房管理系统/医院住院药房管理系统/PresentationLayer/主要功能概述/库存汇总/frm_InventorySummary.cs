using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using System.Xml.Linq;
using 医院住院药房管理系统.DataAccessLayer;
using 医院住院药房管理系统.Repository;

namespace 医院住院药房管理系统.PresentationLayer.主要功能概述.库存汇总
{
    public partial class frm_InventorySummary : Form
    {
        /// <summary>
        /// SQL助手
        /// </summary>
        private SQLHepler SqlHelper;
        /// <summary>
        /// 一般方法
        /// </summary>
        private F_Fuction F_Fuction;

        public frm_InventorySummary()
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
            this.SqlHelper = new SQLHepler();
            this.F_Fuction = new F_Fuction();
            LoadPage(1);
            LoadPage1(1);
        }   
        private string _No;
        /// <summary>
        /// 构造函数；
        /// </summary>
        /// <param name="studentNo">用户名</param>
        public frm_InventorySummary(string No) : this()
        {
            this._No = No;
        }

        /// <summary>
        /// 选显卡的格式
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
        // 分页设置
        int pageSize = 15; // 每页显示的项数
        int currentPage = 1; // 当前页码
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
        /// 页面1分页
        /// </summary>
        /// <param name="pageNumber"></param>
        private void LoadPage(int pageNumber)
        {
            string CommandText = @"
                SELECT *
                FROM (                   
                SELECT ROW_NUMBER() OVER (ORDER BY M.No DESC) AS 序号,
                M.No 药品编号,M.Name 药品名称,M.Standard 药品规格,M.BatchUnit 供货厂家,M.LoginUnit 注册单位,M.Price3 单价,
                MI.库存数量,(M.Price3*MI.库存数量)AS 总价 FROM tb_Medicine AS M,
                (SELECT M.MedicineNo ,SUM(M.Amount) 库存数量
                FROM tb_MedicineInventory AS M
                GROUP BY M.MedicineNo) AS MI
                WHERE MI.MedicineNo=M.NO
                ) AS SubQuery
                WHERE 序号 BETWEEN @Skip AND @Take 
                ";
            DataTable table=
            this.F_Fuction.LoadPage(pageNumber, pageSize, CommandText);
            dgv_StoreSumary.DataSource = table;

        }

        private void dgv_StoreSumary_Click(object sender, EventArgs e)
        {
            string MedicineName =txb_MedicineName.Text= dgv_StoreSumary.CurrentRow.Cells[2].Value.ToString();
            string amount = dgv_StoreSumary.CurrentRow.Cells[7].Value.ToString();
            string amountPrice = dgv_StoreSumary.CurrentRow.Cells[8].Value.ToString();
            rtb_Propect.Text = $@"药品：{MedicineName}，库存数量：{amount}，共计{amountPrice}金额";
        }

        private void btn_Pre1_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadPage1(currentPage);
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            currentPage++;
            LoadPage1(currentPage);
        }
        
        private void LoadPage1(int pageNumber)
        {
            string CommandText = @"
                                SELECT *
                                FROM (                   
                                SELECT ROW_NUMBER() OVER (ORDER BY M.No DESC) AS 序号,
                                M.No 药品编号,M.Name 药品名称,M.Standard 药品规格,M.BatchUnit 供货厂家,M.LoginUnit 注册单位,M.Price3 单价,
                                MI.库存数量,(M.Price3*MI.库存数量)AS 总价 FROM tb_Medicine AS M,
                                (SELECT M.MedicineNo ,SUM(M.Amount) 库存数量
                                FROM tb_MedicineEnterHall AS M
                                GROUP BY M.MedicineNo) AS MI
                                WHERE MI.MedicineNo=M.NO
                                ) AS SubQuery
                                WHERE 序号 BETWEEN @Skip AND @Take 
                                ";
            DataTable table =
            this.F_Fuction.LoadPage(pageNumber, pageSize, CommandText);

            dgv_HallSummary.DataSource = table;
        }

        private void btn_Print1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("打印药库库存汇总表成功！", "消息",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }

        private void btn_Close1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Print2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("打印药房库存汇总表成功！", "消息",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }

        private void btn_Close2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_HallSummary_Click(object sender, EventArgs e)
        {
            string MedicineName = txb_MedicineName1.Text = dgv_HallSummary.CurrentRow.Cells[2].Value.ToString();
            string amount = dgv_HallSummary.CurrentRow.Cells[7].Value.ToString();
            string amountPrice = dgv_HallSummary.CurrentRow.Cells[8].Value.ToString();
            rtb_Propect1.Text = $@"药品：{MedicineName}，房存数量：{amount}，共计{amountPrice}金额";
        }
    }
}
