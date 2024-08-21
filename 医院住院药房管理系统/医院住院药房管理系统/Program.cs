using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using 医院住院药房管理系统.PresentationLayer.主要功能概述.库存汇总;
using 医院住院药房管理系统.PresentationLayer.主要功能概述.报表统计;
using 医院住院药房管理系统.主要功能概述.入房处理;
using 医院住院药房管理系统.主要功能概述.出房处理;
using 医院住院药房管理系统.主要功能概述.库存处理;
using 医院住院药房管理系统.主要功能概述.报销处理;
using 医院住院药房管理系统.主要功能概述.系统设置;
using 医院住院药房管理系统.主要功能概述.药品盘点;
using 医院住院药房管理系统.主要功能概述.领药处理;

namespace 医院住院药房管理系统
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frm_Login login = new frm_Login();
            login.Show();
            //frm_ReportMedicine frm=new frm_ReportMedicine("3220707051");
            //frm.Show();
            Application.Run();
        }
    }
}
