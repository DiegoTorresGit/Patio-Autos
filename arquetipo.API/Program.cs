using Microsoft.EntityFrameworkCore;
using arquetipo.Entity.Models;
using arquetipo.Repository.Context;

using arquetipo.Domain.Interfaces;
using arquetipo.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BlogContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPost,PostImplementacion>();
builder.Services.AddScoped<ICliente, ClienteImplementacion>();
builder.Services.AddScoped<IMarca, MarcaImplementacion>();
builder.Services.AddScoped<IEjecutivo, EjecutivoImplementacion>();
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
