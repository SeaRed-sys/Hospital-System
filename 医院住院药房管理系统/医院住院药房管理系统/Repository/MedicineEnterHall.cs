namespace 医院住院药房管理系统.Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MedicineEnterHall
    {
        [Key]
        public int No { get; set; }

        [Required]
        [StringLength(20)]
        public string RequestNo { get; set; }

        [Required]
        [StringLength(20)]
        public string MedicineNo { get; set; }

        [Required]
        [StringLength(20)]
        public string OperatorNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int? Amount { get; set; }
    }
}
