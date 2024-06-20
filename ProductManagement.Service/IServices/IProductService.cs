using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Common.Models;

namespace ProductManagement.Service.IServices
{
    public interface IProductService
    {
        IEnumerable<Products> GetProducts();
    }
}
