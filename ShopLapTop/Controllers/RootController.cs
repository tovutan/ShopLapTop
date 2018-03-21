using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;
using System.Web.Mvc;
using ShopLapTop.Areas.Admin.Models;
using ShopLapTop.Models;
namespace ShopLapTop.Controllers
{
    public class RootController : Controller
    {
        laptop lt = new laptop();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            List<Loai> loai = lt.Loais.ToList();
            ViewBag.loai = loai;
            return View();
        }
    }
}