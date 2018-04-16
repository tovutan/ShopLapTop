using ShopLapTop.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopLapTop.Areas.Admin.Dao
{
    public class BrandDao
    {
        laptop lt = null;
        public BrandDao()
        {
            lt = new laptop();
        }

        public Nhanhieu ViewDetail(int Mahieu)
        {
            return lt.Nhanhieux.FirstOrDefault(x => x.Mahieu == Mahieu);
        }

        public Nhanhieu Edit(Nhanhieu nh)
        {
            lt.Entry(nh).State = System.Data.Entity.EntityState.Modified;
            lt.SaveChanges();
            return nh;
        }

        public Nhanhieu Delete(int Mahieu)
        {
            var kq = lt.Nhanhieux.FirstOrDefault(x => x.Mahieu == Mahieu);
            lt.SaveChanges();
            return kq;
        }
    }
}