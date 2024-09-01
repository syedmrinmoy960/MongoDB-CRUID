//using MongoDB_CRUID.Managers.IManager;
//using MongoDB_CRUID.Managers.Manager;
//using MongoDB_CRUID.Repositories.IRepository;
//using MongoDB_CRUID.Repositories.Repository;
//using MongoDB_CRUID.Models;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Configuration;

//namespace MongoDB_CRUID.Extensions
//{
//    public static class ServiceExtensions
//    {
//        public static void ConfigureMongoDbServices(this IServiceCollection services, IConfiguration configuration)
//        {
//            // Bind MongoDB settings from appsettings.json
//            services.Configure<MongoDBSettings>(configuration.GetSection("MongoDB"));

//            // Register repositories and managers
//            services.AddScoped<IUserRepository, UserRepository>();
//            services.AddScoped<IUserManager, UserManager>();
//        }
//    }
//}


using MongoDB_CRUID.Managers.IManager;
using MongoDB_CRUID.Managers.Manager;
using MongoDB_CRUID.Repositories.IRepository;
using MongoDB_CRUID.Repositories.Repository;
using MongoDB_CRUID.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MongoDB_CRUID.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureMongoDbServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Bind MongoDB settings from appsettings.json
            services.Configure<MongoDBSettings>(configuration.GetSection("MongoDB"));

            services.AddSingleton<IMongoClient>(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<MongoDBSettings>>().Value;
                return new MongoClient(settings.ConnectionString);
            });

            // Register MongoDatabase
            services.AddScoped<IMongoDatabase>(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<MongoDBSettings>>().Value;
                var client = sp.GetRequiredService<IMongoClient>();
                return client.GetDatabase(settings.DatabaseName);
            });

            // Register repositories and managers with Scoped lifetime
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<ILoginManager, LoginManager>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IReportsManager, ReportManager>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IDashboardManager, DashboardManager>();
            services.AddScoped<IDashboardRepository, DashboardRepository>();
        }
    }
}
