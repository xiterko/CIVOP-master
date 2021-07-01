using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static CIVOP.BundleConfig;

namespace CIVOP
{
    public partial class updateProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var productId = Convert.ToInt32(Request.QueryString["ProductId"]);
                if (productId != 0)
                {
                    using (var db = new CivopContext())
                    {
                        var product = db.Products.FirstOrDefault(x => x.ProductId == productId);

                        TxtProductCode.Text = product?.Code;
                        TxtProductName.Text = product?.Name;
                        TxtProductPrice.Text = product?.Price.ToString();
                    }
                }
                else
                {
                    Heade.Text = "Přidání produktu";
                }
            }
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            var productId = Convert.ToInt32(Request.QueryString["ProductId"]);

            if(productId != 0)
            {
                using (var db = new CivopContext())
                {
                    var product = db.Products.FirstOrDefault(x => x.ProductId == productId);
                    product.Code = TxtProductCode.Text;
                    product.Name = TxtProductName.Text;
                    product.Price = Convert.ToInt32(TxtProductPrice.Text);
                    db.SaveChanges();
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
                using (var db = new CivopContext())
                {
                    db.Products.Add(new Tables.Products
                    {
                        Code = TxtProductCode.Text,
                        Name = TxtProductName.Text,
                        Price = Convert.ToInt32(TxtProductPrice.Text)
                    });
                    db.SaveChanges();
                    Response.Redirect("Default.aspx");
                }
            }            
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}