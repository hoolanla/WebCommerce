using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebCommerce.Restaurant
{
    public partial class TableMng : System.Web.UI.Page
    {
        BLL.RestaurantBLL svRestaurant = new BLL.RestaurantBLL();
        DAL.URLEncrypt svURL = new DAL.URLEncrypt();
        //string restaurantID = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MODEL.Criteria.reqTable req = new MODEL.Criteria.reqTable();
                hdMemberID.Value = getMemberID();
                hdRestaurantID.Value = getRestaurantID();

                //req.restaurantID = Session["session_restaurantID"].ToString().Trim();
                req.restaurantID = getRestaurantID();
                
                
                dgvData.DataSource = svRestaurant.getTable(req);
                dgvData.DataBind();
            }
        }
        private string getRestaurantID()
        {
            string strReq = "";
            strReq = Request.RawUrl;
            strReq = strReq.Substring(strReq.IndexOf('?') + 1);

            if (!strReq.Equals(""))
            {
                strReq = svURL.Decrypt(strReq, "r0b1nr0y");

                //Parse the value... this is done is very raw format..
                //you can add loops or so to get the values out of the query string...
                string[] arrMsgs = strReq.Split('&');
                string[] arrIndMsg;
                string memberID = "", restaurantID = "";
                arrIndMsg = arrMsgs[0].Split('='); //Get the Name
                memberID = arrIndMsg[1].ToString().Trim();
                arrIndMsg = arrMsgs[1].Split('='); //Get the Age
                restaurantID = arrIndMsg[1].ToString().Trim();
                //arrIndMsg = arrMsgs[2].Split('='); //Get the Phone
                //strPhone = arrIndMsg[1].ToString().Trim();

                //lblName.Text = strName;
                //lblAge.Text = strAge;
                //lblPhone.Text = strPhone;
                return restaurantID;
            }
            else
            {
                return "";
                //Response.Redirect("Page1.aspx");
            }
        }
        private string getMemberID()
        {
            string strReq = "";
            strReq = Request.RawUrl;
            strReq = strReq.Substring(strReq.IndexOf('?') + 1);

            if (!strReq.Equals(""))
            {
                strReq = svURL.Decrypt(strReq, "r0b1nr0y");

                //Parse the value... this is done is very raw format..
                //you can add loops or so to get the values out of the query string...
                string[] arrMsgs = strReq.Split('&');
                string[] arrIndMsg;
                string memberID = "", restaurantID = "";
                arrIndMsg = arrMsgs[0].Split('='); //Get the Name
                memberID = arrIndMsg[1].ToString().Trim();
                arrIndMsg = arrMsgs[1].Split('='); //Get the Age
                restaurantID = arrIndMsg[1].ToString().Trim();
                //arrIndMsg = arrMsgs[2].Split('='); //Get the Phone
                //strPhone = arrIndMsg[1].ToString().Trim();

                //lblName.Text = strName;
                //lblAge.Text = strAge;
                //lblPhone.Text = strPhone;
                return memberID;
            }
            else
            {
                return "";
                //Response.Redirect("Page1.aspx");
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            //string memberID = getMemberID();
            //string restaurantID = getRestaurantID();           
            string URL = @"memberID=" + hdMemberID.Value + "&restaurantID=" + hdRestaurantID.Value;
            URL = svURL.Encrypt(URL, "r0b1nr0y");

            Response.Redirect("TableDetail.aspx?" + URL, true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt;
            dt = svRestaurant.getTableDT(hdRestaurantID.Value);
            Session["DATATABLE"] = dt;


            //DAL.URLEncrypt svURL = new DAL.URLEncrypt();
            //string SuffixUrl = "restaurantID=" + hdRestaurantID.Value;
            //SuffixUrl = svURL.Encrypt(SuffixUrl, "r0b1nr0y");

            string url = "../Reports/QRCode.aspx";
            string s = "window.open('" + url + "');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        }
    }
}