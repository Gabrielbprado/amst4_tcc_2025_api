using AMSeCommerce.Communication.Response.Payment;
using AMSeCommerce.Domain.Contracts.Token;
using AMSeCommerce.Domain.Services.BankAPI.GetPaymentMethod;

namespace AMSeCommerce.Application.UseCases.Order.GetPaymentMethod;

public class GetPaymentMethodUseCase(ILoggedUser loggedUser,IGetPaymentMethodOnBank getPaymentMethodOnBank) : IGetPaymentMethodUseCase
{
    private readonly ILoggedUser _loggedUser = loggedUser;
    private readonly IGetPaymentMethodOnBank _getPaymentMethodOnBank = getPaymentMethodOnBank;
    public async Task<List<ResponseCardInfoJson>> Execute()
    {
        var user = await _loggedUser.User();
        return await _getPaymentMethodOnBank.GetPaymentMethod(user.MercadoPagoUserId);
        
    }
}