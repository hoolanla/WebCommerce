using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.ReportViewer.Html5.WebForms;
using Telerik.Reporting.Processing;

namespace WebCommerce.Restaurant
{
    public partial class ReportTableQRCode : System.Web.UI.Page
    {

        DAL.URLEncrypt svURL = new DAL.URLEncrypt();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdRestaurantID.Value = getRestaurantID();

                BindReportDocument(hdRestaurantID.Value);
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
                restaurantID = arrIndMsg[1].ToString().Trim();
                //arrIndMsg = arrMsgs[1].Split('='); //Get the Age
                //restaurantID = arrIndMsg[1].ToString().Trim();
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
        private void BindReportDocument(string restaurantID)
        {
            try
            {

                //Session["session_GSOrderID"] = "13";
                //RTVID = Request.QueryString["RTVID"].ToString().Trim();
                var clientReportSource = new Telerik.ReportViewer.Html5.WebForms.ReportSource();
                clientReportSource.IdentifierType = IdentifierType.UriReportSource;
                //clientReportSource.Identifier = Server.MapPath(@"reportPickBox.trdp");//or <namespace>.<class>, <assembly> e.g. "MyReports.Report1, MyReportsLibrary"
                clientReportSource.Identifier = @"C:\ReportFiles\reportQRCodeTable.trdp";

                clientReportSource.Parameters.Add("restaurantID", restaurantID);
                //reportViewer1.PrintMode = PrintMode.ForcePDFFile;
                this.rptDocument.ReportSource = clientReportSource;
                rptDocument.ViewMode = ViewMode.PrintPreview;
                rptDocument.PrintMode = PrintMode.ForcePDFFile;



            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}