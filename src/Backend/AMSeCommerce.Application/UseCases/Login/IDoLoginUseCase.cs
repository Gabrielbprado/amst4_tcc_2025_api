using AMS_News.Communication.Response.User;
using AMSeCommerce.Communication.Request;

namespace AMS_News.Application.Login;

public interface IDoLoginUseCase
{
    Task<ResponseRegisterUserJson> Execute(RequestLoginUserJson request);
}