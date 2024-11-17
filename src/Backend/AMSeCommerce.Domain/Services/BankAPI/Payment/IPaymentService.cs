using AMSeCommerce.Communication.Request.Payment;
using AMSeCommerce.Communication.Response.Payment;

namespace AMSeCommerce.Domain.Services.BankAPI.Payment;

public interface IPaymentService
{
    Task<ResponsePixJson> PixPayment(RequestCreatePixJson request);    
    Task<ResponseBoletoJson> BoletoPayment(RequestCreateBoletoJson request);
    Task<ResponseCardJson> CreditCardPayment(RequestCreateCardPaymentJson request);
    Task<ResponsePixJson> GetPayment(long id);
}