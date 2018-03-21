using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopLapTop.Models
{
    public class GioHang
    {
        public class MotSanPhamTrongGioHang
        {
            public int Ma { get; set; }
            public string Ten { get; set; }
            public int GiaBan { get; set; }
            public int SoLuong { get; set; }
            public string HinhAnh { get; set; }
            public int ThanhTien { get; set; }
        }
        public List<MotSanPhamTrongGioHang> ds { get; set; }
        public GioHang()
        {
            ds = new List<MotSanPhamTrongGioHang>();
        }
        public void themmotsanphamtronggiohang(MotSanPhamTrongGioHang item)
        {
            if (ds.Where(x => x.Ma == item.Ma).Any())
            {
                var kq = ds.Where(x => x.Ma == item.Ma).SingleOrDefault();
                kq.SoLuong++;
                kq.ThanhTien = kq.SoLuong * kq.GiaBan;
            }
            else
            {
                ds.Add(item);
            }
        }
        public void suamotsanphamtronggiohang(int ma, int soluong)
        {
            if (ds.Where(x => x.Ma == ma).Any())
            {
                var kq = ds.Where(x => x.Ma == ma).SingleOrDefault();
                kq.SoLuong = soluong;
                kq.ThanhTien = soluong * kq.GiaBan;
            }
        }
        public void xoamotsanphamtronggiohang(int ma)
        {
            if (ds.Where(x => x.Ma == ma).Any())
            {
                var kq = ds.Where(x => x.Ma == ma).SingleOrDefault();
                ds.Remove(kq);
            }
        }
        public void xoanguyengiohang()
        {
            ds.Clear();
        }
    }
}