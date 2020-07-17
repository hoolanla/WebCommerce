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
    public partial class MenuDetail : System.Web.UI.Page
    {

        eMenuBLL svMenu = new eMenuBLL();
        RestaurantBLL svRestaurant = new RestaurantBLL();
        DAL.URLEncrypt svURL = new DAL.URLEncrypt();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdMemberID.Value = getMemberID();
                hdRestaurantID.Value = getRestaurantID();

                BindComboCategoryLV1();
                BindComboCategoryLV2(ddlCategoryLV1.SelectedValue.ToString().Trim());
                BindData();
                

                //string foodID = Request.QueryString["foodID"];
                //if(foodID != "")
                //{
                //    lblStatus.InnerText = "แก้ไขข้อมูลเมนูอาหาร";
                //    btnSave.Text = "แก้ไข";
                //}
                //else
                //{

                //}

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

        private void BindData()
        {
            txtRestaurant.Value = svRestaurant.getRestaurant(hdRestaurantID.Value).RestaurantName;
            
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
            //Page.ClientScript.RegisterStartupScript(GetType(),
            //    "ShowMessage", string.Format("<script type='text/javascript'>alert('{0}')</script>",
            //    txt));
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
            modelMenu.MemberID = "0";
            modelMenu.MenuCategoryLV1ID = ddlCategoryLV1.SelectedValue.ToString().Trim();
            modelMenu.MenuCategoryLV2ID = ddlCategoryLV2.SelectedValue.ToString().Trim();
            modelMenu.MenuName = txtMenuName.Value.ToString().Trim();           
            if(imgFood.ImageUrl != "")
            {
                string imageName = imgFood.ImageUrl.Substring(imgFood.ImageUrl.LastIndexOf(@"/") + 1); 
                string FileName = DateTime.Now.ToString("yyMMddhhmmss") + "_" + imageName;
                string Origin = Server.MapPath("~/ImageTemp/") + imageName;
                string Desination = Server.MapPath("~/ImagesFood/") + FileName;
                File.Copy(Origin, Desination);
               
                modelMenu.MenuPicture = FileName;
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

            if (svMenu.InsertMenu(modelMenu).ResultOk == "true")
            {
                MSG("บันทึกข้อมูลเรียบร้อย");

                string URL = @"memberID=" + hdMemberID.Value + "&restaurantID=" + hdRestaurantID.Value;
                URL = svURL.Encrypt(URL, "r0b1nr0y");

                Response.Redirect("MenuList.aspx?" + URL, true);
            }


        }

        protected void FileUpload1_Disposed(object sender, EventArgs e)
        {
            MSG("Upload");
        }
    }
}