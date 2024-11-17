using AMS_News.Domain.Contracts;
using AMSeCommerce.Application.Extensions;
using AMSeCommerce.Communication.Request.Product;
using AMSeCommerce.Communication.Response.Product;
using AMSeCommerce.Domain.Contracts.Category;
using AMSeCommerce.Domain.Contracts.Product;
using AMSeCommerce.Domain.Contracts.Storage;
using AMSeCommerce.Domain.Contracts.Token;
using AMSeCommerce.Domain.Entities;
using AMSeCommerce.Exceptions.BaseExceptions;
using AutoMapper;

namespace AMSeCommerce.Application.UseCases.Product.Update;

public class UpdateProductUseCase(
    IProductWriteOnlyRepository productRepository,
    IMapper mapper,
    IUnityOfWork unityOfWork,
    IBlobStorageService blob,
    ILoggedUser loggedUser,
    ICategoryReadOnlyRepository categoryReadOnlyRepository,
    IProductReadOnlyRepository productReadOnlyRepository)
    : IUpdateProductUseCase
{
    private readonly IBlobStorageService _blob = blob;
    private readonly ILoggedUser _loggedUser = loggedUser;
    private readonly IMapper _mapper = mapper;
    private readonly IProductWriteOnlyRepository _productRepository = productRepository;
    private readonly IUnityOfWork _unityOfWork = unityOfWork;
    private readonly ICategoryReadOnlyRepository _categoryReadOnlyRepository = categoryReadOnlyRepository;
    private readonly IProductReadOnlyRepository _productReadOnlyRepository = productReadOnlyRepository;

    public async Task Execute(RequestProductJson request)
    {
        var user = await _loggedUser.User();

        var product = await _productReadOnlyRepository.GetById(request.ProductId.Value);
      

        product.UserIdentifier = user.Id;
        product.Category = await _categoryReadOnlyRepository.GetCategoryById(request.CategoryId);
        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;
        product.StockQuantity = request.StockQuantity;
        product.CategoryId = request.CategoryId;

        var productImages = await _productReadOnlyRepository.GetProductImages(product.Id);

        // Se necessário, exclua imagens antigas ou faça uma atualização.
        foreach (var productImage in productImages)
        {
            // Lógica para excluir ou marcar imagens antigas como inativas, se necessário
        }

        if (request.Images != null && request.Images.Any())
        {
            foreach (var image in request.Images)
            {
                var fileStream = image.OpenReadStream();
                (var isValidImage, var extension) = fileStream.ValidateAndGetImageExtension();

                if (!isValidImage)
                    throw new ErrorOnValidatorException(new List<string> { "Somente imagens são aceitas" });

                var productImage = new ProductImage
                {
                    ProductId = product.Id,
                    ImageUrl = $"{Guid.NewGuid()}{extension}",
                    IsMainImage = false  // Ajuste conforme necessário
                };

                await _blob.Upload(user, fileStream, productImage.ImageUrl);
                 _productRepository.UpdateProductImages(productImage); // Atualiza ou adiciona as novas imagens
            }
        }

         _productRepository.UpdateProduct(product);
        await _unityOfWork.Commit();
    }
}