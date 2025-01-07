using ApiForMgok.Interfaces;
using ApiForMgok.Interfaces.Repository;
using ApiForMgok.Interfaces.Service;
using ApiForMgok.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;
using ApiForMgok.Models;
using ApiForMgok.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApiForMgokContext>(options =>
    options.UseNpgsql(connectionString));

// ���������� ������������
builder.Services.AddControllers();

// ������������ Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ������������ �������������� ����� JWT
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

// ���������� ����������� ��� �����
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("User", policy =>
        policy.RequireRole("User"));
    options.AddPolicy("Admin", policy =>
        policy.RequireRole("Admin"));
});

// ���������� ��������
builder.Services.AddScoped<IJointRepos, JointRepos>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ITelegramBotRepos, TelegramBotRepos>();
builder.Services.AddScoped<ITelegramBotService, TelegramBotService>();

builder.Services.AddScoped<IOnlinePanelAdminRepos, OnlinePanelAdminRepos>();
builder.Services.AddScoped<IOnlinePanelAdminService, OnlinePanelAdminService>();
builder.Services.AddLogging();

var app = builder.Build();

// ������������ HTTP-���������
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// �������������� � �����������
app.UseAuthentication();
app.UseAuthorization();

// ��������� ��������� ������������
app.MapControllers();

// ������ ����������
app.Run();
