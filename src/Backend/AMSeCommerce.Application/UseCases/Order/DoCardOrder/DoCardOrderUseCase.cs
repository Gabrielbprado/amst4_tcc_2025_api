using AMS_News.Domain.Contracts;
using AMSeCommerce.Communication.Request.Order;
using AMSeCommerce.Communication.Request.Payment;
using AMSeCommerce.Communication.Response.Payment;
using AMSeCommerce.Domain.Contracts.Order;
using AMSeCommerce.Domain.Contracts.Product;
using AMSeCommerce.Domain.Contracts.Token;
using AMSeCommerce.Domain.Services.BankAPI.Payment;

namespace AMSeCommerce.Application.UseCases.Order.DoCardOrder;

public class DoCardOrderUseCase(IOrderWriteOnlyRepository repository,ILoggedUser logged,IUnityOfWork unityOfWork,IPaymentService paymentService,IProductReadOnlyRepository productReadOnlyRepository) : IDoCardOrderUseCase
{
    private readonly IOrderWriteOnlyRepository _repository = repository;
    private readonly ILoggedUser _logged = logged;
    private readonly IUnityOfWork _unityOfWork = unityOfWork;
    private readonly IPaymentService _paymentService = paymentService;
    private readonly IProductReadOnlyRepository _productReadOnlyRepository = productReadOnlyRepository;
    public async Task<ResponseCardJson> Execute(RequestOrderJson request)
    {
        var product = await _productReadOnlyRepository.GetById(request.ProductId);
        var order = new Domain.Entities.Order
        {
            ProductId = product.Id,
            TransactionAmount = product.Price,
            Description = product.Name,
            ShippingAddress = request.ShippingAddress,
            Status = request.Status,
        };
        order.TransactionAmount = product.Price;
        order.Description = product.Name;
        var user = await _logged.User();
        order.UserId = user.Id;
        var requestPayment = new RequestCreateCardPaymentJson
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
        var responseCard = await _paymentService.CreditCardPayment(requestPayment);
        order.PaymentMethodId = responseCard.TransactionId;
        await _repository.CreateOrder(order);
        await _unityOfWork.Commit();
        return responseCard;
        
    }
}