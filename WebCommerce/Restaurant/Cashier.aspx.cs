using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace WebCommerce.Restaurant
{
    public partial class Cashier : System.Web.UI.Page
    {
        DateTimeFormatInfo dtfInfo;
        DAL.Restaurant sv = new DAL.Restaurant();
        DAL.URLEncrypt svURL = new DAL.URLEncrypt();
        public class M_Table
        {
            public string tableName { get; set; }
            public string menu { get; set; }
            public string menuStatus { get; set; }
            public int price { get; set; }
            //private string menuList { get; set; }
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdRestaurantID.Value = getRestaurantID();
                hdMemberID.Value = getMemberID();
                dtfInfo = DateTimeFormatInfo.InvariantInfo;
                MODEL.Criteria.reqKitchen req = new MODEL.Criteria.reqKitchen();
                req.foodStatusID = "1";
                req.restaurantID = hdRestaurantID.Value;//Session["session_restaurantID"].ToString().Trim();
                req.currentDate = DateTime.Today.ToString("MM/dd/yyyy", dtfInfo);

                List<MODEL.FoodView> model = new List<MODEL.FoodView>();
                DAL.Restaurant sv = new DAL.Restaurant();
                model = sv.getCashierView(req);
                this.RadListView1.DataSource = model;
                RadListView1.DataBind();

            }
        }
    }
}