// namespace: AMSeCommerce.Application.UseCases.Product.Register

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

namespace AMSeCommerce.Application.UseCases.Product.Register;

public class RegisterProductUseCase(
    IProductWriteOnlyRepository productRepository,
    IMapper mapper,
    IUnityOfWork unityOfWork,
    IBlobStorageService blob,
    ILoggedUser loggedUser,
    ICategoryReadOnlyRepository categoryReadOnlyRepository)
    : IRegisterProductUseCase
{
    private readonly IBlobStorageService _blob = blob;
    private readonly ILoggedUser _loggedUser = loggedUser;
    private readonly IMapper _mapper = mapper;
    private readonly IProductWriteOnlyRepository _productRepository = productRepository;
    private readonly IUnityOfWork _unityOfWork = unityOfWork;
    private readonly ICategoryReadOnlyRepository _categoryReadOnlyRepository = categoryReadOnlyRepository;

    public async Task<ResponseRegisteredProductJson> Execute(RequestProductJson request)
    {
        await Validate(request);
        var user = await _loggedUser.User();

        var product = _mapper.Map<Domain.Entities.Product>(request);
        product.UserIdentifier = user.Id;
        product.Category = await _categoryReadOnlyRepository.GetCategoryById(request.CategoryId);
        
      
            for (int i = 0; i < request.Images.Count; i++)
            {
               
                var productImage = new ProductImage
                {
                    Product = product,
                    ImageUrl = string.Empty,
                    ProductId = product.Id
                };
                
                if (request.Images is not null)
                {
                    var fileStream = request.Images[i].OpenReadStream();
                    (var isValidImage, var extension) = fileStream.ValidateAndGetImageExtension();

                    if (!isValidImage)
                        throw new ErrorOnValidatorException(new List<string> { "Only images are accepted" });
                    productImage.ImageUrl = $"{Guid.NewGuid()}{extension}";
                    if (i == 0)
                        productImage.IsMainImage = true;
                    await _blob.Upload(user,fileStream, productImage.ImageUrl);
                    
                    await _productRepository.AddProductImages(productImage);
                }
            }
            

        await _productRepository.AddProduct(product);
        await _unityOfWork.Commit();

        return new ResponseRegisteredProductJson {Name = product.Name };
    }

    private async Task Validate(RequestProductJson request)
    {
        var validator = new ProductValidator();
        var result = await validator.ValidateAsync(request);
        if (!result.IsValid)
            throw new ErrorOnValidatorException(result.Errors.Select(e => e.ErrorMessage).ToList());
    }
}