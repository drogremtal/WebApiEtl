using Etl.Core.Interface;
using Etl.Core.Service;
using Etl.DataAccess.Postgres;
using Etl.DataAccess.Postgres.Repository;
using Etl.UploadData.UploadService;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
}); ;
builder.Services.AddScoped<IUniversitetsRepository, UniversitetsRepository>();
builder.Services.AddScoped<IUniversitetsRepository, UniversitetsRepository>();
builder.Services.AddScoped<IDomainRepository, DomainRepository>();
builder.Services.AddScoped<IWebPageRepository, WebPageRepository>();

builder.Services.AddScoped<IServiceUniversitet, ServiceUniversitet>();
builder.Services.AddScoped<IUploadService, UploadService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var config = builder.Configuration;

builder.Services.AddDbContext<DefaultDbContext>(
    option =>
    {
        option.UseNpgsql(config.GetConnectionString("DefaultConnection"));
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
