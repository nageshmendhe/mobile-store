
using Microsoft.EntityFrameworkCore;
using mobile_store.Models;
using mobile_store.Repository;
using mobile_store.Repository.IRepository;
using mobile_store.Services;
using mobile_store.Services.IServices;

namespace mobile_store
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<ISaleService, SaleService>();
            builder.Services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddDbContext<MobilePhoneStoreContext>(opt =>
            {
                opt.UseSqlServer("Data Source=DESKTOP-4ODO15H;Initial Catalog=MobilePhoneStore;Integrated Security=True;Trust Server Certificate=True;");
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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
