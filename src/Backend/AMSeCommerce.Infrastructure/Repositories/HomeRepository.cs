using AMSeCommerce.Communication.Response.Home;
using AMSeCommerce.Domain.Contracts.Home;
using AMSeCommerce.Domain.Entities;
using AMSeCommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AMSeCommerce.Infrastructure.Repositories;

public class HomeRepository(AmsEcommerceContext context) : IHomeSectionReadOnlyRepository 
{
    private readonly AmsEcommerceContext _context = context;
    public Task<List<HomeSection>> GetHomeSections() => _context.HomeSection.Include(x => x.Category.ParentCategories).Include(x => x.HomeSectionImages).Take(5).ToListAsync();
}