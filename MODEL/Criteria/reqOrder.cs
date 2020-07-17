using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Criteria
{
    public class reqOrder
    {
        public string restaurantID { get; set; }
        public string tableID { get; set; }
        public string userID { get; set; }
        public string statusID { get; set; }
        public string orderNo { get; set; }
        public string orderID { get; set; }
        public List<FoodsItems> orderList { get; set; }
      
    }
}
