using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FN.Store.Data.EF;
using FN.Store.Data.EF.Repositories;
using FN.Store.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace FN.Store.UI
{
    public class Startup
    {
        // Control + D , Control + C => // texto
        // Control + D , Control + U => texto 

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme =
                options.DefaultSignInScheme =
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options => {
                options.LoginPath = "/auth/signin";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(20); // expira em 1 minuto
            });

            // o obj  é único na aplicação
            //services.AddSingleton();

            // Ciclo de vida é por requisição
            services.AddScoped<StoreDataContext>();

            // Gera um novo objeto
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            // Ciclo de vida do objeto é único
            //services.AddSingleton<IDataContext, StoreDataContext>();

            // Dura 1 requisição
            //services.AddScoped<IDataContext, StoreDataContext>();

            // Gera sempre um novo objeto
            //services.AddTransient<IDataContext, StoreDataContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (ctx, next) =>
            {
                // tratamento de um erro específico. ex: 404
                await next.Invoke();

                if (ctx.Response.StatusCode == 404)
                {
                    await ctx.Response.WriteAsync("404:`(");
                }
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute(); // Rota padrão Nome do controller/ nome da action
            app.UseMvc(routes => {

                routes.MapRoute("about", "sobre", new { controller = "home", action = "about"}); // se não achar essa rota específica vai pra default
                routes.MapRoute("editar", "{controller}/Editar/{id}", new { action = "addedit" });
                routes.MapRoute("add", "{controller}/Novo", new { action = "addedit" });
                routes.MapRoute("default", "{controller=home}/{action=index}/{id?}"); // igual ao app.UseMvcWithDefaultRoute() 
            });

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
