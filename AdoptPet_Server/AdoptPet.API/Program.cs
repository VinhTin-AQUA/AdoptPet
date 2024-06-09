using AdoptPet.Application.DTOs;
using AdoptPet.Infrastructure;
using AdoptPet.Infrastructure.Services;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// infrastructure
builder.Services.AddServiceInfrastructure(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allow cors
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowAnyOrigin", option => option.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
});
builder.Services.Configure<GlobalSettings>(builder.Configuration.GetSection("GlobalSettings"));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Use(async (context, next) =>
{
    await next();
    if (context.Response.StatusCode == 200 &&
        context.Response.Headers["Content-Type"].ToString().StartsWith("image"))
    {
        context.Response.Headers.Add("Access-Control-Allow-Origin", "*"); // Or your specific origin
    }
});
app.UseHttpsRedirection();

app.UseCors(option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// cấu hình file tĩnh
app.UseStaticFiles();


using var scope = app.Services.CreateScope();
try
{
    var contextSeedService = scope.ServiceProvider.GetService<ContextSeedService>();
    await contextSeedService!.InitializeContextAsync(); // gọi hàm để sinh dữ liệu mẫu
}
catch (Exception ex)
{
    var logger = scope.ServiceProvider.GetService<ILogger<Program>>();
    logger!.LogError("Error: " + ex.InnerException, ex.InnerException);
}

app.Run();
