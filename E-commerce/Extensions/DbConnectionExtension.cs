using E_commerce.Context;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Extensions
{
    public static class DbConnectionExtension 
    {
        public static IServiceCollection GetSqlConnection(this IServiceCollection services, IConfigurationManager config) {
            var version = new MySqlServerVersion(new Version(8,0,30));
            services.AddDbContext<ECommerceContext>(option =>
            {
                option.UseMySql(config.GetConnectionString("Default"), version);
            });
            return services;
        }
    }
}
