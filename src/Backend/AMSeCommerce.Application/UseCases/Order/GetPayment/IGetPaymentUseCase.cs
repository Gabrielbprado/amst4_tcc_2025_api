using AMSeCommerce.Communication.Response.Payment;

namespace AMSeCommerce.Application.UseCases.Order.GetPayment;

public interface IGetPaymentUseCase
{
    Task<ResponsePixJson> Execute(long id);
        
}