using AMSeCommerce.Communication.Response.Product;
using AMSeCommerce.Domain.Contracts.Product;
using AMSeCommerce.Domain.Contracts.Storage;
using AMSeCommerce.Domain.Contracts.User;
using AutoMapper;

namespace AMSeCommerce.Application.UseCases.Product.GetById;

public class GetByIdProductUseCase(IProductReadOnlyRepository readOnlyRepository,IMapper mapper,IBlobStorageService storageService,IUserReadOnlyRepository userReadOnlyRepository) : IGetByIdProductUseCase
{
    private readonly IProductReadOnlyRepository _readOnlyRepository = readOnlyRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IBlobStorageService _blobStorageService = storageService;
    private readonly IUserReadOnlyRepository _userReadOnlyRepository = userReadOnlyRepository;
    public async Task<ResponseProductJson> Execute(long id)
    {
        var product = await _readOnlyRepository.GetById(id);
        var user = await _userReadOnlyRepository.GetById(product.UserIdentifier);
        var response = _mapper.Map<ResponseProductJson>(product);
        response.ImageUrl = await _blobStorageService.GetUri(user, product.ImageIdentifier);
        return response;
    }
}