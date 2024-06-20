using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Service.IServices;
using ProductManagement.Common.Models;

namespace ProductManagement.Service.Services
{
    public class ProductService : IProductService
    {
        public IEnumerable<Products> GetProducts()
        {
            var products = new List<Products>();
            products.Add(new Products() { Id = 1, Description = "any", Name = "product 1" });
            return products;
        }
    }
}
