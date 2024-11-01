namespace AMSeCommerce.Domain.Contracts.Category;

public interface ICategoryReadOnlyRepository
{
    Task<Entities.Category?> GetCategoryById(long id);

    Task<Entities.Category?> GetParentCategoryById(long requestParentCategoryId);
}