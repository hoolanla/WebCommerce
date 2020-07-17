using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using MODEL;
using System.Web.Services;


namespace WebCommerce.Admin
{
    public partial class SOCreate : System.Web.UI.Page
    {
        ProductBLL svProduct = new ProductBLL();
 
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session["session_cbProduct"] = svProduct.getProductAll();
                BindComboProduct();
                //string txt = "";
                //txt += "ปฏิพัทธ์ ตรีนก";
                //txt += "\r\n";
                //txt += "63 ถ.คุรุสามัคคี ต.ปากช่อง อ.ปากช่อง จ.นครราชสีมา 30130";
                //txt += "\r\n";
                //txt += "0854895444";
                //txtDetail.InnerText = txt;
            }
            
        }

        private void BindComboProduct()
        {
            if(Session["session_cbProduct"] != null)
            {
                ddlProduct.DataSource = Session["session_cbProduct"];
                ddlProduct.DataTextField = "ProductName";
                ddlProduct.DataValueField = "ProductID";
                ddlProduct.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //string s = txtDetail.InnerText;
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            string s = txtDetail.InnerText;
            string[] splitText = txtDetail.InnerText.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            if (splitText.Length == 3)
            {
                string Name = splitText[0];
                string Address = splitText[1];
                string Phone = splitText[2];
            }



        }

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        [WebMethod]

        public static string GetProduct()
        {
            return "Ok";
            //ProductBLL svProduct = new ProductBLL();            
            //return svProduct.getProductAll();
        }
    }
}