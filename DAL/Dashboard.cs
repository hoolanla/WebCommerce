using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http.Headers;
using System.IO;
using System.Net.Http;
using Newtonsoft;
using Newtonsoft.Json;
using Flurl;
using MODEL;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Dashboard
    {
        public class PostData
        {
            public string RestaurantID { get; set; }
            public string DashboardDate { get; set; }

        }
        public MODEL.DashboardKitchen getDashboardKitchen(string  restaurantID,string DashboardDate)
        {
            MODEL.DashboardKitchen Obj;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost/APIRes/api/Dashboard/getDashboardKitchen");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"RestaurantID\":\"13\"," +
                              "\"DashboardDate\":\"1234\"}";

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Obj = JsonConvert.DeserializeObject<MODEL.DashboardKitchen>(result);
                

                //Response.Write(bsObj.Name);
            }
            return Obj;


        }


        public MODEL.DashboardCashier getDashboardCashier(string restaurantID, string DashboardDate)
        {
            MODEL.DashboardCashier Obj;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost/APIRes/api/Dashboard/getDashboardCashier");
            ////http://localhost/APIRes/api/Dashboard/getDashboardCashier
        
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"RestaurantID\":\"13\"," +
                              "\"DashboardDate\":\"1234\"}";

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Obj = JsonConvert.DeserializeObject<MODEL.DashboardCashier>(result);


                //Response.Write(bsObj.Name);
            }
            return Obj;


        }


        public MODEL.DashboardCashier getDashboardCashier(MODEL.Criteria.reqDashboard req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            MODEL.DashboardCashier result = new MODEL.DashboardCashier();
            List<Bill> bill = new List<Bill>();
            try
            {
                conn.Open();

                string Sql;
                SqlDataAdapter adp = new SqlDataAdapter("sp_getDashboard_Cashier", conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.Add(new SqlParameter("@restaurantID", req.RestaurantID));
                adp.SelectCommand.Parameters.Add(new SqlParameter("@StartDate", req.DashboardDate + " 00:00"));
                adp.SelectCommand.Parameters.Add(new SqlParameter("@EndDate", req.DashboardDate + " 23:59"));
                //adp.Fill(ds);
                adp.Fill(ds);
                if(ds.Tables.Count > 0)
                {
                    result.ResultOk = "true";
                    result.FoodsOrder = ds.Tables[0].Rows[0][0].ToString().Trim();
                    result.CountTable = ds.Tables[1].Rows[0][0].ToString().Trim();
                    result.CountSalesOrderPerDay = ds.Tables[2].Rows[0][0].ToString().Trim();
                    result.CountNoticeBill = ds.Tables[3].Rows[0][0].ToString().Trim();
                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        DataTable dt = new DataTable();
                        dt = ds.Tables[4];
                        Bill f;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            f = new Bill();
                            f.queue_no = dt.Rows[i]["queue_no"].ToString().Trim();
                            f.billNo = dt.Rows[i]["order_no"].ToString().Trim();
                            f.billTableName = dt.Rows[i]["table_name"].ToString().Trim();
                            f.billMenuCount = dt.Rows[i]["CountFoods2"].ToString().Trim();
                            f.billTotalPrice = dt.Rows[i]["SumPrice2"].ToString().Trim();
                            f.billStatusText = dt.Rows[i]["status_order"].ToString().Trim();
                            bill.Add(f);
                        }
                    }
                    result.list = bill;
                }
                else
                {
                    result.ResultOk = "false";
                }


            }
            catch (Exception ex)
            {
                result.ResultOk = "false";
                result.ErrorMessage = ex.Message;
               
            }
            finally
            {
                conn.Close();

            }
            return result;


        }

        public string getCountTable(MODEL.Criteria.reqDashboard req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            String ret = "0";
            DataTable tb;

   
            try
            {
                conn.Open();

                string Sql;
                SqlDataAdapter adp = new SqlDataAdapter("sp_GetCountTable", conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.Add(new SqlParameter("@restaurantID", req.RestaurantID));
                adp.SelectCommand.Parameters.Add(new SqlParameter("@StartDate", req.DashboardDate + " 00:00"));
                adp.SelectCommand.Parameters.Add(new SqlParameter("@EndDate", req.DashboardDate + " 23:59"));
                //adp.Fill(ds);
                adp.Fill(ds);
                tb = ds.Tables[0];
                if (tb.Rows.Count > 0)
                {
                    ret = tb.Rows[0][0].ToString();
                
                }
                else
                {
            
                }


            }
            catch (Exception ex)
            {
     

            }
            finally
            {
                conn.Close();

            }
            return ret;


        }

        public string getSumPrice(MODEL.Criteria.reqDashboard req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            String ret = "0";
            DataTable tb;


            try
            {
                conn.Open();

                string Sql;
                SqlDataAdapter adp = new SqlDataAdapter("sp_GetSumPrice", conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.Add(new SqlParameter("@restaurantID", req.RestaurantID));
                adp.SelectCommand.Parameters.Add(new SqlParameter("@StartDate", req.DashboardDate + " 00:00"));
                adp.SelectCommand.Parameters.Add(new SqlParameter("@EndDate", req.DashboardDate + " 23:59"));
                //adp.Fill(ds);
                adp.Fill(ds);
                tb = ds.Tables[0];
                if (tb.Rows.Count > 0)
                {
                    ret = tb.Rows[0][0].ToString();

                }
                else
                {

                }


            }
            catch (Exception ex)
            {


            }
            finally
            {
                conn.Close();

            }
            return ret;


        }

        public string getUserBuy(MODEL.Criteria.reqDashboard req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            String ret = "0";
            DataTable tb;


            try
            {
                conn.Open();

                string Sql;
                SqlDataAdapter adp = new SqlDataAdapter("sp_GetUserBuy", conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.Add(new SqlParameter("@restaurantID", req.RestaurantID));
                adp.SelectCommand.Parameters.Add(new SqlParameter("@StartDate", req.DashboardDate + " 00:00"));
                adp.SelectCommand.Parameters.Add(new SqlParameter("@EndDate", req.DashboardDate + " 23:59"));
                //adp.Fill(ds);
                adp.Fill(ds);
                tb = ds.Tables[0];
                if (tb.Rows.Count > 0)
                {
                    ret = tb.Rows[0][0].ToString();

                }
                else
                {

                }


            }
            catch (Exception ex)
            {


            }
            finally
            {
                conn.Close();

            }
            return ret;


        }

        public string getFoodPending(MODEL.Criteria.reqDashboard req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            String ret = "0";
            DataTable tb;


            try
            {
                conn.Open();

                string Sql;
                SqlDataAdapter adp = new SqlDataAdapter("sp_GetFoodPending", conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.Add(new SqlParameter("@restaurantID", req.RestaurantID));
                adp.SelectCommand.Parameters.Add(new SqlParameter("@StartDate", req.DashboardDate + " 00:00"));
                adp.SelectCommand.Parameters.Add(new SqlParameter("@EndDate", req.DashboardDate + " 23:59"));
                //adp.Fill(ds);
                adp.Fill(ds);
                tb = ds.Tables[0];
                if (tb.Rows.Count > 0)
                {
                    ret = tb.Rows[0][0].ToString();

                }
                else
                {

                }


            }
            catch (Exception ex)
            {


            }
            finally
            {
                conn.Close();

            }
            return ret;


        }


        public string getCountFood(MODEL.Criteria.reqDashboard req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            String ret = "0";
            DataTable tb;


            try
            {
                conn.Open();

                string Sql;
                SqlDataAdapter adp = new SqlDataAdapter("sp_GetCountFood", conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.Add(new SqlParameter("@restaurantID", req.RestaurantID));
                adp.SelectCommand.Parameters.Add(new SqlParameter("@StartDate", req.DashboardDate + " 00:00"));
                adp.SelectCommand.Parameters.Add(new SqlParameter("@EndDate", req.DashboardDate + " 23:59"));
                //adp.Fill(ds);
                adp.Fill(ds);
                tb = ds.Tables[0];
                if (tb.Rows.Count > 0)
                {
                    ret = tb.Rows[0][0].ToString();

                }
                else
                {

                }


            }
            catch (Exception ex)
            {


            }
            finally
            {
                conn.Close();

            }
            return ret;


        }

        public string getCountDrink(MODEL.Criteria.reqDashboard req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            String ret = "0";
            DataTable tb;


            try
            {
                conn.Open();

                string Sql;
                SqlDataAdapter adp = new SqlDataAdapter("sp_GetCountDrink", conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.Add(new SqlParameter("@restaurantID", req.RestaurantID));
                adp.SelectCommand.Parameters.Add(new SqlParameter("@StartDate", req.DashboardDate + " 00:00"));
                adp.SelectCommand.Parameters.Add(new SqlParameter("@EndDate", req.DashboardDate + " 23:59"));
                //adp.Fill(ds);
                adp.Fill(ds);
                tb = ds.Tables[0];
                if (tb.Rows.Count > 0)
                {
                    ret = tb.Rows[0][0].ToString();

                }
                else
                {

                }


            }
            catch (Exception ex)
            {


            }
            finally
            {
                conn.Close();

            }
            return ret;


        }


    }
}
