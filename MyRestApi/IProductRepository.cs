
namespace MyRestApi;

public interface IProductRepository
{
    Task Add(Product product);
    Task<Product?> Delete(int id);
    Task<Product?> Get(int id);
    Task<List<Product>> GetAll();
    Task Update(Product product);
}