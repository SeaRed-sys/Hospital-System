using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 医院住院药房管理系统.DataAccessLayer;
using 医院住院药房管理系统.PresentationLayer;

namespace 医院住院药房管理系统.主要功能概述.出房处理
{
    public partial class frm_PrintSelect : Form
    {
        /// <summary>
        /// 一般方法
        /// </summary>
        private F_Fuction F_Fuction;
        /// <summary>
        /// SQL助手
        /// </summary>
        private SQLHepler SqlHelper;

        public frm_PrintSelect()
        {
            InitializeComponent();
            this.AcceptButton = this.btn_Back;
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
        private string _ward;
        private bool _isDate;
        private bool _isYes;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ward"></param>
        /// <param name="isDate"></param>
        /// <param name="isYes"></param>
        public frm_PrintSelect(string ward,bool isDate,bool isYes) : this()
        {
            _ward = ward;
            _isDate = isDate;
            _isYes = isYes;
        }

        private void frm_PrintSelect_Load(object sender, EventArgs e)
        {
            LoadPage(currentPage);    
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // 分页设置
        int pageSize = 10; // 每页显示的项数
        int currentPage = 1; // 当前页码
        // 创建分页的方法
        private void LoadPage(int pageNumber)
        {
            string commandText = "";
            if (_isDate && _isYes)
            {
                commandText = $@"SELECT *
                                        FROM (
                                        select ROW_NUMBER() OVER (ORDER BY MO.No asc) AS 序号,
                                        MO.WardName 病区,MO.RoomName 病房,
                                        MO.ManName 病人,MO.MedicineName 药品名称,M.Standard 药品规格,MO.Amount 总量,M.Unit 单位,M.Price3*MO.Amount 总价,MO.Date 时间
                                        ,MO.Nurse 领药护士,O.Name 操作人员
			                            from 
                                        tb_MedicineOutHall AS MO,tb_Medicine AS M,tb_Operator AS O
                                        WHERE MO.MedicineName=M.Name  AND MO.OperateNo=O.NO AND MO.WardName='{_ward}'
                                        ) AS SubQuery
				                        WHERE 序号 BETWEEN @Skip AND @Take";
            }
            else if (!_isDate && !_isYes)
            {
                commandText = $@"SELECT *
                                        FROM (
                                        select ROW_NUMBER() OVER (ORDER BY MO.No asc) AS 序号,
                                         MO.WardName 病区,MO.RoomName 病房,
                                        MO.ManName 病人,MO.MedicineName 药品名称,MO.Amount 总量,M.Unit 单位,M.Price3*MO.Amount 总价
                                        ,MO.Nurse 领药护士,O.Name 操作人员
			                            from 
                                        tb_MedicineOutHall AS MO,tb_Medicine AS M,tb_Operator AS O
                                        WHERE MO.MedicineName=M.Name  AND MO.OperateNo=O.NO AND MO.WardName='{_ward}'
                                        ) AS SubQuery
				                        WHERE 序号 BETWEEN @Skip AND @Take";
            }
            else if (!_isDate && _isYes)
            {
                commandText = $@"SELECT *
                                        FROM (
                                        select ROW_NUMBER() OVER (ORDER BY MO.No asc) AS 序号,
                                        MO.WardName 病区,MO.RoomName 病房,
                                        MO.ManName 病人,MO.MedicineName 药品名称,M.Standard 药品规格,MO.Amount 总量,M.Unit 单位,M.Price3*MO.Amount 总价
                                        ,MO.Nurse 领药护士,O.Name 操作人员
			                            from 
                                        tb_MedicineOutHall AS MO,tb_Medicine AS M,tb_Operator AS O
                                        WHERE MO.MedicineName=M.Name  AND MO.OperateNo=O.NO AND MO.WardName='{_ward}'
                                        ) AS SubQuery
				                        WHERE 序号 BETWEEN @Skip AND @Take";
            }
            else
            {
                commandText = $@"SELECT *
                                        FROM (
                                        select ROW_NUMBER() OVER (ORDER BY MO.No asc) AS 序号,
                                        MO.WardName 病区,MO.RoomName 病房,
                                        MO.ManName 病人,MO.MedicineName 药品名称,MO.Amount 总量,M.Unit 单位,M.Price3*MO.Amount 总价,MO.Date 时间
                                         ,MO.Nurse 领药护士,O.Name 操作人员
			                            from 
                                        tb_MedicineOutHall AS MO,tb_Medicine AS M,tb_Operator AS O
                                        WHERE MO.MedicineName=M.Name  AND MO.OperateNo=O.NO AND MO.WardName='{_ward}'
                                        ) AS SubQuery
				                        WHERE 序号 BETWEEN @Skip AND @Take";
            }
            DataTable table = this.F_Fuction.LoadPage(pageNumber, pageSize, commandText);
            dgv_print.DataSource = table;

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
