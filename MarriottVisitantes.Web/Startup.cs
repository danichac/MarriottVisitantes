using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MarriottVisitantes.Repositorio;
using MarriottVisitantes.Repositorio.Identidad;
using MarriottVisitantes.Repositorio.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MarriottVisitantes.Repositorio.Interfaces;
using MarriottVisitantes.Repositorio.Implementaciones;
using MarriottVisitantes.Servicios.Interfaces;
using MarriottVisitantes.Servicios.Implementaciones;
using MarriottVisitantes.Dominio.Identidad;

namespace MarriottVisitantes.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<MarriottVisitantesDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("SqlServer"));
            });
            services.AddIdentity<Usuario, Rol>(options => 
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
            })
                .AddUserStore<ApplicationUserStore>()
                .AddEntityFrameworkStores<MarriottVisitantesDbContext>()
                .AddDefaultTokenProviders();
            services.AddScoped<IUserClaimsPrincipalFactory<Usuario>,MarriottUserClaimsPrincipalFactory>();
            services.AddScoped<IRepositorioUsuario, RepositorioUsuarios>();
            services.AddScoped<IRepositorioVisitas, RepositorioVisitas>();
            services.AddScoped<IRepositorioVisitante, RepositorioVisitante>();
            services.AddScoped<IServicioUsuarios, ServicioUsuarios>();
            services.AddScoped<IServicioVisitas, ServicioVisitas>();
            services.AddScoped<IServicioVisitante, ServicioVisitante>();
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
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
