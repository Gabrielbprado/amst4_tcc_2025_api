namespace AMSeCommerce.Domain.Contracts.Category;

public interface ICategoryWriteOnlyRepository
{
    Task AddCategory(Entities.Category category);
    void UpdateCategory(Entities.Category category);
}