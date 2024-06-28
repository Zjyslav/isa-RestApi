
namespace MyRestApi;

public interface ICartRepository
{
    Task Add(Cart cart);
    Task<Cart?> Delete(int id);
    Task<Cart?> Get(int id);
    Task<List<Cart>> GetAll();
    Task Update(Cart cart);
}