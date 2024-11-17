using AMS_News.Domain.Contracts;
using AMSeCommerce.Communication.Request.BankAPI;
using AMSeCommerce.Communication.Response.Payment;
using AMSeCommerce.Domain.Contracts.Order;

namespace AMSeCommerce.Application.UseCases.Order.UpdateStatus;

public class UpdateOrderUseCase(IOrderReadOnlyRepository orderReadOnlyRepository,IOrderWriteOnlyRepository orderWriteOnlyRepository,IUnityOfWork unityOfWork) : IUpdateOrderUseCase
{
    private readonly IOrderReadOnlyRepository _orderReadOnlyRepository = orderReadOnlyRepository;
    private readonly IOrderWriteOnlyRepository _orderWriteOnlyRepository = orderWriteOnlyRepository;
    private readonly IUnityOfWork _unityOfWork = unityOfWork;
    public async Task Execute(RequestChangeStatus pixJson)
    {
        var order = await _orderReadOnlyRepository.GetOrderByTransactionId(pixJson.TransactionId);
        order.Status = pixJson.Status;
        _orderWriteOnlyRepository.UpdateOrderStatus(order);
        await _unityOfWork.Commit();
    }
}