using System.ComponentModel.DataAnnotations.Schema;

namespace AMSeCommerce.Domain.Entities;

public class ParentCategory : BaseEntity
{
    public string Description { get; set; } = string.Empty;
    public long CategoryId { get; set; } 
}