using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApp.Models
{
    public class ProductViewModel
    {
        public ProductCategory CurrentCategory { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
