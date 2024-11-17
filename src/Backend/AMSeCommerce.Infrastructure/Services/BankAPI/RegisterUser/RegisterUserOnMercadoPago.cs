using AMSeCommerce.Communication.Request.User;
using AMSeCommerce.Domain.Services.BankAPI.RegisterUser;
using MercadoPago.Client;
using MercadoPago.Client.Common;
using MercadoPago.Client.Customer;
using MercadoPago.Config;
using MercadoPago.Resource.Common;
using MercadoPago.Resource.Customer;

namespace AMSeCommerce.Infrastructure.Services.BankAPI.RegisterUser;

public class RegisterUserOnMercadoPago : IRegisterUserOnBank
{
    public RegisterUserOnMercadoPago()
    {
        MercadoPagoConfig.AccessToken = "APP_USR-1464374085804434-110516-aed7e64e8aadc3b86b76762f783993bf-1108019351";
    }
    public async Task<string> RegisterUser(RequestRegisterUserJson request)
    {
        var requestOptions = new RequestOptions();
        requestOptions.CustomHeaders.Add("x-idempotency-key", Guid.NewGuid().ToString());
        var customer = new CustomerRequest
        {
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Address = new CustomerDefaultAddressRequest
            {
                StreetName = "request.Address.StreetName",
                StreetNumber = 4,
                ZipCode = "15902178",
                Id = Guid.NewGuid().ToString(),
            },
            DefaultAddress = "Home",
            Description = "descr",
            DateRegistred = DateTime.Now, // Converte a data de registro se necessário
            DefaultCard = "None",
            Identification = new IdentificationRequest
            {
                Type = "CPF",
                Number = request.Cpf
            },
        };
            var customerClient = new CustomerClient();
            var response = await customerClient.CreateAsync(customer, requestOptions);
            return response.Id;
    }
}