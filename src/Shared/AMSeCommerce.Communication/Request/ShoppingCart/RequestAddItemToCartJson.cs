namespace AMSeCommerce.Communication.Request.ShoppingCart;

public class RequestAddItemToCartJson
{
    public long ProductId { get; set; }
    public int Quantity { get; set; } = 1;
}