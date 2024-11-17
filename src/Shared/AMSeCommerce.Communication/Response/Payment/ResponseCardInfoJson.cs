using Newtonsoft.Json;

namespace AMSeCommerce.Communication.Response.Payment;

public class ResponseCardInfoJson
{
    public Cardholder Cardholder { get; set; }
    public string CustomerId { get; set; }
    [JsonProperty("first_six_digits")]
    public string FirstSixDigits { get; set; }

    [JsonProperty("last_four_digits")]
    public string LastFourDigits { get; set; }

    [JsonProperty("expiration_month")]
    public int ExpirationMonth { get; set; }

    [JsonProperty("expiration_year")]
    public int ExpirationYear { get; set; }
    public Issuer Issuer { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
}