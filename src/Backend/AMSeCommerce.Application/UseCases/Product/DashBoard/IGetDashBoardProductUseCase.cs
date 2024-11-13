using AMSeCommerce.Communication.Response.Product;

namespace AMSeCommerce.Application.UseCases.Product.DashBoard;

public interface IGetDashBoardProductUseCase
{
    Task<List<ResponseShortProductJson>> Execute();
}