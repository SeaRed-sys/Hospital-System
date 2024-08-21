namespace 医院住院药房管理系统.Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ChangeInformation
    {
        [Key]
        [StringLength(10)]
        public string NO { get; set; }

        [StringLength(100)]
        public string PasswordQuestional1 { get; set; }

        [StringLength(100)]
        public string Answer1 { get; set; }

        [StringLength(100)]
        public string PasswordQuestional2 { get; set; }

        [StringLength(100)]
        public string Answer2 { get; set; }
    }
}
