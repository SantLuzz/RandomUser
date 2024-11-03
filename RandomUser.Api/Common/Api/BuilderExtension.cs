using Microsoft.EntityFrameworkCore;
using RandomUser.Api.Data;
using RandomUser.Api.Handlers;

namespace RandomUser.Api.Common.Api;

public static class BuilderExtension
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        Configuration.ConnectionString = builder.Configuration
            .GetConnectionString("DefaultConnection") ?? string.Empty;

        Configuration.ApiUrl = builder.Configuration.GetValue<string>("ApiUrl") ?? string.Empty;
    }

    public static void AddDocumentation(this WebApplicationBuilder builder) 
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(x =>
        {
            x.CustomSchemaIds(n => n.FullName);
        });
    }
    
    public static void AddDataContext(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddDbContext<AppDbContext>(x => 
                x.UseNpgsql(Configuration.ConnectionString));
    }

    public static void AddHttpClients(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpClient(Configuration.ApiUrl, opt =>
        {
            opt.BaseAddress = new Uri(Configuration.ApiUrl);
        });
    }
    
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<UserHandler>();
        builder.Services.AddTransient<FetchUserHandler>();
        
    }
    
    public static void AddCrossOrigin(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options => options.AddPolicy(
            Configuration.CorsPolicyName,
            policy => policy
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
        ));
    }
}