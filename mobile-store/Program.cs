
using Microsoft.EntityFrameworkCore;
using mobile_store.Models;
using mobile_store.Repository;
using mobile_store.Repository.IRepository;
using mobile_store.Services;
using mobile_store.Services.BrandService;
using mobile_store.Services.BrandService.IBrandService;
using mobile_store.Services.DealsService;
using mobile_store.Services.DealsService.IDealsService;
using mobile_store.Services.LedgerService;
using mobile_store.Services.LedgerService.ILedgerService;
using mobile_store.Services.OrderService;
using mobile_store.Services.OrderService.IOrderService;
using mobile_store.Services.ProductService;
using mobile_store.Services.ProductsService.IProductsService;
using mobile_store.Services.TransactionService;
using mobile_store.Services.TransactionService.ITransactionService;
using mobile_store.Services.TransactionsService;


namespace mobile_store
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IBrandService, BrandService>();
            builder.Services.AddScoped<IProductsService, ProductsService>();
            builder.Services.AddScoped<IDealsService, DealsService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<ILedgerService, LedgerService>();
            builder.Services.AddScoped<ITransactionsService, TransactionsService>();
            builder.Services.AddDbContext<MobilePhoneStoreContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("Data Source=DESKTOP-4ODO15H;Initial Catalog=MobilePhoneStore;Integrated Security=True;Trust Server Certificate=True;"));
            });
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseCors("AllowAll");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
