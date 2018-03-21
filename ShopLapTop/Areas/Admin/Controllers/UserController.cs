using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopLapTop.Areas.Admin.Dao;
namespace ShopLapTop.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
     
        public ActionResult List()
        {
            var user = new UserDao();
            var model = user.GetListUser();
            return View(model);
        }
    }
}