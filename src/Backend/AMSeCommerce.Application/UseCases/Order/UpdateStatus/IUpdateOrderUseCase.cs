using AMSeCommerce.Communication.Request.BankAPI;
using AMSeCommerce.Communication.Response.Payment;

namespace AMSeCommerce.Application.UseCases.Order.UpdateStatus;

public interface IUpdateOrderUseCase
{
    Task Execute(RequestChangeStatus status);
}