using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FN.Store.UI.Data;
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
            app.UseMvcWithDefaultRoute();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
