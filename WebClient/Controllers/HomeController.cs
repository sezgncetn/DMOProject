using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebClient.Models;
using WebClient.ServiceProduct;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        ProductServiceClient s = new ProductServiceClient();
        ProductsModel model = new ProductsModel();
        [UserAuthentication]
        public ActionResult Index()
        {
            model.plist = s.GetProductsBySupplier(Convert.ToInt32(Session["SupplierID"])).ToList();
            return View(model);
        }
        public ActionResult TumUrunler()
        {
            model.plist = s.GetProducts().ToList();
            return View(model);
        }
        public ActionResult Guncelle(int id)
        {
            model.pdto = s.GetOneProduct(id, Convert.ToInt32(Session["SupplierID"]));
            if (model.pdto.UrunAd != null)
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Guncelle(ProductsModel m)
        {
            bool sonuc = s.ProductUpdate(m.pdto);
            return RedirectToAction("Index");

        }
    }
}