using AMSeCommerce.Communication.Request.Payment;
using AMSeCommerce.Communication.Response.Payment;

namespace AMSeCommerce.Domain.Services.Payment;

public interface IPaymentService
{
    Task<ResponsePixJson> PixPayment(RequestCreatePixJson request);    
    Task<ResponsePixJson> GetPayment(long id);
}