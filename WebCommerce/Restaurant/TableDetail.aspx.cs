using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCommerce.Restaurant
{
    public partial class TableDetail : System.Web.UI.Page
    {
        DAL.URLEncrypt svURL = new DAL.URLEncrypt();
        BLL.RestaurantBLL svRestaurant = new BLL.RestaurantBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdRestaurantID.Value = getRestaurantID();
                hdMemberID.Value = getMemberID();
                string restaurantID = getRestaurantID();
                MODEL.Restaurant model = svRestaurant.getRestaurant(restaurantID);
                if(model!= null)
                {
                    txtRestaurantName.Value = model.RestaurantName;
                }
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

        private void MSG(string txt)
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + txt + "');", true);          
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if(txtTableName.Value.Trim() == "")
            {
                MSG("กรุณาป้อนชื่อโต๊ะ !!!");
                return;
            }

            MODEL.Result res = new MODEL.Result();
            MODEL.Criteria.reqTable req = new MODEL.Criteria.reqTable();
            req.restaurantID = hdRestaurantID.Value;
            req.tableDetail = txtTableName.Value.Trim();
            req.tableGroupID = ddlCategoryTable.SelectedValue.ToString().Trim();
            req.tableTypeID = ddlTypeTable.SelectedValue.ToString().Trim();
            req.tableRemark = txtRemark.Value.Trim();
            req.userID = hdMemberID.Value;
            //req.QRCode = 

            res = svRestaurant.insertTable(req);
            if(res.ResultOk == "true")
            {
                MSG("Success");
            }

        }
    }
}