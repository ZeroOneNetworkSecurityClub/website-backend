using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using website_backend.Data;
using website_backend.Middleware;
using website_backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Database configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("数据库连接字符串未配置")));

// Add controllers with JSON options to handle circular references
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // 循环引用处理，设置为null禁用引用处理
        options.JsonSerializerOptions.ReferenceHandler = null;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Register services
builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IContactService, ContactService>();

var app = builder.Build();

// Create database if not exists
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("数据库连接字符串未配置");
}
using (var connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString.Replace("Database=club_website;", "")))
{
    connection.Open();
    using (var command = new MySql.Data.MySqlClient.MySqlCommand("CREATE DATABASE IF NOT EXISTS club_website;", connection))
    {
        command.ExecuteNonQuery();
    }
    connection.Close();
}

// Apply database migrations and seed data
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

// Add global exception handler middleware
app.UseMiddleware<GlobalExceptionHandler>();

// Add response middleware
app.UseMiddleware<ResponseMiddleware>();

app.MapControllers();

app.Run();