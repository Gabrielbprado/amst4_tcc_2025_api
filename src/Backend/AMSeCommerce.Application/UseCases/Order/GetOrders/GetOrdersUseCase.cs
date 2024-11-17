using AMSeCommerce.Communication.Response.Order;
using AMSeCommerce.Communication.Response.Product;
using AMSeCommerce.Domain.Contracts.Order;
using AMSeCommerce.Domain.Contracts.Product;
using AMSeCommerce.Domain.Contracts.Token;
using AutoMapper;

namespace AMSeCommerce.Application.UseCases.Order.GetOrders;

public class GetOrdersUseCase(IOrderReadOnlyRepository orderReadOnlyRepository,IMapper mapper,IProductReadOnlyRepository productReadOnlyRepository,ILoggedUser loggedUser) : IGetOrdersUseCase
{
    private readonly IOrderReadOnlyRepository _orderReadOnlyRepository = orderReadOnlyRepository;
    private readonly IProductReadOnlyRepository _productReadOnlyRepository = productReadOnlyRepository;
    private readonly IMapper _mapper = mapper;
    private readonly ILoggedUser _loggedUser = loggedUser;
    public async Task<List<ResponseOrderJson>> Execute()
    {
        var user = await _loggedUser.User();
        var orders = await _orderReadOnlyRepository.GetOrders(user.Id);
        var products = new List<ResponseProductJson>();
        var response = _mapper.Map<List<ResponseOrderJson>>(orders);
        for (int i = 0; i < orders.Count; i++)
        {
            var product = await _productReadOnlyRepository.GetById(orders[i].ProductId);
            var responseProduct = new ResponseProductJson
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                CategoryId = product.CategoryId,
                StockQuantity = product.StockQuantity,
                Images = new List<ResponseProductImagesJson>()
                {
                    new ResponseProductImagesJson
                    {
                        ImageUrl = "teste",
                    }
                }
            };
            products.Add(responseProduct);

          response[i].Product = products;
        }
          return response;
        
    }
}