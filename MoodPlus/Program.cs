using MongoDB.Driver;
using MoodPlus.Data;
using static MoodPlus.Data.MongoDbConnection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<MongoDbConnection>(builder.Configuration.GetSection("MongoDB"));

builder.Services.AddSingleton<MongoClient>(s =>
{
    var settings = builder.Configuration.GetSection("MongoDB").Get<MongoDbSettings>();
    return new MongoClient(settings.ConnectionString);
});

builder.Services.AddSingleton<IMongoDatabase>(s =>
{
    var settings = builder.Configuration.GetSection("MongoDB").Get<MongoDbSettings>();
    var client = s.GetRequiredService<MongoClient>();
    return client.GetDatabase(settings.DatabaseName);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
