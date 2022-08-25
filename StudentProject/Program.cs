using Microsoft.EntityFrameworkCore;
using StudentProject.Database;
using StudentProject.IContract;
using StudentProject.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AminjonDbContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("AminjonConnection")));

builder.Services.AddScoped<IAminjonService, AminjonService>();


builder.Services.AddDbContext<PostgresDbContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("PostgresConnection")));

builder.Services.AddScoped<IPostgresService, PostgresService>();

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
