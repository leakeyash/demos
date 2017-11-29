using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.DI.Unity.IDAL;
using WebApi.DI.Unity.Model;


namespace WebApi.DI.Unity.Controllers
{
    public class ProductsController : ApiController
    {
        //ProductRepository _repository = new ProductRepository();
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository repository)
        {
            _productRepository = repository;
        }
        public IEnumerable<Product> Get()
        {
            return _productRepository.GetAll();
        }

        public IHttpActionResult Get(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
