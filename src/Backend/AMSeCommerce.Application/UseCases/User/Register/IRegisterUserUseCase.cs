using AMS_News.Communication.Response.User;
using AMSeCommerce.Communication.Request.User;

namespace AMSeCommerce.Application.UseCases.User.Register;

public interface IRegisterUserUseCase
{
    Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson requestRegisterUserJson);
}