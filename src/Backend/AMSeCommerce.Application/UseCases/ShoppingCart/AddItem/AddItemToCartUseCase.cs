using AMS_News.Domain.Contracts;
using AMSeCommerce.Communication.Request.ShoppingCart;
using AMSeCommerce.Domain.Contracts.ShoppingCart;
using AMSeCommerce.Domain.Contracts.Token;
using AutoMapper;

namespace AMSeCommerce.Application.UseCases.ShoppingCart.AddItem;

public class AddItemToCartUseCase(IShoppingCartWriteOnlyRepository cartWriteOnlyRepository,IMapper mapper,ILoggedUser loggedUser,IUnityOfWork unityOfWork,IShoppingCartReadOnlyRepository shoppingCartReadOnlyRepository) : IAddItemToCartUseCase
{
    private readonly IShoppingCartWriteOnlyRepository _cartWriteOnlyRepository = cartWriteOnlyRepository;
    private readonly IMapper _mapper = mapper;
    private readonly ILoggedUser _loggedUser = loggedUser;
    private readonly IUnityOfWork _unityOfWork = unityOfWork;
    private readonly IShoppingCartReadOnlyRepository _readOnlyRepository = shoppingCartReadOnlyRepository;
    public async Task Execute(RequestAddItemToCartJson request)
    {
        var shoppingCart = _mapper.Map<Domain.Entities.ShoppingCart>(request);
        var user = await _loggedUser.User();
        shoppingCart.UserId = user.Id;
        var existShoppingCart = await _readOnlyRepository.GetProduct(request.ProductId);
        if (existShoppingCart is not null)
        {
            existShoppingCart.Quantity++;
             _cartWriteOnlyRepository.UpdateItemToCart(existShoppingCart);
             await _unityOfWork.Commit();
            return;
        }
        await _cartWriteOnlyRepository.AddItemToCart(shoppingCart);
        await _unityOfWork.Commit();
    }
}