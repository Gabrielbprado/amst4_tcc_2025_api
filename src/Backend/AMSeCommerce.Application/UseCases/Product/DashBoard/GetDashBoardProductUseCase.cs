using AMSeCommerce.Communication.Response.Product;
using AMSeCommerce.Domain.Contracts.Category;
using AMSeCommerce.Domain.Contracts.Product;
using AMSeCommerce.Domain.Contracts.Storage;
using AMSeCommerce.Domain.Contracts.User;
using AMSeCommerce.Domain.Entities;
using AutoMapper;

namespace AMSeCommerce.Application.UseCases.Product.DashBoard;

public class GetDashBoardProductUseCase(IProductReadOnlyRepository repository,
    IMapper mapper,
    IUserReadOnlyRepository readOnlyRepository,
    IBlobStorageService storageService,
    ICategoryReadOnlyRepository categoryReadOnlyRepository) : IGetDashBoardProductUseCase
{
    private readonly IProductReadOnlyRepository _repository = repository;
    private readonly IUserReadOnlyRepository _userReadOnlyRepository = readOnlyRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IBlobStorageService _blobStorageService = storageService;
    private readonly ICategoryReadOnlyRepository _categoryReadOnlyRepository = categoryReadOnlyRepository;
    public async Task<List<ResponseShortProductJson>> Execute()
    {
        var products = await _repository.GetProducts();
        
        var response =  _mapper.Map<List<ResponseShortProductJson>>(products);
        foreach (var responseProduct in response)
        {
            
            var productImages = await _repository.GetProductImages(responseProduct.Id);
            var mainImage = productImages.FirstOrDefault(n => n.IsMainImage);
            var product = products.FirstOrDefault(n => n.Id == responseProduct.Id);
                var user = await _userReadOnlyRepository.GetById(product.UserIdentifier);
                responseProduct.ImageUrl = await _blobStorageService.GetUri(user, mainImage.ImageUrl);
        }
        for (int i = 0; i < response.Count; i++)
        {
            response[i].ParentCategoryId = products[i].Category.ParentCategories[0].Id;
        }
        return response;
    }
}