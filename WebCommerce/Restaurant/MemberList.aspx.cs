using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCommerce.Restaurant
{
    public partial class MemberList : System.Web.UI.Page
    {
        BLL.eMenuBLL svMenu = new BLL.eMenuBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

     
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberDetail.aspx",true);
        }
    }
}