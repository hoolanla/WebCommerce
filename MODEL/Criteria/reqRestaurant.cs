using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Criteria
{
    public class reqRestaurant
    {
        public string UserID { get; set; }

        public string RestaurantID { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantImagePath { get; set; }
        public string RestaurantLat { get; set; }
        public string RestaurantLong { get; set; }

        public string ContactName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactAddressNo { get; set; }
        public string ContactMoo { get; set; }
        public string ContactRoad { get; set; }
        public string ContactSoi { get; set; }
        public int ContactProvince { get; set; }
        public int ContactAmphur { get; set; }
        public int ContactTumbon { get; set; }
        public string ContactZipcode { get; set; }
        public string ContactTel { get; set; }
        public string ContactPhone { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string ImageCover { get; set; }
    }
}
