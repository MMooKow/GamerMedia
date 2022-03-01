using FluentValidation.AspNetCore;
using GamerMedia.Data;
using GamerMedia.Data.Interfaces;
using GamerMedia.Data.Repositories;
using GamerMedia.Extensions;
using Microsoft.OpenApi.Models;

namespace GamerMedia
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationServices(_config);

            services.AddControllers();

            services.AddScoped<IUsersRepo, UsersRepo>();

            services.AddScoped<IPostsRepo, PostsRepo>();

            services.AddScoped<ICommentRepo, CommentRepo>();

            services.AddSingleton(_ => _config);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gamer_Media", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowNgDev", policy =>
                    policy.WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());

                options.AddPolicy("AllowProduction", policy =>
                     policy.WithOrigins("http://localhost:4200")
                         .AllowAnyMethod()
                         .AllowAnyHeader()
                         .AllowCredentials());
            });
            
            services.AddFluentValidation(cfg =>
            {
                cfg.DisableDataAnnotationsValidation = true;
                cfg.RegisterValidatorsFromAssemblyContaining<Startup>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Client_Portal v1"));
            }

            // TODO: for security, make sure this is more defined later on
            app.UseCors("AllowNg");

            if (env.IsDevelopment())
            {
                app.UseHttpsRedirection();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
