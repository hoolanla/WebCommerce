using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DAL;

namespace BLL
{
    public class ProductBLL
    {
        Product svProduct = new Product();
        public List<MODEL.M_Product> getProductAll()
        {
            return svProduct.getProductAll();
        }
    }
}
