namespace AMSeCommerce.Communication.Request.Address;

public class RequestAddressJson
{
    public string StreetName { get; set; } = string.Empty;
    public int StreetNumber { get; set; } 
    public string ZipCode { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Neighborhood { get; set; } = string.Empty;
}