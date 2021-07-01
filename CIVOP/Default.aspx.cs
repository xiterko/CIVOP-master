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
    public partial class _Default : Page
    {
        IList<Products> products = new List<Products>();
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var db = new CivopContext())
            {
                products =  db.Set<Products>().OrderBy(x=>x.ProductId).ToList();               
                GridView1.DataSource = products;
                GridView1.DataBind();               
            }            
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            var productId = products[e.NewEditIndex].ProductId;
            Response.Redirect($"updateProduct.aspx?ProductId={productId}");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var productId = products[e.RowIndex].ProductId;
            using (var db = new CivopContext())
            {
                var product = db.Products.Single(x => x.ProductId == productId);
                db.Products.Remove(product);
                db.SaveChanges();
                Page_Load(null,null);
                
            }
        }

        protected void AddProductBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect($"updateProduct.aspx");
        }
    }
}