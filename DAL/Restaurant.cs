using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using Flurl;
using MODEL;
using System.Net;
using System.Net.Http.Headers;
using System.IO;
using System.Net.Http;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System.Drawing;
using System.Drawing.Imaging;    

namespace DAL
{
    public class Restaurant
    {

        public Result InitialRestaurant(string MemberID)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            Result res = new Result();
            try
            {
                StringBuilder sqlstr = new StringBuilder();
              

                sqlstr.Append("INSERT INTO [tb_Restaurant] (restaurant_name,member_id,created_date,flag) values (");
                sqlstr.Append("'','" + MemberID + "',getdate(),'1');");


                conn.Open();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.InsertCommand = new SqlCommand(sqlstr.ToString(), conn);
                adp.InsertCommand.CommandType = CommandType.Text;
                adp.InsertCommand.ExecuteNonQuery();
                res.ResultOk = "true";
            }
            catch (Exception ex)
            {
                res.ResultOk = "false";
                res.ErrorMessage = ex.Message;
                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }

        public Result updateRestaurant(MODEL.Criteria.reqRestaurant req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            Result res = new Result();
            try
            {
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("update tb_Restaurant ");
                sqlstr.Append(" set ");
                sqlstr.Append(" restaurant_name = '" + req.RestaurantName + "'");
                sqlstr.Append(",restaurant_last = '" + req.RestaurantLat + "'");
                sqlstr.Append(",restaurant_long = '" + req.RestaurantLong + "'");
                sqlstr.Append(",restaurant_image = '" + req.RestaurantImagePath + "'");
                sqlstr.Append(",contact_name = '" + req.ContactName + "'");
                sqlstr.Append(",contact_lastname = '" + req.ContactLastName + "'");
                sqlstr.Append(",contact_address_number = '" + req.ContactAddressNo + "'");
                sqlstr.Append(",contact_moo = '" + req.ContactMoo + "'");
                sqlstr.Append(",contact_road = '" + req.ContactRoad + "'");
                sqlstr.Append(",contact_province = '" + req.ContactProvince + "'");
                sqlstr.Append(",contact_amphur = '" + req.ContactAmphur + "'");
                sqlstr.Append(",contact_tumbon = '" + req.ContactTumbon + "'");
                sqlstr.Append(",contact_zipcode = '" + req.ContactZipcode + "'");
                sqlstr.Append(",contact_tel = '" + req.ContactTel + "'");
                sqlstr.Append(",contact_phone = '" + req.ContactPhone + "'");
                sqlstr.Append(",lat = '" + req.Lat + "'");
                sqlstr.Append(",lng = '" + req.Lng + "'");
                sqlstr.Append(",updated_date=getdate()");
                sqlstr.Append(",updated_by='" + req.UserID +"'");
                sqlstr.Append(" where restaurant_id = '" + req.RestaurantID + "'");
              
                conn.Open();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.InsertCommand = new SqlCommand(sqlstr.ToString(), conn);
                adp.InsertCommand.CommandType = CommandType.Text;
                adp.InsertCommand.ExecuteNonQuery();
                res.ResultOk = "true";
            }
            catch (Exception ex)
            {
                res.ResultOk = "false";
                res.ErrorMessage = ex.Message;
                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }

        //public g

        public int getLastOrderID()
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            int res = 0;
            try
            {
                conn.Open();

                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select top 1 order_detail_id  from  tb_Order_detail order by order_detail_id desc");
                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    res = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString().Trim());
                }
                else
                {
                    res = 0;
                }

            }
            catch (Exception ex)
            {
                res = 0;
                
                
            }
            finally
            {
                conn.Close();

            }
            return res;

        }
        public string getLastOrderNo()
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            string res = "";
            try
            {
                conn.Open();
                string Prefix = "B-" + DateTime.Now.ToString("yyyyMMdd") + "-";
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select top 1 order_no  from  tb_Order_Header where order_no like  '" + Prefix + "%' order by order_no desc");
                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string[] Run = ds.Tables[0].Rows[0][0].ToString().Trim().Split(Convert.ToChar("-"));
                    res = Prefix + (Convert.ToInt32(Run[2]) + 1).ToString("D3");
                }
                else
                {
                    res = Prefix + "001";
                }

            }
            catch (Exception ex)
            {
                res = "";


            }
            finally
            {
                conn.Close();

            }
            return res;

        }

        public Result getStatusOrder(string restaurantID,string tableID)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            Result res = new Result();
            try
            {
                
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select top 1 order_status from tb_Order_Header inner join tb_Order_Status on tb_Order_Header.order_status = tb_Order_Status.keys ");
                sqlstr.Append(" where restaurant_id = '" + restaurantID + "' and table_id = '" + tableID + "'");
                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //string StatusOrder = ds.Tables[0].Rows[0][0].ToString().Trim();
                    //if (StatusOrder == "1")
                    //{

                    //}
                    res.ResultOk = "true";
                    res.ReturnMessage = ds.Tables[0].Rows[0][0].ToString().Trim();
                    res.ErrorMessage = "";
                }
                else
                {
                    res.ResultOk = "false";
                    res.ReturnMessage = "";
                    res.ErrorMessage = "";
                }


               

            }
            catch (Exception ex)
            {
                res.ResultOk = "false";
                res.ErrorMessage = ex.Message;
                res.ReturnMessage = "";
                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }

        public Result getStatusOrderIsBillPleae(string restaurantID, string tableID,string userID)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            Result res = new Result();
            try
            {

                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select top 1 order_status from tb_Order_Header inner join tb_Order_Status on tb_Order_Header.order_status = tb_Order_Status.keys ");
                sqlstr.Append(" inner join tb_Table on tb_Table.table_id = tb_Order_Header.table_id");
                sqlstr.Append(" where restaurant_id = '" + restaurantID + "' and table_id = '" + tableID + "' and user_ID = '" + userID + "'");
                sqlstr.Append(" and table_type = '2'");
                sqlstr.Append(" order by tb_Order_Header.order_id desc");
                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if(ds.Tables[0].Rows[0][0].ToString().Trim() == "2")
                    {
                        res.ResultOk = "true";
                        res.ReturnMessage = ds.Tables[0].Rows[0][0].ToString().Trim();
                        res.ErrorMessage = "";
                    }
                    else
                    {
                        res.ResultOk = "false";
                        res.ReturnMessage = ds.Tables[0].Rows[0][0].ToString().Trim();
                        res.ErrorMessage = "";
                    }
                    
                }
                else
                {
                    res.ResultOk = "false";
                    res.ReturnMessage = "";
                    res.ErrorMessage = "";
                }




            }
            catch (Exception ex)
            {
                res.ResultOk = "false";
                res.ErrorMessage = ex.Message;
                res.ReturnMessage = "";
                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }

        public Result canOpenOrder(string restaurantID, string tableID,string userID)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            Result res = new Result();
            try
            {

                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select top 1 order_no,order_status,tb_Order_Header.user_id from tb_Order_Header inner join tb_Order_Status on tb_Order_Header.order_status = tb_Order_Status.keys ");
                sqlstr.Append(" inner join tb_Table on tb_Table.table_id = tb_Order_Header.table_id");
                sqlstr.Append(" where tb_Order_Header.restaurant_id = '" + restaurantID + "' and tb_Order_Header.table_id = '" + tableID + "' ");
                sqlstr.Append(" and table_type = '2'");
                //sqlstr.Append(" and user_id = '" + userID + "'");
                sqlstr.Append(" order by tb_Order_Header.order_id desc");

                //and order_status = '1'
                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string status = dt.Rows[0][1].ToString().Trim();
                    switch (status)
                    {
                        case "1":
                            //Check User
                            if(userID == dt.Rows[0][2].ToString().Trim())
                            {
                                res.ResultOk = "Add";
                                res.ReturnMessage = dt.Rows[0][0].ToString().Trim();
                                res.ErrorMessage = "";
                            }
                            else
                            {
                                res.ResultOk = "false";
                                res.ReturnMessage = "";
                                res.ErrorMessage = "โต๊ะนี้มีผู้ใช้แล้ว !!!";
                            }
                            
                            break;
                        case "2":
                            res.ResultOk = "false";
                            res.ReturnMessage = "";
                            res.ErrorMessage = "โต๊ะนี้กำลังเช็คบิล !!!";
                            break;
                        case "3":
                            res.ResultOk = "New";
                            res.ReturnMessage = "";
                            res.ErrorMessage = "";
                            break;
                        default:
                            break;
                    }                    
                }
                else
                {
                    res.ResultOk = "New";
                    res.ReturnMessage = "";
                    res.ErrorMessage = "";
                }




            }
            catch (Exception ex)
            {
                res.ResultOk = "false";
                res.ErrorMessage = ex.Message;
                res.ReturnMessage = "";
                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }

        public Result canOpenOrderFrontTable(string restaurantID, string tableID, string userID)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            Result res = new Result();
            try
            {

                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select top 1 order_no,order_status from tb_Order_Header inner join tb_Order_Status on tb_Order_Header.order_status = tb_Order_Status.keys ");
                sqlstr.Append(" inner join tb_Table on tb_Table.table_id = tb_Order_Header.table_id");
                sqlstr.Append(" where tb_Order_Header.restaurant_id = '" + restaurantID + "' and tb_Order_Header.table_id = '" + tableID + "' ");
                sqlstr.Append(" and table_type = '1'");
                sqlstr.Append(" and user_id = '" + userID + "'");
                sqlstr.Append(" order by tb_Order_Header.order_id desc");

                //and order_status = '1'
                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string status = dt.Rows[0][1].ToString().Trim();
                    switch (status)
                    {
                        case "1":
                            res.ResultOk = "Add";
                            res.ReturnMessage = dt.Rows[0][0].ToString().Trim();
                            res.ErrorMessage = "";
                            break;
                        case "2":
                            res.ResultOk = "false";
                            res.ReturnMessage = "";
                            res.ErrorMessage = "กำลังเช็คบิล !!!";
                            break;
                        case "3":
                            res.ResultOk = "New";
                            res.ReturnMessage = "";
                            res.ErrorMessage = "";
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    res.ResultOk = "New";
                    res.ReturnMessage = "";
                    res.ErrorMessage = "";
                }


            }
            catch (Exception ex)
            {
                res.ResultOk = "false";
                res.ErrorMessage = ex.Message;
                res.ReturnMessage = "";
                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }

        public Result getTypeTable(string restaurantID, string tableID)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            Result res = new Result();
            try
            {

                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select table_type from tb_Table where restaurant_id = '" + restaurantID + "'");
                sqlstr.Append(" and table_id = '" + tableID + "'");


                insertLog(sqlstr.ToString());

                //and order_status = '1'
                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    res.ResultOk = "true";
                    res.ReturnMessage = ds.Tables[0].Rows[0][0].ToString().Trim();
                    res.ErrorMessage = "";
                }
                else
                {
                    res.ResultOk = "false";
                    res.ReturnMessage = "";
                    res.ErrorMessage = "";
                }




            }
            catch (Exception ex)
            {
                res.ResultOk = "false";
                res.ErrorMessage = ex.Message;
                res.ReturnMessage = "";
                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }

        public Result bookTable(MODEL.Criteria.reqTable req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            Result res = new Result();
            try
            {
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("update tb_table set book_status = '1', book_by = '" + req.userID + "' where table_id = '" + req.tableID + "'");

                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlstr.ToString(), conn);
                cmd.ExecuteNonQuery();
                res.ResultOk = "true";
                res.ReturnMessage = "";
                res.ErrorMessage = "";

            }
            catch (Exception ex)
            {
                res.ResultOk = "false";
                res.ErrorMessage = ex.Message;
                res.ReturnMessage = "";
                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }
        public Result cancelTable(MODEL.Criteria.reqTable req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            Result res = new Result();
            try
            {
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("update tb_table set book_status = '0',book_by=null where table_id = '" + req.tableID + "'");

                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlstr.ToString(), conn);
                cmd.ExecuteNonQuery();
                res.ResultOk = "true";
                res.ReturnMessage = "";
                res.ErrorMessage = "";

            }
            catch (Exception ex)
            {
                res.ResultOk = "false";
                res.ErrorMessage = ex.Message;
                res.ReturnMessage = "";
                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }
        public Result getbookStatusTableTypeIsBook(string restaurantID, string tableID, string userID,string Type)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            Result res = new Result();
            try
            {

                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select top 1 isnull(book_status,0) from tb_Table ");                
                sqlstr.Append(" where restaurant_id = '" + restaurantID + "' and table_id = '" + tableID + "' ");
                sqlstr.Append(" and table_type = '" + Type + "'");
                if(Type == "1")
                {
                    sqlstr.Append(" and user_id = '" + userID + "'");
                }                
                

                //and order_status = '1'
                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string status = dt.Rows[0][0].ToString().Trim();
                    switch (status)
                    {
                        case "0":
                            res.ResultOk = "false";
                            res.ReturnMessage = "empty";
                            res.ErrorMessage = "";
                            break;
                        case "1":
                            res.ResultOk = "true";
                            res.ReturnMessage = "booked";
                            res.ErrorMessage = "";
                            break;
                      
                        default:
                            res.ResultOk = "false";
                            res.ReturnMessage = "!!!";
                            res.ErrorMessage = "";
                            break;
                    }
                }
                else
                {
                    res.ResultOk = "false";
                    res.ReturnMessage = "not found table !!!";
                    res.ErrorMessage = "";
                }


            }
            catch (Exception ex)
            {
                res.ResultOk = "false";
                res.ErrorMessage = ex.Message;
                res.ReturnMessage = "";
                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }

        public Result checkOrderNotComplete(string userID)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            Result result = new Result();            
            try
            {
                conn.Open();
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select top 1 order_no from tb_Order_Header where order_status in(1,2) and  user_id = '" + userID + "'");
                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                if(dt.Rows.Count > 0)
                {
                    result.ResultOk = "true";
                    result.ReturnMessage = "Order No." + dt.Rows[0][0].ToString().Trim();
                    result.ErrorMessage = "";
                }
                else
                {
                    result.ResultOk = "false";
                    result.ReturnMessage = "";
                    result.ErrorMessage = "";
                }

            }
            catch (Exception ex)
            {
                result.ResultOk = "false";
                result.ErrorMessage = ex.Message;
                //res = null
                result.ReturnMessage = "";

                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return result;
        }

        public Result checkCompleteKitchenByOrderNo(string OrderNo)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            Result result = new Result();
            try
            {
                conn.Open();
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select order_no from tb_order_detail_kitchen where order_no = '" + OrderNo + "' and order_detail_food_status = '1' and flag = '1'");
                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    result.ResultOk = "false";
                    result.ReturnMessage = "Not Complete";
                    result.ErrorMessage = "";
                }
                else
                {
                    result.ResultOk = "true";
                    result.ReturnMessage = "";
                    result.ErrorMessage = "Complate";
                }

            }
            catch (Exception ex)
            {
                result.ResultOk = "false";
                result.ErrorMessage = ex.Message;
                //res = null
                result.ReturnMessage = "";

                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return result;
        }

        public Result getbillStatusOrder(MODEL.Criteria.reqOrder req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            Result res = new Result();
            try
            {

                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("seelct isnull(book_status) from tb_table where table_id = '" + req.tableID + "'");
                //sqlstr.Append(" and order_status = '1'");
                //and order_status = '1'
                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string status = dt.Rows[0][0].ToString().Trim();
                    switch (status)
                    {
                        case "1":
                            res.ResultOk = "false";
                            res.ReturnMessage = "Table is use !!!";
                            res.ErrorMessage = "";
                            break;
                        case "2":
                            res.ResultOk = "false";
                            res.ReturnMessage = "Table is bill please !!!";
                            res.ErrorMessage = "";
                            break;
                        case "0":
                            res.ResultOk = "true";
                            res.ReturnMessage = "Table is empty";
                            res.ErrorMessage = "";
                            break;
                        default:
                            res.ResultOk = "false";
                            res.ReturnMessage = "";
                            res.ErrorMessage = "!!!";
                            break;
                    }
                }
                else
                {
                    res.ResultOk = "false";
                    res.ReturnMessage = "Table not found !!!";
                    res.ErrorMessage = "";
                }

            }
            catch (Exception ex)
            {
                res.ResultOk = "false";
                res.ErrorMessage = ex.Message;
                res.ReturnMessage = "";
                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }


        public Result canNotedBillOrder(string restaurantID, string tableID)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            Result res = new Result();
            try
            {

                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select top 1 order_status from tb_Order_Header");
                sqlstr.Append(" where restaurant_id = '" + restaurantID + "'");
                sqlstr.Append(" and table_id = '" + tableID + "'");
                sqlstr.Append(" order by order_id desc");
                //sqlstr.Append(" and order_status = '1'");
                //and order_status = '1'
                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string status = dt.Rows[0][0].ToString().Trim();
                    switch (status)
                    {
                        case "1":
                            res.ResultOk = "true";
                            res.ReturnMessage = "";
                            res.ErrorMessage = "";
                            break;
                        case "2":
                            res.ResultOk = "false";
                            res.ReturnMessage = "";
                            res.ErrorMessage = "โต๊ะนี้กำลังเช็คบิล !!!";
                            break;
                        case "3":
                            res.ResultOk = "true";
                            res.ReturnMessage = "";
                            res.ErrorMessage = "";
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    res.ResultOk = "false";
                    res.ReturnMessage = "โต๊ะนี้ไม่มีบิล !!!";
                    res.ErrorMessage = "";
                }




            }
            catch (Exception ex)
            {
                res.ResultOk = "false";
                res.ErrorMessage = ex.Message;
                res.ReturnMessage = "";
                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }


        public int getQueue(MODEL.Criteria.reqOrder req)
        {

            DateTimeFormatInfo dtfInfo = DateTimeFormatInfo.InvariantInfo;
            String curDate = DateTime.Today.ToString("MM/dd/yyyy", dtfInfo);


            //    sqlstr.Append(" where tb_Order_Header.restaurant_id = '" + req.restaurantID + "' and tb_Order_Header.created_date between '" + req.currentDate + " 00:00' and '" + req.currentDate + " 23:59'");
            string sql = "select max(queue_no) from tb_order_header";
            sql += " where restaurant_id = '" + req.restaurantID + "' and created_date between '" + curDate + " 00:00' and '" + curDate + " 23:59'";
            
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
            adp.SelectCommand.CommandType = CommandType.Text;
            adp.Fill(ds);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            if(dt.Rows.Count > 0)
            {
                if(dt.Rows[0][0] == DBNull.Value)
                {
                    return 1;
                }
                else
                {
                    return Convert.ToInt32(dt.Rows[0][0].ToString()) + 1;
                }
               
            }
            else
            {
                return 1;
            }
        }

        public Result insertOrder(MODEL.Criteria.reqOrder req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            Result res = new Result();
            try
            {               
                string OrderNo = getLastOrderNo();
                Result OpenOrder = canOpenOrder(req.restaurantID, req.tableID,req.userID);
                string Status = OpenOrder.ResultOk;
                StringBuilder sqlstr = new StringBuilder();
                switch (Status)
                {
                    // Table temp can open alway.
                    case "New":

                        int tmpQ = getQueue(req);

                        sqlstr.Append("INSERT INTO[dbo].[tb_Order_Header]");
                        sqlstr.Append("([order_no],[restaurant_id],[table_id],[user_id],[user_email],[order_status],[order_remark],[created_date],[created_by],[flag],[queue_no]) values (");
                        sqlstr.Append("'" + OrderNo + "','" + req.restaurantID + "','" + req.tableID + "'");
                        sqlstr.Append(",'" + req.userID + "','USEReMAIL','1','REMARK',getdate(),'" + req.userID + "','1'," + tmpQ + ");");
                        sqlstr.Append("\r\n");
                        break;
                    // Table one only (Wait for empty).
                    case "Add":
                        OrderNo = OpenOrder.ReturnMessage;
                        break;
                    default:
                        return OpenOrder;                        
                }               
                if(req.orderList.Count > 0)
                {
                    //get Last Order Detail
                    int orderID = 0;
                    foreach (FoodsItems item in req.orderList)
                    {
                        DateTime dtNow = DateTime.Now;
                        DateTime startDT = new DateTime(2014, 01, 21);
                        DateTime endDT = startDT.AddDays(1);
                        string sessionID = String.Format("{0}_{1}_{2}"
                                                , dtNow.Year.ToString("0000") + dtNow.ToString("MMdd:HHmmss")
                                                , startDT.Year.ToString("0000") + startDT.Date.ToString("MMdd")
                                                , endDT.Year.ToString("0000") + endDT.Date.ToString("MMdd"));
                        //for (int i = 0; i < item.qty; i++)
                        //{
                        sqlstr.Append("INSERT INTO[dbo].[tb_Order_Detail] ([order_no],[order_detail_food_id],[order_detail_food_name],[order_detail_food_size],[order_detail_food_price],[order_detail_food_status]");
                        sqlstr.Append(",[created_date],[created_by],[flag],order_detail_food_taste,order_detail_food_qty,sessionID,order_detail_food_comment) values ('" + OrderNo + "','" + item.foodsID + "','" + item.foodsName + "','" + item.size + "'");
                        sqlstr.Append(",'" + item.price + "','1',getdate(),'" + req.userID + "','1','" + item.taste + "','" + item.qty + "','" + sessionID + "','" + item.comment + "');");

                        sqlstr.Append("\r\n");
                        //}
                        for (int i = 0; i < item.qty; i++)
                        {
                            sqlstr.Append("INSERT INTO[dbo].[tb_Order_Detail_kitchen] ([order_no],[order_detail_food_id],[order_detail_food_name],[order_detail_food_size],[order_detail_food_price],[order_detail_food_status]");
                            sqlstr.Append(",[created_date],[created_by],[flag],order_detail_food_taste,order_detail_food_qty,sessionID) values ('" + OrderNo + "','" + item.foodsID + "','" + item.foodsName + "','" + item.size + "'");
                            sqlstr.Append(",'" + item.price + "','1',getdate(),'" + req.userID + "','1','" + item.taste + "','" + item.qty + "','" + sessionID + "');");
                            sqlstr.Append("\r\n");
                        }
                        System.Threading.Thread.Sleep(1000);

                    }
                }


               
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlstr.ToString(), conn);
                cmd.ExecuteNonQuery();
                res.ResultOk = "true";
                res.ReturnMessage = OrderNo;
                res.ErrorMessage = "";

            }
            catch (Exception ex)
            {
                res.ResultOk = "false";
                res.ErrorMessage = ex.Message;
                res.ReturnMessage = "";
                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }

        public Result getStatusOrderDetail(string orderID)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            Result res = new Result();
            try
            {

                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select order_detail_food_status from tb_order_detail where order_detail_id = '" + orderID + "'");
              
                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    res.ResultOk = "true";
                    res.ReturnMessage = dt.Rows[0][0].ToString().Trim();
                    res.ErrorMessage = "";
                }
                else
                {
                    res.ResultOk = "false";
                    res.ReturnMessage = "";
                    res.ErrorMessage = "";
                }

            }
            catch (Exception ex)
            {
                res.ResultOk = "false";
                res.ErrorMessage = ex.Message;
                res.ReturnMessage = "";
                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }

        public Result cancelOrder(MODEL.Criteria.reqOrder req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            Result res = new Result();
            try
            {
                Result statusOrderDetail = getStatusOrderDetail(req.orderID);
                if (statusOrderDetail.ResultOk == "true")
                {
                    if(statusOrderDetail.ReturnMessage == "2")
                    {
                        res.ResultOk = "false";
                        res.ErrorMessage = "Food is complete !!!";
                        res.ReturnMessage = "";
                        return res;
                    }
                    if (statusOrderDetail.ReturnMessage == "3")
                    {
                        res.ResultOk = "false";
                        res.ErrorMessage = "Food is closed !!!";
                        res.ReturnMessage = "";
                        return res;
                    }
                }

                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("update tb_Order_Detail set flag = '0',updated_date=getdate(),updated_by='" + req.userID + "' where order_detail_id = '" + req.orderID + "';");
                sqlstr.Append("\r\n");
                sqlstr.Append("update tb_Order_Detail_kitchen set flag = '0',updated_date=getdate(),updated_by='" + req.userID + "' where sessionID = (select top 1 sessionID from tb_Order_Detail where order_detail_id = '" + req.orderID + "');");
                sqlstr.Append("\r\n");

                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlstr.ToString(), conn);
                cmd.ExecuteNonQuery();
                res.ResultOk = "true";
                res.ReturnMessage = "";
                res.ErrorMessage = "";

            }
            catch (Exception ex)
            {
                res.ResultOk = "false";
                res.ErrorMessage = ex.Message;
                res.ReturnMessage = "";
                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }

        public Result updateOrder(MODEL.Criteria.reqOrder req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            Result res = new Result();
            try
            {
                Result resCanNotedBill = new Result();
                resCanNotedBill = canNotedBillOrder(req.restaurantID, req.tableID);
                if (resCanNotedBill.ResultOk == "true")
                {
                    StringBuilder sqlstr = new StringBuilder();
                    sqlstr.Append("update tb_Order_Header set order_status = '" + req.statusID + "'");
                    sqlstr.Append(",updated_by = '" + req.userID + "'");
                    sqlstr.Append(",updated_date = getdate()");
                    sqlstr.Append(" where restaurant_id = '" + req.restaurantID + "'");
                    sqlstr.Append(" and table_id = '" + req.tableID + "'");
                    sqlstr.Append(" and order_status = '1'");
                    
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlstr.ToString(), conn);
                    cmd.ExecuteNonQuery();
                    res.ResultOk = "true";
                    res.ReturnMessage = "";
                    res.ErrorMessage = "";
                }
                else
                {
                    res = resCanNotedBill;
                }
                

            }
            catch (Exception ex)
            {
                res.ResultOk = "false";
                res.ErrorMessage = ex.Message;
                res.ReturnMessage = "";
                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }
        public Result updateOrderByOrderNo(MODEL.Criteria.reqOrder req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            Result res = new Result();
            try
            {
                //Result resCanNotedBill = new Result();
                //resCanNotedBill = canNotedBillOrder(req.restaurantID, req.tableID);
                //if (resCanNotedBill.ResultOk == "true")
                //{
                    StringBuilder sqlstr = new StringBuilder();
                    sqlstr.Append("update tb_Order_Header set order_status = '" + req.statusID + "'");
                    sqlstr.Append(",updated_by = '" + req.userID + "'");
                    sqlstr.Append(",updated_date = getdate()");
                    sqlstr.Append(" where order_no = '" + req.orderNo + "'");
                    sqlstr.Append("\r\n");
                    sqlstr.Append("update tb_table set book_status = '0', book_by=null where table_id = (select top 1 table_id from tb_Order_Header where order_no = '" + req.orderNo + "')");
                    //sqlstr.Append(" where restaurant_id = '" + req.restaurantID + "'");
                    //sqlstr.Append(" and table_id = '" + req.tableID + "'");
                    //sqlstr.Append(" and order_status = '1'");

                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlstr.ToString(), conn);
                    cmd.ExecuteNonQuery();
                    res.ResultOk = "true";
                    res.ReturnMessage = "";
                    res.ErrorMessage = "";
                //}
                //else
                //{
                //    res = resCanNotedBill;
                //}


            }
            catch (Exception ex)
            {
                res.ResultOk = "false";
                res.ErrorMessage = ex.Message;
                res.ReturnMessage = "";
                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }

        public ResultOrder getOrderList(MODEL.Criteria.reqOrder req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            ResultOrder result = new ResultOrder();
            List<Order> res = new List<Order>();
            try
            {
                conn.Open();
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select h.restaurant_id,h.user_id,h.table_id,d.order_detail_food_id,d.order_detail_food_name");
                sqlstr.Append(",(select count(order_detail_food_id) from tb_order_detail where order_no = h.order_no) as [CountQty]");
                sqlstr.Append(",(d.order_detail_food_qty * d.order_detail_food_price) as [SumPrice]");
                sqlstr.Append(",(select sum(order_detail_food_price * order_detail_food_qty) from tb_order_detail where order_no = h.order_no and flag = '1') as [TotalPrice]");
           
                sqlstr.Append(",d.order_detail_food_price,d.order_detail_food_status,tb_Food_Status.food_status");
                sqlstr.Append(",menu_name,menu_picture");
                sqlstr.Append(",d.order_detail_id,d.order_detail_food_qty");
                sqlstr.Append(",d.order_detail_food_comment");
                sqlstr.Append(",tb_Order_Status.status_order");
                sqlstr.Append(",h.order_no");
                sqlstr.Append(" from tb_order_header h");
                sqlstr.Append(" inner join tb_order_detail d on h.order_no = d.order_no");
                sqlstr.Append(" inner join tb_Food_Status on d.order_detail_food_status = tb_Food_Status.keys");
                sqlstr.Append(" inner join tb_menu on tb_menu.menu_id = d.order_detail_food_id");
                sqlstr.Append(" inner join tb_Order_Status on tb_Order_Status.keys = h.order_status ");
                sqlstr.Append(" where h.restaurant_id = '" + req.restaurantID + "' and h.table_id = '" + req.tableID + "'");
                sqlstr.Append(" and h.created_by = '" + req.userID + "'");
                sqlstr.Append(" and d.flag = '1'");
                sqlstr.Append(" and h.order_status in (1,2)");
               
                //sqlstr.Append(" and h.order_status in (1,2)");
                //if (req.statusID != null)
                //{
                //    if(req.statusID != "")
                //    {
                //        sqlstr.Append(" and h.order_status = '" + req.statusID + "'");
                //    }
                //}
                
                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    Order f;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        f = new Order();
                        f.orderID = dt.Rows[i]["order_detail_id"].ToString().Trim();
                        f.restuarantID = dt.Rows[i]["restaurant_id"].ToString().Trim();
                        f.tableID = dt.Rows[i]["table_id"].ToString().Trim();
                        f.foodsID = dt.Rows[i]["order_detail_food_id"].ToString().Trim(); 
                        f.foodsName = dt.Rows[i]["menu_name"].ToString().Trim();
                        f.qty = dt.Rows[i]["order_detail_food_qty"].ToString().Trim();
                        f.price = dt.Rows[i]["order_detail_food_price"].ToString().Trim();
                        f.totalPrice = dt.Rows[i]["SumPrice"].ToString().Trim(); 
                        f.status = dt.Rows[i]["food_status"].ToString().Trim();
                        f.comment = dt.Rows[i]["order_detail_food_comment"].ToString().Trim();
                        f.image = DataHelper.PartHost + @"/ImagesFood/" + dt.Rows[i]["menu_picture"].ToString().Trim();
                        f.userID = req.userID;
                        //f.or
                        //f.foodsID = dt.Rows[i][].ToString().Trim();
                        res.Add(f);


                    }
                    result.ResultOk = "true";
                    result.ErroMessage = "";
                    result.ReturnMessage = "";
                    result.orderNo = dt.Rows[0]["order_no"].ToString().Trim();
                    result.orderStatus = dt.Rows[0]["status_order"].ToString().Trim();
                    result.orderList = res;
                }
                else
                {
                    result.ResultOk = "false";
                    result.ErroMessage = "";
                    result.ReturnMessage = "No Foods Item !!!";
                    result.orderList = res;
                }
                
                

            }
            catch (Exception ex)
            {
                result.ResultOk = "false";
                result.ErroMessage = ex.Message;
                //res = null
                result.ReturnMessage = "";

                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return result;
        }

        public ResultRestaurantContent getFirstPage(MODEL.Criteria.reqRestaurant req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            ResultRestaurantContent result = new ResultRestaurantContent();
            List<RestaurantContent> res = new List<RestaurantContent>();
            try
            {
                conn.Open();
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select restaurant_id, restaurant_name, restaurant_content, restaurant_description, restaurant_image");
                sqlstr.Append(" from tb_Restaurant where flag = '1' ");
                if(req != null)
                {
                    sqlstr.Append(" and restaurant_id = '" + req.RestaurantID + "'");
                }
                

                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    RestaurantContent f;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        f = new RestaurantContent();
                        f.restaurantID= dt.Rows[i]["restaurant_id"].ToString().Trim();
                        f.restaurantName = dt.Rows[i]["restaurant_name"].ToString().Trim();
                        f.content = dt.Rows[i]["restaurant_content"].ToString().Trim();
                        f.description = dt.Rows[i]["restaurant_description"].ToString().Trim();
                        f.images = DataHelper.PartHost + @"/ImagesRestaurant/" + dt.Rows[i]["restaurant_image"].ToString().Trim();
                        // + dt.Rows[i]["menu_picture"].ToString().Trim();
                        res.Add(f);


                    }
                    result.ResultOk = "true";
                    result.ErrorMessage = "";                 
                    result.data = res;
                }
                else
                {
                    result.ResultOk = "false";
                    result.ErrorMessage = "";
                  
                }



            }
            catch (Exception ex)
            {
                result.ResultOk = "false";
                result.ErrorMessage = ex.Message;
                //res = null
                //result.ReturnMessage = "";

                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return result;
        }



        public ResultProfile updateProfile(MODEL.ResultProfile req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            ResultProfile res = new ResultProfile();

            try
            {
                conn.Open();
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("Update tb_member");
                sqlstr.Append(" set member_name ='" + req.Name + "',");
                sqlstr.Append(" lastname='" + req.Lastname + "',");
                sqlstr.Append(" tel='" + req.Tel + "'");
                sqlstr.Append(" where member_id='" + req.UserID + "'");

                SqlCommand cmd = new SqlCommand(sqlstr.ToString(), conn);
                cmd.ExecuteNonQuery();
                res.ResultOk = "true";
                res.ErrorMessage = "";
                res.Name = req.Name;
                res.Lastname = req.Lastname;
                res.Tel = req.Tel;
                res.Email = "";
                res.UserID = "";



            }
            catch (Exception ex)
            {
                res.ResultOk = "false";
                res.ErrorMessage = ex.Message;
                res.Name = req.Name;
                res.Lastname = "";
                res.Tel = "";
                res.Email = "";
                res.UserID = "";
            }
            finally
            {
                conn.Close();

            }
            return res;
        }

        public ResultOrderForBill getOrderListForCheckBill(MODEL.Criteria.reqOrder req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            ResultOrderForBill result = new ResultOrderForBill();
            List<Order> res = new List<Order>();
            try
            {
                conn.Open();
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select tb_Order_Header.order_no,table_name,order_detail_food_id,order_detail_food_name,(order_detail_food_price * order_detail_food_qty) as order_detail_food_price");
                sqlstr.Append(",order_detail_food_size,order_detail_food_taste,tb_Food_Status.food_status,tb_Order_Detail.order_detail_id,menu_picture");
                sqlstr.Append(",order_detail_food_qty");
                sqlstr.Append(" from tb_Order_Header inner join tb_Order_Detail on tb_Order_Header.order_no = tb_Order_Detail.order_no");
                sqlstr.Append(" inner join tb_Table on tb_Table.table_id = tb_Order_Header.table_id");
                sqlstr.Append(" inner join tb_Order_Status on tb_Order_Header.order_status = tb_Order_Status.keys");
                sqlstr.Append(" inner join tb_Food_Status on tb_Order_Detail.order_detail_food_status = tb_Food_Status.keys");
                sqlstr.Append(" inner join tb_Menu on tb_Menu.menu_id = order_detail_food_id");
                

                sqlstr.Append(" where tb_Order_Header.order_no = '" + req.orderNo + "'");
                sqlstr.Append(" and tb_Order_Detail.order_detail_food_status in ('1','2')");
                sqlstr.Append(" and tb_Order_Detail.flag = '1'");


                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                double totalPrice = 0;
                if (dt.Rows.Count > 0)
                {
                    Order f;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        f = new Order();
                        //f.restuarantID = dt.Rows[i]["restaurant_id"].ToString().Trim();
                        //f.tableID = dt.Rows[i]["table_id"].ToString().Trim();
                        f.foodsID = dt.Rows[i]["order_detail_food_id"].ToString().Trim();
                        f.foodsName = dt.Rows[i]["order_detail_food_name"].ToString().Trim();
                        f.qty = dt.Rows[i]["order_detail_food_qty"].ToString().Trim();
                        f.price = dt.Rows[i]["order_detail_food_price"].ToString().Trim();
                        f.foodsTaste = dt.Rows[i]["order_detail_food_taste"].ToString().Trim();
                        f.foodsSize = dt.Rows[i]["order_detail_food_size"].ToString().Trim();
                        //f.totalPrice = dt.Rows[i]["SumPrice"].ToString().Trim();
                        f.status = dt.Rows[i]["food_status"].ToString().Trim();
                        totalPrice = totalPrice + Convert.ToDouble(f.price );
                       // totalPrice = totalPrice + (Convert.ToDouble(f.price) * Convert.ToDouble(f.qty));
                        //f.userID = req.userID;
                        //f.foodsID = dt.Rows[i][].ToString().Trim();
                        res.Add(f);


                    }
                    result.ResultOk = "true";
                    result.ErroMessage = "";
                    result.ReturnMessage = "";
                    result.tableName = dt.Rows[0]["table_name"].ToString().Trim();
                    result.totalPrice = totalPrice;
                    result.restaurantName = getRestaurant(req.restaurantID).RestaurantName;
                    result.orderList = res;
                }
                else
                {
                    result.ResultOk = "false";
                    result.ErroMessage = "";
                    result.ReturnMessage = "No Foods Item !!!";
                    result.orderList = res;
                }



            }
            catch (Exception ex)
            {
                result.ResultOk = "false";
                result.ErroMessage = ex.Message;
                //res = null
                result.ReturnMessage = "";

                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return result;
        }

        public MODEL.Restaurant getRestaurant(string restaurantID)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            MODEL.Restaurant res = new MODEL.Restaurant();
            try
            {
                conn.Open();
               
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select");
                sqlstr.Append(" restaurant_name,restaurant_last,restaurant_long,restaurant_image");
                sqlstr.Append(",contact_name,contact_lastname,contact_address_number,contact_moo");
                sqlstr.Append(",contact_road,contact_province,contact_amphur,contact_tumbon,contact_zipcode");
                sqlstr.Append(",contact_tel,contact_phone");
               
                sqlstr.Append(" from tb_Restaurant where restaurant_id = '" + restaurantID  + "'");

                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    res.RestaurantID = restaurantID;
                    res.RestaurantName = dt.Rows[0]["restaurant_name"].ToString().Trim();
                    //DataHelper.PartHost + @"/ImagesFood/" +
                    res.RestaurantImagePath = dt.Rows[0]["restaurant_image"].ToString().Trim();
                    res.RestaurantLast = dt.Rows[0]["restaurant_last"].ToString().Trim();
                    res.RestaurantLong = dt.Rows[0]["restaurant_long"].ToString().Trim();
                    res.ContactName = dt.Rows[0]["contact_name"].ToString().Trim();
                    res.ContactLastName = dt.Rows[0]["contact_lastname"].ToString().Trim();
                    res.ContactAddressNo = dt.Rows[0]["contact_address_number"].ToString().Trim();
                    res.ContactMoo = dt.Rows[0]["contact_moo"].ToString().Trim();
                    res.ContactRoad = dt.Rows[0]["contact_road"].ToString().Trim();
                    res.ContactProvince = Convert.ToInt32(dt.Rows[0]["contact_province"].ToString().Trim());
                    res.ContactAmphur = Convert.ToInt32(dt.Rows[0]["contact_amphur"].ToString().Trim());
                    res.ContactTumbon = Convert.ToInt32(dt.Rows[0]["contact_tumbon"].ToString().Trim());
                    res.ContactZipcode = dt.Rows[0]["contact_zipcode"].ToString().Trim();
                    res.ContactTel = dt.Rows[0]["contact_tel"].ToString().Trim();
                    res.ContactPhone = dt.Rows[0]["contact_phone"].ToString().Trim();


                }
                else
                {
                    res.RestaurantID = "";
                    res.RestaurantName = "";
                    res.RestaurantImagePath = "";
                }

            }
            catch (Exception ex)
            {
                res = null;

            }
            finally
            {
                conn.Close();

            }
            return res;
        }

        public List<Table> getTable(MODEL.Criteria.reqTable req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            List<Table> res = new List<Table>();
            try
            {
                conn.Open();
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select table_id,table_group_id,table_name,table_remark");
                sqlstr.Append(" from tb_Table where flag = '1'");
                sqlstr.Append(" and restaurant_id = '" + req.restaurantID + "'");

                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    Table f;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        f = new Table();
                        f.TableID = dt.Rows[i]["table_id"].ToString().Trim();
                        f.TableName = dt.Rows[i]["table_name"].ToString().Trim();
                        f.TableGroupID = dt.Rows[i]["table_group_id"].ToString().Trim();
                        f.TableRemark = dt.Rows[i]["table_remark"].ToString().Trim();                        
                        res.Add(f);
                    }
                }

            }
            catch (Exception ex)
            {
                res = null;

                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;


        }

        public DataTable getTableDT(String req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
     
         
                conn.Open();
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select a.table_id,a.table_group_id,a.table_name,a.table_remark,a.flag,b.restaurant_id,b.restaurant_name");
                sqlstr.Append(" from tb_Table as a,tb_restaurant as b  where a.flag = '1'");
                sqlstr.Append(" and a.restaurant_id=b.restaurant_id and a.restaurant_id = '" + req + "'");

                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                return dt;

        }

        public int getMaxIDTable()
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();            
            try
            {
                conn.Open();
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select top 1 table_id from tb_Table order by table_id desc");                
                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0][0].ToString().Trim());
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                return 0;

                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            


        }



        public void  insertLog(String log_)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            String sql;
            sql = "insert into tb_Log(Log_) Values('" + log_ + "')";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
 
        }



        public Result insertTable(MODEL.Criteria.reqTable req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            Result res = new Result();
            //try
            //{
                StringBuilder sqlstr = new StringBuilder();
                //get MAXID Table
                int MaxID = getMaxIDTable() + 1;
                string password = "Lumpsum";
                string encryptedstring = DAL.StringCipher.Encrypt("{\"restaurantID\":\"" + req.restaurantID + "\",\"tableID\":\"" + MaxID.ToString() + "\"}", password);
                //string decryptedstring = DAL.StringCipher.Decrypt(encryptedstring, password);

                sqlstr.Append("INSERT INTO tb_Table");
                sqlstr.Append("(restaurant_id,table_name,table_status,table_remark,table_group_id,[created_date],[created_by],flag,table_type,QRCode) values (");
                sqlstr.Append("'" + req.restaurantID + "','" + req.tableDetail + "','1','" + req.tableRemark + "'");
                sqlstr.Append(",'" + req.tableGroupID + "',getdate(),'" + req.userID + "','1','" + req.tableTypeID + "','" + encryptedstring + "');");
                sqlstr.Append("\r\n");

             

                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlstr.ToString(), conn);
                cmd.ExecuteNonQuery();
                res.ResultOk = "true";
                res.ReturnMessage = "";
                res.ErrorMessage = "";

                QRCodeEncoder qr = new QRCodeEncoder();
                Bitmap img = qr.Encode(encryptedstring);
               String path = AppDomain.CurrentDomain.BaseDirectory;
                img.Save(path + "/QRCode/" + MaxID + ".jpeg", ImageFormat.Jpeg);
                



            //}
            //catch (Exception ex)
            //{
            //    res.ResultOk = "false";
            //    res.ErrorMessage = ex.Message;
            //    res.ReturnMessage = "";
            //    //throw ex;
            //}
            //finally
            //{
            //    conn.Close();

            //}
            return res;
        }

        public Result updateFood(MODEL.Criteria.reqFood req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            Result res = new Result();
            try
            {
                StringBuilder sqlstr = new StringBuilder();
                
                

                sqlstr.Append("update tb_Order_Detail_kitchen set order_detail_food_status = '" + req.FoodStatus + "'");
                sqlstr.Append(",updated_date = getdate(),updated_by = '" + req.UserID + "'");
                sqlstr.Append(" where order_detail_kitchen_id = '" + req.FoodID + "';");

                //update tb_Order_Detail_kitchen set order_detail_food_status = '2'
             //, updated_date = getdate(), updated_by = '1'
              //where order_detail_kitchen_id = '48';
                sqlstr.Append("\r\n");
                sqlstr.Append("update tb_Order_Detail set order_detail_food_status = '" + req.FoodStatus + "'");
                sqlstr.Append(", updated_date = getdate(), updated_by = '" + req.UserID + "'");
                sqlstr.Append(" where sessionID = (select top 1 sessionID from tb_Order_Detail_kitchen where order_detail_kitchen_id = '" + req.FoodID + "')");
                sqlstr.Append(" and (select count(order_detail_kitchen_id) from tb_Order_Detail_kitchen where sessionID = (select top 1 sessionID from tb_Order_Detail_kitchen where order_detail_kitchen_id = '" + req.FoodID + "') and order_detail_food_status = '1') = 0");
             
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlstr.ToString(), conn);
                cmd.ExecuteNonQuery();
                res.ResultOk = "true";
                res.ReturnMessage = "";
                res.ErrorMessage = "";

            }
            catch (Exception ex)
            {
                res.ResultOk = "false";
                res.ErrorMessage = ex.Message;
                res.ReturnMessage = "";
                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }

        public List<MODEL.FoodView> getFoodsView(MODEL.Criteria.reqKitchen req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            List<MODEL.FoodView> res = new List<MODEL.FoodView>();
            try
            {
                conn.Open();
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select tb_Order_Header.order_no,table_name,order_detail_food_id,order_detail_food_name,order_detail_food_price");
                sqlstr.Append(",order_detail_food_size,order_detail_food_taste,tb_Food_Status.food_status,tb_Order_Detail.order_detail_id,menu_picture");
                sqlstr.Append(" from tb_Order_Header inner join tb_Order_Detail on tb_Order_Header.order_no = tb_Order_Detail.order_no");
                sqlstr.Append(" inner join tb_Table on tb_Table.table_id = tb_Order_Header.table_id");
                sqlstr.Append(" inner join tb_Order_Status on tb_Order_Header.order_status = tb_Order_Status.keys");
                sqlstr.Append(" inner join tb_Food_Status on tb_Order_Detail.order_detail_food_status = tb_Food_Status.keys");
                sqlstr.Append(" inner join tb_Menu on tb_Menu.menu_id = order_detail_food_id");
                sqlstr.Append(" where tb_Order_Header.restaurant_id = '" + req.restaurantID + "' and tb_Order_Header.created_date between '" + req.currentDate + " 00:00' and '" + req.currentDate + " 23:59'");
                sqlstr.Append(" and tb_Order_Detail.order_detail_food_status = '" + req.foodStatusID + "'");
                sqlstr.Append(" and tb_Order_Detail_kitchen.flag = '1'");


                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    FoodView f;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        f = new FoodView();
                        f.tableName = dt.Rows[i]["table_name"].ToString().Trim();
                        //f.tableID = dt.Rows[i]["table_group_id"].ToString().Trim();
                        f.foodMenuID = dt.Rows[i]["order_detail_id"].ToString().Trim();
                        f.foodMenuName = dt.Rows[i]["order_detail_food_name"].ToString().Trim();
                        f.foodMenuSize = dt.Rows[i]["order_detail_food_size"].ToString().Trim();
                        f.foodMenuTaste = dt.Rows[i]["order_detail_food_taste"].ToString().Trim();
                        f.foodMenuStatus = dt.Rows[i]["food_status"].ToString().Trim();
                        f.foodMenuImage = DataHelper.PartHost + @"/ImagesFood/" + dt.Rows[i]["menu_picture"].ToString().Trim();
                        f.foodMenuPrice = Convert.ToDouble(dt.Rows[i]["order_detail_food_price"].ToString().Trim());
                        res.Add(f);
                    }
                }

            }
            catch (Exception ex)
            {
                res = null;

                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }


        public List<MODEL.FoodView> getFoodsViewForKitchen(MODEL.Criteria.reqKitchen req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            List<MODEL.FoodView> res = new List<MODEL.FoodView>();
            try
            {
                conn.Open();
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select tb_Order_Header.order_no,table_name,order_detail_food_id,order_detail_food_name,order_detail_food_price");
                sqlstr.Append(",order_detail_food_size,order_detail_food_taste,tb_Food_Status.food_status,tb_Order_Detail_kitchen.order_detail_kitchen_id,menu_picture");
                sqlstr.Append(" from tb_Order_Header inner join tb_Order_Detail_kitchen on tb_Order_Header.order_no = tb_Order_Detail_kitchen.order_no");
                sqlstr.Append(" inner join tb_Table on tb_Table.table_id = tb_Order_Header.table_id");
                sqlstr.Append(" inner join tb_Order_Status on tb_Order_Header.order_status = tb_Order_Status.keys");
                sqlstr.Append(" inner join tb_Food_Status on tb_Order_Detail_kitchen.order_detail_food_status = tb_Food_Status.keys");
                sqlstr.Append(" inner join tb_Menu on tb_Menu.menu_id = order_detail_food_id");
                sqlstr.Append(" where tb_Order_Header.restaurant_id = '" + req.restaurantID + "' and tb_Order_Header.created_date between '" + req.currentDate + " 00:00' and '" + req.currentDate + " 23:59'");
                sqlstr.Append(" and tb_Order_Detail_kitchen.order_detail_food_status = '" + req.foodStatusID + "'");
                sqlstr.Append(" and tb_Order_Detail_kitchen.flag = '1'");

                //sqlstr.Append(" and ");


                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    FoodView f;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        f = new FoodView();
                        f.tableName = dt.Rows[i]["table_name"].ToString().Trim();
                        //f.tableID = dt.Rows[i]["table_group_id"].ToString().Trim();
                        f.foodMenuID = dt.Rows[i]["order_detail_kitchen_id"].ToString().Trim();
                        f.foodMenuName = dt.Rows[i]["order_detail_food_name"].ToString().Trim();
                        f.foodMenuSize = dt.Rows[i]["order_detail_food_size"].ToString().Trim();
                        f.foodMenuTaste = dt.Rows[i]["order_detail_food_taste"].ToString().Trim();
                        f.foodMenuStatus = dt.Rows[i]["food_status"].ToString().Trim();
                        f.foodMenuImage = DataHelper.PartHost + @"/ImagesFood/" + dt.Rows[i]["menu_picture"].ToString().Trim();
                        f.foodMenuPrice = Convert.ToDouble(dt.Rows[i]["order_detail_food_price"].ToString().Trim());
                        res.Add(f);
                    }
                }

            }
            catch (Exception ex)
            {
                res = null;

                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }

        public List<MODEL.FoodView> getCashierView(MODEL.Criteria.reqKitchen req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            List<MODEL.FoodView> res = new List<MODEL.FoodView>();
            try
            {
                conn.Open();
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select tb_Order_Header.order_no,table_name,order_detail_food_id,order_detail_food_name,order_detail_food_price");
                sqlstr.Append(",order_detail_food_size,order_detail_food_taste,tb_Food_Status.food_status,tb_Order_Detail.order_detail_id,menu_picture");
                sqlstr.Append(",order_detail_food_qty");
                sqlstr.Append(" from tb_Order_Header inner join tb_Order_Detail on tb_Order_Header.order_no = tb_Order_Detail.order_no");
                sqlstr.Append(" inner join tb_Table on tb_Table.table_id = tb_Order_Header.table_id");
                sqlstr.Append(" inner join tb_Order_Status on tb_Order_Header.order_status = tb_Order_Status.keys");
                sqlstr.Append(" inner join tb_Food_Status on tb_Order_Detail.order_detail_food_status = tb_Food_Status.keys");
                sqlstr.Append(" inner join tb_Menu on tb_Menu.menu_id = order_detail_food_id");
                sqlstr.Append(" where tb_Order_Header.restaurant_id = '" + req.restaurantID + "' and tb_Order_Header.created_date between '" + req.currentDate + " 00:00' and '" + req.currentDate + " 23:59'");
                //sqlstr.Append(" and tb_Order_Detail.order_detail_food_status = '" + req.foodStatusID + "'");
                sqlstr.Append(" and tb_Order_Header.order_status = '1'");
                sqlstr.Append(" and tb_Order_Detail.flag = '1'");


                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    FoodView f;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        f = new FoodView();
                        f.tableName = dt.Rows[i]["table_name"].ToString().Trim();
                        //f.tableID = dt.Rows[i]["table_group_id"].ToString().Trim();
                        f.foodMenuID = dt.Rows[i]["order_detail_id"].ToString().Trim();
                        f.foodMenuName = dt.Rows[i]["order_detail_food_name"].ToString().Trim();
                        f.foodMenuSize = dt.Rows[i]["order_detail_food_size"].ToString().Trim();
                        f.foodMenuTaste = dt.Rows[i]["order_detail_food_taste"].ToString().Trim();
                        f.foodMenuStatus = dt.Rows[i]["food_status"].ToString().Trim();
                        f.foodMenuImage = DataHelper.PartHost + @"/ImagesFood/" + dt.Rows[i]["menu_picture"].ToString().Trim();
                        //DataHelper.PartHost + @"/ImagesFood/" + dt.Rows[i]["menu_picture"].ToString().Trim();
                        f.foodMenuPrice = Convert.ToDouble(dt.Rows[i]["order_detail_food_price"].ToString().Trim()) * Convert.ToDouble(dt.Rows[i]["order_detail_food_qty"].ToString().Trim());
                        f.foodMenuQty = dt.Rows[i]["order_detail_food_qty"].ToString().Trim();
                        res.Add(f);
                    }
                }

            }
            catch (Exception ex)
            {
                res = null;

                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }

        public List<MODEL.FoodView> getFoodView(string restaurantID, string DashboardDate)
        {
            List<MODEL.FoodView> Obj;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://203.150.203.74/eMenuAPI/api/DashboardFoodview/getFoodview");
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
                Obj = JsonConvert.DeserializeObject<List<MODEL.FoodView>>(result);


                //Response.Write(bsObj.Name);
            }
            return Obj;


        }
        public List<MODEL.Bill> getBillList(string restaurantID, string DashboardDate)
        {
            List<MODEL.Bill> Obj;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://203.150.203.74/eMenuAPI/api/DashboardBillList/getBillList");
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
                Obj = JsonConvert.DeserializeObject<List<MODEL.Bill>>(result);


                //Response.Write(bsObj.Name);
            }
            return Obj;


        }
        public MODEL.ResultHistoryUser getHistoryByUserID(MODEL.Criteria.reqUser req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            MODEL.ResultHistoryUser result = new MODEL.ResultHistoryUser();
            List<History> history = new List<History>();
            try
            {
                conn.Open();

                string Sql;
                SqlDataAdapter adp = new SqlDataAdapter("sp_History_Order", conn);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.Add(new SqlParameter("@userID", req.userID));
               
                //adp.Fill(ds);
                adp.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    result.ResultOk = "true";
                    result.ErrorMessage = "";
                    History h;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        h = new History();
                        h.CategoryName = dt.Rows[i]["category_lv1_name"].ToString().Trim();
                        h.CountOrder = dt.Rows[i]["CountOrder"].ToString().Trim();
                        h.SumPrice = dt.Rows[i]["SumPrice"].ToString().Trim();
                        history.Add(h);
                    }
                    
                    result.Username = "";
                    result.data = history;
                }
                else
                {
                    result.ResultOk = "false";
                    result.ErrorMessage = "";
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
        public Result getUserProcessInTable(string restaurantID,string tableID,string userID)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            Result res = new Result();
            try
            {

                StringBuilder sqlstr = new StringBuilder();
                ///sqlstr.Append("select top 1 order_no from tb_Order_Header where user_id = '" + userID + "' and table_id = '" + tableID + "'");
                //sqlstr.Append(" and restaurant_id = '" + restaurantID + "' and order_status in (1,2) order by order_id desc");
                sqlstr.Append("select top 1 table_id from tb_table where book_by = '" + userID + "' and table_id = '" + tableID + "' and book_status = '1'");
                //sqlstr.Append(" and order_status = '1'");
                //and order_status = '1'
                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    res.ResultOk = "true";
                    res.ReturnMessage = "";
                    res.ErrorMessage = "";
                }
                else
                {
                    res.ResultOk = "false";
                    res.ReturnMessage = "";
                    res.ErrorMessage = "";
                }

            }
            catch (Exception ex)
            {
                res.ResultOk = "false";
                res.ErrorMessage = ex.Message;
                res.ReturnMessage = "";
                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }
        public Result getTableName(string tableID)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            Result res = new Result();
            try
            {

                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select table_name from tb_Table where table_id = '" + tableID + "'");
                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    res.ResultOk = "true";
                    res.ReturnMessage = dt.Rows[0][0].ToString().Trim();
                    res.ErrorMessage = "";
                }
                else
                {
                    res.ResultOk = "false";
                    res.ReturnMessage = "";
                    res.ErrorMessage = "";
                }

            }
            catch (Exception ex)
            {
                res.ResultOk = "false";
                res.ErrorMessage = ex.Message;
                res.ReturnMessage = "";
                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }

    }
}
