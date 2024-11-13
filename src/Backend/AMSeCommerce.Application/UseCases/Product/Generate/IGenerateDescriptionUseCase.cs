namespace AMSeCommerce.Application.UseCases.Product.Generate;

public interface IGenerateDescriptionUseCase
{
    Task<string> Execute(string request);
}