namespace 医院住院药房管理系统.Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OutDateResult
    {
        [Key]
        public int No { get; set; }

        [Required]
        [StringLength(20)]
        public string Text { get; set; }
    }
}
