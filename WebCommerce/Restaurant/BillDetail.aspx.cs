using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace WebCommerce.Restaurant
{
    public partial class BillDetail : System.Web.UI.Page
    {
        DAL.Restaurant svRestaurant = new DAL.Restaurant();
        DateTimeFormatInfo dtfInfo;
        DAL.URLEncrypt svURL = new DAL.URLEncrypt();
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
        private string getOrderNo()
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
                string memberID = "", restaurantID = "",orderNo = "";
                arrIndMsg = arrMsgs[0].Split('='); //Get the Name
                memberID = arrIndMsg[1].ToString().Trim();
                arrIndMsg = arrMsgs[1].Split('='); //Get the Age
                restaurantID = arrIndMsg[1].ToString().Trim();
                arrIndMsg = arrMsgs[2].Split('='); //Get the Age
                orderNo = arrIndMsg[1].ToString().Trim();
                //arrIndMsg = arrMsgs[2].Split('='); //Get the Phone
                //strPhone = arrIndMsg[1].ToString().Trim();

                //lblName.Text = strName;
                //lblAge.Text = strAge;
                //lblPhone.Text = strPhone;
                return orderNo;
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
                hdOrderNo.Value = getOrderNo();

                dtfInfo = DateTimeFormatInfo.InvariantInfo;
                MODEL.ResultOrderForBill res = new MODEL.ResultOrderForBill();
                
                MODEL.Criteria.reqOrder req = new MODEL.Criteria.reqOrder();
                //req.restaurantID = Session["session_retaurantID"].ToString().Trim();
                //req.tableID = Session["session_tableID"].ToString().Trim();
                req.userID = hdMemberID.Value;//Session["session_memberID"].ToString().Trim();
                req.orderNo = hdOrderNo.Value;//Session["session_orderNo"].ToString().Trim();
                req.restaurantID = hdRestaurantID.Value;//Session["session_restaurantID"].ToString().Trim();
                res = svRestaurant.getOrderListForCheckBill(req);

                txtRestaurantName.InnerText = "ชื่อร้านอาหาร : " + res.restaurantName;
                txtUser.InnerText = ".....";
                txtTableName.InnerText = res.tableName;
                txtTotalPrice.InnerText = res.totalPrice.ToString();
                txtBillNo.InnerText = req.orderNo;
                txtCurrentDate.InnerText = DateTime.Today.ToString("dd/MM/yyyy", dtfInfo);

                repMain.DataSource = res.orderList;
                repMain.DataBind();

            }
        }

        private void MSG(string txt)
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + txt + "');", true);
            //Page.ClientScript.RegisterStartupScript(GetType(),
            //    "ShowMessage", string.Format("<script type='text/javascript'>alert('{0}')</script>",
            //    txt));
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            MODEL.Criteria.reqOrder req = new MODEL.Criteria.reqOrder();
            req.orderNo = hdOrderNo.Value;//Session["session_orderNo"].ToString().Trim();
            req.userID = hdMemberID.Value;//Session["session_memberID"].ToString().Trim();
            req.statusID = "3";

            //Check Complete All
            if(svRestaurant.checkCompleteKitchenByOrderNo(req.orderNo).ResultOk == "false")
            {
                MSG("อาหารยังเสริฟไม่ครบไม่สามารถเช๊คบิลได้ !!!");
                return;
            }

            if (svRestaurant.updateOrderByOrderNo(req).ResultOk == "true")
            {
                MSG("Success");
            }
            else
            {
                MSG("Fail");
            }
        }
    }
}