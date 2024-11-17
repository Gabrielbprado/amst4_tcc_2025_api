using AMSeCommerce.Communication.Response.Product;
using AMSeCommerce.Domain.Contracts.Product;
using AMSeCommerce.Domain.Contracts.Storage;
using AMSeCommerce.Domain.Contracts.User;
using AutoMapper;

namespace AMSeCommerce.Application.UseCases.Product.GetBySeller;

public class GetProductBySellerUseCase(IProductReadOnlyRepository repository,IMapper mapper,IUserReadOnlyRepository readOnlyRepository,IBlobStorageService storageService) : IGetProductBySellerUseCase
{
    private readonly IProductReadOnlyRepository _repository = repository;
    private readonly IUserReadOnlyRepository _userReadOnlyRepository = readOnlyRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IBlobStorageService _blobStorageService = storageService;
    public async Task<IList<ResponseProductJson>> Execute(long id)
    {
        var products = await _repository.GetProductsBySeller(id);
        var response =  _mapper.Map<List<ResponseProductJson>>(products);

        foreach (var responseProduct in response)
        {
            var product = products.FirstOrDefault(n => n.Id == responseProduct.Id);
            
            var user = await _userReadOnlyRepository.GetById(product.UserIdentifier);
        }

        return response;
    }
}