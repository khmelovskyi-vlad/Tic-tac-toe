using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Tic_tac_toe_api.Data;
using Tic_tac_toe_api.SignalRApp.Hubs;

namespace Tic_tac_toe_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyCorsPolicy = "_myPolicy";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<Tic_tac_toeContext>(options => options.UseSqlServer(GetSqlConnectionStringBuilder().ConnectionString));
            services.AddSignalR(hubOptions =>
            {
                hubOptions.EnableDetailedErrors = true;
                hubOptions.KeepAliveInterval = TimeSpan.FromMinutes(4);
            })
            .AddJsonProtocol(options => {
                options.PayloadSerializerOptions.PropertyNamingPolicy = null;
            });

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:5001";
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query["access_token"];
                            if (string.IsNullOrEmpty(accessToken))
                            {
                                Console.WriteLine("so bad");
                            }
                            else
                            {
                                Console.WriteLine($"oo good {accessToken}");
                            }
                            // If the request is for our hub...
                            var path = context.HttpContext.Request.Path;
                            if (!string.IsNullOrEmpty(accessToken) &&
                                (path.StartsWithSegments("/tic_tac_toehub")))
                            {
                                Console.WriteLine("it is super");
                                // Read the token out of the query string
                                context.Token = accessToken;
                            }
                            return Task.CompletedTask;
                        }
                    };
                    //options.Events = new JwtBearerEvents
                    //{
                    //    OnMessageReceived = context =>
                    //    {

                    //        var accessToken = context.Request.Query["access_token"];
                    //        var authToken = context.Request.Headers["Authorization"].ToString();

                    //        var token = !string.IsNullOrEmpty(accessToken) ? accessToken.ToString() : !string.IsNullOrEmpty(authToken) ? authToken.Substring(7) : String.Empty;
                    //        if (string.IsNullOrEmpty(token))
                    //        {
                    //            Console.WriteLine("so bad");
                    //        }
                    //        else
                    //        {
                    //            Console.WriteLine($"oo good {token}");
                    //        }
                    //        // If the request is for our hub...
                    //        var path = context.HttpContext.Request.Path;
                    //        if (!string.IsNullOrEmpty(accessToken) &&
                    //            (path.StartsWithSegments("/tic_tac_toehub")))
                    //        {
                    //            Console.WriteLine("it is super");
                    //            context.Token = accessToken;
                    //            //context.Request.Headers.Add("Authorization", "Bearer " + accessToken);
                    //        }
                    //        return Task.CompletedTask;
                    //    }
                    //};
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };

                });

            services.TryAddEnumerable(
                ServiceDescriptor.Singleton<IPostConfigureOptions<JwtBearerOptions>,
                    ConfigureJwtBearerOptions>());

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "api1");
                });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyCorsPolicy,
                                  builder =>
                                  {
                                      builder
                                                  .WithOrigins("http://127.0.0.1:5500", "http://127.0.0.1:5500/dist", 
                                                  "https://localhost:5003", "https://localhost:5001")
                                                  //.AllowAnyOrigin()
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod()
                                                  .AllowCredentials();
                                  });
            });
            //services.AddCors(options =>
            //{
            //    // this defines a CORS policy called "default"
            //    options.AddPolicy("default", policy =>
            //    {
            //        policy.WithOrigins("https://localhost:5003")
            //            .AllowAnyHeader()
            //            .AllowAnyMethod();
            //    });
            //});



            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultScheme = "Cookies";
            //    options.DefaultChallengeScheme = "oidc";
            //})
            //.AddCookie("Cookies")
            //.AddOpenIdConnect("oidc", options =>
            //{
            //    options.Authority = "https://localhost:5001";

            //    options.ClientId = "mvc";
            //    options.ClientSecret = "secret";
            //    options.ResponseType = "code";

            //    options.SaveTokens = true;

            //    options.Scope.Add("api1");
            //    options.Scope.Add("offline_access");
            //});
            ////.AddOpenIdConnect("oidc", options =>
            ////{
            ////    options.SignInScheme = "Cookies";

            ////    options.Authority = "https://localhost:5001";

            ////    options.ClientId = "mvc";
            ////    options.ClientSecret = "secret";
            ////    options.ResponseType = "code id_token";

            ////    //options.Scope.Add("roles");
            ////    //options.ClaimActions.MapJsonKey("role", "role");
            ////    //options.Scope.Add("permissions");
            ////    //options.ClaimActions.MapJsonKey("Permission", "Permission");
            ////    options.SaveTokens = true;
            ////    options.GetClaimsFromUserInfoEndpoint = true;
            ////    options.Scope.Add("offline_access");
            ////    options.ClaimActions.MapJsonKey("website", "website");
            ////    options.TokenValidationParameters = new TokenValidationParameters
            ////    {
            ////        NameClaimType = "name",
            ////        RoleClaimType = "role"
            ////    };
            ////});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(MyCorsPolicy);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                    //.RequireAuthorization("ApiScope");
                endpoints.MapHub<Tic_tac_toeHub>("/tic_tac_toehub", options =>
                {
                    options.Transports =
                        HttpTransportType.WebSockets;
                });
                //.RequireAuthorization("ApiScope");
            });
        }
        private SqlConnectionStringBuilder GetSqlConnectionStringBuilder()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "WIN-DHV0BQSLTCR";
            sqlConnectionStringBuilder.UserID = "SQLFirst";
            sqlConnectionStringBuilder.Password = "Test1234";
            sqlConnectionStringBuilder.InitialCatalog = "Tic_tac_toe";
            return sqlConnectionStringBuilder;
        }
    }
}
