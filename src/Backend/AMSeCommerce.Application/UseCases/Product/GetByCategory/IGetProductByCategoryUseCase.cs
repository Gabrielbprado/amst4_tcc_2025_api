using AMSeCommerce.Communication.Response.Product;

namespace AMSeCommerce.Application.UseCases.Product.GetByCategory;

public interface IGetProductByCategoryUseCase
{
    Task<IList<ResponseShortProductJson>> Execute(long categoryId);
}