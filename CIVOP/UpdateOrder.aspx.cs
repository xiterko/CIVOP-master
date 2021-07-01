using CIVOP.Tables;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static CIVOP.BundleConfig;

namespace CIVOP
{
    public partial class UpdateOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TxtCreatedDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            if (!IsPostBack)
            {
                var orderId = Convert.ToInt32(Request.QueryString["OrderId"]);
                if (orderId != 0)
                {
                    Label4.Visible = true;
                    using (var db = new CivopContext())
                    {
                        var order = db.Orders.FirstOrDefault(x => x.OrderId == orderId);
                        var totalPrice = 0;
                        order.Products.ForEach(x => totalPrice += (int)x.Price);
                        TotalValue.Text += totalPrice;
                        
                        TxtCustomerName.Text = order?.CustomerName;
                        TxtCustomerAddress.Text = order?.CustomerAdddress;
                        TxtCreatedDate.Text = order?.CreatedDate.ToString("yyyy-MM-dd");
                        GridView1.DataSource = order.Products;
                        GridView1.DataBind();
                    }
                }
                else
                {
                    TotalValue.Visible = false;
                    Heade.Text = "Přidání Objednávky";
                }
            }
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            var orderId = Convert.ToInt32(Request.QueryString["OrderId"]);

            if (orderId != 0)
            {
                using (var db = new CivopContext())
                {

                    var order = db.Orders.FirstOrDefault(x => x.OrderId == orderId);
                    order.CustomerName = TxtCustomerName.Text;
                    order.CustomerAdddress = TxtCustomerAddress.Text;
                    order.CreatedDate = DateTime.Parse(TxtCreatedDate.Text);
                    db.SaveChanges();
                    Response.Redirect("Order.aspx");
                }
            }
            else
            {
                using (var db = new CivopContext())
                {

                    db.Orders.Add(new Tables.Orders
                    {
                        CustomerName = TxtCustomerName.Text,
                        CustomerAdddress = TxtCustomerAddress.Text,
                        CreatedDate = DateTime.Parse(TxtCreatedDate.Text)
                    });
                    db.SaveChanges();
                    Response.Redirect("Order.aspx");
                }
            }
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Order.aspx");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var productId = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[0].Text);
            using (var db = new CivopContext())
            {
                var orderId = Convert.ToInt32(Request.QueryString["OrderId"]);

                var order = db.Orders.Where(x => x.OrderId == orderId).Include(cc => cc.Products).First();

                order.Products.Remove(db.Products.First(x => x.ProductId == productId));
                db.SaveChanges();
                GridView1.DataSource = order.Products;
                GridView1.DataBind();
                Page_Load(null, null);
            }
        }
        
        protected void BtnAddProducts_Click(object sender, EventArgs e)
        {
            if (GridView2.Visible) {
                GridView2.Visible = false;
                Button1.Text = "Přidat produkty k objednávce";
            }
            else
            {
                GridView2.Visible = true;
                Button1.Text = "Zrušit";
                var orderId = Convert.ToInt32(Request.QueryString["OrderId"]);

                using (var db = new CivopContext())
                {
                    var products = db.Set<Products>().ToList();
                    if (orderId != 0)
                    {
                        var order = db.Orders.FirstOrDefault(x => x.OrderId == orderId);
                        var productIdsToRemove = order.Products.Select(x => x.ProductId);
                        products.RemoveAll(x => productIdsToRemove.Contains(x.ProductId));
                    } 

                    GridView2.DataSource = products;
                    GridView2.DataBind();
                }
            }            
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            var productId = Convert.ToInt32(GridView2.Rows[e.NewEditIndex].Cells[0].Text);
            using (var db = new CivopContext())
            {
                var orderId = Convert.ToInt32(Request.QueryString["OrderId"]);
                Orders order;
                var product = db.Products.First(x => x.ProductId == productId);
                if (orderId == 0)
                {
                    order = db.Orders.Add(
                        new Orders
                        {
                            CreatedDate = DateTime.Parse(TxtCreatedDate.Text),
                            CustomerName = TxtCustomerName.Text,
                            CustomerAdddress = TxtCustomerAddress.Text
                        });
                    order.Products = new List<Products> { product };
                }
                else
                {
                    order = db.Orders.Where(x => x.OrderId == orderId).Include(cc => cc.Products).First();
                    order.Products.Add(db.Products.First(x => x.ProductId == productId));
                }

                db.SaveChanges();
                GridView1.DataSource = order.Products;
                GridView1.DataBind();
                GridView2.Rows[e.NewEditIndex].Visible = false;
                if (orderId == 0)
                    Response.Redirect($"UpdateOrder.aspx?OrderId={order.OrderId}");
            }
        }

    }
}