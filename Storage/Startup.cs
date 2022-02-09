using BBL;
using BBL.Services.Classes;
using BBL.Services.Interfaces;
using DAL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Storage
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Storage", Version = "v1" });
            });

            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            //{
            //    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/api/Account/Login");
            //    options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/api/Account/Login");
            //});

            services.AddAutoMapper(typeof(ApplicationContext), typeof(MappingProfile));

            services.AddScoped<IAuthenticateService, AuthenticateService>();
            services.AddTransient<IInitializeReportService, InitializeReportService>();
            services.AddScoped<IEmployerService, EmployerService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IManagerService, ManagerService>();
            services.AddScoped<IMarkService, MarkService>();
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<ILoginService, LoginService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Storage v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
