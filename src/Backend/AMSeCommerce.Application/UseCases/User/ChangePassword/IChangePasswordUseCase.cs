using AMSeCommerce.Communication.Request.User;

namespace AMSeCommerce.Application.UseCases.User.ChangePassword;

public interface IChangePasswordUseCase
{
    Task Execute(RequestChangePasswordJson request);
}