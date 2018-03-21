using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopLapTop.Areas.Admin.Models;
using ShopLapTop.Common;

namespace ShopLapTop.Areas.Admin.Controllers
{
    public class NhanHieuController : BaseController
    {
        laptop lt = new laptop();
        // GET: Admin/NhanHieu
        [HasCredential(RoleID ="VIEW_BRAND")]
        public ActionResult hiennh()
        {
            var kq = lt.Nhanhieux.ToList();
            return View(kq);
        }
        [HttpGet]
        public ActionResult themnh()
        {
            return View();
        }
        [HttpPost]
        public ActionResult themnh(Nhanhieu nh)
        {
            try
            {
                lt.Nhanhieux.Add(nh);
                lt.SaveChanges();
                SetAlert("Thêm nhãn hiệu thành công", "success");
                return RedirectToAction("hiennh", "NhanHieu");
            }
            catch (Exception e)
            {

                ModelState.AddModelError("", "Thêm không thành công");
            }
            return View();
            
        }
    }
}