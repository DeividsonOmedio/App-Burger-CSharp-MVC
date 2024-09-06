using Domain.Interfaces.InterfacesRepositories;
using Domain.Interfaces.InterfacesServices;
using Domain.Services;
using Infrastructure.Configuration;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mvc.Data;

var builder = WebApplication.CreateBuilder(args);

var mvcConnectionString = builder.Configuration.GetConnectionString("MvcContextConnection")
    ?? throw new InvalidOperationException("Connection string 'MvcContextConnection' not found.");

var infraConnectionString = builder.Configuration.GetConnectionString("ConexaoPadrao")
    ?? throw new InvalidOperationException("Connection string 'ConexaoPadrao' not found.");

// Configure MvcContext
builder.Services.AddDbContext<MvcContext>(options =>
    options.UseSqlServer(mvcConnectionString));

// Configure ContextBase
builder.Services.AddDbContext<ContextBase>(options =>
    options.UseSqlServer(infraConnectionString));


builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<MvcContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
builder.Services.AddScoped<IIngredientsRepository, IngredientsRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<IIngredientsService, IngredientsService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IAddressServices, AddressService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
