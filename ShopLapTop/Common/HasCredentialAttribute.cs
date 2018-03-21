using ShopLapTop.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Command;
using System.Web.Mvc;
using ShopLapTop.Areas.Admin.Controllers;

namespace ShopLapTop.Common
{
    public class HasCredentialAttribute:AuthorizeAttribute
    {
        public string RoleID { get; set; }
        //protected override bool AuthorizeCore(HttpContextBase httpContext)
        //{
        //    var session = (taikhoan)HttpContext.Current.Session["user"];
        //    if (session == null)
        //        return false;
        //    List<string> privilegeLevels = this.GetCredentialByLoggedInUser(session.username);
        //    if (privilegeLevels.Contains(this.RoleID)||session.GroupID==Constants.ADMIN_GROUP)
        //    {
        //        return true;
        //    }
        //    else
        //    {            
        //        return false;
        //    }
        //}
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var session = (taikhoan)HttpContext.Current.Session["user"];
            if (session == null)
            {
                //httpContext.Response=("/Admin/Login/dangnhap/");
                // return HttpContext.Current.Response.Redirect("/Admin/Login/dangnhap");
                httpContext.Response.Redirect("~/Admin/Login/dangnhap");
                return false;
            }
                //AuthorizationContext context = new AuthorizationContext();
               
            List<string> privilegeLevels = this.GetCredentialByLoggedInUser(session.username);
            if (privilegeLevels.Contains(this.RoleID) || session.GroupID == Constants.ADMIN_GROUP)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {          
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Areas/Admin/Views/Shared/401.cshtml"
            };
        }
        private List<string> GetCredentialByLoggedInUser(string Username)
        {
            var credential = (List<string>)HttpContext.Current.Session[Common.CommonConstants.SESSION_CREDENTIAL];
            return credential;
        }
    }
}