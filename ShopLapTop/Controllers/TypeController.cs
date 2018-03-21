using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using ShopLapTop.Areas.Admin.Models;
using ShopLapTop.Models;
namespace ShopLapTop.Controllers
{
    public class TypeController : Controller
    {
        laptop lt = new laptop();
        // GET: Type
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult asus(int id)
        {
            var kq = lt.Sanphams.Where(x => x.Mahieu == id).ToList();
            return View(kq);
        }
        [HttpGet]
        public ActionResult sanphamtheoloaiasus(int? page,int? tu, int? den,string ten, int pagesize=8)
        {
            if (tu == 9000000 && den == null)
            {
                var kq = lt.Sanphams.Where(x => x.Giaban < 10000000
                && x.TenSP.Contains(ten)).OrderBy(x=>x.Giaban).ToPagedList(page??1,8);
                ViewBag.tu = tu;
                ViewBag.den = den;
                ViewBag.ten = ten;
                return View(kq);
            }
            else if (tu == 10000000 && den == 15000000)
            {
                var kq = lt.Sanphams.Where(x => x.Giaban >= 10000000 && 
                x.Giaban < 15000000 && x.TenSP.Contains(ten)).OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                ViewBag.tu = tu;
                ViewBag.den = den;
                ViewBag.ten = ten;
                return View(kq);
            }
            else if (tu == 15000000 && den == 20000000)
            {
                var kq = lt.Sanphams.Where(x => x.Giaban >= 15000000 && 
                x.Giaban < 20000000 && x.TenSP.Contains(ten)).OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                ViewBag.tu = tu;
                ViewBag.den = den;
                ViewBag.ten = ten;
                return View(kq);
            }
            else if (tu == 20000000 && den == 25000000)
            {
                var kq = lt.Sanphams.Where(x => x.Giaban >= 20000000 &&
                x.Giaban < 25000000 && x.TenSP.Contains(ten)).OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                ViewBag.tu = tu;
                ViewBag.den = den;
                ViewBag.ten = ten;
                return View(kq);
            }
            else if (tu == null && den == 26000000)
            {
                var kq = lt.Sanphams.Where(x => x.Giaban >= 25000000 
                && x.TenSP.Contains(ten)).OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                ViewBag.tu = tu;
                ViewBag.den = den;
                ViewBag.ten = ten;
                return View(kq);
            }
            return View();        
        }
        [HttpPost]
        public ActionResult sanphamtheoloaiasus(int? page,int? tu, int? den, string ten)
        {
            if (tu == 9000000 && den == null)
            {
                var kq = lt.Sanphams.Where(x => x.Giaban < 10000000
                && x.TenSP.Contains(ten)).OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                ViewBag.tu = tu;
                ViewBag.den = den;
                ViewBag.ten = ten;
                return View(kq);
            }
            else if (tu == 10000000 && den == 15000000)
            {
                var kq = lt.Sanphams.Where(x => x.Giaban >= 10000000 &&
                x.Giaban < 15000000 && x.TenSP.Contains(ten)).OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                ViewBag.tu = tu;
                ViewBag.den = den;
                ViewBag.ten = ten;
                return View(kq);
            }
            else if (tu == 15000000 && den == 20000000)
            {
                var kq = lt.Sanphams.Where(x => x.Giaban >= 15000000 &&
                x.Giaban < 20000000 && x.TenSP.Contains(ten)).OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                ViewBag.tu = tu;
                ViewBag.den = den;
                ViewBag.ten = ten;
                return View(kq);
            }
            else if (tu == 20000000 && den == 25000000)
            {
                var kq = lt.Sanphams.Where(x => x.Giaban >= 20000000 &&
                x.Giaban < 25000000 && x.TenSP.Contains(ten)).OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                ViewBag.tu = tu;
                ViewBag.den = den;
                ViewBag.ten = ten;
                return View(kq);
            }
            else if (tu == null && den == 26000000)
            {
                var kq = lt.Sanphams.Where(x => x.Giaban >= 25000000
                && x.TenSP.Contains(ten)).OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 8);
                ViewBag.tu = tu;
                ViewBag.den = den;
                ViewBag.ten = ten;
                return View(kq);
            }
            return RedirectToAction("Index","TrangChu");
        }
        public ActionResult hien(int? page, int? tu, int? den, string ten)
        {
            return View();
        }


    }
}