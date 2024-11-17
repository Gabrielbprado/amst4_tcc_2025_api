namespace AMSeCommerce.Domain.Entities;

public class ProductImage : BaseEntity
{
    public long ProductId { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public bool IsMainImage { get; set; } = false;

    public Product Product { get; set; } = null!;
}