using GerenciadorDeEstufasAPI.Context;
using GerenciadorDeEstufasAPI.Repository;
using GerenciadorDeEstufasAPI.Repository.Interfaces;
using GerenciadorDeEstufasAPI.Services;
using GerenciadorDeEstufasAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<GerenciadorContext>(opts => 
    opts.UseSqlServer(connectionString));

builder.Services.AddScoped<IAmostraRepository, AmostraRepository>();
builder.Services.AddScoped<IEstufaRepository, EstufaRepository>();

builder.Services.AddTransient<IEstufaService, EstufaService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
