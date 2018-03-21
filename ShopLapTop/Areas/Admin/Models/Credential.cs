using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopLapTop.Areas.Admin.Models
{
    [Table("Credential")]
    [Serializable]
    public class Credential
    {
        [Key]
        [Column(Order =0)]
        public string UserGroupID { get; set; }
        [Key]
        [Column(Order =1)]
        public string  RoleID { get; set; }
    }
}