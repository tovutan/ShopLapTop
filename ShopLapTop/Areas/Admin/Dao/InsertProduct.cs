using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList.Mvc;
using PagedList;
using ShopLapTop.Areas.Admin.Models;
using ShopLapTop.Areas.Admin.Dao;
namespace ShopLapTop.Areas.Admin.Dao
{
    public class InsertProduct
    {
        laptop lt = new laptop();
        public int insert(Sanpham sp)
        {
            
            lt.Sanphams.Add(sp);
            lt.SaveChanges();
            return sp.MaSP;
        }
    }
}