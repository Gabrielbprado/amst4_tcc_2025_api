using AMSeCommerce.Communication.Response.Category;
using AMSeCommerce.Domain.Contracts.Category;
using AutoMapper;

namespace AMSeCommerce.Application.UseCases.Category.Get;

public class GetAllCategoryUseCase(ICategoryReadOnlyRepository categoryReadOnlyRepository,IMapper mapper) : IGetAllCategoryUseCase
{
    private readonly ICategoryReadOnlyRepository _categoryReadOnlyRepository = categoryReadOnlyRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<IList<ResponseCategoryJson>> Execute()
    {
        var categories = await _categoryReadOnlyRepository.GetAllCategories();
        return _mapper.Map<IList<ResponseCategoryJson>>(categories);
    }
}