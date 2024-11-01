using AMS_News.Communication.Response.User;
using AMSeCommerce.Domain.Contracts.Token;
using AutoMapper;

namespace AMSeCommerce.Application.UseCases.User.Profile;

public class GetProfileUserUseCase(ILoggedUser loggedUser, IMapper mapper) : IGetProfileUserUseCase
{
    private readonly IMapper _mapper = mapper;
    private readonly ILoggedUser _loggedUser = loggedUser;
    public async Task<ResponseUserProfileJson> Execute()
    {
        var user = await _loggedUser.User();
        return _mapper.Map<ResponseUserProfileJson>(user);
    }
}
