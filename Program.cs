using ApiForMgok.Interfaces;
using ApiForMgok.Interfaces.Repository;
using ApiForMgok.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;
using ApiForMgok.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApiForMgokContext>(options =>
    options.UseNpgsql(connectionString));

// Добавление контроллеров
builder.Services.AddControllers();

// Конфигурация Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Конфигурация аутентификации через JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
    options.DefaultChallengeScheme =
    options.DefaultForbidScheme =
    options.DefaultScheme =
    options.DefaultSignInScheme =
    options.DefaultSignOutScheme =
    JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigninKey"])),
        ValidateLifetime = true,
    };
});

// Добавление авторизаций для ролей
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("User", policy =>
        policy.RequireRole("User"));
    options.AddPolicy("Admin", policy =>
        policy.RequireRole("Admin"));
});

// Добавление сервисов
builder.Services.AddScoped<IJointRepos, JointRepos>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddLogging();

var app = builder.Build();

// Конфигурация HTTP-пайплайна
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Аутентификация и авторизация
app.UseAuthentication();
app.UseAuthorization();

// Настройка маршрутов контроллеров
app.MapControllers();

// Запуск приложения
app.Run();
