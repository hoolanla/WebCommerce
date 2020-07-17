using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
  public  class MenuDetail
    {
        public string MenuID { get; set; }
        public string restaurantID { get; set; }
        public string recommend { get; set; }
        public string UserID { get; set; }
        public string MenuCategoryLV1ID { get; set; }
        public string MenuCategoryLV2ID { get; set; }
        public string MenuName { get; set; }
        public string MenuPicture { get; set; }
        public string MenuPrice { get; set; }
        public string MenuPriceS { get; set; }
        public string MenuPriceM { get; set; }
        public string MenuPriceL { get; set; }
        public string MenuActivate { get; set; }
        public string MenuRecommend { get; set; }
        public string MenuRemark { get; set; }
        public string MenuDescription { get; set; }
        public string MemberID { get; set; }
    }
}
