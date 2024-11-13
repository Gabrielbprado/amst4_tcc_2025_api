using AMSeCommerce.Communication.Request.ShoppingCart;
using AMSeCommerce.Domain.Contracts.ShoppingCart;
using AutoMapper;

namespace AMSeCommerce.Application.UseCases.ShoppingCart;

public class AddItemToCartUseCase(IShoppingCartWriteOnlyRepository cartWriteOnlyRepository,IMapper mapper) : IAddItemToCartUseCase
{
    private readonly IShoppingCartWriteOnlyRepository _cartWriteOnlyRepository = cartWriteOnlyRepository;
    private readonly IMapper _mapper = mapper;
    public async Task Execute(RequestAddItemToCartJson request)
    {
        var shoppingCart = _mapper.Map<Domain.Entities.ShoppingCart>(request);
        await _cartWriteOnlyRepository.AddItemToCart(shoppingCart);
    }
}