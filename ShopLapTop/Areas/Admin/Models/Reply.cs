using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopLapTop.Areas.Admin.Models
{
    [Table("Reply")]
    public class Reply
    {
        [Key]
        public int ID { get; set; }

        public int ProductID { get; set; }

        public int CommentID { get; set; }// của bảng Comment

        public int ParentReplyID { get; set; }
        public DateTime DateTime { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }

        [DefaultValue(false)]
        public bool Deleted { get; set; }

        public virtual Comment comment { get; set; }
        public virtual Sanpham sanpham { get; set; }
        
        public virtual ICollection<ReplyLike> ReplyLike { get; set; }
    }
}