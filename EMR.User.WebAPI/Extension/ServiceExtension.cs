using EMR.Data.Context;
using EMR.Data.Model.Settings;
using EMR.Services.Interfaces;
using EMR.Services.Services;
using EMR.UnitOfWork.Interfaces;
using EMR.UnitOfWork.SqlServer;
using EMR.WebAPI.Authorization;
using Microsoft.EntityFrameworkCore;

namespace EMR.WebAPI.Extension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDependencyInjectionServices(this IServiceCollection services, AppSettings settings)
        {
            services.AddDbContext<EmrContext>(options =>
            {
                var connectionString = GetConnectionString(settings.ConnectionString);                
                options.UseNpgsql(connectionString);
            });

            services.AddScoped<IJwtUtils, JwtUtils>();
            services.AddScoped<IUnitOfWork, UnitOfWorkSqlServer>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IConfigService, ConfigService>();
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }

        private static string GetConnectionString(ConnectionString connection)
        {
            return String.Format(
                    "Server={0};Database={1};Port={2};Username={3};Password={4};SSLMode=Prefer",
                    connection.Host,
                    connection.DatabaseName,
                    connection.Port,
                    connection.User,
                    connection.Password);
        }
    }
}
