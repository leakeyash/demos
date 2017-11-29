using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DI.Unity.IDAL;
using WebApi.DI.Unity.Model;

namespace WebApi.DI.Unity.DAL.Repositories
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        private ProductsContext _db = new ProductsContext();

        public IEnumerable<Product> GetAll()
        {
            return _db.Products;
        }

        public Product GetById(int id)
        {
            return _db.Products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_db != null)
                {
                    _db.Dispose();
                    _db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
