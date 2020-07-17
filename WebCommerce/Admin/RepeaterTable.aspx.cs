using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCommerce.Admin
{
    public partial class RepeaterTable : System.Web.UI.Page
    {
        public class M_Table
        {
            public string tableName { get; set; }
            public string menu { get; set; }
            public string menuStatus { get; set; }
            public int price { get; set; }
            //private string menuList { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<M_Table> model = new List<M_Table>();
                M_Table data;
                data = new M_Table();
                data.tableName = "X1";
                data.menu = "M1";
                data.menuStatus = "Wait";
                data.price = 9500;
                model.Add(data);

                data = new M_Table();
                data.tableName = "X1";
                data.menu = "M2";
                data.menuStatus = "Wait";
                data.price = 9500;
                model.Add(data);
                data = new M_Table();
                data.tableName = "X1";
                data.menu = "M2";
                data.menuStatus = "Wait";
                data.price = 9500;
                model.Add(data);
                data = new M_Table();
                data.tableName = "X1";
                data.menu = "M2";
                data.menuStatus = "Wait";
                data.price = 9500;
                model.Add(data);
                data = new M_Table();
                data.tableName = "X1";
                data.menu = "M2";
                data.menuStatus = "Wait";
                data.price = 9500;
                model.Add(data);
                data = new M_Table();
                data.tableName = "X1";
                data.menu = "M2";
                data.menuStatus = "Wait";
                data.price = 9500;
                model.Add(data);
                data = new M_Table();
                data.tableName = "X1";
                data.menu = "M2";
                data.menuStatus = "Wait";
                data.price = 9500;
                model.Add(data);
                data = new M_Table();
                data.tableName = "X1";
                data.menu = "M2";
                data.menuStatus = "Wait";
                data.price = 9500;
                model.Add(data);

                data = new M_Table();
                data.tableName = "X1";
                data.menu = "M2";
                data.menuStatus = "Wait";
                data.price = 9500;
                model.Add(data);
                data = new M_Table();
                data.tableName = "X1";
                data.menu = "M2";
                data.menuStatus = "Wait";
                data.price = 9500;
                model.Add(data);

                this.RadListView1.DataSource = model;
                RadListView1.DataBind();

            }
        }
    }
}