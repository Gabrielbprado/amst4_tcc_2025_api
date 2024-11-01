using System.Reflection;
using AMS_News.Application.Login;
using AMS_News.Domain.Contracts;
using AMS_News.Domain.Contracts.Token;
using AMSeCommerce.Application.Services.AutoMapper;
using AMSeCommerce.Application.UseCases.Category;
using AMSeCommerce.Application.UseCases.Login;
using AMSeCommerce.Application.UseCases.Product;
using AMSeCommerce.Application.UseCases.User.ChangePassword;
using AMSeCommerce.Application.UseCases.User.Profile;
using AMSeCommerce.Application.UseCases.User.Register;
using AMSeCommerce.Application.UseCases.User.Update;
using AMSeCommerce.Domain.Contracts.Category;
using AMSeCommerce.Domain.Contracts.Product;
using AMSeCommerce.Domain.Contracts.Storage;
using AMSeCommerce.Domain.Contracts.Token;
using AMSeCommerce.Domain.Contracts.User;
using AMSeCommerce.Infrastructure.Data;
using AMSeCommerce.Infrastructure.Repositories;
using AMSeCommerce.Infrastructure.Security.Encrypter;
using AMSeCommerce.Infrastructure.Security.Token.Access.Generate;
using AMSeCommerce.Infrastructure.Security.Token.Access.Validate;
using AMSeCommerce.Infrastructure.Services.LoggedUser;
using AMSeCommerce.Infrastructure.Services.Upload;
using AutoMapper;
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
        
    }
    
    private static void AddAzureBlob(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddSingleton(x => new BlobServiceClient(configuration.GetValue<string>("Settings:Azure:BlobStorage")));
        serviceCollection.AddScoped<IBlobStorageService, AzureBlobStorageService>();
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