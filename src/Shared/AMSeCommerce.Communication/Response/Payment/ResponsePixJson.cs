namespace AMSeCommerce.Communication.Response.Payment;

public class ResponsePixJson
{
    public long TransactionId { get; set; } 
    public decimal TransactionAmount { get; set; }
    public string Status { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string QrCode { get; set; } = string.Empty;
    public string QrCodeBase64 { get; set; } = string.Empty;
    public string ExpirationDate { get; set; } = string.Empty;
    public string TicketUrl { get; set; } = string.Empty;
}