using AMSeCommerce.Communication.Response.Product;
using AMSeCommerce.Domain.Entities;

namespace AMSeCommerce.Application.UseCases.Product.DashBoard;

public interface IGetDashBoardProductUseCase
{
    Task<List<ResponseShortProductJson>> Execute();
}