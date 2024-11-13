using AMSeCommerce.Communication.Request.User;

namespace AMSeCommerce.Application.UseCases.User.Update;

public interface IUpdateUserUseCase
{
    Task Execute(RequestUpdateUserJson request);
}