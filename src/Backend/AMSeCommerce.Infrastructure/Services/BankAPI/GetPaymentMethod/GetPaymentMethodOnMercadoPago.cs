using System.Net.Http.Headers;
using AMSeCommerce.Communication.Response.Payment;
using AMSeCommerce.Domain.Services.BankAPI.GetPaymentMethod;
using MercadoPago.Config;
using Newtonsoft.Json;

namespace AMSeCommerce.Infrastructure.Services.BankAPI.GetPaymentMethod
{
    public class GetPaymentMethodOnMercadoPago : IGetPaymentMethodOnBank
    {
        private static readonly HttpClient _httpClient = new();
        
        public GetPaymentMethodOnMercadoPago()
        {
            MercadoPagoConfig.AccessToken = "APP_USR-1464374085804434-110516-aed7e64e8aadc3b86b76762f783993bf-1108019351";
        }

        public async Task<List<ResponseCardInfoJson>> GetPaymentMethod(string customerId)
        {
            string url = $"https://api.mercadopago.com/v1/customers/{customerId}/cards";
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", "APP_USR-1464374085804434-110516-aed7e64e8aadc3b86b76762f783993bf-1108019351");

            var response = await _httpClient.GetAsync(url);

            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<ResponseCardInfoJson>>(responseString);

        }
    }
}