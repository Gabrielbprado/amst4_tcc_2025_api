using AMS_News.Application.Login;
using AMS_News.Communication.Response.Token;
using AMS_News.Communication.Response.User;
using AMS_News.Domain.Contracts;
using AMS_News.Domain.Contracts.Token;
using AMSeCommerce.Communication.Request;
using AMSeCommerce.Domain.Contracts.User;
using AMSeCommerce.Exceptions;
using AMSeCommerce.Exceptions.BaseExceptions;

namespace AMSeCommerce.Application.UseCases.Login;

public class DoLoginUseCase(IPasswordEncrypter encrypter,IUserReadOnlyRepository repository,ITokenGenerator generator) : IDoLoginUseCase
{
    private readonly IPasswordEncrypter _encrypter = encrypter;
    private readonly IUserReadOnlyRepository _repository = repository;
    private readonly ITokenGenerator _tokenGenerator = generator;
    
    public async Task<ResponseRegisterUserJson> Execute(RequestLoginUserJson request)
    {
        var user = await _repository.GetByEmail(request.Email);
        var verify = user is not null && _encrypter.Verify(request.Password, user.Password) is true; 
        if (verify is false)
        {
            throw new InvalidLoginException(ErrorMessage.INVALID_LOGIN);
        }
        return new ResponseRegisterUserJson
        {
            FirstName = user.FirstName,
            Token = new ResponseTokenJson()
            {
                AccessToken = _tokenGenerator.Generate(user.UserIdentifier)
            }
        };
    }
}