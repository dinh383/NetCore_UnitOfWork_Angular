using System;
using System.Collections.Generic;
using System.Text;
using App.Data.EF;
using App.Data.EF.Repositories;
using App.Data.Entities;
using App.Data.IRepositories;
using App.Infrastructure.Interface;
using App.Service.Implement;
using App.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace App.CommonExtensions.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient(typeof(IUnitOfWork), typeof(EfUnitOfWork));
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddTransient(typeof(ICategoryRepository), typeof(CategoryRepository));
            services.AddTransient(typeof(ICategoryService), typeof(CategoryService));
            services.AddTransient(typeof(IRegisterConsultativeRepository), typeof(RegisterConsultativeRepository));
            services.AddTransient(typeof(IRegisterConsultativeService), typeof(RegisterConsultativeService));
            services.AddTransient(typeof(IUserRepository), typeof(UserRepository));
            services.AddTransient(typeof(IUserService), typeof(UserService));
            services.AddTransient(typeof(IResource_CategoryRepository), typeof(Resource_CategoryRepository));
            services.AddTransient(typeof(IResource_CategoryService), typeof(Resource_CategoryService));
            services.AddTransient(typeof(IResource_VideoRepository), typeof(Resource_VideoRepository));
            services.AddTransient(typeof(IResource_VideoService), typeof(Resource_VideoService));
            return services;
        }
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AppDbConnection"),
                b => b.MigrationsAssembly("App.Data.EF")));
            return services;
        }
        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>()
               .AddEntityFrameworkStores<AppDbContext>()
               .AddDefaultTokenProviders();
            return services;
        }
    }
}
