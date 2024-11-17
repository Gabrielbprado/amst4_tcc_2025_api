using AMSeCommerce.Communication.Response.Payment;

namespace AMSeCommerce.Application.UseCases.Order.GetPaymentMethod;

public interface IGetPaymentMethodUseCase
{
    Task<List<ResponseCardInfoJson>> Execute();
}