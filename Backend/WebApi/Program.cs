using WebApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
	options.InputFormatters.Insert(0, MyJPIF.GetJsonPatchInputFormatter());
}).AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<ResultsDbSettings>(
	builder.Configuration.GetSection("ResultsDatabase"));

builder.Services.AddSingleton<ResultService>();

//var settings = MongoClientSettings.FromConnectionString(connectionUri);
//// Set the ServerApi field of the settings object to set the version of the Stable API on the client
//settings.ServerApi = new ServerApi(ServerApiVersion.V1);
//// Create a new client and connect to the server
//var client = new MongoClient(settings);
//// Send a ping to confirm a successful connection
//try
//{
//	var result = client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
//	Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
//}
//catch (Exception ex)
//{
//	Console.WriteLine(ex);
//}

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

app.Run();