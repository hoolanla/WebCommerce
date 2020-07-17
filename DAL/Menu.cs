using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class Menu
    {

        DAL.Restaurant svRestaurant = new Restaurant();

        public List<FoodGroup> getMenuCategoryLV1()
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            List<FoodGroup> res = new List<FoodGroup>();
            try
            {
                conn.Open();
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("SELECT [category_lv1_id]");
                sqlstr.Append(",[category_lv1_name]");
                sqlstr.Append(",[flag]");
                sqlstr.Append(" FROM[Restaurant].[dbo].[tb_Category_LV1]");
                sqlstr.Append(" where flag = '1'");

                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                FoodGroup Group;
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Group = new FoodGroup();
                        Group.foodsTypeIDLevel1 = dt.Rows[i]["category_lv1_id"].ToString().Trim();
                        Group.foodsTypeNameLevel1 = dt.Rows[i]["category_lv1_name"].ToString().Trim();
                        res.Add(Group);
                    }                    
                }          

            }
            catch (Exception ex)
            {
                res = null;
                
                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;

        }

        public List<FoodGroup> getMenuCategoryLV2(string CategoryLV1)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            List<FoodGroup> res = new List<FoodGroup>();
            try
            {
                conn.Open();
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("SELECT [category_lv2_id]");
                sqlstr.Append(",[category_lv2_name]");
                sqlstr.Append(",[flag]");
                sqlstr.Append(" FROM [Restaurant].[dbo].[tb_Category_LV2]");
                sqlstr.Append(" where flag = '1'");
                sqlstr.Append(" and category_lv1_id = '" + CategoryLV1 + "'");

                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                FoodGroup Group;
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Group = new FoodGroup();
                        Group.foodsTypeIDLevel2 = dt.Rows[i]["category_lv2_id"].ToString().Trim();
                        Group.foodsTypeNameLevel2 = dt.Rows[i]["category_lv2_name"].ToString().Trim();
                        res.Add(Group);
                    }
                }

            }
            catch (Exception ex)
            {
                res = null;

                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;

        }



        public eMenuFood getFoodseMenu(MODEL.Criteria.reqeMenu req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            eMenuFood res = new eMenuFood();
            try
            {

             

                conn.Open();
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select menu.menu_id,LV1.category_lv1_id,LV1.category_lv1_name");
                sqlstr.Append(",LV2.category_lv2_id,LV2.category_lv2_name");
                sqlstr.Append(",menu.menu_name,menu.menu_description,menu.menu_price");
                sqlstr.Append(",menu.menu_picture,menu.menu_flag_recommend");
                sqlstr.Append(" from tb_Menu as menu");
                sqlstr.Append(" inner join tb_Category_LV1 as [LV1] on LV1.category_lv1_id = menu.menu_category_lv1");
                sqlstr.Append(" inner join tb_Category_LV2 as [LV2] on LV2.category_lv2_id = menu.menu_category_lv2");
                sqlstr.Append(" where menu.restaurant_id = '" + req.restaurantID + "'");

                //if (req.recommend == "1")
                //{
                //    sqlstr.Append(" and menu.menu_flag_recommend = '1'");
                //}
                //else if (req.recommend == "2")
                //{
                //    sqlstr.Append(" and LV2.category_lv2_id = 24");
                //}
                //else
                //{

                //}

                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                //eMenuFood res = new eMenuFood();
                dt = ds.Tables[0];
                if(dt.Rows.Count > 0)
                {
                    res.ResultOk = "true";
                    res.ErrorMessage = "";
                    List<eMenuFood> listeMenu = new List<eMenuFood>();
                    List<MODEL.FoodGroup> listMasterFoods = new List<MODEL.FoodGroup>();
                    List<MODEL.FoodGroup> listGroupFoods = new List<MODEL.FoodGroup>();
                    MODEL.FoodGroup MDrinks = new FoodGroup();
                    List<FoodsItems> listFoodsItem;
                    FoodsItems FoodsItem;
                    FoodGroup MFoods;
                    //DataTable dtCategoryLV1 = new DataTable();
                    //dtCategoryLV1 = getCategoryeMenu(req);
                    //DataTable dtFood = new DataTable();
                    //DataRow[] rowsFoods = dt.Select("");
                    FoodGroup Group; 
                    listGroupFoods = getCategoryeMenu(req);
                    foreach(FoodGroup item in listGroupFoods)
                    {
                        Group = new FoodGroup();
                        Group.foodsTypeIDLevel1 = item.foodsTypeIDLevel1;
                        Group.foodsTypeNameLevel1 = item.foodsTypeNameLevel1;
                        Group.foodsTypeIDLevel2 = item.foodsTypeIDLevel2;
                        Group.foodsTypeNameLevel2 = item.foodsTypeNameLevel2;
                        MODEL.Criteria.reqeMenu reqMenu = new MODEL.Criteria.reqeMenu();
                        reqMenu.restaurantID = req.restaurantID;
                        reqMenu.MenuCategoryLV1ID = Group.foodsTypeIDLevel1;
                        reqMenu.MenuCategoryLV2ID = Group.foodsTypeIDLevel2;
                        reqMenu.recommend = req.recommend;
                        listFoodsItem = new List<FoodsItems>();
                        listFoodsItem = getFoodsItemInGroup(reqMenu);
                        //FoodsItems model;
                        //foreach (FoodsItems itemFoods in listFoodsItem)
                        //{
                        //    model = new FoodsItems();
                        //    model = itemFoods;
                            
                        //}
                        Group.foodsItems= listFoodsItem;
                        listMasterFoods.Add(Group);
                    }
                    res.CountMenu = "";
                    MODEL.Restaurant modelRestaurant = new MODEL.Restaurant();
                    modelRestaurant = svRestaurant.getRestaurant(req.restaurantID);
                    if(modelRestaurant != null)
                    {
                        res.restuarantName = modelRestaurant.RestaurantName;
                        res.imageRestuarant = modelRestaurant.RestaurantImagePath;
                    }
                    else
                    {
                        res.restuarantName = "";
                        res.imageRestuarant = "";
                    }
                   
                    res.Data = listMasterFoods;
                    //foreach (DataRow row in rowsFoods)
                    //{
                    //    listFoodsItem = new List<FoodsItems>();
                    //    MFoods = new FoodGroup();
                    //    MFoods.foodsTypeIDLevel1 = row["category_lv1_id"].ToString().Trim();
                    //    MFoods.foodsTypeNameLevel1 = row["category_lv1_name"].ToString().Trim();
                    //    MFoods.foodsTypeIDLevel2 = row["category_lv2_id"].ToString().Trim();
                    //    MFoods.foodsTypeNameLevel2 = row["category_lv2_name"].ToString().Trim();
                    //    FoodsItem = new FoodsItems();
                    //    FoodsItem.foodID = row["menu_id"].ToString().Trim();
                    //    FoodsItem.foodName = row["menu_name"].ToString().Trim();
                    //    FoodsItem.Size = "";
                    //    FoodsItem.Price = row["menu_price"].ToString().Trim();
                    //    FoodsItem.Description = row["menu_description"].ToString().Trim();
                    //    FoodsItem.ImagePath = row["menu_picture"].ToString().Trim();
                    //    listFoodsItem.Add(FoodsItem);
                    //    MFoods.foodsItems = listFoodsItem;
                    //    listMFoods.Add(MFoods);
                    //    //Console.WriteLine("{0}, {1}", row[0], row[1]);
                    //}
                    //res.CountMenu = listMFoods.Count.ToString().Trim();
                    //res.Data = listMFoods;
                    //res.Data.Add(MDrinks);
                }
                



                

             
            }
            catch (Exception ex)
            {
                res.ResultOk = "false";
                res.ErrorMessage = ex.Message;
                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }


        public MenuDetail getMenuDetail(String foodID)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            MenuDetail res = new MenuDetail();
        
                conn.Open();
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select menu.menu_id,LV1.category_lv1_id,LV1.category_lv1_name");
                sqlstr.Append(",LV2.category_lv2_id,LV2.category_lv2_name");
                sqlstr.Append(",menu.restaurant_id,menu.menu_category_lv1,menu.menu_category_lv2");
                sqlstr.Append(",menu.menu_name,menu.menu_description,menu.menu_price");
                sqlstr.Append(",menu.menu_price_S,menu.menu_price_M,menu.menu_price_L");
                sqlstr.Append(",menu.menu_picture,menu.menu_flag_recommend,menu.menu_activate,menu.menu_remark");
                sqlstr.Append(" from tb_Menu as menu");
                sqlstr.Append(" inner join tb_Category_LV1 as [LV1] on LV1.category_lv1_id = menu.menu_category_lv1");
                sqlstr.Append(" inner join tb_Category_LV2 as [LV2] on LV2.category_lv2_id = menu.menu_category_lv2");
                sqlstr.Append(" where menu.menu_id = " + foodID);
                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                //eMenuFood res = new eMenuFood();
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {

                    MODEL.MenuDetail resMenu = new MODEL.MenuDetail();



                resMenu.MenuCategoryLV1ID = dt.Rows[0]["menu_category_lv1"].ToString();
                resMenu.MenuCategoryLV2ID = dt.Rows[0]["menu_category_lv2"].ToString();
                resMenu.restaurantID = dt.Rows[0]["restaurant_id"].ToString();

                resMenu.MenuName = dt.Rows[0]["menu_name"].ToString();
                resMenu.MenuDescription = dt.Rows[0]["menu_description"].ToString();

                resMenu.MenuPicture = dt.Rows[0]["menu_picture"].ToString();
                resMenu.MenuPrice = dt.Rows[0]["menu_price"].ToString();
                resMenu.MenuPriceS = dt.Rows[0]["menu_price_S"].ToString();
                resMenu.MenuPriceM = dt.Rows[0]["menu_price_M"].ToString();
                resMenu.MenuPriceL = dt.Rows[0]["menu_price_L"].ToString();
                resMenu.MenuRemark = dt.Rows[0]["menu_remark"].ToString();
                resMenu.MenuActivate = dt.Rows[0]["menu_activate"].ToString();
                resMenu.MenuRecommend = dt.Rows[0]["menu_flag_recommend"].ToString();



                return resMenu;

            }
                else
            {
                return null;
            }
            }
            

        public List<MODEL.FoodsItem2> getFoodseMenu2(MODEL.Criteria.reqeMenu req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            List<MODEL.FoodsItem2> res = new List<MODEL.FoodsItem2>();
            try
            {
                conn.Open();
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select menu.menu_id,LV1.category_lv1_id,LV1.category_lv1_name");
                sqlstr.Append(",LV2.category_lv2_id,LV2.category_lv2_name");
                sqlstr.Append(",menu.menu_name,menu.menu_description,menu.menu_price");
                sqlstr.Append(",menu_price_S,menu_price_M,menu_price_L");
                sqlstr.Append(",menu.menu_picture,menu.menu_flag_recommend");
                sqlstr.Append(",menu.menu_activate,menu.menu_remark");
                sqlstr.Append(" from tb_Menu as menu");
                sqlstr.Append(" inner join tb_Category_LV1 as [LV1] on LV1.category_lv1_id = menu.menu_category_lv1");
                sqlstr.Append(" inner join tb_Category_LV2 as [LV2] on LV2.category_lv2_id = menu.menu_category_lv2");
                sqlstr.Append(" where menu.flag = '1'");
                sqlstr.Append(" and menu.restaurant_id = '" + req.restaurantID + "'");
                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                FoodsItem2 item;
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item = new FoodsItem2();
                        item.foodsTypeIDLevel1 = dt.Rows[i]["category_lv1_id"].ToString().Trim();
                        item.foodsTypeNameLevel1 = dt.Rows[i]["category_lv1_name"].ToString().Trim();
                        item.foodsTypeIDLevel2 = dt.Rows[i]["category_lv2_id"].ToString().Trim();
                        item.foodsTypeNameLevel2 = dt.Rows[i]["category_lv2_name"].ToString().Trim();
                        item.foodID = dt.Rows[i]["menu_id"].ToString().Trim();
                        item.foodName = dt.Rows[i]["menu_name"].ToString().Trim();
                        item.description = dt.Rows[i]["menu_description"].ToString().Trim();
                        item.price = dt.Rows[i]["menu_price"].ToString().Trim();
                        item.priceS = dt.Rows[i]["menu_price_S"].ToString().Trim();
                        item.priceM = dt.Rows[i]["menu_price_M"].ToString().Trim();
                        item.priceL = dt.Rows[i]["menu_price_L"].ToString().Trim();
                        item.recommend = dt.Rows[i]["menu_flag_recommend"].ToString().Trim();
                        item.images = DataHelper.PartHost + @"/ImagesFood/" +   dt.Rows[i]["menu_picture"].ToString().Trim();
                        res.Add(item);

                    }                  
                }

            }
            catch (Exception ex)
            {
                res = null;
                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }

        public List<FoodGroup> getCategoryeMenu(MODEL.Criteria.reqeMenu req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            List<FoodGroup> res = new List<FoodGroup>();
            try
            {
                conn.Open();
                StringBuilder sqlstr = new StringBuilder();
                //sqlstr.Append("select LV1.category_lv1_id,LV1.category_lv1_name");
                //sqlstr.Append(" from tb_Category_LV1 as [LV1]");
                //sqlstr.Append(" group by LV1.category_lv1_id,LV1.category_lv1_name");                
                sqlstr.Append("select LV1.category_lv1_id,LV1.category_lv1_name");
                sqlstr.Append(",LV2.category_lv2_id,LV2.category_lv2_name");
                sqlstr.Append(" from tb_Menu as menu");
                sqlstr.Append(" inner join tb_Category_LV1 as [LV1] on LV1.category_lv1_id = menu.menu_category_lv1");
                sqlstr.Append(" inner join tb_Category_LV2 as [LV2] on LV2.category_lv2_id = menu.menu_category_lv2");
                sqlstr.Append(" where menu.restaurant_id = '" + req.restaurantID + "'");
                if(req.recommend == "2")
                {
                 sqlstr.Append(" and LV2.category_lv2_id = 24");
                }
                sqlstr.Append(" group by LV1.category_lv1_id,LV1.category_lv1_name,LV2.category_lv2_id,LV2.category_lv2_name");
                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    FoodGroup f;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        f = new FoodGroup();
                        f.foodsTypeIDLevel1 = dt.Rows[i]["category_lv1_id"].ToString().Trim();
                        f.foodsTypeNameLevel1 = dt.Rows[i]["category_lv1_name"].ToString().Trim();
                        f.foodsTypeIDLevel2 = dt.Rows[i]["category_lv2_id"].ToString().Trim();
                        f.foodsTypeNameLevel2 = dt.Rows[i]["category_lv2_name"].ToString().Trim();
                        res.Add(f);
                    }
                }

            }
            catch (Exception ex)
            {
                res = null;
                
                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }

        public List<FoodsItems> getFoodsItemInGroup(MODEL.Criteria.reqeMenu req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            List<FoodsItems> res = new List<FoodsItems>();
            try
            {
                conn.Open();
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select menu_id,menu_name,menu_description,menu_picture,menu_price,menu_flag_recommend");
                sqlstr.Append(",isnull(menu_price_S,0) as menu_price_S,isnull(menu_price_M,0) as menu_price_M,isnull(menu_price_L,0) as menu_price_L");
                sqlstr.Append(",menu_content");
                sqlstr.Append(" from tb_Menu");
                sqlstr.Append(" where flag = '1' and menu_activate =  '1'");
                sqlstr.Append(" and restaurant_id = '" + req.restaurantID + "'");
                sqlstr.Append(" and menu_category_lv1 ='" + req.MenuCategoryLV1ID + "'");
                sqlstr.Append(" and menu_category_lv2 ='" + req.MenuCategoryLV2ID + "'");
                //sqlstr.Append(" and restaurant_id = '" + req.restaurantID + "'");
                if(req.recommend == "1")
                {
                    sqlstr.Append(" and menu_flag_recommend = 1");
                }
                else if(req.recommend == "2")
                {
                    sqlstr.Append(" and menu_category_lv2 = 24");
                }
                else
                {

                }
                SqlDataAdapter adp = new SqlDataAdapter(sqlstr.ToString(), conn);
                adp.SelectCommand.CommandType = CommandType.Text;
                adp.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    FoodsItems f;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        f = new FoodsItems();
                        f.foodsID = dt.Rows[i]["menu_id"].ToString().Trim();
                        f.foodsName = dt.Rows[i]["menu_name"].ToString().Trim();
                        f.content = dt.Rows[i]["menu_content"].ToString().Trim();
                        f.description= dt.Rows[i]["menu_description"].ToString().Trim();
                        f.images = DataHelper.PartHost + @"/ImagesFood/" + dt.Rows[i]["menu_picture"].ToString().Trim();//dt.Rows[i]["menu_picture"].ToString().Trim();
                        f.price = Convert.ToDouble(dt.Rows[i]["menu_price"].ToString().Trim());
                        f.priceS = Convert.ToDouble(dt.Rows[i]["menu_price_S"].ToString().Trim());
                        f.priceM = Convert.ToDouble(dt.Rows[i]["menu_price_M"].ToString().Trim());
                        f.priceL = Convert.ToDouble(dt.Rows[i]["menu_price_L"].ToString().Trim());
                        f.size = "S";
                        res.Add(f);
                    }
                }

            }
            catch (Exception ex)
            {
                res = null;

                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }



        public Result InsertMenu(MODEL.Criteria.reqeMenu req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            Result res = new Result();
            try
            {                
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("insert into tb_Menu (restaurant_id,menu_category_lv1,menu_category_lv2,menu_name,menu_description,menu_picture,menu_price");
                sqlstr.Append(",menu_price_S,menu_price_M,menu_price_L,menu_activate,menu_remark,created_date,created_by,flag,menu_flag_recommend) values (");
                sqlstr.Append("'" + req.restaurantID + "'");
                sqlstr.Append(",'" + req.MenuCategoryLV1ID + "'");
                sqlstr.Append(",'" + req.MenuCategoryLV2ID + "'");
                sqlstr.Append(",'" + req.MenuName + "'");
                sqlstr.Append(",'" + req.MenuDescription + "'");
                sqlstr.Append(",'" + req.MenuPicture + "'");
                sqlstr.Append(",'" + req.MenuPrice + "'");
                sqlstr.Append(",'" + req.MenuPriceS + "'");
                sqlstr.Append(",'" + req.MenuPriceM + "'");
                sqlstr.Append(",'" + req.MenuPriceL + "'");
                sqlstr.Append(",'" + req.MenuActivate + "'");
                sqlstr.Append(",'" + req.MenuRemark + "'");
                sqlstr.Append(",getdate()");
                sqlstr.Append(",'" + req.MemberID + "'");
                sqlstr.Append(",'1','" + req.MenuRecommend + "');");

                conn.Open();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.InsertCommand = new SqlCommand(sqlstr.ToString(), conn);
                adp.InsertCommand.CommandType = CommandType.Text;
                adp.InsertCommand.ExecuteNonQuery();
                res.ResultOk = "true";
            }
            catch (Exception ex)
            {
                res.ResultOk = "false";
                res.ErrorMessage = ex.Message;
                //throw ex;
            }
            finally
            {                
                conn.Close();
                
            }
            return res;
        }
        public Result updateMenu(MODEL.Criteria.reqeMenu req)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            Result res = new Result();
            try
            {
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("update tb_menu set menu_category_lv1 = '" + req.MenuCategoryLV1ID + "'");
                sqlstr.Append(",menu_category_lv2 = '" + req.MenuCategoryLV2ID + "'");
                sqlstr.Append(",menu_name = '" + req.MenuName + "'");
                sqlstr.Append(",menu_description = '" + req.MenuDescription + "'");
                sqlstr.Append(",menu_picture = '" + req.MenuPicture + "'");
                sqlstr.Append(",menu_price = '" +  req.MenuPrice + "'");
                sqlstr.Append(",menu_price_S = '" + req.MenuPriceS + "'");
                sqlstr.Append(",menu_price_M = '" + req.MenuPriceM + "'");
                sqlstr.Append(",menu_price_L = '" + req.MenuPriceL + "'");
                sqlstr.Append(",menu_activate = '" + req.MenuActivate  + "'");
                sqlstr.Append(",menu_flag_recommend = '" + req.MenuRecommend + "'");
                sqlstr.Append(",menu_remark = '" + req.MenuRemark + "'");
                sqlstr.Append(",updated_date = getdate()");
                sqlstr.Append(",updated_by = '" + req.MemberID + "'");
                sqlstr.Append(" where menu_id = " + req.MenuID );

                
                conn.Open();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.InsertCommand = new SqlCommand(sqlstr.ToString(), conn);
                adp.InsertCommand.CommandType = CommandType.Text;
                adp.InsertCommand.ExecuteNonQuery();
                res.ResultOk = "true";
               
            }
            catch (Exception ex)
            {
                res.ResultOk = "false";
                res.ErrorMessage = ex.Message;
                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }


        public Result deleteMenu(string foodID)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            Result res = new Result();
            try
            {
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("delete from tb_menu where menu_id = " + foodID );
                conn.Open();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.InsertCommand = new SqlCommand(sqlstr.ToString(), conn);
                adp.InsertCommand.CommandType = CommandType.Text;
                adp.InsertCommand.ExecuteNonQuery();
                res.ResultOk = "true";
               
            }
            catch (Exception ex)
            {
                res.ResultOk = "false";
                res.ErrorMessage = ex.Message;
                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }

        public Result setRecommend(string foodID,string val)
        {
            SqlConnection conn = new SqlConnection(DataHelper.GetConnectionString());
            DataSet ds = new DataSet();
            Result res = new Result();
            try
            {
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("update tb_menu set menu_flag_recommend = " + val + " where menu_id = " + foodID);
                conn.Open();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.InsertCommand = new SqlCommand(sqlstr.ToString(), conn);
                adp.InsertCommand.CommandType = CommandType.Text;
                adp.InsertCommand.ExecuteNonQuery();
                res.ResultOk = "true";

            }
            catch (Exception ex)
            {
                res.ResultOk = "false";
                res.ErrorMessage = ex.Message;
                //throw ex;
            }
            finally
            {
                conn.Close();

            }
            return res;
        }
    }
}
