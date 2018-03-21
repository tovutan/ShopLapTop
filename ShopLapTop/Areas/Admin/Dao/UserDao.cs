using ShopLapTop.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopLapTop.Areas.Admin.Dao
{
    public class UserDao
    {
        laptop lt = null;
        public UserDao()
        {
            lt = new laptop();
        }
        public List<taikhoan> GetListUser()
        {
            var user = lt.taikhoans.ToList();
            return user.ToList();
        }
    }
}