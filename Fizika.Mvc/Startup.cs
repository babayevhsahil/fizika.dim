﻿using AutoMapper;
using Fizika.Entities.Concrete;
using Fizika.Mvc.Areas.Admin.Helpers.Abstract;
using Fizika.Mvc.Areas.Admin.Helpers.Concrete;
using Fizika.Mvc.AutoMapper.Profiles;
using Fizika.Mvc.Filters;
using Fizika.Services.AutoMapper.Profiles;
using Fizika.Services.Extensions;
using Fizika.Shared.Utilities.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Fizika.Mvc
{
    public class Startup
    {
        [Obsolete]
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.Json", true, true)
                .AddJsonFile("appsettings.Development.Json", true, true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IImageHelper, ImageHelper>();
            services.AddTransient<IFileHelper, FileHelper>();
            services.Configure<AboutUsPageInfo>(Configuration.GetSection("AboutUsPageInfo"));
            services.Configure<WebsiteInfo>(Configuration.GetSection("WebsiteInfo"));
            services.Configure<SmtpSettings>(Configuration.GetSection("SmtpSettings"));
            services.Configure<SliderPageInfo>(Configuration.GetSection("SliderPageInfo"));
            services.Configure<ChooseUsPageInfo>(Configuration.GetSection("ChooseUsPageInfo"));
            services.Configure<ArticleRightSideBarWidgetOptions>(Configuration.GetSection("ArticleRightSideBarWidgetOptions"));
            services.ConfigureWritable<ArticleRightSideBarWidgetOptions>(Configuration.GetSection("ArticleRightSideBarWidgetOptions"));
            services.ConfigureWritable<WebsiteInfo>(Configuration.GetSection("WebsiteInfo"));
            services.ConfigureWritable<AboutUsPageInfo>(Configuration.GetSection("AboutUsPageInfo"));
            services.ConfigureWritable<SmtpSettings>(Configuration.GetSection("SmtpSettings"));
            services.ConfigureWritable<SliderPageInfo>(Configuration.GetSection("SliderPageInfo"));
            services.ConfigureWritable<ChooseUsPageInfo>(Configuration.GetSection("ChooseUsPageInfo"));
            services.AddControllersWithViews(options =>
            {
                options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(value => "Bu sahə boş ola bilməz");
                options.Filters.Add<MvcExceptionFilter>();
            }).AddRazorRuntimeCompilation().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            }).AddNToastNotifyToastr();

            services.AddSession();
            services.AddAutoMapper(typeof(CategoryProfile), typeof(ArticleProfile), typeof(UserProfile), typeof(CommentProfile), typeof(ViewModelsProfile), typeof(BusinessProfile), typeof(TeamProfile), typeof(ProjectCategoryProfile),typeof(RegisterProfile) ,typeof(ProjectProfile),typeof(VideoProfile));
            services.LoadMyServices(connectionString: Configuration["Data:DefaultConnection:ConnectionString"]);
            //services.LoadMyServices(connectionString: Configuration.GetConnectionString("LocalDB"));

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/Admin/Auth/Login");
                options.LogoutPath = new PathString("/Admin/Auth/Logout");
                options.Cookie = new CookieBuilder
                {
                    Name = "Fizika",
                    HttpOnly = true,  //Cookiler front end terefinde gorsenmyecek!
                    SameSite = SameSiteMode.Strict, //Cookiler ferqli unvandan gelir
                    SecurePolicy = CookieSecurePolicy.SameAsRequest //Always!
                };
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = System.TimeSpan.FromDays(7);
                options.AccessDeniedPath = new PathString("/Admin/Auth/AccesDenied");
            });
            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    app.UseHsts();
            //}
            app.Use(async (context, next) =>
            {
                if (context.Request.Path.StartsWithSegments("/robots.txt"))
                {
                    var robotsTxtPath = Path.Combine(env.ContentRootPath, "robots.txt");
                    string output = "User-agent: *  \nDisallow: /";
                    if (File.Exists(robotsTxtPath))
                    {
                        output = await File.ReadAllTextAsync(robotsTxtPath);
                    }
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync(output);
                }
                else await next();
            });
            app.UseDeveloperExceptionPage();
            app.UseSession();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseNToastNotify();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "article",
                    pattern: "bloq/{title}/{articleId}",
                    defaults: new { controller = "Article", action = "Detail" }
                    );
                endpoints.MapControllerRoute(
                    name: "sinaq",
                    pattern: "sinaq/{name}/{examId}",
                    defaults: new { controller = "Exam", action = "Detail" }
                    );
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
