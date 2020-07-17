using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MODEL;
using System.Data.SqlClient;

namespace DAL
{
    public class Product
    {
        public List<MODEL.M_Product> getProductAll()
        {

            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();

            try
            {
                
                conn.Open();
                SqlDataAdapter adp = new SqlDataAdapter("sp_getProductAll", conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
               
                adp.Fill(ds);
                List<MODEL.M_Product> result = new List<M_Product>();
                MODEL.M_Product data;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = new M_Product();
                        data.ProductID = dt.Rows[i]["product_id"].ToString().Trim();
                        data.ProductName = dt.Rows[i]["product_name"].ToString().Trim();
                        data.ProductPrice = dt.Rows[i]["product_price"].ToString().Trim();
                        data.ProductUnit = dt.Rows[i]["unit_name"].ToString().Trim();                        
                        result.Add(data);
                    }
                }
                else
                {
                    //data = new UserInfo();
                    //data.
                }
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
