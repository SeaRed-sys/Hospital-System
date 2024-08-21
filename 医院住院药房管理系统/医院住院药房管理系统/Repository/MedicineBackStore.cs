namespace 医院住院药房管理系统.Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MedicineBackStore
    {
        [Key]
        public int No { get; set; }

        [Required]
        [StringLength(20)]
        public string RestoreNo { get; set; }

        public int Amount { get; set; }

        [Required]
        [StringLength(20)]
        public string OperatorNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
    }
}
