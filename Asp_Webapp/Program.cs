using Microsoft.EntityFrameworkCore;
using Asp_Webapp.Helpers.Repositories;
using Asp_Webapp.Helpers.Services;
using Asp_Webapp.Models.Contexts;
using Asp_Webapp.Models.Identity;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("merketo")));
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("sql")));

builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<UserAddressRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<SeedService>();

builder.Services.AddScoped<ShowcaseService>();

builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ProductRepo>();
builder.Services.AddScoped<CategoryRepo>();
builder.Services.AddScoped<ProductCategoryRepo>();
builder.Services.AddScoped<ContactFormRepo>();
builder.Services.AddScoped<ContactFormService>();

builder.Services.AddIdentity<AppUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<IdentityContext>()
    .AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>();

builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/login";
    x.LogoutPath = "/";
    x.AccessDeniedPath = "/denied";
});

var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
