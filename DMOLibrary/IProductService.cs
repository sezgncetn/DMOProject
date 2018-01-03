using DMODTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DMOLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        List<ProductsDTO> GetProducts();

        [OperationContract]
        List<ProductsDTO> GetProductsBySupplier(int SupplierID);
        [OperationContract]
        ProductsDTO GetOneProduct(int id, int suppid);
        [OperationContract]
        bool ProductUpdate(ProductsDTO Pdto);
        [OperationContract]
        UsersDTO Login(int id,string pw);


    }

  
  
}
