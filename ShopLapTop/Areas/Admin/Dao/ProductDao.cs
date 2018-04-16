using ShopLapTop.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopLapTop.Areas.Admin.Dao
{
    public class ProductDao
    {
        laptop lt = null;
        public ProductDao()
        {
            lt = new laptop();
        }
        public int insert(Sanpham sp)
        {

            lt.Sanphams.Add(sp);
            lt.SaveChanges();
            return sp.MaSP;
        }
        public Sanpham ViewDetail(int id)
        {         
            return lt.Sanphams.FirstOrDefault(x => x.MaSP == id); ;      
        }

        public Sanpham sua(Sanpham sp)
        {
            //var kq = lt.Sanphams.FirstOrDefault(x => x.MaSP == sp.MaSP);
            lt.Entry(sp).State = System.Data.Entity.EntityState.Modified;
            lt.SaveChanges();
            return sp;
        }

        public void UpdateImages(int MaSP, string images)
        {
            var kq = lt.Sanphams.FirstOrDefault(x => x.MaSP == MaSP);
            kq.MoreImages = images;
            lt.SaveChanges();
        }
    }
}