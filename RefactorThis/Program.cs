using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RefactorThis.Filters;
using RefactorThis.Infrastructure;
using RefactorThis.Interfaces;
using RefactorThis.Services;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
    options.Filters.Add(new ApiExceptionFilter()));

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var contentRootPath = "";
var connectionString = builder.Configuration.GetConnectionString("ProductDbContext");

if (connectionString.Contains("%CONTENTROOTPATH%"))
{
    connectionString = connectionString.Replace("%CONTENTROOTPATH%", contentRootPath);
}
builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlServer(connectionString,
        b => b.MigrationsAssembly(typeof(ProductDbContext).Assembly.FullName)));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductOptionRepository, ProductOptionRepository>();
builder.Services.AddScoped<IProductOptionService, ProductOptionService>();

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