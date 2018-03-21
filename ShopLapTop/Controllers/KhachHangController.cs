using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopLapTop.LopMoRong;
using ShopLapTop.Areas.Admin.Models;

namespace ShopLapTop.Controllers
{
    public class KhachHangController : Controller
    {
        laptop lt = new laptop();
        // GET: KhachHangDangKi
        [HttpGet]
        public ActionResult dangki()
        {
            return View();
        }
        [HttpPost]
        public ActionResult dangki(Khachhang kh, FormCollection form)
        {
            try
            {
                var mk = form["Password"];               
                var nlmk = form["RePassword"];               
                ViewBag.hoten = form["Hoten"];
                string hoten = ViewBag.hoten;              
                ViewBag.email = form["Email"];
                string gmail = ViewBag.email;
                if (gmail.Count() == 0)
                {
                    ModelState.AddModelError("", "Vui lòng nhập gmail của bạn");
                }
                var kq = lt.Khachhangs.Where(x => x.Email == gmail).SingleOrDefault();
                if (kq != null)
                {                
                    ViewBag.gt = form["Gioitinh"];
                    ViewBag.mk = mk;
                    ViewBag.nlmk = nlmk;
                    ViewBag.sdt = form["Dienthoai"];
                    ViewBag.dc = form["Diachi"];
                    ModelState.AddModelError("", "Email đã tồn tại rồi nè hihihi");                   
                }
                else
                {
                    ViewBag.gt = form["Gioitinh"];
                    ViewBag.mk = mk;
                    ViewBag.nlmk = nlmk;
                    ViewBag.sdt = form["Dienthoai"];
                    string sdt = ViewBag.sdt;
                    if (hoten.Count() == 0)
                    {
                        ModelState.AddModelError("", "Vui lòng nhập họ tên của bạn");
                    }
                    if (mk.Count() == 0)
                    {
                        ModelState.AddModelError("", "Vui lòng nhập mật khẩu của bạn");
                    }
                    if (nlmk.Count() == 0)
                    {
                        ModelState.AddModelError("", "Vui lòng nhập đúng mật khẩu xác thực của bạn");
                    }                  
                    if (sdt.Count() == 0)
                    {
                        ModelState.AddModelError("", "Vui lòng nhập số điện thoại của bạn");
                    }
                    ViewBag.dc = form["Diachi"];
                    string dc = ViewBag.dc;
                    if (dc.Count() == 0)
                    {
                        ModelState.AddModelError("", "Vui lòng nhập địa chỉ của bạn");
                    }
                    if (mk == nlmk)
                    {
                        lt.Khachhangs.Add(kh);
                        lt.SaveChanges();
                        return RedirectToAction("Index", "TrangChu");
                    }
                }                            
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Đăng kí thất bại");
            }

            return View();
        }
        [HttpGet]
        public ActionResult dangnhap(string path)
        {
            //ViewBag.path = path;
            ViewBag.path = path;
            return View();
        }
        [HttpPost]
        public ActionResult dangnhap(FormCollection form)
        {
            //var path = form["Path"];
            var path = form["Path"];         
            var email = form["Email"];
            var pass = form["Password"];
            Khachhang kh = lt.Khachhangs.
                SingleOrDefault(x => x.Email == email  && x.Password ==pass);
            if (kh == null)
            {
                ModelState.AddModelError("", "Tài khoản đăng nhập không hợp lệ");
            }
            else if (kh != null)
            {
                Session["kh"] = kh;
                //if (path =="")
                if(path=="")
                {
                    return RedirectToAction("Index", "TrangChu");
                }
                return Redirect(path);         
            }           
            return View();
        }
        public ActionResult dangxuat()
        {
            Session["kh"] = null;
            return RedirectToAction("Index","TrangChu");
        }
    }
}