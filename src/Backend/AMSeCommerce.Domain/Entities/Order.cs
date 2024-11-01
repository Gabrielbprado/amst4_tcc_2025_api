namespace AMSeCommerce.Domain.Entities;

public class Order : BaseEntity
{
    public long UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = string.Empty;
    public string ShippingAddress { get; set; } = string.Empty;
    public string? BillingAddress { get; set; }

    public Customers User { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}