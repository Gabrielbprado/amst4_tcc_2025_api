using AMS_News.Domain.Contracts;
using AMSeCommerce.Communication.Request.Category;
using AMSeCommerce.Communication.Response.Category;
using AMSeCommerce.Domain.Contracts.Category;
using AutoMapper;

namespace AMSeCommerce.Application.UseCases.Category.Register;

public class RegisterCategoryUseCase(
    ICategoryWriteOnlyRepository writeOnlyRepository,
    IMapper mapper,
    IUnityOfWork unityOfWork,
    ICategoryReadOnlyRepository readOnlyRepository)
    : IRegisterCategoryUseCase
{
    private readonly ICategoryWriteOnlyRepository _writeOnlyRepository = writeOnlyRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IUnityOfWork _unityOfWork = unityOfWork;
    private readonly ICategoryReadOnlyRepository _readOnlyRepository = readOnlyRepository;

    public async Task<ResponseCategoryJson> Execute(RequestCategoryJson request)
    {
        var category = _mapper.Map<Domain.Entities.Category>(request);

        if (request.ParentCategoryId.HasValue)
        {
            var parentCategory = await _readOnlyRepository.GetParentCategoryById(request.ParentCategoryId.Value);
            if (parentCategory == null)
                throw new Exception("Parent category not found");
            
            category.ParentCategory = parentCategory;
        }

        await _writeOnlyRepository.AddCategory(category);
        await _unityOfWork.Commit();

        return _mapper.Map<ResponseCategoryJson>(category);
    }
}