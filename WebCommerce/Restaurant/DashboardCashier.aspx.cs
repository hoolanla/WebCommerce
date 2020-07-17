using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Flurl.Http;
using System.Globalization;
using System.Data;

namespace WebCommerce.Restaurant
{
    public partial class DashboardCashier : System.Web.UI.Page
    {

        public class PostData
        {
            public string RestaurantID { get; set; }
            public string DashboardDate { get; set; } 
              
        }
        DateTimeFormatInfo dtfInfo;
        DAL.URLEncrypt svURL = new URLEncrypt();

        private async Task<string> CallApi(PostData sd)
        {

            string result = String.Empty;

            using (var client = new HttpClient())
            {

                string url = @"http://203.150.203.74/eMenuAPI/api/DashboardCashier/getDashboarrdCashier";
                client.DefaultRequestHeaders.Accept.Clear();

                var response = await client.PostAsJsonAsync(url, sd);

                if (response.IsSuccessStatusCode)
                {
                    result = "Success";
                }
                else
                {
                    result = response.StatusCode + " : Message - " + response.ReasonPhrase;
                }
            }

            return result;
        }
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {



         


                dtfInfo = DateTimeFormatInfo.InvariantInfo;
                MODEL.Criteria.reqDashboard req = new MODEL.Criteria.reqDashboard();
                hdMemberID.Value = getMemberID();
                hdRestaurantID.Value = getRestaurantID();
                //req.RestaurantID = HttpContext.Current.Application["app_memberID"].ToString().Trim();
                //req.RestaurantID = Session["session_restaurantID"].ToString().Trim();
                req.RestaurantID = hdRestaurantID.Value;

                req.DashboardDate = DateTime.Today.ToString("MM/dd/yyyy", dtfInfo);

                initDashBoard();

                DAL.Dashboard sv = new DAL.Dashboard();
                MODEL.DashboardCashier model = new MODEL.DashboardCashier();
                model = sv.getDashboardCashier(req);
                if (model.ResultOk == "true")
                {
                //    lblFoodsOrder.InnerText = model.FoodsOrder;
                //    lblCountTable.InnerText = model.CountTable;
                 //   lblSalesOrder.InnerText = model.CountSalesOrderPerDay;
                 //   lblNoticeBill.InnerText = model.CountNoticeBill;
                    repMain.DataSource = model.list;
                    repMain.DataBind();
                }
                else
                {

                }


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



        private void initDashBoard()
        {
            MODEL.Criteria.reqDashboard req = new MODEL.Criteria.reqDashboard();
            BLL.DashBoard _BLL = new BLL.DashBoard();
            String SumPrice;
            String CountTable;
            String CountUser;
            String FoodPending;
            String CountFood;
            String CountDrink;
            hdMemberID.Value = getMemberID();
            hdRestaurantID.Value = getRestaurantID();
            req.RestaurantID = hdRestaurantID.Value;
            req.DashboardDate = DateTime.Today.ToString("MM/dd/yyyy", dtfInfo);

            SumPrice = _BLL.getSumPrice(req);
            lblSumPrice.InnerText = SumPrice;

            CountTable = _BLL.getCountTable(req);
            lblCountTable.InnerText = CountTable;

            CountUser = _BLL.getUserBuy(req);
            lblCountUser.InnerText = CountUser;

            FoodPending = _BLL.getFoodPending(req);
            lblFoodPending.InnerText = FoodPending;

            CountDrink = _BLL.getCountDrink(req);
            lblCountDrink.InnerText = CountDrink;

            CountFood = _BLL.getCountFood(req);
            lblCountFood.InnerText = CountFood;

        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string URL = @"memberID=" + hdMemberID.Value + "&restaurantID=" + hdRestaurantID.Value + "&orderNo=" + btn.ToolTip.ToString().Trim();
            URL = svURL.Encrypt(URL, "r0b1nr0y");

            //
            //Session["session_orderNo"] = btn.ToolTip.ToString().Trim();
            Response.Redirect("BillDetail.aspx?" + URL,true);
        }

        protected void repMain_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {


                Label lblQueueNo = (Label)e.Item.FindControl("lblQueue");
                Label lblBillNo = (Label)e.Item.FindControl("lblBillNo");
                Label lblBillTableName = (Label)e.Item.FindControl("lblBillTableName");
                Label lblBillMenuCount = (Label)e.Item.FindControl("lblBillMenuCount");
                Label lblBillTotalPrice = (Label)e.Item.FindControl("lblBillTotalPrice");
                Label lblBillStatusText = (Label)e.Item.FindControl("lblBillStatusText");

                if (lblBillStatusText.Text == "Open")
                {
                    lblQueueNo.ForeColor = System.Drawing.Color.Green;
                    lblBillNo.ForeColor = System.Drawing.Color.Green;
                    lblBillTableName.ForeColor = System.Drawing.Color.Green;
                    lblBillMenuCount.ForeColor = System.Drawing.Color.Green;
                    lblBillTotalPrice.ForeColor = System.Drawing.Color.Green;
                    lblBillStatusText.ForeColor = System.Drawing.Color.Green;
                }
               else if (lblBillStatusText.Text == "Bill Please")
                {
                    lblQueueNo.ForeColor = System.Drawing.Color.Red;
                    lblBillNo.ForeColor = System.Drawing.Color.Red;
                    lblBillTableName.ForeColor = System.Drawing.Color.Red;
                    lblBillMenuCount.ForeColor = System.Drawing.Color.Red;
                    lblBillTotalPrice.ForeColor = System.Drawing.Color.Red;
                    lblBillStatusText.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lblQueueNo.ForeColor = System.Drawing.Color.Gray;
                    lblBillNo.ForeColor = System.Drawing.Color.Gray;
                    lblBillTableName.ForeColor = System.Drawing.Color.Gray;
                    lblBillMenuCount.ForeColor = System.Drawing.Color.Gray;
                    lblBillTotalPrice.ForeColor = System.Drawing.Color.Gray;
                    lblBillStatusText.ForeColor = System.Drawing.Color.Gray;
                }

            }



        }
    }
}