namespace 医院住院药房管理系统.Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MedicineBad
    {
        [Key]
        public int No { get; set; }

        [Required]
        [StringLength(20)]
        public string StoreNo { get; set; }

        public int Amount { get; set; }

        [Required]
        [StringLength(10)]
        public string OperatorNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [StringLength(50)]
        public string Result { get; set; }
    }
}
