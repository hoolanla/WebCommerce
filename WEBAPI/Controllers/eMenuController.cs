using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MODEL;
using BLL;
using Newtonsoft.Json;

namespace WEBAPI.Controllers
{
    public class eMenuController : ApiController
    {
        [Route("api/eMenu/insertMenu")]
        [HttpPost]
        public Result insertMenu([FromBody]MODEL.Criteria.reqeMenu req)
        {
            Result result = new Result();
            result.ResultOk = "false";
            eMenuBLL sv = new eMenuBLL();
            try
            {
                //Veriy Data

                if (req != null)
                {
                    return sv.InsertMenu(req);

                }
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;
                result.ResultOk = "false";
            }            
            return result;
        }

        [Route("api/eMenu/geteMenu")]
        [HttpPost]
        public eMenuFood geteMenu([FromBody]MODEL.Criteria.reqeMenu req)
        {
            eMenuFood result = new eMenuFood();
            result.ResultOk = "false";
            eMenuBLL sv = new eMenuBLL();
            try
            {
                //Veriy Data

                if (req != null)
                {
                    return sv.getFoodseMenu(req);

                }
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;
                result.ResultOk = "false";
            }
            return result;
        }


        [Route("api/eMenu/insertOrder")]
        [HttpPost]
        public Result insertOrder([FromBody]MODEL.Criteria.reqOrder req)
        {
            Result result = new Result();
            result.ResultOk = "false";
            RestaurantBLL sv = new RestaurantBLL();
            try
            {
                result = sv.insertOrder(req);

                //Result OrderStatus = sv.getStatusOrder(req.restaurantID, req.tableID);
                //if (OrderStatus.ResultOk == "false")
                //{
                //    result = sv.insertOrder(req);
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
                //            result = sv.insertOrder(req);
                //            break;
                //    }
                //}
                

                //Veriy Data
                //result.ResultOk = "Success";
                //for (int i = 0; i < req.listFood.Count; i++)
                //{
                //    result.ReturnMessage += req.listFood[i].foodID + ",";
                //}
                //if (req != null)
                //{

                    //return sv.InsertMenu(req);

                //}
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;
                result.ResultOk = "false";
                
            }
            return result;
        }

        [Route("api/eMenu/noticeBillOrder")]
        [HttpPost]
        public Result noticeBillOrder([FromBody]MODEL.Criteria.reqOrder req)
        {
            Result result = new Result();
            result.ResultOk = "false";
            RestaurantBLL sv = new RestaurantBLL();
            try
            {
                req.statusID = "2";
                result = sv.updateOrder(req);               
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;
                result.ResultOk = "false";
            }
            return result;
        }

        [Route("api/eMenu/getOrder")]
        [HttpPost]
        public ResultOrder getOrder([FromBody]MODEL.Criteria.reqOrder req)
        {
            ResultOrder result = new ResultOrder();
            result.ResultOk = "false";
            RestaurantBLL sv = new RestaurantBLL();
            try
            {
               
               result = sv.getOrderList(req);

                //Veriy Data
                //result.ResultOk = "Success";
                //for (int i = 0; i < req.listFood.Count; i++)
                //{
                //    result.ReturnMessage += req.listFood[i].foodID + ",";
                //}
                //if (req != null)
                //{

                //return sv.InsertMenu(req);

                //}
            }
            catch (Exception e)
            {
                result.ErroMessage = e.Message;
                result.ResultOk = "false";
            }
            return result;
        }




        [Route("api/eMenu/updateProfile")]
        [HttpPost]
        public ResultProfile updateProfile([FromBody]MODEL.ResultProfile  req)
        {
            ResultProfile result = new ResultProfile();
            result.ResultOk = "false";
            RestaurantBLL sv = new RestaurantBLL();
            try
            {

                result = sv.updateProfile(req);


            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;
                result.ResultOk = "false";
            }
            return result;
        }



        [Route("api/eMenu/cancelOrder")]
        [HttpPost]
        public Result cancelOrder([FromBody]MODEL.Criteria.reqOrder req)
        {
            Result result = new Result();
            result.ResultOk = "false";
            RestaurantBLL sv = new RestaurantBLL();
            try
            {

                result = sv.cancelOrder(req);

                //Veriy Data
                //result.ResultOk = "Success";
                //for (int i = 0; i < req.listFood.Count; i++)
                //{
                //    result.ReturnMessage += req.listFood[i].foodID + ",";
                //}
                //if (req != null)
                //{

                //return sv.InsertMenu(req);

                //}
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;
                result.ResultOk = "false";
                result.ReturnMessage = "";
            }
            return result;
        }

