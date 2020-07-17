using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MODEL;

namespace WEBAPI.Controllers
{
    public class DashboardController : ApiController
    {
       

        [Route("api/Dashboard/getDashboardKitchen")]
        [HttpPost]
        public DashboardKitchen getDashboardKitchen([FromBody]MODEL.Criteria.reqDashboard req)
        {
            DashboardKitchen result = new DashboardKitchen();
            result.resultOk = "false";
            try
            {
                if (req != null)
                {
                    result.resultOk = "true";
                    result.errorMessage = "";
                    result.CountFoodsPending = "15";
                    result.CountFoodPerDay = "2";
                    result.MenuUrgent = "10";
                    List<Food> listFood = new List<Food>();
                    Food mFood;
                    mFood = new Food();
                    mFood.menuFoodsName = "Meet Steak";
                    mFood.tableName = "Table 1";
                    mFood.menuStatus = "Wait";
                    listFood.Add(mFood);
                    mFood = new Food();
                    mFood.menuFoodsName = "Pork Steak";
                    mFood.tableName = "Table 1";
                    mFood.menuStatus = "Wait";
                    listFood.Add(mFood);
                    //List<Bill> listBill = new List<Bill>();
                    //Bill mBill;
                    //mBill = new Bill();
                    //mBill.billID = "20191020002";
                    //mBill.billNo = "03";
                    //mBill.billCreateDate = "20-10-2019 08:30:00";
                    //mBill.billCreateName = "sombut";
                    //mBill.billTableName = "10";
                    //mBill.billMenuCount = "6";
                    //mBill.billTotalPrice = "750";
                    //mBill.billStatusText = "Complete";
                    //listBill.Add(mBill);
                    result.list = listFood;

                   
                //"billID": "20191020002",
                //"billNo": "03",
                //"billCreateDate": "20-10-2019 08:30:00",
                //"billCreateName": "sombut",
                //"billTableName": "10",
                //"billMenuCount": "6",
                //"billTotalPrice": "750",
                //"billStatusText": "Complete"
            
            
        

                  

                    
                }
            }
            catch (Exception e)
            {
                result.errorMessage = e.Message;
                result.resultOk = "false";
            }
            finally
            {
               
            }
            return result;
        }

        [Route("api/Dashboard/getDashboardCashier")]
        [HttpPost]
        public MODEL.DashboardCashier getDashboardCashier([FromBody]MODEL.Criteria.reqDashboard req)
        {
            MODEL.DashboardCashier result = new MODEL.DashboardCashier();
            result.ResultOk = "false";
            try
            {
                if (req != null)
                {
                    result.ResultOk = "true";
                    result.ErrorMessage = "";
                    result.FoodsOrder = "15";
                    result.CountTable = "2";
                    result.CountSalesOrderPerDay = "45,000";
                    List<Bill> listBill = new List<Bill>();
                    Bill mBill;
                    mBill = new Bill();
                    mBill.billID = "20191020002";
                    mBill.billNo = "20191020002";
                    mBill.billCreateDate = "20-10-2019 08:30:00";
                    mBill.billCreateName = "sombut";
                    mBill.billTableName = "10";
                    mBill.billMenuCount = "6";
                    mBill.billTotalPrice = "4000";
                    mBill.billStatusText = "Complete";
                    listBill.Add(mBill);                  
                    mBill = new Bill();
                    mBill.billID = "20191020003";
                    mBill.billNo = "20191020003";
                    mBill.billCreateDate = "20-10-2019 10:30:00";
                    mBill.billCreateName = "nathan";
                    mBill.billTableName = "15";
                    mBill.billMenuCount = "4";
                    mBill.billTotalPrice = "7500";
                    mBill.billStatusText = "Complete";
                    listBill.Add(mBill);
                    result.list = listBill;


                  



                }
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;
                result.ResultOk = "false";
            }
            finally
            {

            }
            return result;
        }
    }
}
