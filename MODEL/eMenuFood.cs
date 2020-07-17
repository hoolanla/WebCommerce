using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class eMenuFood
    {


        public string ResultOk { get; set; }
        public string ErrorMessage { get; set; }
        public string CountMenu { get; set; }
        public string restuarantName { get; set; }
        public string imageRestuarant { get; set; }
        

        public List<FoodGroup> Data { get; set; }


    }
}