        [Route("api/eMenu/Register")]
        [HttpPost]
        public Result Register([FromBody]MODEL.Criteria.reqLogin req)
        {
            Result result = new Result();
            result.ResultOk = "false";
            RestaurantBLL sv = new RestaurantBLL();
            try
            {
                result = sv.insertMemberGuest(req);

            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;
                result.ResultOk = "false";
                result.ReturnMessage = "";
            }
            return result;
        }
        [Route("api/eMenu/Login")]
        [HttpPost]
        public ResultLogin Login([FromBody]MODEL.Criteria.reqLogin req)
        {
            ResultLogin result = new ResultLogin();
            result.ResultOk = "false";
            RestaurantBLL sv = new RestaurantBLL();
            try
            {
                result = sv.getLoginGuest(req);

            }
            catch (Exception e)
            {
                result.ErroMessage = e.Message;
                result.ResultOk = "false";
                result.ReturnMessage = "";
            }
            return result;
        }

        [Route("api/eMenu/getFirstPage")]
        [HttpPost]
        public ResultRestaurantContent getFirstPage()
        {
            ResultRestaurantContent result = new ResultRestaurantContent();
            result.ResultOk = "false";
            RestaurantBLL sv = new RestaurantBLL();
            try
            {
                result = sv.getFirstPage(null);

            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;
                result.ResultOk = "false";
                
            }
            return result;
        }
        [Route("api/eMenu/getFirstPageByID")]
        [HttpPost]
        public ResultRestaurantContent getFirstPageByID(MODEL.Criteria.reqRestaurant req)
        {
            ResultRestaurantContent result = new ResultRestaurantContent();
            result.ResultOk = "false";
            RestaurantBLL sv = new RestaurantBLL();
            try
            {
                result = sv.getFirstPage(req);

            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;
                result.ResultOk = "false";

            }
            return result;
        }

        [Route("api/eMenu/getHistoryUser")]
        [HttpPost]
        public ResultHistoryUser getHistoryUser(MODEL.Criteria.reqUser req)
        {
            ResultHistoryUser result = new ResultHistoryUser();
            result.ResultOk = "false";
            RestaurantBLL sv = new RestaurantBLL();
            try
            {
                result = sv.getHistoryByUserID(req);

            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;
                result.ResultOk = "false";

            }
            return result;
        }

