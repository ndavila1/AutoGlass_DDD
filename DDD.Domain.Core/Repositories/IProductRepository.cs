using DDD.Domain.Core.Entities;

namespace DDD.Domain.Core.Repositories
{
    public interface IProductRepository
    {
        Product GetProductById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        List<Product> GetAllProducts(int skip, int take);
    }
}
