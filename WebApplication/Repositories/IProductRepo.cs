using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DAL;

namespace WebApplication.Repositories
{
    interface IProductRepo
    {
        List<Product> GetAllProducts();
        Product GetProduct(long id);
        Product CreateProduct(Product product);
        void UpdateProduct(long id, Product product);
        void DeleteProduct(long id);
    }
}
