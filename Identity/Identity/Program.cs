using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileProviders;

using Identity;
using Identity.Data;
using Identity.Models;

var builder = WebApplication.CreateBuilder(args);

// Db configuration
var connectionString = builder.Configuration.GetConnectionString("MyPostgresDB");

builder.Services.AddDbContext<AuthDbContext>(options =>
{
	options.UseNpgsql(connectionString);
});

// User identity configuration
builder.Services.AddIdentity<AppUser, IdentityRole>(config =>
{
    // User password configuration
    config.Password.RequiredLength = 4;
	config.Password.RequireDigit = false;
	config.Password.RequireNonAlphanumeric = false;
	config.Password.RequireUppercase = false;

})
	.AddEntityFrameworkStores<AuthDbContext>()
	.AddDefaultTokenProviders();

// IdentityServer configuration
builder.Services.AddIdentityServer()
	.AddAspNetIdentity<AppUser>()
	.AddInMemoryApiResources(Configuration.ApiResources)
	.AddInMemoryIdentityResources(Configuration.IdentityResources)
	.AddInMemoryApiScopes(Configuration.ApiScopes)
	.AddInMemoryClients(Configuration.Clients)
	.AddDeveloperSigningCredential();

// Cookie configuration
builder.Services.ConfigureApplicationCookie(config =>
{
	config.LoginPath = "/Auth/Login";
	config.LogoutPath = "/Auth/Logout";

	config.Cookie.HttpOnly = true;
	config.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}

app.UseStaticFiles(new StaticFileOptions
{
	FileProvider = new PhysicalFileProvider(
		Path.Combine(app.Environment.ContentRootPath, "Styles")),
	RequestPath = "/styles"
});

app.UseRouting();
app.UseIdentityServer();
app.MapDefaultControllerRoute();
app.Run();
