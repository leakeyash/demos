using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DI.Unity.Model;

namespace WebApi.DI.Unity.DAL
{
    public class ProductsContext:DbContext
    {
        public ProductsContext()
            : base("name=ProductsContext")
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
