using CIVOP.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace CIVOP
{
    public class BundleConfig
    {
        // Další informace o sdružování najdete na webu https://go.microsoft.com/fwlink/?LinkID=303951.
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
                            "~/Scripts/WebForms/WebForms.js",
                            "~/Scripts/WebForms/WebUIValidation.js",
                            "~/Scripts/WebForms/MenuStandards.js",
                            "~/Scripts/WebForms/Focus.js",
                            "~/Scripts/WebForms/GridView.js",
                            "~/Scripts/WebForms/DetailsView.js",
                            "~/Scripts/WebForms/TreeView.js",
                            "~/Scripts/WebForms/WebParts.js"));

            // Pro fungování těchto souborů je velmi důležité pořadí, neboť mezi nimi existují explicitní závislosti.
            bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            // K vývoji a výuce použijte verzi Development nástroje Modernizr. Až budete
            // Připraveno na produkční prostředí. Použijte nástroj pro sestavení na webu https://modernizr.com a vyberte jenom testy, které potřebujete.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                            "~/Scripts/modernizr-*"));


        }
        public class CivopContext : DbContext
        {
            public DbSet<Orders> Orders { get; set; }
            public DbSet<Products> Products { get; set; }

            protected override void OnModelCreating(DbModelBuilder builder)
            {
                builder.Entity<Orders>().HasMany(x => x.Products).WithMany();
            }
        }

    }
}