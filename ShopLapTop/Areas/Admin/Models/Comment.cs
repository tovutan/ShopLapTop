using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopLapTop.Areas.Admin.Models
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        public int ID { get; set; }
        public int MaSP { get; set; }
      
        public DateTime Datetime { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }

        [DefaultValue(0)]
        public int LikeCount { get; set; }
        
        [DefaultValue(false)]
        public bool Deleted { get; set; }

        public virtual Sanpham sanpham { get; set; }

        public virtual ICollection<CommentLike> CommentLike { get; set; }
        public virtual ICollection<Reply> Reply { get; set; }


    }
}