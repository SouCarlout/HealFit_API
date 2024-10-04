using HealFit.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using HealFit.Repositories.Interfaces;
using HealFit.Repositories;
using HealFit.DTO.Mapping;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
   options.AddDefaultPolicy(
   policy => {
       policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
   })
);

// Configurando a cultura padrão para pt-BR
var cultureInfo = new CultureInfo("pt-BR");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

// Conexao Banco de Dados
string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(mySqlConnection,
    ServerVersion.AutoDetect(mySqlConnection)));

// Ignorando Ciclos de Repeticao
builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.
          ReferenceHandler = ReferenceHandler.IgnoreCycles).AddNewtonsoftJson();
builder.Services.AddControllers()
        .AddNewtonsoftJson(options => {
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        });

// Repositorios
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//AutoMapper
builder.Services.AddAutoMapper(typeof(UsuarioDTOMappingProfile));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();