using System.Reflection;
using AMS_News.Application.Login;
using AMS_News.Domain.Contracts;
using AMS_News.Domain.Contracts.Token;
using AMSeCommerce.Application.Services.AutoMapper;
using AMSeCommerce.Application.UseCases.Address;
using AMSeCommerce.Application.UseCases.Category;
using AMSeCommerce.Application.UseCases.Category.Get;
using AMSeCommerce.Application.UseCases.Category.Register;
using AMSeCommerce.Application.UseCases.Login;
using AMSeCommerce.Application.UseCases.Order.DoBoletoOrder;
using AMSeCommerce.Application.UseCases.Order.DoCardOrder;
using AMSeCommerce.Application.UseCases.Order.DoPixOrder;
using AMSeCommerce.Application.UseCases.Order.GetOrders;
using AMSeCommerce.Application.UseCases.Order.GetPayment;
using AMSeCommerce.Application.UseCases.Product;
using AMSeCommerce.Application.UseCases.Product.DashBoard;
using AMSeCommerce.Application.UseCases.Product.Generate;
using AMSeCommerce.Application.UseCases.Product.GetByCategory;
using AMSeCommerce.Application.UseCases.Product.GetById;
using AMSeCommerce.Application.UseCases.Product.GetBySeller;
using AMSeCommerce.Application.UseCases.Product.Register;
using AMSeCommerce.Application.UseCases.ShoppingCart.AddItem;
using AMSeCommerce.Application.UseCases.ShoppingCart.Delete;
using AMSeCommerce.Application.UseCases.ShoppingCart.Get;
using AMSeCommerce.Application.UseCases.User.ChangePassword;
using AMSeCommerce.Application.UseCases.User.Profile;
using AMSeCommerce.Application.UseCases.User.Register;
using AMSeCommerce.Application.UseCases.User.Update;
using AMSeCommerce.Domain.Contracts.Address;
using AMSeCommerce.Domain.Contracts.Category;
using AMSeCommerce.Domain.Contracts.Order;
using AMSeCommerce.Domain.Contracts.Product;
using AMSeCommerce.Domain.Contracts.ShoppingCart;
using AMSeCommerce.Domain.Contracts.Storage;
using AMSeCommerce.Domain.Contracts.Token;
using AMSeCommerce.Domain.Contracts.User;
using AMSeCommerce.Domain.Entities;
using AMSeCommerce.Domain.Services.BankAPI.Payment;
using AMSeCommerce.Domain.Services.BankAPI.RegisterUser;
using AMSeCommerce.Domain.Services.GPT;
using AMSeCommerce.Infrastructure.Data;
using AMSeCommerce.Infrastructure.Repositories;
using AMSeCommerce.Infrastructure.Security.Encrypter;
using AMSeCommerce.Infrastructure.Security.Token.Access.Generate;
using AMSeCommerce.Infrastructure.Security.Token.Access.Validate;
using AMSeCommerce.Infrastructure.Services.BankAPI.Payment;
using AMSeCommerce.Infrastructure.Services.BankAPI.RegisterUser;
using AMSeCommerce.Infrastructure.Services.GPT;
using AMSeCommerce.Infrastructure.Services.LoggedUser;
using AMSeCommerce.Infrastructure.Services.Upload;
using AutoMapper;
using Azure;
using Azure.AI.OpenAI;
using Azure.Storage.Blobs;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AMSeCommerce.IOC;

public static class DependencyInjection
{
    
