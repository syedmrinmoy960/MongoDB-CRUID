//using Microsoft.OpenApi.Models;
//using MongoDB_CRUID;
//using MongoDB_CRUID.Extensions;
//using MongoDB_CRUID.Models;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.Configure<MongoDBSettings>(
//    builder.Configuration.GetSection("MongoDB"));
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
//});



//// Add controllers, etc.
//builder.Services.AddControllers();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//    // Enable Swagger in development mode
//    app.UseSwagger();
//    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
//}
//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

using Microsoft.OpenApi.Models;
using MongoDB_CRUID.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Configure MongoDB services, repositories, and managers
builder.Services.ConfigureMongoDbServices(builder.Configuration);

// Add Swagger for API documentation
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

// Add controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
