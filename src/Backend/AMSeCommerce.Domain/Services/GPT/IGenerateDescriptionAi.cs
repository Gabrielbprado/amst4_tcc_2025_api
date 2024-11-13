namespace AMSeCommerce.Domain.Services.GPT;

public interface IGenerateDescriptionAi
{
    Task<string> GenerateDescription(string request);

}