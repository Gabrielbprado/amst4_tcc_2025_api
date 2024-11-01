using AMS_News.Communication.Response.User;

namespace AMSeCommerce.Application.UseCases.User.Profile;

public interface IGetProfileUserUseCase
{
    Task<ResponseUserProfileJson> Execute();
}
