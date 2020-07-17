using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using System.Data;

namespace BLL
{
    public class RestaurantBLL
    {
        DAL.Restaurant RestaurantDAL = new DAL.Restaurant();
        DAL.Member MemberDAL = new DAL.Member();
        DAL.Dashboard DashboardDAL = new DAL.Dashboard();

        public Result insertOrder(MODEL.Criteria.reqOrder req)
        {
            //Result result = new Result();
            //Result OrderStatus = RestaurantDAL.getStatusOrder(req.restaurantID, req.tableID);
            //if (OrderStatus.ResultOk == "false")
            //{
            //    result = RestaurantDAL.insertOrder(req);
            //}
            //else
            //{
            //    switch (OrderStatus.ReturnMessage)
            //    {
            //        case "1":
            //            result.ResultOk = "false";
            //            result.ErroMessage = "Table is open";
            //            result.ReturnMessage = "";
            //            break;
            //        case "2":
            //            result.ResultOk = "false";
            //            result.ErroMessage = "Table is bill please";
            //            result.ReturnMessage = "";
            //            break;
            //        default:
            //            result = RestaurantDAL.insertOrder(req);
            //            break;
            //    }
            //}

            //return result;

            return RestaurantDAL.insertOrder(req);
        }


        public ResultProfile updateProfile(MODEL.ResultProfile req)
        {
            return RestaurantDAL.updateProfile(req);
        }

      

        public ResultOrder getOrderList(MODEL.Criteria.reqOrder req)
        {
            return RestaurantDAL.getOrderList(req);
        }

        public DataTable getTableDT(String req)
        {
            return RestaurantDAL.getTableDT(req);
        }

        public ResultLogin insertMember(MODEL.Criteria.reqLogin req)
        {
            return MemberDAL.insertMember(req);
        }
        public MODEL.ResultLogin getLogin(MODEL.Criteria.reqLogin req)
        {
            return MemberDAL.getLogin(req);
        }
        public MODEL.ResultLogin getLoginGuest(MODEL.Criteria.reqLogin req)
        {
            return MemberDAL.getLoginGuest(req);
        }
        public Result insertMemberGuest(MODEL.Criteria.reqLogin req)
        {
            return MemberDAL.insertMemberGuest(req);
        }
        public Result updateRestaurant(MODEL.Criteria.reqRestaurant req)
        {
            return RestaurantDAL.updateRestaurant(req);
        }
        public Result getStatusOrder(string restaurantID, string tableID)
        {
            return getStatusOrder(restaurantID, tableID);

        }
        public Result updateOrder(MODEL.Criteria.reqOrder req)
        {
            return RestaurantDAL.updateOrder(req);
        }
        public MODEL.Restaurant getRestaurant(string restaurantID)
        {
            return RestaurantDAL.getRestaurant(restaurantID);
        }
        public Result insertTable(MODEL.Criteria.reqTable req)
        {
            return RestaurantDAL.insertTable(req);
        }
        public List<Table> getTable(MODEL.Criteria.reqTable req)
        {
            return RestaurantDAL.getTable(req);
        }

        public MODEL.DashboardCashier getDashboardCashier(MODEL.Criteria.reqDashboard req)
        {
            return DashboardDAL.getDashboardCashier(req);
        }
        public ResultRestaurantContent getFirstPage(MODEL.Criteria.reqRestaurant req)
        {
            return RestaurantDAL.getFirstPage(req);
        }
        public Result cancelOrder(MODEL.Criteria.reqOrder req)
        {
            return RestaurantDAL.cancelOrder(req);
        }
        public MODEL.ResultHistoryUser getHistoryByUserID(MODEL.Criteria.reqUser req)
        {
            return RestaurantDAL.getHistoryByUserID(req);
        }
        public Result getTypeTable(string restaurantID, string tableID)
        {
            return RestaurantDAL.getTypeTable(restaurantID, tableID);
        }
        public Result checkCompleteKitchenByOrderNo(string OrderNo)
        {
            return RestaurantDAL.checkCompleteKitchenByOrderNo(OrderNo);
        }
        public Result getTableName(string tableID)
        {
            return RestaurantDAL.getTableName(tableID);
        }

    }
}
