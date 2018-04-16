using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using ShopLapTop.Areas.Admin.Lopdungchung;
using ShopLapTop.Areas.Admin.Models;
using ShopLapTop.Areas.Admin.Dao;
using ShopLapTop.Common;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace ShopLapTop.Areas.Admin.Controllers
{
    public class SanPhamController : BaseController
    {
        // GET: Admin/SanPham
        laptop lt = new laptop();
        // GET: Admin/SanPham
       // [HasCredential(RoleID = "VIEW_PRODUCT")]
       [HasCredential(RoleID ="VIEW_PRODUCT")]
        public ActionResult hiensp(int? page, int pagesize = 6)
        {
            var kq = lt.Sanphams.OrderBy(x => x.Giaban).ToPagedList(page ?? 1, 6);
            
            return View(kq);
        }
        public ActionResult tim(FormCollection form)
        {
            var tim = form["txttim"];
           
            var kq = lt.Sanphams.Where(x => x.TenSP.Contains(tim)).ToList();
            //var kq=from n in 
            return View(kq);
        }
        [HttpGet]
        [HasCredential(RoleID ="ADD_PRODUCT")]
        public ActionResult them()
        {
            //var user = new InsertProduct();          
            // var nh = lt.Nhanhieux.ToList();
            // ViewBag.Brand = new SelectList(nh, "Mahieu", "Tenhieu");          
            ViewBag.Brand = lt.Nhanhieux.ToList();
            ViewBag.Type = lt.Loais.ToList();
            
            ViewBag.ChildCategory = lt.ChildCategories.Where(x => x.Maloai.HasValue).ToList(); 
            //if()     
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [HasCredential(RoleID ="ADD_PRODUCT")]
        public ActionResult them(FormCollection form, Sanpham sp)
        {
            //int ma = int.Parse(form["Brand"]);
            //ViewBag.Brand= new SelectList(lt.Nhanhieux.ToList(), "Mahieu", "Tenhieu",ma);
            //sp.Mahieu = int.Parse(form["Brand"]);
            int ma = int.Parse(form["Maloai"]);
            var chilCat = lt.ChildCategories.FirstOrDefault(x => x.ID == ma);
            if (chilCat != null)
            {
                int? cat = chilCat.Maloai;
                sp.Maloai = cat;
            }
            else            
                sp.Maloai = ma;          
                Session["ID"] = sp.MaSP;      
                if (ModelState.IsValid)
                {
                    try
                    {
                        var dao = new ProductDao();
                        //ViewBag.Brand = new SelectList(lt.Nhanhieux.ToList(), "Mahieu", "Tenhieu", ma);
                        // var ht = lt.ChildCategories.ToList();
                        int id = dao.insert(sp);
                        ViewBag.gia = sp.Giaban;
                        ViewBag.gkm = sp.Giakhuyenmai;
                        if (id > 0)
                        {
                            SetAlert("Thêm sản phẩm thành công", "success");
                            return RedirectToAction("hiensp");
                        }
                    }
                    catch (Exception ex)
                    {

                        ModelState.AddModelError("", "Thêm không thành công");
                    }
                }
                         
            return View();

        }
        [HttpGet]      
        [HasCredential(RoleID ="EDIT_PRODUCT")]
        public ActionResult sua(int id)
        {
            //var kq = lt.Sanphams.Where(x => x.MaSP == id).SingleOrDefault();
            var result = new ProductDao();
            var kq = result.ViewDetail(id);
            ViewBag.gia = kq.Giaban;
            ViewBag.gkm = kq.Giakhuyenmai;
            return View(kq);
        }
        [HttpPost]
        [ValidateInput(false)]
        [HasCredential(RoleID ="EDIT_PRODUCT")]
        public ActionResult sua(Sanpham sp)
        {
            try
            {
                //lt.Entry(sp).State = System.Data.Entity.EntityState.Modified;
                //ViewBag.gia = sp.Giaban;
                //ViewBag.gkm = sp.Giakhuyenmai;
                //lt.SaveChanges();
                var result = new ProductDao();
                var kq = result.sua(sp);
                ViewBag.gia = sp.Giaban;
                ViewBag.gkm = sp.Giakhuyenmai;
                lt.SaveChanges();
                SetAlert("Sửa sản phẩm thành công", "success");
                return RedirectToAction("hiensp", "SanPham");
            }
            catch (Exception e)
            {

            }
            return View();
         
        }
        [HasCredential(RoleID ="DELETE_PRODUCT")]
        public ActionResult xoa(int id)
        {
            var kq = lt.Sanphams.Where(x => x.MaSP == id).SingleOrDefault();
            lt.Sanphams.Remove(kq);
            lt.SaveChanges();
            SetAlert("Xóa sản phẩm thành công", "success");
            return RedirectToAction("hiensp", "SanPham");
        }

        // load Images
        public JsonResult LoadImages(int MaSP)
        {
            ProductDao dao = new Dao.ProductDao();
            var product = dao.ViewDetail(MaSP);
            var images = product.MoreImages;
            XElement xImages = XElement.Parse(images);
            // List<string> ListImagesReturn = new List<string>();
            List<string> ListImagesReturn = new List<string>();

            foreach (XElement element in xImages.Elements())
            {
                 ListImagesReturn.Add(element.NextNode.ToString());
                //ListImagesReturn.Add(element.Value);
            }
            return Json(new
            {
                data = ListImagesReturn
            },JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveImages(int MaSP,string images)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var listImages = serializer.Deserialize<List<string>>(images);
            XElement xElement = new XElement("Images");

            foreach (var item in listImages)
            {
                xElement.Add(new XElement("Image"), item);
            }
            ProductDao sp = new ProductDao();
            try
            {
                sp.UpdateImages(MaSP, xElement.ToString());
                return Json(new
                {
                    trangthai = true
                });
            }
            catch (Exception ex)
            {

                sp.UpdateImages(MaSP, xElement.ToString());
                return Json(new
                {
                    trangthai = false
                });
            }
           
        }
    }
}