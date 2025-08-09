using Application.Interfaces;
using Application.Services;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using ProductManagement;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IServiceProviderService, ServiceProviderService>();


builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IServiceProviderRepository, ServiceProviderRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}");

app.Run();