        [Route("api/eMenu/DecodeQRTable")]
        [HttpPost]
        public ResultDecode DecodeQRTable(MODEL.Criteria.reqTableQRCode req)
        {
            ResultDecode result = new ResultDecode();
            ResultDecode result2 = new ResultDecode();
            result.ResultOk = "false";
            RestaurantBLL sv = new RestaurantBLL();
            DAL.Restaurant svDAL = new DAL.Restaurant();
            //DAL.StringCipher sv = new DAL.StringCipher();
            try
            {
                string password = "Lumpsum";               
                string decryptedstring = DAL.StringCipher.Decrypt(req.QRCode, password);
                //result.ResultOk = "true";
                //result.ErrorMessage = "";
                //result.ReturnMessage = "";
                result2 = JsonConvert.DeserializeObject<ResultDecode>(decryptedstring);

                DAL.Restaurant _DAL = new DAL.Restaurant();

                _DAL.insertLog(result2.ToString());

                _DAL.insertLog(result.restaurantID + "  " + result.tableID);

                result.restaurantID = result2.restaurantID;
                result.tableID = result2.tableID;
                result.tableName = sv.getTableName(result2.tableID).ReturnMessage;//getTableName;
                Result TypeTable = sv.getTypeTable(result.restaurantID,result.tableID);
                if(TypeTable.ReturnMessage == "1")
                {
                    //Result FrontTable = svDAL.getbookStatusTableTypeIsBook(result.restaurantID, result.tableID, req.userID, "1");
                    //if (FrontTable.ResultOk == "false")
                    //{
                    //    result.ResultOk = "true";
                    //    result.ReturnMessage = "";
                    //    result.ErrorMessage = "";
                       
                    //}
                    //else
                    //{
                    //    result.ResultOk = "false";
                    //    result.ReturnMessage = "Table is use !!!";
                    //    result.ErrorMessage = "";
                    //}
                    //Result FrontTable = svDAL.canOpenOrderFrontTable(result.restaurantID, result.tableID, req.userID);
                    //if(FrontTable.ResultOk != "false")
                    //{
                    //    result.ResultOk = "true";
                    //    result.ReturnMessage = FrontTable.ResultOk;
                    //    result.ErrorMessage = "";
                    //}
                    //else
                    //{
                    //    result.ResultOk = "false";
                    //    result.ReturnMessage = FrontTable.ReturnMessage;
                    //    result.ErrorMessage = FrontTable.ErrorMessage;
                    //}
                    //result.ResultOk = "true"
                }
                else
                {
                    //get user in process on table
                    Result resultgetUserinTabl = svDAL.getUserProcessInTable(result.restaurantID, result.tableID, req.userID);
                    if (resultgetUserinTabl.ResultOk == "true")
                    {
                        result.ResultOk = "true";
                        result.ReturnMessage = "";
                        result.ErrorMessage = "";
                        return result;
                    }

                    Result NormalTable = svDAL.getbookStatusTableTypeIsBook(result.restaurantID, result.tableID, req.userID, "2");
                    if (NormalTable.ResultOk == "false")
                    {                       
                        result.ResultOk = "true";
                        result.ReturnMessage = NormalTable.ReturnMessage;
                        result.ErrorMessage = "";
                        MODEL.Criteria.reqTable reqTable = new MODEL.Criteria.reqTable();
                        reqTable.tableID = result.tableID;
                        reqTable.userID = req.userID;
                        Result updateTable = svDAL.bookTable(reqTable);
                        if (updateTable.ResultOk == "false")
                        {
                            result.ResultOk = "false";
                            result.ErrorMessage = updateTable.ErrorMessage;
                        }
                    }
                    else
                    {
                        result.ResultOk = "false";
                        result.ReturnMessage = "Table is use !!!";
                        result.ErrorMessage = "";
                    }
                    //Result NormalTable = svDAL.canOpenOrder(result.restaurantID, result.tableID, req.userID);
                    //if (NormalTable.ResultOk != "false")
                    //{
                    //    result.ResultOk = "true";
                    //    result.ReturnMessage = NormalTable.ResultOk;
                    //    result.ErrorMessage = "";
                    //}
                    //else
                    //{
                    //    result.ResultOk = "false";
                    //    result.ReturnMessage = NormalTable.ReturnMessage;
                    //    result.ErrorMessage = NormalTable.ErrorMessage;
                    //}
                }


            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;
                result.ResultOk = "false";
                result.ReturnMessage = "";

            }
            return result;
        }

        [Route("api/eMenu/CancelTable")]
        [HttpPost]
        public Result CancelTable(MODEL.Criteria.reqTable req)
        {
            Result result = new Result();
            
            result.ResultOk = "false";
            RestaurantBLL sv = new RestaurantBLL();
            DAL.Restaurant svDAL = new DAL.Restaurant();
            //DAL.StringCipher sv = new DAL.StringCipher();
            try
            {
                result = svDAL.cancelTable(req);    


            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;
                result.ResultOk = "false";
                result.ReturnMessage = "";

            }
            return result;
        }

        [Route("api/eMenu/getStatusOrderIsBillPlease")]
        [HttpPost]
        public Result getStatusOrderISBillPlease(MODEL.Criteria.reqTable req)
        {
            Result result = new Result();
            result.ResultOk = "false";
            RestaurantBLL sv = new RestaurantBLL();
            DAL.Restaurant svDAL = new DAL.Restaurant();
            //DAL.StringCipher sv = new DAL.StringCipher();
            try
            {
                result = svDAL.getStatusOrderIsBillPleae(req.restaurantID, req.tableID, req.userID);


            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;
                result.ResultOk = "false";
                result.ReturnMessage = "";

            }
            return result;
        }


        [Route("api/eMenu/Logout")]
        [HttpPost]
        public Result Logout(MODEL.Criteria.reqTable req)
        {
            Result result = new Result();

            result.ResultOk = "false";
            RestaurantBLL sv = new RestaurantBLL();
            DAL.Restaurant svDAL = new DAL.Restaurant();
            //DAL.StringCipher sv = new DAL.StringCipher();
            try
            {
                ///Check User
                Result UserComplete = svDAL.checkOrderNotComplete(req.userID);   
                if(UserComplete.ResultOk == "true")
                {
                    result.ResultOk = "false";
                    result.ErrorMessage = "User not pay !!!";
                    result.ReturnMessage = "";
                    return result;
                }

                Result CancelTable = svDAL.cancelTable(req);
                result = CancelTable;
                


            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;
                result.ResultOk = "false";
                result.ReturnMessage = "";

            }
            return result;
        }
    }
}
