using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopLapTop.Areas.Admin.Models
{
    [Table("ProductLike")]
    public class ProductLike
    {
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public bool Like { get; set; }
        public bool  Dislike { get; set; }
        public int Product_ID { get; set; }

        public virtual Sanpham sanpham { get; set; }

    }
}