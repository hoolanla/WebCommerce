using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MODEL;


namespace WebCommerce.Restaurant
{
    public partial class DashboardKitchen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DAL.Dashboard sv = new DAL.Dashboard();
                MODEL.DashboardKitchen model = new MODEL.DashboardKitchen();
                model = sv.getDashboardKitchen("", "");
                if(model.resultOk == "true")
                {
                    lblFoodPending.InnerText = model.CountFoodsPending;
                    lblCountPerDay.InnerText = model.CountFoodPerDay;
                    lblMenuUrgent.InnerText = model.MenuUrgent;
                    repMain.DataSource = model.list;
                    repMain.DataBind();
                }


            }
        }
    }
}