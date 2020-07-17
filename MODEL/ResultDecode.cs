using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class ResultDecode
    {
        public string ResultOk { get; set; }
        public string ErrorMessage { get; set; }
        public string ReturnMessage { get; set; }
        public string restaurantID { get; set; }
        public string tableID { get; set; }
        public string tableName { get; set; }
        public ResultDecode()
        {
            tableName = "";
        }

    }
}
