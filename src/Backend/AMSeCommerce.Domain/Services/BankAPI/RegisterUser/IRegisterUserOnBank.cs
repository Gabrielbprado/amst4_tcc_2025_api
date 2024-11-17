using AMSeCommerce.Communication.Request.User;

namespace AMSeCommerce.Domain.Services.BankAPI.RegisterUser;

public interface IRegisterUserOnBank
{
    Task<string> RegisterUser(RequestRegisterUserJson request);
}