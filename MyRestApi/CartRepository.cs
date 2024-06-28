using Microsoft.EntityFrameworkCore;

namespace MyRestApi;

public class CartRepository : ICartRepository
{
    ApiContext context;
    public CartRepository(ApiContext apiContext)
    {
        context = apiContext;
    }
    public async Task Add(Cart cart)
    {
        context.Carts.Add(cart);
        await context.SaveChangesAsync();
    }
    public async Task<List<Cart>> GetAll()
    {
        return await context.Carts.Include(c => c.Products).ToListAsync();
    }
    public async Task<Cart?> Get(int id)
    {
        return await context.Carts.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);
    }
    public async Task<Cart?> Delete(int id)
    {
        var cart = await context.Carts.FirstOrDefaultAsync(c => c.Id == id);
        if (cart != null)
        {
            context.Carts.Remove(cart);
            await context.SaveChangesAsync();
        }
        return cart;
    }
    public async Task Update(Cart cart)
    {
        context.Entry(cart).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        await context.SaveChangesAsync();
    }
}
