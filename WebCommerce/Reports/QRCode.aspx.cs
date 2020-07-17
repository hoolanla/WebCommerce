using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.IO;

namespace WebCommerce.Reports
{
    public partial class QRCode1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            genReport();





        }


        private bool genReport()
        {

            DataTable dtMap = new DataTable("QRCode");  //*** DataTable Map DataSet.xsd ***//
            DataTable m_dt = (DataTable)Session["DATATABLE"];

            DataRow dr = null;
            dtMap.Columns.Add(new DataColumn("table_id", typeof(string)));
            dtMap.Columns.Add(new DataColumn("table_name", typeof(string)));
            dtMap.Columns.Add(new DataColumn("restaurant_name", typeof(string)));
            dtMap.Columns.Add(new DataColumn("barcode", typeof(System.Byte[])));




            for (int i = 0; i < (m_dt.Rows.Count); i++)
            {

                FileStream fiStream = new FileStream(Server.MapPath("~/QRCode/" + m_dt.Rows[i]["table_id"].ToString() + ".jpeg"), FileMode.Open, FileAccess.Read);
                BinaryReader binReader = new BinaryReader(fiStream);
                byte[] pic1 = {};
                pic1 = binReader.ReadBytes((int)fiStream.Length);

                fiStream.Close();
                binReader.Close();



                dr = dtMap.NewRow();
                dr["table_id"] = m_dt.Rows[i]["table_id"];
                dr["table_name"] = m_dt.Rows[i]["table_name"];
                dr["restaurant_name"] = m_dt.Rows[i]["restaurant_name"];
                dr["barcode"] = pic1;

                dtMap.Rows.Add(dr);
            }


            ReportDocument rpt = new ReportDocument();
            rpt.Load(Server.MapPath("~/Reports/QRCode.rpt"));

            foreach (CrystalDecisions.CrystalReports.Engine.Table crTable in rpt.Database.Tables)
            {
                TableLogOnInfo tableLogOnInfo = crTable.LogOnInfo;
                object connectionInfo = tableLogOnInfo.ConnectionInfo;
                crTable.ApplyLogOnInfo(tableLogOnInfo);
            }

            rpt.SetDataSource(dtMap);
            CRVW.ReportSource = rpt;
            //  crVw.RefreshReport();

            return true;
        }
    }
}