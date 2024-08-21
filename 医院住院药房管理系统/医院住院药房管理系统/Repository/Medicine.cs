namespace 医院住院药房管理系统.Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Medicine
    {
        [Key]
        [StringLength(10)]
        public string No { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string NamePinyin { get; set; }

        [Required]
        [StringLength(20)]
        public string Standard { get; set; }

        [StringLength(300)]
        public string FunctionWork { get; set; }

        [Required]
        [StringLength(10)]
        public string Type { get; set; }

        [StringLength(10)]
        public string Unit { get; set; }

        [StringLength(20)]
        public string MedicinePropert { get; set; }

        [StringLength(20)]
        public string MedicineForm { get; set; }

        [StringLength(20)]
        public string BatchNo { get; set; }

        [StringLength(50)]
        public string BatchUnit { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BatchDate { get; set; }

        [StringLength(10)]
        public string LifeSpan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UseDate { get; set; }

        [StringLength(50)]
        public string LoginUnit { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price1 { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price2 { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price3 { get; set; }

        public byte[] Photo { get; set; }
    }
}
