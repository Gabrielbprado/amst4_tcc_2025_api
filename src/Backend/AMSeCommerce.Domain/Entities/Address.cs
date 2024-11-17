namespace AMSeCommerce.Domain.Entities;

public class Address : BaseEntity
{
    public string StreetName { get; set; } = string.Empty; 
    public int StreetNumber { get; set; } 
    public string ZipCode { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Neighborhood { get; set; } = string.Empty;
    public long UserId { get; set; }
    
    public virtual Customers User { get; set; } 
}