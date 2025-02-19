using System.ComponentModel.DataAnnotations.Schema;

namespace AMSeCommerce.Domain.Entities;

[Table("HomeSection_Images")]
public class HomeSectionImages : BaseEntity
{
    public long HomeSectionId { get; set; } 
    public string ImageUrl { get; set; } = string.Empty;
}