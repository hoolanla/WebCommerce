using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebCommerce.Restaurant
{
    public partial class BillList : System.Web.UI.Page
    {
        public class M_Bill_Header
        {
            public string BillID { get; set; }
            public string BillNo { get; set; }
            public string BillCreateDate { get; set; }
            public string BillCreateName { get; set; }
            public string BillTableName { get; set; }
            public string BillMenuCount { get; set; }
            public string BillTotalPrice { get; set; }
            public string BillStatusText { get; set; }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Menu svMenu = new DAL.Menu();
            BLL.RestaurantBLL svRestaurant = new BLL.RestaurantBLL();
            MODEL.Criteria.reqeMenu req = new MODEL.Criteria.reqeMenu();
            req.restaurantID = "2";
            req.recommend = "0";
            svMenu.getFoodseMenu(req);
            //MODEL.Criteria.reqOrder req = new MODEL.Criteria.reqOrder();
            //req.restaurantID = "1";
            //req.tableID = "1";
            //req.userID = "1";
            //req.statusID = "2";

            //string password = "Lumpsum";

            //string encryptedstring = DAL.StringCipher.Encrypt("{\"restaurantID\":\"3\",\"tableID\":\"10\"}", password);

            //string decryptedstring = DAL.StringCipher.Decrypt(encryptedstring, password);
            //List<MODEL.FoodsItems> list = new List<MODEL.FoodsItems>();

            //MODEL.FoodsItems x;
            //x = new MODEL.FoodsItems();
            //x.foodsID = "1";
            //x.price = 25;
            //x.qty = 5;
            //list.Add(x);
            //req.orderList = list;

            //svRestaurant.insertOrder(req);

            //svRestaurant.updateOrder(req);




            //List<M_Bill_Header> model = new List<M_Bill_Header>();
            //M_Bill_Header data;
            //data = new M_Bill_Header();
            //data.BillNo = "B201908200001";
            //data.BillTableName = "X1";
            //data.BillMenuCount = "12";
            //data.BillTotalPrice = "19500";
            //data.BillStatusText = "Pending";
            //model.Add(data);

            //data = new M_Bill_Header();
            //data.BillNo = "B201908200002";
            //data.BillTableName = "X1";
            //data.BillMenuCount = "10";
            //data.BillTotalPrice = "19500";
            //data.BillStatusText = "Pending";
            //model.Add(data);

            //data = new M_Bill_Header();
            //data.BillNo = "B201908200003";
            //data.BillTableName = "X1";
            //data.BillMenuCount = "9";
            //data.BillTotalPrice = "19500";
            //data.BillStatusText = "Pending";
            //model.Add(data);

            DAL.Restaurant sv = new DAL.Restaurant();
            

            dgvData.DataSource = sv.getBillList("","");
            dgvData.DataBind();


        }
    }
}