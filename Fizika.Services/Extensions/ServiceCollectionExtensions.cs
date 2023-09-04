using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Fizika.Data.Abstract.UnitOfWorks;
using Fizika.Data.Concrete.EntityFramework.Context;
using Fizika.Data.Concrete.UnitOfWork;
using Fizika.Entities.Concrete;
using Fizika.Services.Abstract;
using Fizika.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection,string connectionString)
        {
            //AddScoped = Her request yarandiqda yeni bir instance yaranir ve bir request icersinde sadece bir dene obyekt istfd olunur
            //Transient = Her obyekt cagirisinda yeni bir instance yaradir,Scopedde ise sadece Request zamani 1defe yaranir
            serviceCollection.AddDbContext<FizikaContext>(options=>options.UseSqlServer(connectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            serviceCollection.AddIdentity<User, Role>(options => {
                //User Password Options
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                //User UserName and Email Options
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@";
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<FizikaContext>();
            serviceCollection.Configure<SecurityStampValidatorOptions>(options =>
            {
                options.ValidationInterval = TimeSpan.FromMinutes(15);
            });
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<ICategoryService, CategoryManager>();
            serviceCollection.AddScoped<IArticleService, ArticleManager>();
            serviceCollection.AddScoped<ICommentService, CommentManager>();
            serviceCollection.AddScoped<IBusinessService, BusinessManager>();
            serviceCollection.AddScoped<IStudentsService, StudentsManager>();
            serviceCollection.AddScoped<IRegisterService, RegisterManager>();
            serviceCollection.AddScoped<IExamCategoryService, ProjectCategoryManager>();
            serviceCollection.AddScoped<IExamService, ProjectManager>();
            serviceCollection.AddScoped<IVideoService, VideoManager>();
            serviceCollection.AddSingleton<IMailService, MailManager>();
            return serviceCollection;
        }
    }
}
