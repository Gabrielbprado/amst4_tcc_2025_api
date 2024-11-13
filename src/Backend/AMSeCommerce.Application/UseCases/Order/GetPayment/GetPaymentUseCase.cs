using AMSeCommerce.Communication.Response.Payment;
using AMSeCommerce.Domain.Services.Payment;

namespace AMSeCommerce.Application.UseCases.Order.GetPayment;

public class GetPaymentUseCase(IPaymentService service) : IGetPaymentUseCase
{
    private readonly IPaymentService _service = service;
    public async Task<ResponsePixJson> Execute(long id)
    {
        return await _service.GetPayment(id);
    }
}