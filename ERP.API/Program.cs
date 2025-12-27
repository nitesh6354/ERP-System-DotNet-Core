using ERP.API.Middleware;
using ERP.Application.Interfaces;
using ERP.Application.Services;
using ERP.Infrastructure.Data;
using ERP.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ==================================================
// 1. ADD SERVICES TO THE DEPENDENCY INJECTION (DI)
// ==================================================

// 1️⃣ Add Controllers (API endpoints)
builder.Services.AddControllers();

// 2️⃣ Register DbContext (EF Core + SQL Server)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// 3️⃣ Register Application Layer services (Business logic)
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

// 4️⃣ Register Infrastructure repositories (Data access)
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

// 5️⃣ Swagger (API documentation)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ==================================================
// 2. CONFIGURE HTTP REQUEST PIPELINE (MIDDLEWARE)
// ==================================================

// 🔴 Global Exception Handling Middleware (MUST be first)
app.UseMiddleware<ExceptionMiddleware>();

// Swagger only in Development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirect HTTP → HTTPS
app.UseHttpsRedirection();

// Authorization middleware (Authentication will be added later)
app.UseAuthorization();

// Map controller routes
app.MapControllers();

// Start the application
app.Run();
