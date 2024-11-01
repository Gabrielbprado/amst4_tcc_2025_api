using AMS_News.Domain.Contracts;

namespace AMSeCommerce.Infrastructure.Security.Encrypter;

public class PasswordEncrypter : IPasswordEncrypter
{
    public string Encrypt(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool Verify(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}