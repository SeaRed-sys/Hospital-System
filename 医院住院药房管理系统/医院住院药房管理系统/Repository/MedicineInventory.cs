namespace 医院住院药房管理系统.Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MedicineInventory
    {
        [Key]
        [StringLength(20)]
        public string No { get; set; }

        [Required]
        [StringLength(10)]
        public string MedicineNo { get; set; }

        public int Amount { get; set; }

        [Column(TypeName = "date")]
        public DateTime PurchaseDate { get; set; }

        [Required]
        [StringLength(20)]
        public string Supplier { get; set; }

        [Required]
        [StringLength(50)]
        public string ApprovalNumber { get; set; }

        [StringLength(5)]
        public string isHasQualified { get; set; }

        [StringLength(5)]
        public string isQualified { get; set; }

        [Column(TypeName = "date")]
        public DateTime OperateTime { get; set; }

        [Required]
        [StringLength(10)]
        public string OperatorNo { get; set; }

        public DateTime? UpdateTime { get; set; }
    }
}
