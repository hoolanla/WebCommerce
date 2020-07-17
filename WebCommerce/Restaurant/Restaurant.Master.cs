using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCommerce.Restaurant
{
    public partial class Restaurant : System.Web.UI.MasterPage
    {

        DAL.URLEncrypt svURL = new DAL.URLEncrypt();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string memberID = getMemberID();
                //string restaurantID = getRestaurantID();

                string memberID = Session["memberID"].ToString();
                string restaurantID = Session["restaurantID"].ToString();


                string URL = @"memberID=" + memberID + "&restaurantID=" + restaurantID;
                URL = svURL.Encrypt(URL, "r0b1nr0y");

                this.linkTableMng.HRef = "TableMng.aspx?" + URL;
                this.linkDashboardCashier.HRef = "DashboardCashier.aspx?" + URL;
                this.linkMenu.HRef = "MenuList.aspx?" + URL;
                this.linkCashier.HRef = "Cashier.aspx?" + URL;
                this.linkKitchen.HRef = "Kitchen.aspx?" + URL;
                this.linkRestaurant.HRef = "MemberDetail.aspx?" + URL;

                  
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
        protected void DashboardCashier_Click(object sender, EventArgs e)
        {
            //Response.Redirect("DashboardCashier.aspx",true);

            
        }
    }
}