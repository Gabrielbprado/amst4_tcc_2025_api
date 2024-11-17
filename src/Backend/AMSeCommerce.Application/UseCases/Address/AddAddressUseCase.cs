using AMS_News.Domain.Contracts;
using AMSeCommerce.Communication.Request.Address;
using AMSeCommerce.Communication.Response.Address;
using AMSeCommerce.Domain.Contracts.Address;
using AMSeCommerce.Domain.Contracts.Token;
using AutoMapper;

namespace AMSeCommerce.Application.UseCases.Address;

public class AddAddressUseCase(ILoggedUser loggedUser,IUnityOfWork unityOfWork, IAddressWriteOnlyRepository addressWriteOnlyRepository,IMapper mapper) : IAddAddressUseCase
{
    private readonly ILoggedUser _loggedUser = loggedUser;
    private readonly IAddressWriteOnlyRepository _addressWriteOnlyRepository = addressWriteOnlyRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IUnityOfWork _unityOfWork = unityOfWork;
    public async Task<ResponseAddressJson> Execute(RequestAddressJson request)
    {
        var user = await _loggedUser.User();
        var address = _mapper.Map<Domain.Entities.Address>(request);
        address.UserId = user.Id;
        await _addressWriteOnlyRepository.AddAsync(address);
        await _unityOfWork.Commit();
        return _mapper.Map<ResponseAddressJson>(address);
    }
}