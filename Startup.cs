using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UrbanCarton.Webapi.DAL;
using UrbanCarton.Webapi.DAL.Repositories;
using UrbanCarton.Webapi.GraphQL;
using UrbanCarton.Webapi.GraphQL.Messaging.Review;

namespace urbancarton
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            Environment = webHostEnvironment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<UrbanCartonDbContext>(options =>
            options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddScoped<ProductRepository>();
            services.AddScoped<ProductReviewRepository>();

            services.AddScoped<IDependencyResolver>(x =>
            new FuncDependencyResolver(x.GetRequiredService));

            services.AddScoped<UrbanCartonSchema>();
            services.AddSingleton<ReviewMessageService>();

            services.AddGraphQL(o => { o.ExposeExceptions = Environment.IsDevelopment(); })
                .AddGraphTypes(ServiceLifetime.Scoped).AddUserContextBuilder(httpContext => httpContext.User)
                .AddDataLoader()
                .AddWebSockets();

            services.AddCors();

            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            // If using IIS:
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, UrbanCartonDbContext dbContext)
        {
            app.UseCors(builder =>
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseWebSockets();
            app.UseGraphQLWebSockets<UrbanCartonSchema>("/graphql");
            app.UseGraphQL<UrbanCartonSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            dbContext.Seed();
        }
    }
}
