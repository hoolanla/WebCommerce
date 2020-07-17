using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class ResultHistoryUser
    {

        public string ResultOk { get; set; }
        public string ErrorMessage { get; set; }       
        public string Username { get; set; }
        public List<History> data;

    }

    public class History
    {
        public string CategoryName { get; set; }
        public string CountOrder { get; set; }
        public string SumPrice { get; set; }
    }


}
