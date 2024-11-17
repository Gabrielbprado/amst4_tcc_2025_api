using Microsoft.AspNetCore.Http;

namespace AMSeCommerce.Communication.Request.Product;

public class RequestImageJson
{
    public IFormFile Files {get;set; } = null!;
}