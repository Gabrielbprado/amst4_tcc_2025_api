using AMS_News.Domain.Contracts.Token;
using AMSeCommerce.API.Filters;
using AMSeCommerce.API.Token;
using AMSeCommerce.Infrastructure.Data.Database;
using AMSeCommerce.IOC;
using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddAllServices(builder.Configuration);
builder.Services.AddFluentMigratorCore();
builder.Services.AddMvc(opts => opts.Filters.Add(new ExceptionFilter()));
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ITokenProvider, HttpContextTokenValue>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});
builder.Services.AddSwaggerGen(opts =>
{
    
    opts.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token in the text input below. Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    
    opts.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "Bearer",
                Name = "Authorization",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
    
   

}); 
var app = builder.Build();

app.UseCors("AllowAll");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();

app.UseHttpsRedirection();

AddDatabase();
app.Urls.Add("http://+:8080");
app.Run();


void AddDatabase()
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    CreateDatabase.Create(connectionString!);
    app.RunMigrations();
    
}