using CIVOP.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static CIVOP.BundleConfig;

namespace CIVOP
{
    public partial class Order : Page
    {
        IList<Orders> orders = new List<Orders>();
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var db = new CivopContext())
            {               
                orders = db.Set<Orders>().OrderBy(x => x.OrderId).ToList();
                GridView1.DataSource = orders;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            var productId = orders[e.NewEditIndex].OrderId;
            Response.Redirect($"updateOrder.aspx?OrderId={productId}");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var orderId = orders[e.RowIndex].OrderId;
            using (var db = new CivopContext())
            {
                var order = db.Orders.Single(x => x.OrderId == orderId);
                db.Orders.Remove(order);
                db.SaveChanges();
                Page_Load(null, null);

            }
        }

        protected void AddOrderBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect($"updateOrder.aspx");
        }
    }
}