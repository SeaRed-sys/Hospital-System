namespace 医院住院药房管理系统.Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string TypeNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string IDName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string Password { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool IsActivated { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LoginFailCount { get; set; }
    }
}
