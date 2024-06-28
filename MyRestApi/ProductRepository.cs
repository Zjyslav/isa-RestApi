using Microsoft.EntityFrameworkCore;

namespace MyRestApi;

public class ProductRepository : IProductRepository
{
    ApiContext context;
    public ProductRepository(ApiContext apiContext)
    {
        context = apiContext;
    }
    public async Task Add(Product product)
    {
        context.Products.Add(product);
        await context.SaveChangesAsync();
    }
    public async Task<List<Product>> GetAll()
    {
        return await context.Products.ToListAsync();
    }
    public async Task<Product?> Get(int id)
    {
        return await context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }
    public async Task<Product?> Delete(int id)
    {
        var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (product != null)
        {
            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }
        return product;
    }
    public async Task Update(Product product)
    {
        context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        await context.SaveChangesAsync();
    }
}
