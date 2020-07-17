using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace WebCommerce.Restaurant
{
    public partial class MenuList : System.Web.UI.Page
    {
        BLL.eMenuBLL svMenu = new BLL.eMenuBLL();
        DAL.URLEncrypt svURL = new DAL.URLEncrypt();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MODEL.Criteria.reqeMenu req = new MODEL.Criteria.reqeMenu();
                hdRestaurantID.Value = getRestaurantID();
                hdMemberID.Value = getMemberID();
                req.restaurantID = hdRestaurantID.Value;//Session["session_restaurantID"].ToString().Trim();
                BindData(req);
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
            string URL = @"memberID=" + hdMemberID.Value + "&restaurantID=" + hdRestaurantID.Value;
            URL = svURL.Encrypt(URL, "r0b1nr0y");
            
            Response.Redirect("MenuDetail.aspx?" + URL, true);
        }



        protected void btnEdit_Click(object sender, EventArgs e)
        {
            //string URL = @"memberID=" + hdMemberID.Value + "&restaurantID=" + hdRestaurantID.Value + "&foodID=" + hdFoodID.Value;
            //URL = svURL.Encrypt(URL, "r0b1nr0y");

            //Response.Redirect("MenuDetailEdit.aspx?" + URL, true);
        }



        private void BindData(MODEL.Criteria.reqeMenu req)
        {
            listFoods.DataSource = svMenu.getFoodseMenu2(req);
            listFoods.DataBind();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (hdConfirm.Value == "Yes")
            {
                //  this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);
                String fid;
                fid = hdFoodID.Value;
                MODEL.Result res = new MODEL.Result();
                BLL.Menu _BLL = new BLL.Menu();
                if( _BLL.deleteMenu(fid).ResultOk == "true")
                {

                    string URL = @"memberID=" + hdMemberID.Value + "&restaurantID=" + hdRestaurantID.Value;
                    URL = svURL.Encrypt(URL, "r0b1nr0y");

                    Response.Redirect("MenuList.aspx?" + URL, true);
                }


            }
            else
            {
               // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
            }
        }

        protected void btnRecommend_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (hdConfirm.Value == "Yes")
            {
        
                String fid;
                fid = hdFoodID.Value;
                MODEL.Result res = new MODEL.Result();
                BLL.Menu _BLL = new BLL.Menu();
                if (_BLL.setRecommend(fid,"1").ResultOk == "true")
                {

                    string URL = @"memberID=" + hdMemberID.Value + "&restaurantID=" + hdRestaurantID.Value;
                    URL = svURL.Encrypt(URL, "r0b1nr0y");

                    Response.Redirect("MenuList.aspx?" + URL, true);
                }


            }
            else
            {

                String fid;
                fid = hdFoodID.Value;
                MODEL.Result res = new MODEL.Result();
                BLL.Menu _BLL = new BLL.Menu();
                if (_BLL.setRecommend(fid, "0").ResultOk == "true")
                {

                    string URL = @"memberID=" + hdMemberID.Value + "&restaurantID=" + hdRestaurantID.Value;
                    URL = svURL.Encrypt(URL, "r0b1nr0y");

                    Response.Redirect("MenuList.aspx?" + URL, true);
                }
            }
        }

        protected void listFoods_ItemDataBound(object sender, Telerik.Web.UI.RadListViewItemEventArgs e)
        {

            if (e.Item is RadListViewDataItem)
            {
                RadListViewDataItem item = e.Item as RadListViewDataItem;

                System.Web.UI.WebControls.Button _btnRecommend = item.FindControl("btnRecommend") as System.Web.UI.WebControls.Button;
                Boolean tmp =    Convert.ToBoolean(DataBinder.Eval(item.DataItem, "recommend").ToString());
                if(tmp == true)
                {
                    _btnRecommend.CssClass = "btn btn-warning";
                }
                else
                {
                    _btnRecommend.CssClass = "btn btn-light";
                }

            
            }


        }
    }
}