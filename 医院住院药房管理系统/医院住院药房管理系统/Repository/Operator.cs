namespace 医院住院药房管理系统.Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Operator
    {
        [Key]
        [StringLength(10)]
        public string NO { get; set; }

        [Required]
        [StringLength(20)]
        public string UserNo { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string Sex { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }

        public int? Age { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        public byte[] Photo { get; set; }
    }
}
