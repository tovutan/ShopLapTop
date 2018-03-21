using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopLapTop.Areas.Admin.Models
{
    [Table("ChildCategory")]
    public class ChildCategory
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public int? Maloai { get; set; }

        public virtual Loai Loai { get; set; }
        
    }
}