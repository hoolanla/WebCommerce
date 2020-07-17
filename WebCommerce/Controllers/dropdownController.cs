using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using MODEL;

namespace WebCommerce.Controllers
{
    public class dropdownController : ApiController
    {
        ProductBLL svProduct = new ProductBLL();
        // GET api/<controller>/5

        [HttpGet]
        [Route("api/dropdown/getProduct")]
        public List<M_Product> getProduct()
        {
            return svProduct.getProductAll();
            //return "value";
        }
    }
}
