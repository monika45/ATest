using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;



namespace ATest
{
    public class Startup
    {
        public const string CookieScheme = "Cookies";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            FreeSql = new FreeSql.FreeSqlBuilder()
                .UseConnectionString(global::FreeSql.DataType.MySql, Configuration.GetConnectionString("DefaultConnection"))
                .UseAutoSyncStructure(true)
                .Build();
        }

        public IConfiguration Configuration { get; }

        public IFreeSql FreeSql { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddSingleton<IFreeSql>(FreeSql);

            //声明转换

            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(options => options.LoginPath = "/Login/Index");

            //services.AddTransient<IClaimsTransformation, ClaimsTransformer>();


            //Cookie身份验证
            services.AddAuthentication(CookieScheme) // set the default scheme to cookies
                .AddCookie(CookieScheme, options =>
                {
                    options.AccessDeniedPath = "/Login/AccessDenied";
                    options.LoginPath = "/Login/Index";
                });
            //自定义cookie选项
            services.AddSingleton<IConfigureOptions<CookieAuthenticationOptions>, ConfigureMyCookie>();


           


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Privacy}/{id?}");
            });
        }
    }
}
