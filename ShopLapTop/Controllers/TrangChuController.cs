using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using ShopLapTop.Areas.Admin.Models;
namespace ShopLapTop.Controllers
{
    public class TrangChuController : Controller
    {
        laptop lt=new laptop();
        // GET: TrangChu
        public ActionResult Index(int? page,int pagesize=8)
        {
            var kq = lt.Sanphams.OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
            return View(kq);
        }
        public ActionResult hienloiGmail()
        {
            return View();
        }
    }
}