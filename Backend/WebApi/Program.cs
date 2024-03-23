using System.Reflection;

using Application;
using Application.Common.Mappings;
using Application.Interfaces;

using Backend.Persistence;

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

//disabling logging of all information about the operations of the entity framework to the console
builder.Logging
	.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning)
	.AddFilter("Microsoft.EntityFrameworkCore", LogLevel.Warning);

// for testing https requests
if(builder.Environment.IsDevelopment())
{	
	builder.Services.AddSwaggerGen();
}

var app = builder.Build();

// for testing https requests
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseCors("MyPolicy");

app.MapControllers();

app.Run();