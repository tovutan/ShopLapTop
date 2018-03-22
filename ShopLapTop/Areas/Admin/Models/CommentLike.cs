using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopLapTop.Areas.Admin.Models
{
    [Table("CommentLike")]
    public class CommentLike
    {
        [Key]
        public int CommentID { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }
        public bool Like { get; set; }
        public bool Dislike { get;set; }
        public int ID { get; set; }

        public virtual Comment comment { get; set; }
    }
}