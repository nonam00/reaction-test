using Backend.Persistence;
using Backend.WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
	options.InputFormatters.Insert(0, MyJPIF.GetJsonPatchInputFormatter());
}).AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddPersistance(builder.Configuration);

//for local responds
builder.Services.AddCors(options =>
{
	options.AddPolicy("MyPolicy", policy =>
	{
		policy.AllowAnyOrigin()
			.AllowAnyMethod()
			.AllowAnyHeader();
	});
});

builder.Services.AddMvcCore();

//builder.Services.Configure<MvcOptions>(options =>
//{
//	options.Filters.Add(new CorsAuthorizationFilterFactory("MyPolicy"));
//});

// for tests
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.UseCors("MyPolicy");

app.Run();