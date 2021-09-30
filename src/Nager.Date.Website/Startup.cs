using AspNetCoreRateLimit;
using Mapster;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Nager.Date.Website.Contract;
using Nager.Date.Website.Models;
using System;
using System.IO;
using System.Reflection;

namespace Nager.Date.Website
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
            #region MappingConfig

            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

            #endregion

            #region IpRateLimit

            services.AddOptions();
            services.AddMemoryCache();

            //load general configuration from appsettings.json
            services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting"));

            //load ip rules from appsettings.json
            services.Configure<IpRateLimitPolicies>(Configuration.GetSection("IpRateLimitPolicies"));

            // inject counter and rules stores
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();

            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

            #endregion

            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.EnableForHttps = true;
            });
            services.Configure<GzipCompressionProviderOptions>(options => { options.Level = System.IO.Compression.CompressionLevel.Fastest; });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
                options.JsonSerializerOptions.Converters.Add(new PublicHolidayTypeConverter());
            });

            services.AddControllersWithViews();

            services.AddCors(o => o.AddPolicy("ApiPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo
                {
                    Title = "Nager.Date API",
                    Description = "Nager.Date is open source software and is completely free for commercial use. If you would like to support the project you can award a GitHub star ⭐ or even better <a href='https://github.com/sponsors/nager'>actively support us</a>",
                    Contact = new OpenApiContact
                    {
                        Name = "Nager.Date on GitHub",
                        Url = new Uri("https://github.com/nager/Nager.Date/issues")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri("https://github.com/nager/Nager.Date/blob/master/LICENSE.md")
                    },
                    Version = "v1.0"
                });

                c.TagActionsBy(api => new[] { api.GroupName });
                c.DocInclusionPredicate((name, api) => true);

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                // Create good names with NSwag
                c.CustomOperationIds(description =>
                {
                    var actionDescriptor = description.ActionDescriptor as ControllerActionDescriptor;
                    return $"{actionDescriptor.ControllerName}{actionDescriptor.ActionName}";
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Initialize Mapster
            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetEntryAssembly());

            var enableCors = Configuration.GetValue<bool>("EnableCors");
            var enableIpRateLimiting = Configuration.GetValue<bool>("EnableIpRateLimiting");
            var enableSwaggerMode = Configuration.GetValue<bool>("EnableSwaggerMode");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            if (enableCors)
            {
                app.UseCors("ApiPolicy");
            }

            if (enableIpRateLimiting)
            {
                app.UseIpRateLimiting();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Nager.Date API V1");

                if (enableSwaggerMode)
                {
                    c.RoutePrefix = string.Empty;
                }
            });

            if (!enableSwaggerMode)
            {
                app.UseHttpsRedirection();
            }

            app.UseResponseCompression();

            if (!enableSwaggerMode)
            {
                app.UseStaticFiles(new StaticFileOptions
                {
                    OnPrepareResponse = ctx =>
                    {
                        const int CacheDays = 365;
                        const int DurationInSeconds = 60 * 60 * 24 * CacheDays;
                        ctx.Context.Response.Headers[HeaderNames.CacheControl] = $"public,max-age={DurationInSeconds}";
                        ctx.Context.Response.Headers[HeaderNames.Expires] = new[] { DateTime.UtcNow.AddDays(CacheDays).ToString("R") }; // Format RFC1123
                }
                });
            }

            app.UseRouting();

            if (enableSwaggerMode)
            {
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }
            else
            {
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
                });
            }
        }
    }
}
