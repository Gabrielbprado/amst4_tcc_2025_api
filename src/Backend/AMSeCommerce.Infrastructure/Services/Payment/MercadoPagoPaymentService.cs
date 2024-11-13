using AMSeCommerce.Communication.Request.Payment;
using AMSeCommerce.Communication.Response.Payment;
using AMSeCommerce.Domain.Services.Payment;
using MercadoPago.Client;
using MercadoPago.Client.Common;
using MercadoPago.Client.Payment;
using MercadoPago.Config;

namespace AMSeCommerce.Infrastructure.Services.Payment;

public class MercadoPagoPaymentService : IPaymentService
{
    public MercadoPagoPaymentService()
    {
        MercadoPagoConfig.AccessToken = "APP_USR-1464374085804434-110516-aed7e64e8aadc3b86b76762f783993bf-1108019351";
    }
    public async Task<ResponsePixJson> PixPayment(RequestCreatePixJson request)
    {
        
        var requestOptions = new RequestOptions();
        requestOptions.CustomHeaders.Add("x-idempotency-key", Guid.NewGuid().ToString());

        var requestToCreate = new PaymentCreateRequest
        {
            TransactionAmount = request.TransactionAmount,
            Description = request.Description,
            PaymentMethodId = "pix",
            Payer = new PaymentPayerRequest
            {
                Email = request.Payer.Email,
                FirstName = request.Payer.FirstName,
                LastName = request.Payer.LastName,
                Identification = new IdentificationRequest
                {
                    Type = "CPF",
                    Number = request.Payer.RequestIdentification.Number,
                },
            },
            NotificationUrl = "https://8d9c-2804-3ef4-2c36-1901-19ae-1ac5-a55d-fcca.ngrok-free.app/api/MercadoPago/webhook",
        };

        var client = new PaymentClient();
        MercadoPago.Resource.Payment.Payment payment = await client.CreateAsync(requestToCreate, requestOptions);
        return new ResponsePixJson
        {
            TransactionId = payment.Id!.Value,
            Description = payment.Description,
            Status = payment.Status,
            TransactionAmount = payment.TransactionAmount!.Value,
            QrCode = payment.PointOfInteraction!.TransactionData!.QrCode,
            QrCodeBase64 = payment.PointOfInteraction!.TransactionData!.QrCodeBase64,
            ExpirationDate = payment.DateOfExpiration!.Value.ToString("dd-MM-yyyy"),
            TicketUrl = payment.PointOfInteraction!.TransactionData!.TicketUrl,
        };
    }
    
    public async Task<ResponsePixJson> GetPayment(long id)
    {
        var client = new PaymentClient();
            MercadoPago.Resource.Payment.Payment payment = await client.GetAsync(id);
            return new ResponsePixJson
            {
                TransactionId = payment.Id!.Value,
                Description = payment.Description,
                Status = payment.Status,
                TransactionAmount = payment.TransactionAmount!.Value,
                QrCode = payment.PointOfInteraction!.TransactionData!.QrCode,
                QrCodeBase64 = payment.PointOfInteraction!.TransactionData!.QrCodeBase64,
                ExpirationDate = payment.DateOfExpiration!.Value.ToString("dd-MM-yyyy"),
            };
}
    }