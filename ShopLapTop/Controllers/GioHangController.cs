using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopLapTop.Areas.Admin.Dao;
using ShopLapTop.LopMoRong;
using ShopLapTop.Models;
using ShopLapTop.Areas.Admin.Models;
using System.Text.RegularExpressions;

namespace ShopLapTop.Controllers
{
    public class GioHangController : Controller
    {
        laptop lt = new laptop();
        // GET: GioHang
        public ActionResult Index()
        {
            GioHang gh = (GioHang)Session["GioHang"];
            if (gh == null)
            {
                return RedirectToAction("Index", "TrangChu");
            }
            return View(gh.ds);         
        }
        public ActionResult them(int Ma)
        {
            var sp = lt.Sanphams.SingleOrDefault(x => x.MaSP == Ma);// tránh trường hợp thêm sản phẩm không có trong csdl(tránh lỗi)
            if (sp != null)
            {
                GioHang.MotSanPhamTrongGioHang i = new GioHang.MotSanPhamTrongGioHang();
                i.HinhAnh = sp.Hinh;
                i.Ma = sp.MaSP;
                i.Ten = sp.TenSP;
                i.GiaBan =(int)sp.Giaban;
                i.SoLuong = 1;
                i.ThanhTien = i.SoLuong * i.GiaBan;
                GioHang gh = (GioHang)Session["GioHang"];
                if (gh == null) // lần đầu khi mới thêm vào trước đó dữ liệu sẽ null
                {
                    gh = new GioHang();
                }
                gh.themmotsanphamtronggiohang(i);
                Session["GioHang"] = gh; // gán session cho giỏ hàng để cập nhật lại giỏ hàng.                
            }
            return RedirectToAction("Index","GioHang");
        }
        public ActionResult suasoluong(int ma, FormCollection form)
        {
            GioHang gh = (GioHang)Session["GioHang"];
            var soluong = int.Parse(form["txtSo"]);
            gh.suamotsanphamtronggiohang(ma, soluong);
            Session["GioHang"] = gh;
            return RedirectToAction("Index", "GioHang");
        }
        public ActionResult xoamotsanpham(int ma)
        {           
            GioHang gh = (GioHang)Session["GioHang"];
            gh.xoamotsanphamtronggiohang(ma);
            //if (gh.ds.Count() == 0)
            //{
            //    Session["GioHang"] = null;
            //}
            if (gh.ds.Count()==0)
            {
                return RedirectToAction("Index", "TrangChu");
            }
            else
                Session["GioHang"] = gh;
            return RedirectToAction("Index");
        }
        public ActionResult xoagiohang()
        {
           Session["GioHang"] = null;
            return RedirectToAction("Index","TrangChu");
        }
        public static bool IsValidEmail(string email)
        {
            Regex rx = new Regex(
            @"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$");
            return rx.IsMatch(email);
        }
        [HttpGet]
        //public ActionResult thanhtoan(string path)
        //{
        //    if (Session["kh"] ==null)
        //    {
        //        return Redirect("~/KhachHang/dangnhap?path=" + path);
        //    }

        //    GioHang gh = (GioHang)Session["GioHang"];
        //    if (gh == null)
        //    {
        //        return RedirectToAction("Index", "TrangChu");
        //    }
        //    return View(gh.ds);
        //}
        public ActionResult thanhtoan(string path)
        {
            ViewBag.path = path;
            Khachhang kh = (Khachhang)Session["kh"];
            //trước tiên sẽ kiểm tra giỏ hàng, if giỏ hang==null thì trả về trangchu,
            GioHang gh = (GioHang)Session["giohang"];
            if (gh == null)
            {
                return RedirectToAction("Index", "TrangChu");
            }
            else
            {
                // if giohang!=null thì sẽ kiểm tra xem khachhang đã đăng nhập hay chưa?
                if (kh == null)
                {
                    return Redirect("~/KhachHang/dangnhap?path="+path);
                }
                else
                {
                    Session["kh"] = kh;
                    return View(gh.ds.ToList());
                }
            }            
        }
        [HttpPost]
        public ActionResult thanhtoan(FormCollection form)
        {
            
            GioHang gh = (GioHang)Session["GioHang"];
            if (gh == null)
            {
                return RedirectToAction("Index", "TrangChu");
            }
            else
            {
                //KiemtraEmail email = new KiemtraEmail();                         
                DateTime ngaymuahang = DateTime.Now;
                var nguoimuahang = form["txtNguoiMua"];
                //IsValidEmail(nguoimuahang);
               
                var tongtien = int.Parse(form["txttongtien"]);
                Hoadon hd = new Hoadon();
                hd.MaHD = 1;
                hd.Email = nguoimuahang;
                hd.Ngaymua = DateTime.Now;
                hd.Ngaygiaohang = DateTime.Now.AddDays(3);
                hd.TrigiaHD = tongtien;

                //if (IsValidEmail(nguoimuahang) == false)
                //{
                //    ModelState.AddModelError("", "Email không đúng định dạng");
                //    return View();
                //}


                //dùng để gửi vào email
                string chiTiet = "";
                chiTiet += "<ul>";

                //thêm hóa đơn và chi tiết hóa đơn dùng transaction
                using (var dbContextTransaction = lt.Database.BeginTransaction())
                {
                    try
                    {
                        // save hoadon
                        lt.Hoadons.Add(hd);
                        lt.SaveChanges();
                        // lấy ra mahd để gán cho chitiethoadon
                        int mahd = lt.Hoadons.OrderByDescending(x => x.MaHD).Select(x => x.MaHD).Take(1).Single();
                        foreach (var item in gh.ds)
                        {
                            CT_HoaDon cthd = new CT_HoaDon();
                            cthd.MaHD = mahd;
                            cthd.MaSP = item.Ma;
                            cthd.Soluong = (int)item.SoLuong;
                            cthd.Dongia = item.GiaBan;
                            lt.CT_HoaDon.Add(cthd);                           
                            lt.SaveChanges();
                            chiTiet += "<li>" + item.Ten + " x <font color = 'blue'><b>" + item.SoLuong + " SP </b ></font> = " + String.Format("{0:0,0} VND", item.ThanhTien) + "</li>";
                        }
                        // sau khi thanh toán thành công thì xóa giỏ hàng
                        gh.xoanguyengiohang();
                        Session["GioHang"] = null;
                        //dùng cho email
                        chiTiet += "</ul>";
                        dbContextTransaction.Commit();
                     }                  
                    catch(Exception e)
                    {

                        dbContextTransaction.Rollback();
                        return RedirectToAction("Index", "TrangChu");
                    }
                }
                GuiMail gmail = new GuiMail();
                string nguoinhan = form["txtNguoiMua"];
                string kq = gmail.SendMail(nguoinhan, nguoimuahang + " mua hàng của Tân đẹp trai", "Cám ơn mấy chú đã mua hàng của EM<br>" + chiTiet + "<br>Vui lòng chuẩn bị " +
                   String.Format("{0:0,0} VNĐ", tongtien) + " cho EM nhé. <br>C.U sun (*_^)", true);
                if (kq == "Successful!")
                    return RedirectToAction("ThanhCong");
                else
                    return RedirectToAction("hienloiGmail", "TrangChu");
            }
        }
        public ActionResult ThanhCong()
        {
            return View();
        }
    }
}