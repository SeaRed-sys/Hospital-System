using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 医院住院药房管理系统.Model
{
    public class Medicine
    {
        /// <summary>
        /// 药品编号
        /// </summary>
        public string No { get; set; }
        /// <summary>
        /// 药品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 名称拼音
        /// </summary>
        public string NamePinyin { get; set; }
        /// <summary>
        /// 药品规格
        /// </summary>
        public string Standard { get; set; }
        /// <summary>
        /// 药品作用
        /// </summary>
        public string FunctionWork { get; set; }
        /// <summary>
        /// 药剂类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 药品单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 药品性质
        /// </summary>
        public string MedicineProperty { get; set; }
        /// <summary>
        /// 药品剂型
        /// </summary>
        public string MedicineForm { get; set; }
        /// <summary>
        /// 生产批号
        /// </summary>
        public string BatchNo { get; set; }
        /// <summary>
        /// 生产单位
        /// </summary>
        public string BatchUnit { get; set; }
        /// <summary>
        /// 生产日期
        /// </summary>
        public string BatchDate { get; set; }
        /// <summary>
        /// 有效期
        /// </summary>
        public string LifeSpan { get; set; }
        /// <summary>
        /// 使用期
        /// </summary>
        public string UseDate { get; set; }
        /// <summary>
        /// 注册单位
        /// </summary>
        public string LoginUnit { get; set; }
        /// <summary>
        /// 实际价
        /// </summary>
        public string Price1 { get; set; }
        /// <summary>
        /// 批发价
        /// </summary>
        public string Price2 { get; set; }
        /// <summary>
        /// 零售价
        /// </summary>
        public string Price3 { get; set; }
      
    }
}
