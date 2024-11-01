using AMS_News.Domain.Contracts;
using AMSeCommerce.Infrastructure.Data;

namespace AMSeCommerce.Infrastructure.Repositories;

public class UnityOfWork(AmsEcommerceContext context) : IUnityOfWork, IDisposable
{
    private readonly AmsEcommerceContext _context = context;
    private bool disposed = false;
    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        Dispose(true);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        disposed = true;
    }

}