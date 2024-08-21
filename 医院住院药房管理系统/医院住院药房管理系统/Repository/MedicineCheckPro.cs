namespace 医院住院药房管理系统.Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MedicineCheckPro
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string CheckNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string StoreNo { get; set; }

        public int? Amount { get; set; }

        [StringLength(100)]
        public string Remark { get; set; }
    }
}
