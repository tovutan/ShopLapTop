using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopLapTop.Areas.Admin.Models;
using ShopLapTop.Common;
using ShopLapTop.Areas.Admin.Dao;
using System.Web.Security;

namespace ShopLapTop.Areas.Admin.Controllers
{
    public class NhanHieuController : BaseController
    {
        laptop lt = new laptop();
        // GET: Admin/NhanHieu
       // [HasCredential(RoleID ="VIEW_BRAND")]
        public ActionResult hiennh()
        {
            //if(User.IsInRole(RoleType.ADMIN))
            var kq = lt.Nhanhieux.ToList();
            return View(kq);
        }
       
        [HttpGet]
        [HasCredential(RoleID = "ADD_BRAND")]
        public ActionResult themnh()
        {
            return View();
        }

        [HttpPost]
        [HasCredential(RoleID = "ADD_BRAND")]
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
        [HttpGet]
        [HasCredential(RoleID = "SELFMOD_EDIT_BRAND")]
        public ActionResult Edit(int Mahieu)
        {
            BrandDao dao = new BrandDao();
            var nh = dao.ViewDetail(Mahieu);
            return View(nh);
        }

        [HttpPost]
        [HasCredential(RoleID = "SELFMOD_EDIT_BRAND")]
        public ActionResult Edit(Nhanhieu nh)
        {
            try
            {
                BrandDao dao = new BrandDao();
                dao.Edit(nh);
                lt.SaveChanges();
                SetAlert("Sửa nhãn hiệu thành công", "success");
                return RedirectToAction("hiennh", "NhanHieu");
            }
            catch (Exception ex)
            {

                return View();
            }
           
        }

        [HasCredential(RoleID= "SELFMOD_DELETE_BRAND")]
        public ActionResult Delete(int Mahieu)
        {
            try
            {
                BrandDao dao = new BrandDao();
                dao.Delete(Mahieu);
                lt.SaveChanges();
                SetAlert("Xóa nhãn hiệu thành công", "success");
                return RedirectToAction("hiennh", "NhanHieu");

            }
            catch (Exception ex)
            {

                return View();
            }
           
        }
    }
}