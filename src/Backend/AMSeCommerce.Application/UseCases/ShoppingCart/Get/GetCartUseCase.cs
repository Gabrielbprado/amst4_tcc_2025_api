using AMSeCommerce.Communication.Response.Product;
using AMSeCommerce.Domain.Contracts.Product;
using AMSeCommerce.Domain.Contracts.ShoppingCart;
using AMSeCommerce.Domain.Contracts.Storage;
using AMSeCommerce.Domain.Contracts.Token;
using AutoMapper;

namespace AMSeCommerce.Application.UseCases.ShoppingCart.Get;

public class GetCartUseCase(IShoppingCartReadOnlyRepository readOnlyRepository,IProductReadOnlyRepository productReadOnlyRepository,ILoggedUser loggedUser,IMapper mapper,IBlobStorageService blobStorageService) : IGetCartUseCase
{
    
    private readonly IShoppingCartReadOnlyRepository _readOnlyRepository = readOnlyRepository;
    private readonly IProductReadOnlyRepository _productReadOnlyRepository = productReadOnlyRepository;
    private readonly ILoggedUser _loggedUser = loggedUser;
    private readonly IMapper _mapper = mapper;
    private readonly IBlobStorageService _blobStorageService = blobStorageService;
    public async Task<IList<ResponseProductJson>> Execute()
    {
        var user = await _loggedUser.User();
        var carts = await _readOnlyRepository.GetCart(user.Id);
        var products = new List<Domain.Entities.Product>();
        var productImages = new List<Domain.Entities.ProductImage>();
        foreach (var cart in carts)
        {
            var product = await _productReadOnlyRepository.GetById(cart.ProductId);
            productImages = await _productReadOnlyRepository.GetProductImages(product.Id);
            products.Add(product);
        }
        
        var responseProduct =  _mapper.Map<IList<ResponseProductJson>>(products);
        for (int i = 0; i<responseProduct.Count; i++)
        {
            responseProduct[i].Images[i].ImageUrl = await _blobStorageService.GetUri(user, productImages[i].ImageUrl);

        }
        return responseProduct;
    }
}