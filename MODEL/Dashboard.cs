using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class DashboardKitchen
    {
        public string resultOk { get; set; }
        public string errorMessage { get; set; }
        public string CountFoodsPending { get; set; }
        public string CountFoodPerDay { get; set; }
        public string MenuUrgent { get; set; }
        public List<Food> list { get; set; }

       

        //public class FoodPending
        //{
        //    public string tableName { get; set; }
        //    public string menuFoodsName { get; set; }
        //    public string menuStatus { get; set; }
        //}      

    }

    public class DashboardCashier
    {
        public string ResultOk { get; set; }
        public string ErrorMessage { get; set; }
        public string FoodsOrder { get; set; }
        public string CountTable { get; set; }
        public string CountSalesOrderPerDay { get; set; }
        public string CountNoticeBill { get; set; }
        public List<Bill> list { get; set; }

        public DashboardCashier()
        {
            FoodsOrder = "0";
            CountTable = "0";
            CountSalesOrderPerDay = "0";
            CountNoticeBill = "0";
        }
    }

   
}
