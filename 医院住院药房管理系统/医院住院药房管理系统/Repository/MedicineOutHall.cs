namespace 医院住院药房管理系统.Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MedicineOutHall
    {
        [Key]
        public int No { get; set; }

        [Required]
        [StringLength(20)]
        public string MedicineName { get; set; }

        [Required]
        [StringLength(20)]
        public string WardName { get; set; }

        [Required]
        [StringLength(20)]
        public string RoomName { get; set; }

        [Required]
        [StringLength(20)]
        public string ManName { get; set; }

        [Required]
        [StringLength(20)]
        public string OperateNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int? Amount { get; set; }

        [Required]
        [StringLength(20)]
        public string Nurse { get; set; }
    }
}
