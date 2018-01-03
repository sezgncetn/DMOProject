using DMODTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebClient.Models;
using WebClient.ServiceProduct;

namespace WebClient.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        ProductServiceClient s = new ProductServiceClient();
        [HttpGet]
        public ActionResult Login()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel m )
        {
            int id = m.User.UserID;
            string pw = m.Password;
            UsersDTO udto = s.Login(id, pw);
            Session["User"] = udto.UserID;
            Session["Role"] = udto.UserRole;
            Session["SupplierID"] = udto.SupplierID;
            //UsersDTO udto = new UsersDTO();
            //udto.UserID = m.User.UserID;
            //udto.SupplierID = m.User.SupplierID;
            //udto.UserRole = m.User.UserRole;

            return RedirectToAction("Index","Home");
        }
    }
}