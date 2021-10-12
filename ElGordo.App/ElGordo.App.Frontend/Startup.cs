using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElGordo.App.Persistencia;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ElGordo.App.Frontend
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
            //<======= Codigo para manejar la autenticación de usuario ==>
            services.AddAuthentication("CookieAdmin").AddCookie("CookieAdmin", options =>
             {
                 options.Cookie.Name = "CookieAdmin";// Nombre de la Cookie
                 options.LoginPath = "/Admin/Login";// Dirección a la que se redirige si no está logeado
             });
            //<====== Lineas para habilitar sesiones =====>
            services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(30));
            services.AddMemoryCache();
            //<===========================================>

            services.AddRazorPages();
            //services.AddSingleton<IRepositorioProductos,RepositorioProductos>();
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
                app.UseExceptionHandler("/Errors/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            //<==================>
            app.UseCookiePolicy();
            app.UseSession();
            //<==================>

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapRazorPages());
        }
    }
}
