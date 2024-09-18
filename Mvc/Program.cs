using Domain.Interfaces.InterfacesRepositories;
using Domain.Interfaces.InterfacesServices;
using Domain.Services;
using Infrastructure.Configuration;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Mvc.Areas.Identity.Data;
using Mvc.Data;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

var cultureInfo = new CultureInfo("pt-BR");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;



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

// Adiciona suporte a roles com o Identity moderno
builder.Services.AddDefaultIdentity<UserModel>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>() // Adiciona suporte a roles
    .AddEntityFrameworkStores<MvcContext>();



// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
builder.Services.AddScoped<IIngredientsRepository, IngredientsRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<ISaleProductRepository, SaleProductRepository>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<IIngredientsService, IngredientsService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IAddressServices, AddressService>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<ISaleProductService, SaleProductService>();

var app = builder.Build();

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(cultureInfo),
    SupportedCultures = new[] { cultureInfo },
    SupportedUICultures = new[] { cultureInfo }
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<UserModel>>();

    // Chame o método para criar roles
    await CreateRoles(services);
}

app.Run();

// Método para criar roles
async Task CreateRoles(IServiceProvider serviceProvider)
{
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = serviceProvider.GetRequiredService<UserManager<UserModel>>();

    string[] roleNames = { "Admin", "Client" };
    IdentityResult roleResult;

    foreach (var roleName in roleNames)
    {
        var roleExist = await roleManager.RoleExistsAsync(roleName);
        if (!roleExist)
        {
            roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    var powerUser = new UserModel
    {
        UserName = "admin@admin.com",
        Email = "admin@admin.com",
        Name = "Admin"
    };

    string adminPassword = "Admin@123";
    powerUser.EmailConfirmed = true;
    // Passando o e-mail diretamente
    var user = await userManager.FindByEmailAsync(powerUser.Email);

    if (user == null)
    {
        var createPowerUser = await userManager.CreateAsync(powerUser, adminPassword);
        if (createPowerUser.Succeeded)
        {
            await userManager.AddToRoleAsync(powerUser, "Admin");
        }
    }
}
