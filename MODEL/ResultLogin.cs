using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class ResultLogin
    {
        public string ResultOk { get; set; }
        public string ErroMessage { get; set; }
        public string ReturnMessage { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public int memberID { get; set; }
        public string restaurantID { get; set; }
        public string lastname { get; set; }
        public string tel { get; set; }
    }
}
