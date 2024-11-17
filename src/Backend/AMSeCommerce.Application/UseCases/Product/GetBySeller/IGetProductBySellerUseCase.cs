using AMSeCommerce.Communication.Response.Product;

namespace AMSeCommerce.Application.UseCases.Product.GetBySeller;

public interface IGetProductBySellerUseCase
{
    Task<IList<ResponseProductJson>> Execute(long id);
}