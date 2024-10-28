using MongoCore.Core.Interfaces.InterfaceRepositories;
using MongoCore.Core.Interfaces.InterfaceServices;
using MongoCore.Core.Services;
using MongoCore.Infrastructure.Repositories;
using MongoDB.Driver;

namespace MongoCore.API.APIHelper;

public static class RegisterBuilderServices
{
    public static IServiceCollection ServicesCollection(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);

        #region Register Core Services
        RegisterCoreServices(services);
        #endregion     

        #region Register Core Repositories
        RegisterCoreRepositories(services);
        #endregion
    
        #region Register Database
        SetDatabase(services, configuration);
        //services.Configure<DatabaseSettings>(configuration.GetSection("ConnectionStrings") );

        #endregion

        return services;
    }

    private static void RegisterCoreServices(IServiceCollection services) 
    {
        services.AddScoped<IMongoService,MongoService>();
    }

    private static void RegisterCoreRepositories(IServiceCollection services)
    {
        services.AddScoped<IMongoRepository, MongoRepository>();
    }

    private static void SetDatabase(IServiceCollection services, IConfiguration configuration)
    {
        var mongoClient = new MongoClient(configuration["ConnectionStrings:ConnectionURL"]);
        var database = mongoClient.GetDatabase(configuration["ConnectionStrings:DatabaseName"]);
        services.AddSingleton<IMongoDatabase>(database);
    }
}