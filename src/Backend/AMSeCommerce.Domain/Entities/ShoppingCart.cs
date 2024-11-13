namespace AMSeCommerce.Domain.Entities;


public class ShoppingCart : BaseEntity
{
    public long ProductId { get; set; }
    public int Quantity { get; set; } = 1;
}