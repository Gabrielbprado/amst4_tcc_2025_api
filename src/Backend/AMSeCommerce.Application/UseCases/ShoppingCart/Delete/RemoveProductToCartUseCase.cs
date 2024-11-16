using AMS_News.Domain.Contracts;
using AMSeCommerce.Domain.Contracts.ShoppingCart;

namespace AMSeCommerce.Application.UseCases.ShoppingCart.Delete;

public class RemoveProductToCartUseCase(IShoppingCartWriteOnlyRepository writeOnlyRepository,IUnityOfWork unityOfWork) : IRemoveProductToCartUseCase
{
    private readonly IShoppingCartWriteOnlyRepository _writeOnlyRepository = writeOnlyRepository;
    private readonly IUnityOfWork _unityOfWork = unityOfWork;
    public async Task Execute(long id)
    {
       
        _writeOnlyRepository.RemoveProduct(id);
        await _unityOfWork.Commit();
    }
}