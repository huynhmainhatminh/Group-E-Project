using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVcaKoi.Common.DAL;
using TVCaKoi.DAL.Models;

namespace TVCaKoi.DAL
{
    public class ProductRep : GenericRep<ApptvcakoiContext, Product>
    {
        public ProductRep() { }

        public List<Product> SearchALLProduct(int product_id_type)
        {
            var res = All.Where(c => c.IdproductType == product_id_type).ToList();
            return res;
        }

        public int GetCountProduct(int product_id_type)
        {
            var res = All.Where(c => c.IdproductType == product_id_type).ToList().Count;
            return res;
        }

    }
}
