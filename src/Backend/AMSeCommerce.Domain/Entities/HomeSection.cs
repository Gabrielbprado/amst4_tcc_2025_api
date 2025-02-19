namespace AMSeCommerce.Domain.Entities;

public class HomeSection : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public Category Category { get; set; } = new();
    public long CategoryId { get; set; }
    public int OrderIndex { get; set; }
    public string Filter { get; set; } = string.Empty;
    public List<HomeSectionImages> HomeSectionImages { get; set; } = new List<HomeSectionImages>();
}