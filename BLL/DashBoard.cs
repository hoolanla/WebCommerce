using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DashBoard
    {
        DAL.Dashboard DashboardDAL = new DAL.Dashboard();

        public string getCountTable(MODEL.Criteria.reqDashboard req)
        {
            return DashboardDAL.getCountTable(req);
        }

        public string getSumPrice(MODEL.Criteria.reqDashboard req)
        {
            return DashboardDAL.getSumPrice(req);
        }

        public string getUserBuy(MODEL.Criteria.reqDashboard req)
        {
            return DashboardDAL.getUserBuy(req);
        }

        public string getFoodPending(MODEL.Criteria.reqDashboard req)
        {
            return DashboardDAL.getFoodPending(req);
        }

        public string getCountFood(MODEL.Criteria.reqDashboard req)
        {
            return DashboardDAL.getCountFood(req);
        }

        public string getCountDrink(MODEL.Criteria.reqDashboard req)
        {
            return DashboardDAL.getCountDrink(req);
        }
    }

}
