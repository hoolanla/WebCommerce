using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;

namespace BLL
{
    public class Menu
    {



        DAL.Menu _DAL = new DAL.Menu();

        public MenuDetail getMenuDetail(String foodID)
        {
            return _DAL.getMenuDetail(foodID);
        }

        public Result updateMenu(MODEL.Criteria.reqeMenu req)
        {
           return  _DAL.updateMenu(req);
        }

        public Result deleteMenu(string foodID)
        {
            return _DAL.deleteMenu(foodID);
        }

        public Result setRecommend(string foodID, string val)
        {
            return _DAL.setRecommend(foodID, val);
        }
    }
}
