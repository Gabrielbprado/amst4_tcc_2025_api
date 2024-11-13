using AMS_News.Domain.Contracts;
using AMSeCommerce.Communication.Request.Order;
using AMSeCommerce.Communication.Request.Payment;
using AMSeCommerce.Communication.Response.Payment;
using AMSeCommerce.Domain.Contracts.Order;
using AMSeCommerce.Domain.Contracts.Product;
using AMSeCommerce.Domain.Contracts.Token;
using AMSeCommerce.Domain.Services.Payment;
using AutoMapper;

namespace AMSeCommerce.Application.UseCases.Order.DoOrder;

public class DoOrderUseCase(IOrderWriteOnlyRepository repository,IMapper mapper,ILoggedUser logged,IUnityOfWork unityOfWork,IPaymentService paymentService,IProductReadOnlyRepository productReadOnlyRepository) : IDoOrderUseCase
{
    private readonly IOrderWriteOnlyRepository _repository = repository;
    private readonly IMapper _mapper = mapper;
    private readonly ILoggedUser _logged = logged;
    private readonly IUnityOfWork _unityOfWork = unityOfWork;
    private readonly IPaymentService _paymentService = paymentService;
    private readonly IProductReadOnlyRepository _productReadOnlyRepository = productReadOnlyRepository;
    
    public async Task<ResponsePixJson> Execute(RequestOrderJson request)
    {
        var product = await _productReadOnlyRepository.GetById(request.ProductId);
        var order = new Domain.Entities.Order
        {
            TransactionAmount = product.Price,
            Description = product.Name,
            ShippingAddress = request.ShippingAddress,
            Status = request.Status,
        };
        order.TransactionAmount = product.Price;
        order.Description = product.Name;
        var user = await _logged.User();
        order.UserId = user.Id;
        var requestPix = new RequestCreatePixJson
        {
            TransactionAmount = order.TransactionAmount,
            Description = order.Description,
            Payer = new RequestPaymentPayer
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                RequestIdentification = new RequestIdentification
                {
                    Number = user.Cpf,
                },
            },
        };
        var responsePix = await _paymentService.PixPayment(requestPix);
        order.PaymentMethodId = responsePix.TransactionId;
        await _repository.CreateOrder(order);
        await _unityOfWork.Commit();
        return responsePix;
    }
}