    public static void AddAllServices(this IServiceCollection services,IConfiguration configuration)
    {
        AddFluentMigration(services,configuration);
        AddDbContext(services,configuration);
        AddRepositories(services);
        AddAutoMapper(services);
        AddTokens(services,configuration);
        AddAzureBlob(services,configuration);
        AddOpenAi(services,configuration);
    }
    
    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        services.AddScoped<IPasswordEncrypter>(ops => new PasswordEncrypter());
        services.AddScoped<IUnityOfWork, UnityOfWork>();
        services.AddScoped<IDoLoginUseCase, DoLoginUseCase>();
        services.AddScoped<IGetProfileUserUseCase, GetProfileUserUseCase>();
        services.AddScoped<IUserUpdateOnlyRepository, UserRepository>();
        services.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();
        services.AddScoped<IChangePasswordUseCase, ChangePasswordUseCase>();
        services.AddScoped<IProductWriteOnlyRepository, ProductRepository>();
        services.AddScoped<IRegisterProductUseCase, RegisterProductUseCase>();
        services.AddScoped<IRegisterCategoryUseCase, RegisterCategoryUseCase>();
        services.AddScoped<ICategoryWriteOnlyRepository, CategoryRepository>();
        services.AddScoped<ICategoryReadOnlyRepository, CategoryRepository>();
        services.AddScoped<IGetDashBoardProductUseCase, GetDashBoardProductUseCase>();
        services.AddScoped<IProductReadOnlyRepository, ProductRepository>();
        services.AddScoped<IPaymentService, MercadoPagoPaymentService>();
        services.AddScoped<IOrderWriteOnlyRepository, OrderRepository>();
        services.AddScoped<IDoPixOrderUseCase, DoPixOrderUseCase>();
        services.AddScoped<IGetByIdProductUseCase, GetByIdProductUseCase>();
        services.AddScoped<IGetPaymentUseCase, GetPaymentUseCase>();
        services.AddScoped<IShoppingCartWriteOnlyRepository, ShoppingCartRepository>();
        services.AddScoped<IAddItemToCartUseCase, AddItemToCartUseCase>();
        services.AddScoped<IGenerateDescriptionUseCase, GenerateDescriptionUseCase>();
        services.AddScoped<IShoppingCartReadOnlyRepository, ShoppingCartRepository>();
        services.AddScoped<IGetCartUseCase, GetCartUseCase>();
        services.AddScoped<IRemoveProductToCartUseCase, RemoveProductToCartUseCase>();
        services.AddScoped<IRegisterUserOnBank, RegisterUserOnMercadoPago>();
        services.AddScoped<IDoCardOrderUseCase, DoCardOrderUseCase>();
        services.AddScoped<IDoBoletoOrderUseCase, DoBoletoOrderUseCase>();
        services.AddScoped<IGetProductBySellerUseCase, GetProductBySellerUseCase>();
        services.AddScoped<IGetAllCategoryUseCase, GetAllCategoryUseCase>();
        services.AddScoped<IGetProductByCategoryUseCase, GetProductByCategoryUseCase>();
        services.AddScoped<IGetOrdersUseCase, GetOrdersUseCase>();
        services.AddScoped<IOrderReadOnlyRepository, OrderRepository>();
        services.AddScoped<IAddAddressUseCase, AddAddressUseCase>();
        services.AddScoped<IAddressWriteOnlyRepository, AddressRepository>();

    }
    
    private static void AddAzureBlob(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddSingleton(x => new BlobServiceClient(configuration.GetValue<string>("Settings:Azure:BlobStorage")));
        serviceCollection.AddScoped<IBlobStorageService, AzureBlobStorageService>();
    }
    
    private static void AddOpenAi(IServiceCollection service, IConfiguration configuration)
    {
        service.AddScoped<IGenerateDescriptionAi, GenerateDescriptionAi>();
        var key = configuration.GetValue<string>("Settings:OpenAi:ApiKey");
        var endpoint = configuration.GetValue<string>("Settings:OpenAi:Endpoint");
        var client = new OpenAIClient(
            new Uri(endpoint),
            new AzureKeyCredential(key));

        service.AddSingleton(client);
    }
    
    private static void AddDbContext(IServiceCollection services,IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<AmsEcommerceContext>(opts =>
        {
            opts.UseSqlite(connectionString);
        });
    }
    
    public static void RunMigrations(this IApplicationBuilder services)
    {
        var serviceProvider = services.ApplicationServices;
        using var scope = serviceProvider.CreateScope();
        var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
        runner.ListMigrations();
        runner.MigrateUp();
    }
    
    private static void AddFluentMigration(IServiceCollection service,IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        service.AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddSQLite()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(Assembly.Load("AMSeCommerce.Infrastructure")).For.Migrations());
    }
    
    private static void AddTokens(IServiceCollection service, IConfiguration configuration)
    {
        var expirationTokenInMinutes = configuration.GetValue<uint>("Settings:JwtToken:ExpirationTokenInMinutes");
        var signKey = configuration.GetValue<string>("Settings:JwtToken:SignKey");

        service.AddScoped<ITokenGenerator>(option => new JwtAccessTokenGenerator(expirationTokenInMinutes, signKey!));
        service.AddScoped<ITokenValidator>(option => new JwtTokenValidator(signKey!));
        service.AddScoped<ILoggedUser, LoggedUser>();
    }
    
    private static void AddAutoMapper(IServiceCollection service)
    {
        var autoMapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AutoMapperProfile());
        }).CreateMapper();
        service.AddScoped(opts => autoMapper);
    }
}