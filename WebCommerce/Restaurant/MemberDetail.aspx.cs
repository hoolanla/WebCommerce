using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCommerce.Restaurant
{
    public partial class MemberDetail : System.Web.UI.Page
    {
        BLL.RestaurantBLL svRestaurant = new BLL.RestaurantBLL();
        DAL.URLEncrypt svURL = new DAL.URLEncrypt();

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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if(Session["session_memberID"] == null)
                //{
                //    Response.Redirect("../MemberLogin.aspx", true);
                //}
                hdRestaurantID.Value = getRestaurantID();
                hdMemberID.Value = getMemberID();


                BindComboProvince();
                BindComboAmphur(ddlProvince.SelectedValue.ToString().Trim());
                BindComboTumbon(ddlAmphur.SelectedValue.ToString().Trim());

                MODEL.Restaurant res = new MODEL.Restaurant();
                res = svRestaurant.getRestaurant(hdRestaurantID.Value);
                if(res!= null)
                {
                    if(res.RestaurantID != "")
                    {
                        txtRestaurantName.Value = res.RestaurantName;
                        txtAddressNo.Value = res.ContactAddressNo;
                        txtAddressMoo.Value = res.ContactMoo;
                        txtAddressSoi.Value = res.ContactSoi;
                        txtAddressRoad.Value = res.ContactSoi;
                        txtContactName.Value = res.ContactName;
                        txtContactLastname.Value = res.ContactLastName;
                        ddlProvince.SelectedValue = res.ContactProvince.ToString().Trim();
                        ddlAmphur.SelectedValue = res.ContactAmphur.ToString().Trim();
                        ddlTumbon.SelectedValue = res.ContactTumbon.ToString().Trim();
                        txtZipCode.Value = res.ContactZipcode;
                        txtTel.Value = res.ContactTel;
                        txtPhone.Value = res.ContactPhone;
                        imgFood.ImageUrl = "~/ImagesRestaurant/" + hdRestaurantID.Value + ".jpg";
                        hid_lat.Value = res.RestaurantLast;
                        hid_lng.Value = res.RestaurantLong;
                    }
                }
            }
        }

        private void BindComboProvince()
        {
            ddlProvince.DataTextField = "ProvinceName";
            ddlProvince.DataValueField = "ProvinceCode";
            ddlProvince.DataSource = DAL.Common.getProvince();
            ddlProvince.DataBind();
            ddlProvince.SelectedIndex = 0;
        }

        private void BindComboAmphur(string ProvinceCode)
        {
            ddlAmphur.DataTextField = "AMPHURName";
            ddlAmphur.DataValueField = "AMPHURCODE";
            ddlAmphur.DataSource = DAL.Common.getAmphur(ProvinceCode);
            ddlAmphur.DataBind();
            ddlAmphur.SelectedIndex = 0;
        }
        private void BindComboTumbon(string AmphurCode)
        {
            ddlTumbon.DataTextField = "TUMBONName";
            ddlTumbon.DataValueField = "TUMBONCODE";
            ddlTumbon.DataSource = DAL.Common.getTumbon(AmphurCode);
            ddlTumbon.DataBind();
            ddlTumbon.SelectedIndex = 0;
        }


        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindComboAmphur(ddlProvince.SelectedValue.ToString().Trim());
            BindComboTumbon(ddlAmphur.SelectedValue.ToString().Trim());
        }

        protected void ddlAmphur_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindComboTumbon(ddlAmphur.SelectedValue.ToString().Trim());
        }
        private void MSG(string txt)
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + txt + "');", true);
            //Page.ClientScript.RegisterStartupScript(GetType(),
            //    "ShowMessage", string.Format("<script type='text/javascript'>alert('{0}')</script>",
            //    txt));
        }


        String Filename;
        protected void Upload(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {

                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string ImagePath = Server.MapPath("~/ImagesRestaurant/") + hdRestaurantID.Value + ".jpg";
                FileUpload1.PostedFile.SaveAs(ImagePath);
                imgFood.ImageUrl = "~/ImagesRestaurant/" + hdRestaurantID + ".jpg";
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



        protected void FileUpload1_Disposed(object sender, EventArgs e)
        {
            MSG("Upload");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            MODEL.Criteria.reqRestaurant model = new MODEL.Criteria.reqRestaurant();
            model.RestaurantName = txtRestaurantName.Value.Trim();
            model.RestaurantLat = hid_lat.Value.Trim();
            model.RestaurantLong = hid_lng.Value.Trim();
            model.RestaurantImagePath = hdRestaurantID.Value + ".jpg";

            model.ContactAddressNo = txtAddressNo.Value.Trim();
            model.ContactMoo = txtAddressMoo.Value.Trim();
            model.ContactSoi = txtAddressSoi.Value.Trim();
            model.ContactRoad = txtAddressRoad.Value.Trim();
            model.ContactProvince = Convert.ToInt32(ddlProvince.SelectedValue.ToString().Trim());
            model.ContactAmphur = Convert.ToInt32(ddlAmphur.SelectedValue.ToString().Trim());
            model.ContactTumbon = Convert.ToInt32(ddlTumbon.SelectedValue.ToString().Trim());
            model.ContactZipcode = txtZipCode.Value.Trim();
            model.ContactTel = txtTel.Value.Trim();
            model.ContactPhone = txtPhone.Value.Trim();
            model.RestaurantID = hdRestaurantID.Value;//Session["session_restaurantID"].ToString().Trim();
            model.UserID = hdMemberID.Value;//Session["session_memberID"].ToString().Trim();

            MODEL.Result res = new MODEL.Result();
            res = svRestaurant.updateRestaurant(model);
            if(res.ResultOk == "true")
            {
                MSG("Updated");
                string URL = @"memberID=" + hdMemberID.Value + "&restaurantID=" + hdRestaurantID.Value;
                URL = svURL.Encrypt(URL, "r0b1nr0y");
                Response.Redirect("~/Restaurant/DashboardCashier.aspx?" + URL);
            }
            else
            {
                MSG("Updated Fail !!!");
            }
            



        }
    }
}