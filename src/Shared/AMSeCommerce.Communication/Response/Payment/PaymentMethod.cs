namespace AMSeCommerce.Communication.Response.Payment;

public class PaymentMethod
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string PaymentTypeId { get; set; }
    public string Thumbnail { get; set; }
    public string SecureThumbnail { get; set; }
}