using AMS_News.Communication.Request.User;
using AMS_News.Communication.Response.User;

namespace AMSeCommerce.Application.UseCases.User.Register;

public interface IRegisterUserUseCase
{
    Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson requestRegisterUserJson);
}