using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Reflection;

using Application;
using Application.Common.Mappings;
using Application.Interfaces;

using Backend.Persistence;
using WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(config =>
{
	config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
	config.AddProfile(new AssemblyMappingProfile(typeof(IResultsDbContext).Assembly));
});

//adding application level via dependency injection
builder.Services.AddApplication();

//adding persistence (data base) level via dependency injection
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddControllers();

//setting cors policy for local responds
builder.Services.AddCors(options =>
{
	options.AddPolicy("MyPolicy", policy =>
	{
		policy.AllowAnyOrigin()
			.AllowAnyMethod()
			.AllowAnyHeader();
	});
});

builder.Services.AddAuthentication(config =>
{
	config.DefaultAuthenticateScheme =
		JwtBearerDefaults.AuthenticationScheme;
	config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
	.AddJwtBearer("Bearer", options =>
	{
		options.Authority = "https://localhost:7076";
		options.Audience = "ResultsWebAPI";
		options.RequireHttpsMetadata = false;
	});

//disabling logging of all information about the operations of the entity framework to the console
builder.Logging
	.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning)
	.AddFilter("Microsoft.EntityFrameworkCore", LogLevel.Warning);

// for testing http requests
if(builder.Environment.IsDevelopment())
{	
	builder.Services.AddSwaggerGen();
}

var app = builder.Build();

// for testing http requests
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCustomExceptionHandler();
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("MyPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();