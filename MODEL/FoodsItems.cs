using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class FoodsItems
    {
        public string foodsID { get; set; }
        public string foodsName { get; set; }
        public double price { get; set; }
        public double priceS { get; set; }
        public double priceM { get; set; }
        public double priceL { get; set; }
        public string size { get; set; }
        public string content { get; set; }
        public string description { get; set; }        
        public string images { get; set; }
        public int qty { get; set; }
        public double totalPrice { get; set; }
        public string taste { get; set; }
        public string comment { get; set; }

        public FoodsItems()
        {
            taste = "";
            comment = "";
        }







    }
}
