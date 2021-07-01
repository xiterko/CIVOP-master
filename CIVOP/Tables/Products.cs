using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CIVOP.Tables
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}