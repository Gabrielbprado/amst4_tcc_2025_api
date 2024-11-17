using AMSeCommerce.Communication.Request.Address;
using AMSeCommerce.Communication.Response.Address;

namespace AMSeCommerce.Application.UseCases.Address;

public interface IAddAddressUseCase
{
    Task<ResponseAddressJson> Execute(RequestAddressJson request);
}