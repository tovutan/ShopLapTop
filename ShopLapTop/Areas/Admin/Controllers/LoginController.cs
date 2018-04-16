using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopLapTop.Areas.Admin.Models;
using ShopLapTop.Areas.Admin.Dao;
using ShopLapTop.LopMoRong;
using ShopLapTop.Common;

namespace ShopLapTop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        laptop lt = new laptop();
        // GET: Admin/Login
        //public ActionResult Index()
        //{
        //    return View();
        //}
        [HttpGet]
        public ActionResult dangnhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult dangnhap(taikhoan model)
        {
            var userdao = new taikhoandangnhap();
            int result = userdao.Login(model.username, model.password,true);
            if (result == 1)
            {

                var user = userdao.GetID(model.username);
                var listCredentials = userdao.GetListCredential(model.username);
                Session.Add(CommonConstants.SESSION_CREDENTIAL, listCredentials);
                Session["user"] = user;
                Session["name"] = user.name;
                return RedirectToAction("hiensp", "SanPham");
            }
            else if (result == -3)
            {
                ModelState.AddModelError("", "Bạn không có quyền truy cập");
            }
            else
            {
                ModelState.AddModelError("", "Tài khoản không hợp lệ nhe cưng");
            }
            return View("dangnhap");
        }
        public ActionResult dangxuat()
        {
            Session["user"] = null;
            return View("dangnhap");
        }
    }
}