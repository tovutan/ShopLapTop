using ShopLapTop.Areas.Admin.DTO;
using ShopLapTop.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopLapTop.Controllers
{
    public class CommentsController : Controller
    {
        // GET: Comments
        laptop lt = new laptop();
        public ActionResult Index()
        {
            return View();
        }
        // tạo Comment mới
        [HttpPost]
        public ActionResult AddComment(CommentViewModel model,int MaSP)
        {
            Comment com = new Comment();
            var postdetail = lt.Sanphams.FirstOrDefault(x => x.MaSP == MaSP);
            if (model != null)
            {
                com = new Comment() {
                    Content=model.Content,
                    Datetime=DateTime.Now
                };

                if (postdetail != null)
                {
                    try
                    {
                        postdetail.comment.Add(com);
                        lt.SaveChanges();
                    }
                    catch (Exception ex)
                    {

                      
                    }
                    
                }
            }
            return RedirectToAction("GetListComment", "Comments",new {MaSP=MaSP});
        }

        // lấy danh sách Comment của bài chi tiết Product đó
        [HttpGet]
        public PartialViewResult GetListComment(int MaSP)
        {
            IQueryable<CommentViewModel> comment = lt.Comments.Where(x => x.MaSP == MaSP).Select(p => new CommentViewModel
            {
                ID=p.ID,
                Datetime=p.Datetime,
                Content=p.Content,
                Like=p.LikeCount,
                UserName=p.UserName,
            }).AsQueryable();
            return PartialView("~/Views/Shared/_MyComments.cshtml",comment);
        }

        // lấy danh sách SubComments
        //[HttpGet]
        public PartialViewResult GetListSubComments(int ID)
        {
            // Lấy ra danh sách SubComment theo ID của Comment.
            IQueryable<CommentLikeViewModel> item = lt.CommentLikes.Where(x => x.ID == ID).Select(p => new CommentLikeViewModel
            {
                CommentID=p.CommentID,
                UserName=p.UserName,
                Content=p.Content,
                DateTime=p.DateTime,
                Like=p.Like,
                Dislike=p.Dislike,              
            }).AsQueryable().Distinct();
            return PartialView("~/Views/Shared/_MySubComments.cshtml",item);
        }

        // thêm SubComment
        [HttpPost]
        public ActionResult AddSubComment(CommentLikeViewModel data, int ID)
        {
            CommentLike commentlike = null;
            var comment = lt.Comments.FirstOrDefault(x => x.ID == ID);
            if (data != null)
            {
                commentlike = new CommentLike {
                    //CommentID=model.CommentID,
                   // UserName=model.UserName,
                    Content=data.Content,
                    DateTime=data.DateTime,                   
                   // Like=model.Like,
                    //Dislike=model.Dislike,
                    //Comment_ID = model.Comment_ID,

                };
                if (comment != null)
                {
                    try
                    {
                        comment.CommentLike.Add(commentlike);
                        lt.SaveChanges();
                    }
                    catch (Exception ex)
                    {

                        
                    }
                    
                }
            }
            return RedirectToAction("GetListSubComments","Comments",new { ID = ID });
        }
    }
}