using AMSeCommerce.Communication.Response.Home;
using AMSeCommerce.Domain.Contracts.Home;
using AMSeCommerce.Domain.Entities;
using AutoMapper;

namespace AMSeCommerce.Application.UseCases.Home;

public class HomeSectionsUseCase(IHomeSectionReadOnlyRepository repository,IMapper mapper) : IHomeSectionsUseCase
{
    private readonly IHomeSectionReadOnlyRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<ResponseHomeSectionJson>> GetHomeSections()
    {
        var homeSections =  await _repository.GetHomeSections();
        var responseHomeSection =  _mapper.Map<List<ResponseHomeSectionJson>>(homeSections);
        for (int i = 0; i < responseHomeSection.Count; i++)
        {
            Console.WriteLine(responseHomeSection[i].ParentCategoryId);
            responseHomeSection[i].ParentCategoryId = homeSections[i].Category.ParentCategories[0].Id;
            responseHomeSection[i].ImageUrls = homeSections[i].HomeSectionImages.Select(x => x.ImageUrl).ToList();
        }
        
        return responseHomeSection;
    }

}