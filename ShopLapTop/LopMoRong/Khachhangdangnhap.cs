using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopLapTop.Areas.Admin.Models;
using ShopLapTop.Models;
namespace ShopLapTop.LopMoRong
{
    public class Khachhangdangnhap
    {
        laptop lt = new laptop();
        public int Login(string email, string password)
        {
            var kq = lt.Khachhangs.SingleOrDefault(x => x.Email == email);
            if (kq == null)
            {
                return 0;
            }
            else
            {
                if (kq.Password == password)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
                   
            }                   
        }
    }
}