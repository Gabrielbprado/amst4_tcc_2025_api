using AMSeCommerce.Communication.Request.Payment;
using AMSeCommerce.Communication.Response.Payment;
using AMSeCommerce.Domain.Services.BankAPI.Payment;
using MercadoPago.Client;
using MercadoPago.Client.Common;
using MercadoPago.Client.Payment;
using MercadoPago.Config;

namespace AMSeCommerce.Infrastructure.Services.BankAPI.Payment;

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
            NotificationUrl = "https://f117-2804-3ef4-2c36-1901-3155-d6b8-385a-74a0.ngrok-free.app/webhook",
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

    public async Task<ResponseBoletoJson> BoletoPayment(RequestCreateBoletoJson request)
    {
        var requestOptions = new RequestOptions();
        string idempotencyKey = Guid.NewGuid().ToString(); 
        requestOptions.CustomHeaders.Add("x-idempotency-key", idempotencyKey);

        var paymentRequest = new PaymentCreateRequest
        {
            TransactionAmount = Convert.ToDecimal(request.TransactionAmount), 
            Description = request.Description, 
            PaymentMethodId = "bolbradesco", 
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
                Address = new PaymentPayerAddressRequest
                {
                    ZipCode = request.Address.ZipCode, 
                    StreetName = request.Address.StreetName, 
                    City = request.Address.City, 
                    StreetNumber = request.Address.StreetNumber, 
                    Neighborhood = request.Address.Neighborhood, 
                    FederalUnit = request.Address.FederalUnit, 
                }
            },
        };

        var client = new PaymentClient();
        MercadoPago.Resource.Payment.Payment payment = await client.CreateAsync(paymentRequest, requestOptions);
        Console.WriteLine(payment.TransactionDetails.ExternalResourceUrl);

        return new ResponseBoletoJson
        {
            TransactionId = payment.Id!.Value,
            TicketUrl = payment.TransactionDetails.ExternalResourceUrl!,
        };
    }

    public async Task<ResponseCardJson> CreditCardPayment(RequestCreateCardPaymentJson request)
    {
        var requestOptions = new RequestOptions();
        requestOptions.CustomHeaders.Add("x-idempotency-key", Guid.NewGuid().ToString());
        var paymentRequest = new PaymentCreateRequest
        {
            TransactionAmount = request.TransactionAmount,
            Token = request.CardToken,
            Description = request.Description,
            Installments = 1,
            PaymentMethodId = request.Brand,
            Payer = new PaymentPayerRequest
            {
                Email = request.Payer.Email,
                Identification = new IdentificationRequest
                {
                    Type = "CPF",
                    Number = request.Payer.RequestIdentification.Number,
                },
            },
        };
 
        var client = new PaymentClient();
        MercadoPago.Resource.Payment.Payment payment = await client.CreateAsync(paymentRequest, requestOptions);
        Console.WriteLine(payment.Status);
        Console.WriteLine(payment.TransactionDetails.ExternalResourceUrl);
        return new ResponseCardJson
        {
            TransactionId = payment.Id!.Value,
            Status = payment.Status,
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