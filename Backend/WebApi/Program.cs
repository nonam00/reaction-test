using Microsoft.AspNetCore.Authentication.JwtBearer;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.Options;
using System.Reflection;

using Application;
using Application.Common.Mappings;
using Application.Interfaces;

using Backend.Persistence;

using WebApi.Middleware;
using WebApi;

var builder = WebApplication.CreateBuilder(args);

// Addding and configurating AutoMapper
builder.Services.AddAutoMapper(config =>
{
	config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
	config.AddProfile(new AssemblyMappingProfile(typeof(IResultsDbContext).Assembly));
});

// Adding application level via dependency injection
builder.Services.AddApplication();

// Adding persistence (data base) level via dependency injection
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddControllers();

// Setting cors policy for local responds
builder.Services.AddCors(options =>
{
	options.AddPolicy("MyPolicy", policy =>
	{
		policy.AllowAnyOrigin()
			.AllowAnyMethod()
			.AllowAnyHeader();
	});
});

// Adding authentication by JWT Tokens
builder.Services.AddAuthentication(config =>
{
	config.DefaultAuthenticateScheme =
		JwtBearerDefaults.AuthenticationScheme;
	config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
	.AddJwtBearer("Bearer", options =>
	{
		options.Authority = "https://localhost:7076/";
		options.Audience = "ResultsWebAPI";
		options.RequireHttpsMetadata = false;
	});

// Disabling logging of all information about the operations of the entity framework to the console
builder.Logging
	.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning)
	.AddFilter("Microsoft.EntityFrameworkCore", LogLevel.Warning);

builder.Services.AddApiVersioning()
				.AddApiExplorer(options =>
				{
					options.GroupNameFormat = "'v'VVV";
				});

// Adding Swagger for testing http requests
if(builder.Environment.IsDevelopment())
{
	builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
	builder.Services.AddSwaggerGen();
}

var app = builder.Build();

// Adding Swagger for testing http requests
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	app.UseSwagger();
	app.UseSwaggerUI(config =>
	{
		foreach(var description in app.DescribeApiVersions())
		{
			config.SwaggerEndpoint(
				$"/swagger/{description.GroupName}/swagger.json",
				description.GroupName.ToUpperInvariant());
			config.RoutePrefix = string.Empty;
		}
	});
}

app.UseCustomExceptionHandler();
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("MyPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();