using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class Result
    {
        public string ResultOk { get; set; }
        public string ErrorMessage { get; set; }
        public string ReturnMessage { get; set; }
        public Result()
        {
            ResultOk = "false";
            ErrorMessage = "";
            ReturnMessage = "";
            
        }



    }
}
