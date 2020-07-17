using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCommerce
{
    public partial class Register : System.Web.UI.Page
    {
        BLL.RestaurantBLL svRestaurant = new BLL.RestaurantBLL();

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

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if(txtMemberName.Value.Trim() == "")
            {
                MSG("กรุณาป้อน ชื่อ !!!");
                return;
            }
            if (txtEmail.Value.Trim() == "")
            {
                MSG("กรุณาป้อน Email !!!");
                return;
            }
            if (txtPassword.Value.Trim() == "")
            {
                MSG("กรุณาป้อน Password !!!");
                return;
            }
            if (txtRePassword.Value.Trim() == "")
            {
                MSG("กรุณาป้อน Re-Password !!!");
                return;
            }
            if(txtPassword.Value.Trim() != txtRePassword.Value.Trim())
            {
                MSG("Password not match !!!");
                return;
            }
            MODEL.Criteria.reqLogin model = new MODEL.Criteria.reqLogin();
            model.username = txtMemberName.Value.Trim();
            model.email = txtEmail.Value.Trim();
            model.password = txtPassword.Value.Trim();

            MODEL.ResultLogin res = new MODEL.ResultLogin();

            res = svRestaurant.insertMember(model);
            if(res.ResultOk == "true")
            {
                //Session["session_memberID"] = res.memberID;
                //Session["session_restaurantID"] = res.restaurantID;
                //MSG("Success");
                //Response.Redirect("~/Restaurant/MemberDetail.aspx?memberID=" + res.ReturnMessage);
                Response.Redirect("~/memberLogin.aspx",true);
            }
            else
            {
                MSG(res.ErroMessage);
            }

            
        }
    }
}