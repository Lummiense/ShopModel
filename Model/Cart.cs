using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Занятие_3.Model
{
    public class Cart
    {
        
        public Buyer _buyer { get; set; }

        public List<ProductForBuyer> _productCart = new List<ProductForBuyer>();

        public ShopForBuyers _shop { get; set; }
        
          
       
    }
}
