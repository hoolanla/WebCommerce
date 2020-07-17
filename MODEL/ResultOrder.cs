using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class ResultOrder
    {
        public string ResultOk { get; set; }
        public string ErroMessage { get; set; }
        public string ReturnMessage { get; set; }
        public string orderNo { get; set; }
        public string orderStatus { get; set; }
        public List<Order> orderList { get; set; } 
    }
}
