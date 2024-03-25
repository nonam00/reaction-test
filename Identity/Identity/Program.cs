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

// IdentityServer login requirements
builder.Services.AddIdentity<AppUser, IdentityRole>(config =>
{
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
	config.Cookie.Name = "Identity.Cookie";
	config.LoginPath = "/Auth/Login";
	config.LogoutPath = "/Auth/Logout";
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

//Db creation
using(var scope = app.Services.CreateScope())
{
	var serviceProvider = scope.ServiceProvider;
	try
	{
		Console.WriteLine("ODnhfds");
		var context = serviceProvider.GetRequiredService<AuthDbContext>();
		DbInitializer.Initialize(context);
		Console.WriteLine("fsdhisogmp[fdlODnhfds");

	}
	catch (Exception exception)
	{
		var logger = serviceProvider.GetRequiredService<ILogger>();
		Console.WriteLine("ERROR");
	}
}

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
