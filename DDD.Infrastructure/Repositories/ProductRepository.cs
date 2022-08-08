using DDD.Domain.Core.Entities;
using DDD.Domain.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        DatabaseContext _dbContext;
        public ProductRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddProduct(Product product)
        {
            _dbContext.Add(product);
            _dbContext.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            _dbContext.Update(product);
            _dbContext.SaveChanges();
        }

        public List<Product> GetAllProducts(int skip, int take)
        {
            var query = _dbContext.Products.Where(p => p.State)
          .OrderBy(p => p.ProductId);

          return query.Skip(skip).Take(take).ToList();
        }

        public Product GetProductById(int id) =>
            _dbContext.Products.Find(id);

        public void UpdateProduct(Product product)
        {
            _dbContext.Update(product);
            _dbContext.SaveChanges();
        }
    }
}
