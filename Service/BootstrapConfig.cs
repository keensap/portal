using System;
using System.Linq;
using AutoMapper;
using KeenSap.Portal.Data;
using KeenSap.Portal.Data.Repository;
using KeenSap.Portal.Data.Repository.Contract;
using KeenSap.Portal.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KeenSap.Portal.Service
{
    public static class BootstrapConfig
    {
        public static void RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt => 
                opt.UseMySql(configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(System.AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
