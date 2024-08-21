namespace 医院住院药房管理系统.Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class IsMedicineRequest
    {
        [Key]
        [StringLength(20)]
        public string ReQuestNo { get; set; }

        public int Amount { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
    }
}
