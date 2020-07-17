using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCommerce
{
    public partial class MemberLogin : System.Web.UI.Page
    {
        BLL.RestaurantBLL svRestaurant = new BLL.RestaurantBLL();
        DAL.URLEncrypt svEncrypt = new DAL.URLEncrypt();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        private void MSG(string txt)
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + txt + "');", true);
            //Page.ClientScript.RegisterStartupScript(GetType(),
            //    "ShowMessage", string.Format("<script type='text/javascript'>alert('{0}')</script>",
            //    txt));
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtEmail.Value.Trim() == "")
            {
                MSG("กรุณาป้อน Email !!!");
                return;
            }
            if (txtPassword.Value.Trim() == "")
            {
                MSG("กรุณาป้อน Password !!!");
                return;
            }
            MODEL.Criteria.reqLogin req = new MODEL.Criteria.reqLogin();
            req.email = txtEmail.Value.Trim();
            req.password = txtPassword.Value.Trim();

            MODEL.ResultLogin res = new MODEL.ResultLogin();
            res = svRestaurant.getLogin(req);
            if(res.ResultOk == "true")
            {
                //HttpContext.Current.Application["app_memberID"] = res.memberID;
                //HttpContext.Current.Application["app_restaurantID"] = res.restaurantID;
                Session["memberID"] = res.memberID;
                Session["restaurantID"] = res.restaurantID;
                string URL = @"memberID=" + res.memberID + "&restaurantID=" + res.restaurantID;
                URL = svEncrypt.Encrypt(URL, "r0b1nr0y");
                Response.Redirect("~/Restaurant/DashboardCashier.aspx?" + URL);
            }
            else
            {
                MSG(res.ErroMessage);
            }
            
        }
    }
}