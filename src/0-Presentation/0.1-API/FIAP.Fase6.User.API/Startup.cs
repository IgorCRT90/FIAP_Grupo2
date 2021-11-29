using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using SimpleInjector;
using FIAP.Fase6.Application.Interfaces;
using FIAP.Fase6.Application.AppServices;
using FIAP.Fase6.Application.Queries;
using FIAP.Fase6.Domain.Users.Commands;
using FIAP.Fase6.Core.Interfaces;
using FIAP.Fase6.Domain.Users.Handlers;
using FIAP.Fase6.Domain.Contracts.Repositories;
using FIAP.Fase6.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using FIAP.Fase6.Infra.Data.Context;

namespace FIAP.Fase6.User.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            container.Options.ResolveUnregisteredConcreteTypes = false;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public Container container = new SimpleInjector.Container();


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "FIAP.Fase6.User.API",
                    Version = "v1",
                });
            });

            services.AddControllers();
            //services.AddDbContext<Fase6Context>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSimpleInjector(container, options =>
            {
                options.AddAspNetCore()
                    .AddControllerActivation();

                options.AddLogging();
            });

            InitializeContainer();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSimpleInjector(container);

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FIAP.Fase6.User.API");
                c.DocExpansion(DocExpansion.None);
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            container.Verify();
        }

        private void InitializeContainer()
        {
            container.Register<IUserAppService, UserAppService>(Lifestyle.Singleton);

            container.Register<IUserQueries, UserQueries>(Lifestyle.Singleton);

            container.Register<ICommandHandler<RegisterNewUserCommand>, RegisterNewUserHandler>(Lifestyle.Singleton);
            container.Register<ICommandHandler<RemoveUserCommand>, RemoveUserHandler>(Lifestyle.Singleton);
            container.Register<ICommandHandler<UpdateUserCommand>, UpdateUserHandler>(Lifestyle.Singleton);

            container.Register<IUserRepository, UserRepository>(Lifestyle.Singleton);

        }
    }
}

