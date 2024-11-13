namespace AMSeCommerce.Domain.Entities;

public class Order : BaseEntity
{
    public long UserId { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public decimal TransactionAmount { get; set; }
    public string Description { get; set; } = string.Empty;
    public long PaymentMethodId { get; set; }
    public string Status { get; set; } = string.Empty;
    public string ShippingAddress { get; set; } = string.Empty;
    public Customers User { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}