using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Command;
using ShopLapTop.Areas.Admin.Models;
using ShopLapTop.LopMoRong;
namespace ShopLapTop.Areas.Admin.Dao
{
    public class taikhoandangnhap
    {
        laptop lt = null;
        public taikhoandangnhap()
        {
            lt = new laptop();
        }
        public taikhoan GetID(string username)
        {
            return lt.taikhoans.SingleOrDefault(x=>x.username==username);
        }

        public List<string> GetListCredential(string userName)
        {
            var user = lt.taikhoans.FirstOrDefault(u => u.username == userName);
            var data = (from a in lt.Credentials
                       join b in lt.UserGroups on a.UserGroupID equals b.ID
                       join c in lt.Roles on a.RoleID equals c.ID
                       where b.ID == user.GroupID
                       select new 
                       {
                           RoleID=a.RoleID,
                           UserGroupID=a.UserGroupID
                       }).AsEnumerable().Select(c=>new Credential() {
                           RoleID=c.RoleID,
                           UserGroupID=c.UserGroupID
                       });
            return data.Select(x => x.RoleID).ToList();
        }
        public int Login(string username,string password,bool IsLoginAdmin=false)
        {
            var kq = lt.taikhoans.Where(x => x.username == username).SingleOrDefault();
            if (kq == null)
            {
                return 0;
            }
            else
            {
                if (IsLoginAdmin)
                {
                    if (kq.GroupID == Constants.ADMIN_GROUP || kq.GroupID == Constants.MOD_GROUP)
                    {
                        if (kq.status == false)
                        {
                            return -1;
                        }
                        else
                        {
                            if (kq.password == password)
                                return 1;
                            else
                                return -2;
                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
                else
                {
                    if (kq.status == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (kq.password == password)
                            return 1;
                        else
                            return -2;
                    }
                }
                
            }
      
        }
    }
}