using TodoApp_Restructuring_Backend;
using TodoApp_Restructuring_Backend.Models.DataSet;
using TodoApp_Restructuring_Backend.Repositories.Implementations;
using TodoApp_Restructuring_Backend.Repositories.Interfaces;
using TodoApp_Restructuring_Backend.Services.Implementations;
using TodoApp_Restructuring_Backend.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();

// Add your service registrations here

builder.Services.AddInfrastructure();
builder.Services.AddTransient<DbContext>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseAuthorization();

app.MapControllers();

app.Run();
