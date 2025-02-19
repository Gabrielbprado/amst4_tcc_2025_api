
using AMSeCommerce.Domain.Contracts.Category;
using AMSeCommerce.Domain.Entities;
using AMSeCommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AMSeCommerce.Infrastructure.Repositories;

public class CategoryRepository(AmsEcommerceContext context) : ICategoryWriteOnlyRepository, ICategoryReadOnlyRepository
{
    private readonly AmsEcommerceContext _context = context;
    public async Task AddCategory(Category category) => await _context.Categories.AddAsync(category);
    public async Task<Category?> GetCategoryById(long id) => await _context.Categories.FirstAsync(c => c.Id == id);
    public Task<Category?> GetParentCategoryById(long requestParentCategoryId) => _context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == requestParentCategoryId);
    public async Task<List<Category>> GetAllCategories() => await _context.Categories.ToListAsync();
    public void UpdateCategory(Category category) => _context.Categories.Update(category);
}