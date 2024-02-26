using Backend.Persistence;
using Backend.WebApi;

var builder = WebApplication.CreateBuilder(args);

//custom json format processing
builder.Services.AddControllers(options =>
{
	options.InputFormatters.Insert(0, MyJPIF.GetJsonPatchInputFormatter());
}).AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer();

//addding persistence (data base) level via dependency injection
builder.Services.AddPersistence(builder.Configuration);

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

// for tests
if(builder.Environment.IsDevelopment())
{
	builder.Services.AddSwaggerGen();
}

var app = builder.Build();

// for tests
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.MapControllers();

app.UseCors("MyPolicy");

app.Run();