using MongoDB.Driver;
using MoodPlus.Data;
using MoodPlus.Model;
using MoodPlus.Repositories;
using MoodPlus.Services;
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

builder.Services.AddSingleton<DAO<User>>(sp =>
{
    var db = sp.GetRequiredService<IMongoDatabase>();
    return new DAO<User>(db, "Users"); 
});
builder.Services.AddScoped<IUserService, UserService>();

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
