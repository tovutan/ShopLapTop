using ShopLapTop.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopLapTop.Areas.Admin.DTO
{
    public class CommentViewModel
    {

        public IList<Comment> Comments { get; set; }
        public int  ID { get; set; }
        public Comment comment { get; set; }
        public DateTime? Datetime { get; set; }
        public IList<CommentViewModel> ChildRelies { get; set; }
        public string Content { get; set; }
        public int? Like { get; set; }
        public int MaSP { get; set; }
        public int ParentReplyId { get; set; }
        public string UserName { get; set; }
    }
}