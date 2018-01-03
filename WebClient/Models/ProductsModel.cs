using DMODTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClient.ServiceProduct;

namespace WebClient.Models
{
    public class ProductsModel
    {
        public List<ProductsDTO> plist { get; set; }
        public ProductsDTO pdto { get; set; }
    }
}