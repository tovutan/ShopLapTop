namespace ShopLapTop.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("taikhoan")]
    public partial class taikhoan
    {
        [Key]
        [StringLength(60)]
        public string username { get; set; }

        [Required]
        [StringLength(60)]
        public string password { get; set; }
        public string name { get; set; }

        public bool status { get; set; }

        public string GroupID { get; set; }
    }
}
