using AMS_News.Communication.Response.Token;

namespace AMS_News.Communication.Response.User;

public class ResponseRegisterUserJson
{
    public string FirstName { get; set; } = string.Empty;
    public ResponseTokenJson Token { get; set; } = null!;
}
