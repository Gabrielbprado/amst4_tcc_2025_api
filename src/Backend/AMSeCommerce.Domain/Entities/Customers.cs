namespace AMSeCommerce.Domain.Entities;

public class Customers : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Guid UserIdentifier { get; set; }
    public string Email { get; set; } = string.Empty;

    public string Cpf { get; set; } = string.Empty;
    public List<Order> Orders { get; set; } = new List<Order>();
}