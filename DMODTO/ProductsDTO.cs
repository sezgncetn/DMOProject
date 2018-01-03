using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DMODTO
{[DataContract]
    public class ProductsDTO
    {
        [DataMember]
        public int UrunID { get; set; }
        [DataMember]
        public string UrunAd { get; set; }
        [DataMember]
        public decimal UrunFiyat { get; set; }
        [DataMember]
        public int TedarikciID { get; set; }
    }
}
