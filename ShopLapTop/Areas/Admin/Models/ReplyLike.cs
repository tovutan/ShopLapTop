using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopLapTop.Areas.Admin.Models
{
    [Table("ReplyLike")]
    public class ReplyLike
    {
        [Key]
        public int ReplyID { get; set; }
        public string UserName { get; set; }
        public bool Like { get; set; }
        public bool Dislike { get; set; }
        public int Reply_ID { get; set; }

        public virtual Reply reply { get; set; }

    }
}