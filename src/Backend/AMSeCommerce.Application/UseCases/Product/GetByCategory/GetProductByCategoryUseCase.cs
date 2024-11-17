using AMSeCommerce.Communication.Response.Product;
using AMSeCommerce.Domain.Contracts.Category;
using AMSeCommerce.Domain.Contracts.Product;
using AMSeCommerce.Domain.Contracts.Storage;
using AMSeCommerce.Domain.Contracts.User;
using AutoMapper;

namespace AMSeCommerce.Application.UseCases.Product.GetByCategory;

public class GetProductByCategoryUseCase(IProductReadOnlyRepository productReadOnly,IMapper mapper,IUserReadOnlyRepository userReadOnlyRepository,IBlobStorageService blobStorageService) : IGetProductByCategoryUseCase
{
    private readonly IProductReadOnlyRepository _productReadOnlyRepository = productReadOnly;
    private readonly IUserReadOnlyRepository _userReadOnlyRepository = userReadOnlyRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IBlobStorageService _blobStorageService = blobStorageService;
    public async Task<IList<ResponseShortProductJson>> Execute(long categoryId)
    {
        var products = await _productReadOnlyRepository.GetProductsByCategory(categoryId);
        var response = _mapper.Map<IList<ResponseShortProductJson>>(products);
        foreach (var responseProduct in response)
        {
            
            var productImages = await _productReadOnlyRepository.GetProductImages(responseProduct.Id);
            var mainImage = productImages.FirstOrDefault(n => n.IsMainImage);
            var product = products.FirstOrDefault(n => n.Id == responseProduct.Id);
            var user = await _userReadOnlyRepository.GetById(product.UserIdentifier);
            responseProduct.ImageUrl = await _blobStorageService.GetUri(user, mainImage.ImageUrl);
        }
        return response;
    }
}