using AMS_News.Communication.Request.User;
using AMS_News.Communication.Response.User;
using AMSeCommerce.Communication.Request.Category;
using AMSeCommerce.Communication.Request.Product;
using AMSeCommerce.Communication.Response.Category;
using AMSeCommerce.Communication.Response.Product;
using AMSeCommerce.Domain.Entities;
using AutoMapper;

namespace AMSeCommerce.Application.Services.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<RequestRegisterUserJson,Customers>();
        CreateMap<Customers,RequestRegisterUserJson>();
        CreateMap<Customers, ResponseUserProfileJson>();
        CreateMap<RequestProductJson, Product>();
        CreateMap<Product, ResponseRegisteredProductJson>();
        CreateMap<RequestCategoryJson, Category>();
        CreateMap<Category, ResponseCategoryJson>();

    }    
}