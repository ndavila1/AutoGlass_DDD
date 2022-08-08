using DDD.Application.ViewModel;
using DDD.Domain.Validations;
namespace DDD.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductViewModelOutput> GetProductById(int id);
        Task<ValidationResult> AddProduct(ProductViewModelInput product);
        Task<ValidationResult> UpdateProduct(int id, ProductViewModelInput product);
        Task<ValidationResult> DeleteProduct(int id);
        Task<List<ProductViewModelOutput>> GetAllProducts(int? page);
    }
}
