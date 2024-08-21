namespace 医院住院药房管理系统.Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MedicineAttribute
    {
        [Key]
        [StringLength(10)]
        public string MedicineNo { get; set; }

        public int SaveNo1 { get; set; }

        public int SaveNo2 { get; set; }

        public int MinNo1 { get; set; }

        public int MinNo2 { get; set; }

        public int MaxNo1 { get; set; }

        public int MaxNo2 { get; set; }
    }
}
