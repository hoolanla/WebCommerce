using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.IO;

namespace WebCommerce.Restaurant
{
    public partial class MenuDetailEdit : System.Web.UI.Page
    {

        eMenuBLL svMenu = new eMenuBLL();

        RestaurantBLL svRestaurant = new RestaurantBLL();
        DAL.URLEncrypt svURL = new DAL.URLEncrypt();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               hdMemberID.Value = Session["memberID"].ToString();
              hdRestaurantID.Value = Session["restaurantID"].ToString();

                BindComboCategoryLV1();
                BindComboCategoryLV2(ddlCategoryLV1.SelectedValue.ToString().Trim());
              //  BindData();
                

               string foodID = Request.QueryString["foodID"];
                if (foodID != "")
                {
                    Session["foodID"] = foodID;
                    BindData(foodID);


                    lblStatus.InnerText = "แก้ไขข้อมูลเมนูอาหาร";
                    btnSave.Text = "แก้ไข";
                }
                else
                {

                }

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
                //arrIndMsg = arrMsgs[2].Split('='); //Get the Phone
                //strPhone = arrIndMsg[1].ToString().Trim();

                //lblName.Text = strName;
                //lblAge.Text = strAge;
                //lblPhone.Text = strPhone;
                return memberID;
            }
            else
            {
                return "";
                //Response.Redirect("Page1.aspx");
            }
        }

        private void BindData(String foodID)
        {
               txtRestaurant.Value = svRestaurant.getRestaurant(hdRestaurantID.Value).RestaurantName;

            MODEL.MenuDetail _Menu = new MODEL.MenuDetail();
            BLL.Menu _BLL = new BLL.Menu();

            _Menu = _BLL.getMenuDetail(foodID);


            ddlCategoryLV1.SelectedValue = _Menu.MenuCategoryLV1ID;
            ddlCategoryLV2.SelectedValue = _Menu.MenuCategoryLV2ID;
       
            ddlStatus.SelectedValue = _Menu.MenuActivate;
            txtMenuName.Value = _Menu.MenuName;
            txtMenuDescription.Value = _Menu.MenuDescription;
            txtPriceS.Value = _Menu.MenuPriceS;
            txtPriceM.Value = _Menu.MenuPriceM;
            txtPriceL.Value = _Menu.MenuPriceL;
            txtMenuRemark.Value = _Menu.MenuRemark;

            if(_Menu.MenuRecommend == "True")
            {
                ddlRecommend.SelectedValue = "1";
            }
            else
            {
                ddlRecommend.SelectedValue = "0";
            }
          

            imgFood.ImageUrl = "~/ImagesFood/" + _Menu.MenuPicture;


        }

        private void BindComboCategoryLV1()
        {
            ddlCategoryLV1.DataTextField = "foodsTypeNameLevel1";
            ddlCategoryLV1.DataValueField = "foodsTypeIDLevel1";
            ddlCategoryLV1.DataSource = svMenu.getMenuCategoryLV1();
            ddlCategoryLV1.DataBind();
            ddlCategoryLV1.SelectedIndex = 0;
        }
        private void BindComboCategoryLV2(string CategoryLV1)
        {
            ddlCategoryLV2.DataTextField = "foodsTypeNameLevel2";
            ddlCategoryLV2.DataValueField = "foodsTypeIDLevel2";
            ddlCategoryLV2.DataSource = svMenu.getMenuCategoryLV2(CategoryLV1);
            ddlCategoryLV2.DataBind();
            ddlCategoryLV2.SelectedIndex = 0;
        }

        protected void ddlCategoryLV1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindComboCategoryLV2(ddlCategoryLV1.SelectedValue.ToString().Trim());
        }

        private void MSG(string txt)
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + txt + "');", true);
      
        }

        protected void Upload(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {

                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string ImagePath = Server.MapPath("~/ImageTemp/") + fileName;
                FileUpload1.PostedFile.SaveAs(ImagePath);
                imgFood.ImageUrl = "~/ImageTemp/" + Path.GetFileName(FileUpload1.FileName);
                //Session["Menu_Image"] = 
                //Update Database
                //string UserID = Session["session_USERID"].ToString().Trim();
                //string UserKeyID = Request.QueryString["UserID"].ToString().Trim();
                //if (File.Exists(Server.MapPath("~/ImageTemp/") + fileName) == true)
                //{
                //    string FileName = DateTime.Now.ToString("yyMMddhhmmss") + "_" + fileName;
                //    string Origin = Server.MapPath("~/ImageTemp/") + fileName;
                //    string Desination = Server.MapPath("~/ImagesUser/") + FileName;
                //    File.Copy(Origin, Desination);
                    //if (svMember.UploadImageUser(UserKeyID, FileName) == true)
                    //{
                       // MSG("Upload Complete");
                   // }
                    //'else
                    //{
                        //MSG("Upload Fail !!!");
                    //}
                //}


                //Session["session_ImageFile"] = fileName;
                //Response.Redirect(Request.Url.AbsoluteUri);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMenuName.Value.Trim() == "")
            {
                MSG("กรุณาป้อนชื่อเมนูอาหาร !!!");
                return;
            }
            if (txtMenuDescription.Value.Trim() == "")
            {
                MSG("กรุณาป้อนรายละเอียดเมนูอาหาร !!!");
                return;
            }
            if (txtPriceS.Value.Trim() == "")
            {
                MSG("กรุณาป้อนราคา [S] !!!");
                return;
            }

            //Insert
            
            //string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
            //string FileNameDesinatoin = DateTime.Now.ToString("yyMMddhhmmss") + "_" + fileName;           
            MODEL.Criteria.reqeMenu modelMenu = new MODEL.Criteria.reqeMenu();
            modelMenu.MemberID = Session["memberID"].ToString();
            modelMenu.MenuID = Session["foodID"].ToString();
            modelMenu.MenuCategoryLV1ID = ddlCategoryLV1.SelectedValue.ToString().Trim();
            modelMenu.MenuCategoryLV2ID = ddlCategoryLV2.SelectedValue.ToString().Trim();
            modelMenu.MenuName = txtMenuName.Value.ToString().Trim();           
            if(imgFood.ImageUrl != "")
            {
              


                string imageName = imgFood.ImageUrl.Substring(imgFood.ImageUrl.LastIndexOf(@"/") + 1);
                modelMenu.MenuPicture = imageName;
                string Origin = Server.MapPath("~/ImageTemp/") + imageName;
                if(File.Exists(@Origin))
                {

                    string FileName = DateTime.Now.ToString("yyMMddhhmmss") + "_" + imageName;

                    string Desination = Server.MapPath("~/ImagesFood/") + FileName;
                    File.Copy(Origin, Desination);
                    modelMenu.MenuPicture = FileName;
                    File.Delete(@Origin);
                }

            }
            modelMenu.MenuDescription = txtMenuDescription.Value.ToString().Trim();
            modelMenu.MenuActivate = ddlStatus.SelectedValue.ToString().Trim();
            modelMenu.MenuRemark = txtMenuRemark.Value.Trim();
            modelMenu.MenuPrice = txtPriceS.Value.ToString().Trim();
            modelMenu.MenuPriceS = txtPriceS.Value.ToString().Trim();
            modelMenu.MenuPriceM = txtPriceM.Value.ToString().Trim();
            modelMenu.MenuPriceL = txtPriceL.Value.ToString().Trim();
            modelMenu.MenuRecommend = ddlRecommend.SelectedValue.ToString().Trim();
            modelMenu.restaurantID = hdRestaurantID.Value;


            MODEL.Result result;
            BLL.Menu _mBLL = new BLL.Menu();
            if (_mBLL.updateMenu(modelMenu).ResultOk == "true")

            {
                MSG("บันทึกข้อมูลเรียบร้อย");
                string URL = @"memberID=" + hdMemberID.Value + "&restaurantID=" + hdRestaurantID.Value;
                URL = svURL.Encrypt(URL, "r0b1nr0y");
                Response.Redirect("MenuList.aspx?" + URL, true);
            }
            else
            {
                MSG("บันทึกข้อมูลไม่สำเร็จ");
            }

        }

        protected void FileUpload1_Disposed(object sender, EventArgs e)
        {
            MSG("Upload");
        }
    }
}