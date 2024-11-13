using AMSeCommerce.Communication.Response.Product;

namespace AMSeCommerce.Application.UseCases.Product.GetById;

public interface IGetByIdProductUseCase
{
    Task<ResponseProductJson> Execute(long id);
}