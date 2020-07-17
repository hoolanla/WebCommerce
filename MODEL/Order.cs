using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class Order
    {
        public string orderID { get; set; }
        public string restuarantID { get; set; }
        public string userID { get; set; }
        public string tableID { get; set; }
        public string foodsID { get; set; }
        public string foodsName { get; set; }
        public string foodsSize { get; set; }
        public string foodsTaste { get; set; }
        public string qty { get; set; }
        public string price { get; set; }
        public string totalPrice { get; set; }
        public string status { get; set; }
        public string comment { get; set; }
        public string image { get; set; }
        public Order()
        {
            foodsSize = "";
            foodsTaste = "";
            comment = "";
        }
       

    }
}
