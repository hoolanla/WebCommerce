using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class FoodGroup
    {
        public string foodsTypeIDLevel1 { get; set; }
        public string foodsTypeIDLevel2 { get; set; }
        public string foodsTypeNameLevel1 { get; set; }
        public string foodsTypeNameLevel2 { get; set; }
        public List<FoodsItems> foodsItems { get; set; } 
    }
}
