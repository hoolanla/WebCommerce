using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public static class Common
    {
        public static List<Province> getProvince()
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            List<Province> res = new List<Province>();
            try
            {
                conn.Open();
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select id,NAMETH from province ");
                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                Province model;
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        model = new Province();
                        model.ProvinceCode = dt.Rows[i]["id"].ToString().Trim();
                        model.ProvinceName = dt.Rows[i]["NAMETH"].ToString().Trim();
                        res.Add(model);
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
        public static List<Amphur> getAmphur(string ProvineCode)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            List<Amphur> res = new List<Amphur>();
            try
            {
                conn.Open();
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select AMPHUR_CODE,AMPHUR_Name from AMPHUR where PROVINCE_CODE = '" + ProvineCode + "'");
                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                Amphur model;
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        model = new Amphur();
                        model.AmphurCode = dt.Rows[i]["AMPHUR_CODE"].ToString().Trim();
                        model.AmphurName = dt.Rows[i]["AMPHUR_Name"].ToString().Trim();
                        res.Add(model);
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

        public static List<Tumbon> getTumbon(string AmphurCode)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            List<Tumbon> res = new List<Tumbon>();
            try
            {
                conn.Open();
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select TUMBON_CODE,TUMBON_Name from TUMBON where AMPHUR_CODE = '" + AmphurCode + "'");
                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                Tumbon model;
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        model = new Tumbon();
                        model.TumbonCode = dt.Rows[i]["TUMBON_CODE"].ToString().Trim();
                        model.TumbonName = dt.Rows[i]["TUMBON_Name"].ToString().Trim();
                        res.Add(model);
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
    }
}
