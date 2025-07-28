using CompanyApp.Data;
using CompanyApp.Helpers;
using CompanyApp.Middlewares;
using CompanyApp.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Add services to the container

// ➤ Database Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ➤ Repository (DI)
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

// ➤ Controllers
builder.Services.AddControllers();

// ➤ Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ➤ AutoMapper
// OR typeof(MappingProfile) if in Helpers
// Fix for CS1503: Argument 2: cannot convert from 'System.Type' to 'System.Action<AutoMapper.IMapperConfigurationExpression>'
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

var app = builder.Build();

// 🔹 Middleware Pipeline

// ➤ Global Exception Handling
app.UseMiddleware<ExceptionMiddleware>();

// ➤ Swagger (Only in Development)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ➤ HTTPS Redirection
app.UseHttpsRedirection();

// ➤ Authorization (Can be expanded later)
app.UseAuthorization();

// ➤ Map API Controllers
app.MapControllers();

// ➤ Run the app
app.Run();
