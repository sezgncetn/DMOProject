using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DMODTO;
using DMOEntity;

namespace DMOLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ProductService : IProductService
    {
        NORTHWNDEntities db = new NORTHWNDEntities();

        public ProductsDTO GetOneProduct(int id, int suppid)
        {
            Products p = db.Products.FirstOrDefault(x => x.ProductID == id && x.SupplierID == suppid);
            ProductsDTO pdto = new ProductsDTO();
            if (p != null)
            {
                pdto.UrunID = p.ProductID;
                pdto.UrunAd = p.ProductName;
                pdto.UrunFiyat = (decimal)p.UnitPrice;
            }
            return pdto;
        }

        public List<ProductsDTO> GetProducts()
        {
            List<ProductsDTO> plist = db.Products.Select(x => new ProductsDTO
            {
                UrunID = x.ProductID,
                UrunAd = x.ProductName,
                UrunFiyat = (decimal)x.UnitPrice

            }).ToList();
            return plist;
        }
        public List<ProductsDTO> GetProductsBySupplier(int SupplierID)
        {
            List<ProductsDTO> plist = db.Products.Select(x => new ProductsDTO
            {
                UrunID = x.ProductID,
                UrunAd = x.ProductName,
                UrunFiyat = (decimal)x.UnitPrice,
                TedarikciID = (int)x.SupplierID

            }).Where(x => x.TedarikciID == SupplierID).ToList();
            return plist;
        }

        public bool ProductUpdate(ProductsDTO Pdto)
        {
            //try
            //{
            Products p = db.Products.Find(Pdto.UrunID);
            p.ProductName = Pdto.UrunAd;
            p.UnitPrice = Pdto.UrunFiyat;
            db.SaveChanges();
            return true;
            //}
            //catch (Exception)
            //{

            //    return false;
            //}
        }
        public UsersDTO Login(int UserID, string pw)
        { //Kısa yol
            return db.Users.Where(x => x.UserID == UserID && x.Password == pw).Select(x => new UsersDTO
            {
                UserID = x.UserID,
                SupplierID = x.SupplierID,
                UserRole = x.UserRole

            }).FirstOrDefault();

            //Uzun yol
            //UsersDTO udto = new UsersDTO();
            //Users u = db.Users.Where(x => x.UserID == UserID && x.Password == pw).FirstOrDefault();
            //udto.UserID = u.UserID;
            //udto.UserRole = u.UserRole;
            //udto.SupplierID = u.SupplierID;
            //return udto;

        }
    }
}
