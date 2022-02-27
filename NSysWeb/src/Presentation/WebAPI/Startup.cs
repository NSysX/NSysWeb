using Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Persistence;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebAPI.Core.Swagger;
using WebAPI.Extensiones;
using IdentityServer4.AccessTokenValidation;
using WebAPI.Middlewares;

namespace WebAPI
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            this._env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers().AddJsonOptions(x =>
            //         x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            services.AgregaCoreDeAplicacion(_env);
            services.AgregaInfraestructuraDeShared(Configuration);
            services.AgregaInfraestructuraDePersistencia(Configuration);

            services.AddControllers();

            services.RegistraVersionamientoAPIExtension();

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "https://localhost:44310";
                    options.ApiName = "NSys.Person";
                    options.EnableCaching = true;
                    options.CacheDuration = TimeSpan.FromMinutes(15);
                    options.RequireHttpsMetadata = false;
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "WebAPI",
                    Version = "v1",
                    Description = "Api que administra el core del sistema de datos personales."
                });
                //c.DocumentFilter<DocumentFilter>();
                c.OrderActionsBy(x => x.HttpMethod);

                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows()
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            // url de autorizacion
                            AuthorizationUrl = new Uri("https://localhost:44310/connect/authorize"),
                            // url obtenr access token
                            TokenUrl = new Uri("https://localhost:44310/connect/token"),
                            Scopes = new Dictionary<string, string>
                            {
                                {
                                    "NSys.Person", "Api que administra el core del sistema de datos personales."
                                }
                            }
                        }
                    }
                });

                c.OperationFilter<AuthorizeCheckOperationFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));

                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "NSys.Web Person");

                    options.OAuthClientId("NSys.Web.Swagger.Client");
                    options.OAuthAppName("NSys.Web.Person");
                    options.OAuthUsePkce();
                });
            }

            app.UseMiddleware<EjemploDeMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // app.UseErrorHandlingMiddleware();
            app.UseMiddleware<ErrorManejadorMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
