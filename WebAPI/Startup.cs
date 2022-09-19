using Business.Handlers.Auth.Queries;
using Business.Handlers.Genres.Command;
using Business.Handlers.Genres.Queries;
using Business.Handlers.Image.Command;
using Business.Handlers.Image.Queries;

using Business.Handlers.News;
using Business.Handlers.News.Commands;
using Business.Handlers.News.Queries;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAPI
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
            services.AddDbContext<NewsDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("KodlamaIoDevsDbConnectionString")));


            services.AddMediatR(typeof(CreateNewsCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeleteNewsCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateNewsCommand).GetTypeInfo().Assembly);

            services.AddMediatR(typeof(CreateGenreCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeleteGenreCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateGenreCommand).GetTypeInfo().Assembly);

            services.AddMediatR(typeof(GetListNewsQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetByIdGenreQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetListGenreQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetByIdNewsQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetAllNewsDetails).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetListNewsImageQuery).GetTypeInfo().Assembly);

            services.AddMediatR(typeof(CreateNewsImageCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeleteNewsImageCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateNewsImageCommand).GetTypeInfo().Assembly);

            services.AddMediatR(typeof(LoginUserQuery).GetTypeInfo().Assembly);


            services.AddMediatR(Assembly.GetExecutingAssembly());

            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                };
            });
            

            //services.AddDbContext<Context>(options =>
            //             options.UseSqlServer(_configuration.GetConnectionString("ContextConn")),
            //  ServiceLifetime.Transient);


            //services.AddScoped<INewsRepository, NewsRepository>();
            //services.AddScoped<IGenreRepository, GenreRepository>();
            //services.AddScoped<INewsImageRepository, NewsImageRepository>();
            //services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<ITokenHelper, JwtHelper>();


            //services.AddSingleton<NewsDbContext>();



            services.AddControllers();

           

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader());

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
