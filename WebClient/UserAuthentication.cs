using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebClient.Models;

namespace WebClient
{
    public class UserAuthentication : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.Session["User"] == null)
            {
                LoginModel model = new LoginModel();
                model.msg = "Bu Sayafaya Giriş Yapmak için önce Login olmalısınız ... ";
                // Bu sayfaya gitme yetkiniz yok diye bir sayfa oluşturur
                // filterContext.Result = new HttpUnauthorizedResult();
                filterContext.Result = new RedirectResult("/Login/Login");
            }
        }
    }
}