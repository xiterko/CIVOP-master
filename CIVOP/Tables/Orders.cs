using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CIVOP.Tables
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAdddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual IList<Products> Products { get; set; }
    }
}