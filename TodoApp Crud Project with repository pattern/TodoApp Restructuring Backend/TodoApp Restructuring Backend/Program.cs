using System.Text.Json.Serialization;
using TodoApp_Restructuring_Backend;
using TodoApp_Restructuring_Backend.Models.DataSet;
using TodoApp_Restructuring_Backend.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Convert enums to/from strings automatically
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.PropertyNamingPolicy = null; // Preserve property names as-is
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- Dependency Injection ---
// DbContext
builder.Services.AddTransient<DbContext>();

// Repositories
builder.Services.AddScoped<CleanCityRepository>(); // Your repository


// Infrastructure (if you have extension method)
builder.Services.AddInfrastructure();

// --- CORS ---
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors(); // Use the default CORS policy
app.UseAuthorization();

app.MapControllers();

app.Run();
