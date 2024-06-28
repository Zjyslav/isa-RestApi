namespace MyRestApi;

public class Cart
{
    public Cart(int id, int userId, string promoCode)
    {
        Id = id;
        UserId = userId;
        PromoCode = promoCode;
    }

    public int Id { get; set; }
    public int UserId { get; set; }
    public List<Product> Products { get; set; } = new();
    public string PromoCode { get; set; } = "";
}
