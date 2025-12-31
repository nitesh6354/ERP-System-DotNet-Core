using ERP.API.Middleware;
using ERP.Application.Interfaces;
using ERP.Application.Interfaces.Auth;
using ERP.Application.Services;
using ERP.Infrastructure.Auth;
using ERP.Infrastructure.Data;
using ERP.Infrastructure.Repositories;
using ERP.Infrastructure.Security;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ==================================================
// 1. SERVICES (DEPENDENCY INJECTION)
// ==================================================

builder.Services.AddControllers();

// ---------- DATABASE ----------
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// ---------- APPLICATION LAYER ----------
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAuthService, AuthService>();

// ---------- INFRASTRUCTURE ----------
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<TokenService>();

// ---------- JWT AUTH ----------
var jwtConfig = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtConfig["Key"]!);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = jwtConfig["Issuer"],
            ValidAudience = jwtConfig["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

builder.Services.AddAuthorization();

// ---------- SWAGGER WITH JWT ----------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter: Bearer {your JWT token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// ==================================================
// 2. MIDDLEWARE PIPELINE
// ==================================================

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 🔐 AUTH ORDER IS CRITICAL
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// ---------- DATABASE SEEDER ----------
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await DbSeeder.SeedAdminAsync(db);
}

app.Run();


// ==================================================
// Project: ERP System
// Company: Nitesh Technologies
// Created By: Nitesh Patil
// Description: Enterprise Resource Planning (ERP) System
// Architecture: Layered Architecture (N-Tier) using .NET 8
// ==================================================
