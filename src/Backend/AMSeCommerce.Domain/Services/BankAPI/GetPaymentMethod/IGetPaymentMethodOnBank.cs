using AMSeCommerce.Communication.Response.Payment;

namespace AMSeCommerce.Domain.Services.BankAPI.GetPaymentMethod;

public interface IGetPaymentMethodOnBank
{
    Task<List<ResponseCardInfoJson>> GetPaymentMethod(string customerId);
}