using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class ResultRestaurantContent
    {
        public string ResultOk { get; set; }
        public string ErrorMessage { get; set; }
        public List<RestaurantContent> data { get; set; }
    }
}
