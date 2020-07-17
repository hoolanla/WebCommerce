using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL
{
    public static class DataHelper
    {
        public static string PartHost = System.Configuration.ConfigurationManager.AppSettings["Path_Hosting"];

        public static string GetConnectionString()
        {
            // Load Connection String from configuration into result
            //Data Source = ptt - db - t05.ptt.corp; Initial Catalog = PTT - D - GA_Mobile_Test; Persist Security Info = True; User ID = pttdgamobiletstusr; Password = cpttdgamobiletstusr; MultipleActiveResultSets = True" providerName="System.Data.SqlClient
            //string con = System.Configuration.ConfigurationManager.ConnectionStrings["cc"].ConnectionString;
            string db_server = System.Configuration.ConfigurationManager.AppSettings["DB_Server"];
            string db_userid = System.Configuration.ConfigurationManager.AppSettings["DB_UserID"];
            string db_password = System.Configuration.ConfigurationManager.AppSettings["DB_Password"];
            string db_database = System.Configuration.ConfigurationManager.AppSettings["DB_Database"];
            string ConnString = "Data Source=" + db_server + ";Initial Catalog=" + db_database + ";Persist Security Info=True;User ID=" + db_userid + ";Password=" + db_password + ";Connect Timeout=120000";

            //ConnString = con;

            return ConnString;
        }

       
    }
}
