using AMS_News.Communication.Response.User;
using AMSeCommerce.Communication.Request.Address;
using AMSeCommerce.Communication.Request.Category;
using AMSeCommerce.Communication.Request.Product;
using AMSeCommerce.Communication.Request.ShoppingCart;
using AMSeCommerce.Communication.Request.User;
using AMSeCommerce.Communication.Response.Address;
using AMSeCommerce.Communication.Response.Category;
using AMSeCommerce.Communication.Response.Order;
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
        CreateMap<RequestProductJson, Product>()
            .ForMember(dest => dest.Images, opt => opt.Ignore());
        CreateMap<Product, ResponseRegisteredProductJson>();
        CreateMap<RequestCategoryJson, Category>();
        CreateMap<Category, ResponseCategoryJson>();
        CreateMap<Product, ResponseShortProductJson>();
        CreateMap<Product, ResponseProductJson>();
        CreateMap<RequestAddItemToCartJson, ShoppingCart>();
        CreateMap<ShoppingCart,RequestAddItemToCartJson>();
        CreateMap<ProductImage, ResponseProductImagesJson>();
        CreateMap<Order, ResponseOrderJson>();
        CreateMap<RequestAddressJson,Address>();
        CreateMap<Address,ResponseAddressJson>();

    }    
}