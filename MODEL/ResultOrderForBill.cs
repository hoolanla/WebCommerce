using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class ResultOrderForBill
    {
        public string ResultOk { get; set; }
        public string ErroMessage { get; set; }
        public string ReturnMessage { get; set; }
        public string restaurantName { get; set; }
        public string userName { get; set; }
        public string tableName { get; set; }
        public double totalPrice { get; set; }
        public List<Order> orderList { get; set; }
    }
}
