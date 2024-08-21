namespace 医院住院药房管理系统.Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MedicineRequest
    {
        [Key]
        [StringLength(20)]
        public string No { get; set; }

        [StringLength(20)]
        public string EnterNo { get; set; }

        [Required]
        [StringLength(10)]
        public string MedicineNo { get; set; }

        [Required]
        [StringLength(10)]
        public string TakeNo { get; set; }

        public int Amount { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(10)]
        public string OperatorNo { get; set; }

        public int? ReallyAmount { get; set; }
    }
}
