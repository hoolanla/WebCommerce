using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MODEL;

namespace DAL
{
    public class Member
    {

        public string getRestaurantID(string MemberID)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            string res = "";
            try
            {
                conn.Open();
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select restaurant_id from tb_Restaurant where member_id = '" + MemberID + "' ");
                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //string[] Run = ds.Tables[0].Rows[0][0].ToString().Trim().Split(Convert.ToChar("-"));
                    res = ds.Tables[0].Rows[0][0].ToString().Trim();
                }
                else
                {
                    res = "";
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

        public string getLastMemberID()
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            string res = "";
            try
            {
                conn.Open();                
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select top 1 member_ID from tb_member order by member_id desc ");
                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //string[] Run = ds.Tables[0].Rows[0][0].ToString().Trim().Split(Convert.ToChar("-"));
                    res = ds.Tables[0].Rows[0][0].ToString().Trim();
                }
                else
                {
                    res = "0";
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
        public ResultLogin insertMember(MODEL.Criteria.reqLogin req)
        {
            DAL.Restaurant svRestaurant = new Restaurant();
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            ResultLogin res = new ResultLogin();
            try
            {
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("INSERT INTO [tb_Member] (member_email,member_password,member_name,member_activate,member_permission,created_date,flag) values (");
                sqlstr.Append("'" + req.email + "','" + req.password + "','" + req.username + "','1','1',getdate(),'1');");

                //sqlstr.Append("INSERT INTO [tb_Restaurant] (restaurant_name,menber_id,created_date,flag) values (");
                //sqlstr.Append("'" + req.MemberEmail + "','" + req.MemberPassword + "','" + req.MemberName + "','1','1',getdate(),'1');");


                conn.Open();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.InsertCommand = new SqlCommand(sqlstr.ToString(), conn);
                adp.InsertCommand.CommandType = CommandType.Text;
                adp.InsertCommand.ExecuteNonQuery();
                string MemberID = getLastMemberID();
                svRestaurant.InitialRestaurant(MemberID);
                res.ResultOk = "true";
                res.ReturnMessage = MemberID;
                res.ErroMessage = "";
                res.memberID = Convert.ToInt32(MemberID);
                res.restaurantID = getRestaurantID(MemberID);
            }
            catch (Exception ex)
            {
                res.ResultOk = "false";
                res.ReturnMessage = "";
                res.ErroMessage = ex.Message;
                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }


        public Result chkDupMemberGuest(string Email)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            Result res = new Result();
            try
            {
                conn.Open();
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select member_email from tb_Member where member_email = '" + Email + "' and member_permission = '2' and flag = '1'");
                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    res.ResultOk = "true";
                }
                else
                {
                    res.ResultOk = "false";
                }

            }
            catch (Exception ex)
            {
                res.ResultOk = "false";

            }
            finally
            {
                conn.Close();

            }
            return res;

        }


        public Result insertMemberGuest(MODEL.Criteria.reqLogin req)
        {
            DAL.Restaurant svRestaurant = new Restaurant();
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            Result res = new Result();
            try
            {
                Result resChkDupMenber = chkDupMemberGuest(req.email);
                if (resChkDupMenber.ResultOk == "true")
                {
                    res.ResultOk = "false";
                    res.ReturnMessage = "";
                    res.ErrorMessage = "Already Email Address !!!";
                    return res;
                }

                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("INSERT INTO [tb_Member] (member_email,member_password,member_name,member_activate,member_permission,created_date,flag) values (");
                sqlstr.Append("'" + req.email + "','" + req.password + "','" + req.username + "','1','2',getdate(),'1');");

                //sqlstr.Append("INSERT INTO [tb_Restaurant] (restaurant_name,menber_id,created_date,flag) values (");
                //sqlstr.Append("'" + req.MemberEmail + "','" + req.MemberPassword + "','" + req.MemberName + "','1','1',getdate(),'1');");


                conn.Open();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.InsertCommand = new SqlCommand(sqlstr.ToString(), conn);
                adp.InsertCommand.CommandType = CommandType.Text;
                adp.InsertCommand.ExecuteNonQuery();
                string MemberID = getLastMemberID();
                //svRestaurant.InitialRestaurant(MemberID);
                res.ResultOk = "true";
                res.ReturnMessage = MemberID;
                res.ErrorMessage = "";
            }
            catch (Exception ex)
            {
                res.ResultOk = "false";
                res.ReturnMessage = "";
                res.ErrorMessage = ex.Message;
                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }

        public MODEL.ResultLogin getLogin(MODEL.Criteria.reqLogin req)
        {
            DAL.Restaurant svRestaurant = new Restaurant();
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            ResultLogin res = new ResultLogin();
            try
            {
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select tb_Member.member_id,member_email,member_name,restaurant_id from tb_Member ");
                sqlstr.Append(" inner join tb_restaurant on tb_Member.member_id = tb_restaurant.member_id");
                sqlstr.Append(" where tb_Member.flag = '1'");
                sqlstr.Append(" and member_email = '" + req.email + "'");                
                sqlstr.Append(" and member_activate = '1'");
                sqlstr.Append(" and member_password = '" + req.password + "'");
                
                
                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                if(dt.Rows.Count > 0)
                {
                    res.ResultOk = "true";
                    res.ReturnMessage = "";
                    res.ErroMessage = "";
                    res.memberID = Convert.ToInt32(dt.Rows[0]["member_id"].ToString().Trim());
                    res.userName = dt.Rows[0]["member_name"].ToString().Trim();
                    res.email = dt.Rows[0]["member_email"].ToString().Trim();
                    res.restaurantID = dt.Rows[0]["restaurant_id"].ToString().Trim();
                }
                else
                {
                    res.ResultOk = "false";
                    res.ReturnMessage = req.email;
                    res.ErroMessage = "Not found member !!!";
                    res.memberID = 0;
                    res.userName = "";
                    res.email = "";
                    res.restaurantID = "";
                }
                
            }
            catch (Exception ex)
            {
                res.ResultOk = "false";
                res.ReturnMessage = "";
                res.ErroMessage = ex.Message;

                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }
        public MODEL.ResultLogin getLoginGuest(MODEL.Criteria.reqLogin req)
        {
            DAL.Restaurant svRestaurant = new Restaurant();
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            ResultLogin res = new ResultLogin();
            try
            {
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select tb_Member.member_id,member_email,member_name,lastname,tel from tb_Member ");                
                sqlstr.Append(" where tb_Member.flag = '1' and member_permission = '2'");
                sqlstr.Append(" and member_email = '" + req.email + "'");
                sqlstr.Append(" and member_activate = '1'");
                if (req.type == "N")
                {
                    sqlstr.Append(" and member_password = '" + req.password + "'");
                }


                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    res.ResultOk = "true";
                    res.ReturnMessage = "";
                    res.ErroMessage = "";
                    res.memberID = Convert.ToInt32(dt.Rows[0]["member_id"].ToString().Trim());
                    res.userName = dt.Rows[0]["member_name"].ToString().Trim();
                    res.email = dt.Rows[0]["member_email"].ToString().Trim();
                    res.tel = dt.Rows[0]["tel"].ToString().Trim();
                    res.lastname = dt.Rows[0]["lastname"].ToString().Trim();
                    res.restaurantID = "";
                }
                else
                {
                    res.ResultOk = "false";
                    res.ReturnMessage = req.email;
                    res.ErroMessage = "Not found member !!!";
                    res.memberID = 0;
                    res.userName = "";
                    res.email = "";
                    res.tel = "";
                    res.lastname = "";
                    res.restaurantID = "";
                }

            }
            catch (Exception ex)
            {
                res.ResultOk = "false";
                res.ReturnMessage = "";
                res.ErroMessage = ex.Message;

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
