
using AMSeCommerce.Domain.Contracts.Category;
using AMSeCommerce.Domain.Entities;
using AMSeCommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AMSeCommerce.Infrastructure.Repositories;

public class CategoryRepository(AmsEcommerceContext context) : ICategoryWriteOnlyRepository, ICategoryReadOnlyRepository
{
    public async Task AddCategory(Category category) => await context.Categories.AddAsync(category);
    public async Task<Category?> GetCategoryById(long id) => await context.Categories.FirstAsync(c => c.Id == id);
    public Task<Category?> GetParentCategoryById(long requestParentCategoryId) => context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == requestParentCategoryId);

    public void UpdateCategory(Category category) => context.Categories.Update(category);
}