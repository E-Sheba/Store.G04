
using Microsoft.EntityFrameworkCore;
using Store.G04.Domain.Mapping.Products;
using Store.G04.Domain.Repository.Contracts;
using Store.G04.Domain.Service.Contracts;
using Store.G04.Repository.Data;
using Store.G04.Repository.Data.Contexts;
using Store.G04.Repository.Repositories;
using Store.G04.Service.Services.Products;

namespace Store.G04.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<StoreDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(M=>M.AddProfile(new ProductProfile()));

            var app = builder.Build();

            //Update Database using code
            //StoreDbContext context = new StoreDbContext();
            //context.Database.MigrateAsync();

            //asking clr to create an object from the StoreDbContext
            //CreateScope is a function that creates all services of type scope 
            //this Service is considered as UnManaged Resource
            using var scope = app.Services.CreateScope(); //Container that contains bunch of services of lifetime type scope
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<StoreDbContext>();
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                //Applies any pending migration to the Database
                await context.Database.MigrateAsync();
                await StoreDbContextSeed.SeedAsync(context);
            }
            catch (Exception ex)
            {
                //logging the error message to the console by 2 ways:

                //1.Console.WriteLine(ex.Message);
                //2.LoggerFactory
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "There were problems during applying the migration");
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
