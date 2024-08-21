namespace 医院住院药房管理系统.Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MedicineCheck
    {
        [Key]
        [StringLength(20)]
        public string No { get; set; }

        [Required]
        [StringLength(20)]
        public string CheckType { get; set; }

        [Required]
        [StringLength(20)]
        public string CheckForm { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [StringLength(20)]
        public string OperatorNo { get; set; }
    }
}
