using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MODEL;


namespace BLL
{
    public class eMenuBLL
    {
        DAL.Menu _DAL = new DAL.Menu();

        public Result InsertMenu(MODEL.Criteria.reqeMenu req)
        {
            return _DAL.InsertMenu(req);
        }
        public eMenuFood getFoodseMenu(MODEL.Criteria.reqeMenu req)
        {
            return _DAL.getFoodseMenu(req);
        }
        public List<FoodGroup> getMenuCategoryLV1()
        {
            return _DAL.getMenuCategoryLV1();
        }
        public List<FoodGroup> getMenuCategoryLV2(string CategoryLV1)
        {
            return _DAL.getMenuCategoryLV2(CategoryLV1);
        }
        public List<MODEL.FoodsItem2> getFoodseMenu2(MODEL.Criteria.reqeMenu req)
        {
            return _DAL.getFoodseMenu2(req);
        }
      

    }
}
