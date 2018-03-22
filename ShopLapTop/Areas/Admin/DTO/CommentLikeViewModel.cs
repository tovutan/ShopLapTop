using ShopLapTop.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopLapTop.Areas.Admin.DTO
{
    public class CommentLikeViewModel
    {
        public int CommentID { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }
        public bool Like { get; set; }
        public bool Dislike {get;set;}
   
        public int ID { get; set; }
        public Comment comment { get; set; }
    }
}