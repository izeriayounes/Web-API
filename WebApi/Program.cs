using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Interfaces;
using WebApi.Repository;
using System.Text.Json.Serialization;
using WebApi.Middlewares;
using WebApi.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddCors(options =>
{
    options.AddPolicy("corspolicy" ,builder =>
    {
        builder.WithOrigins("http://localhost:3000", "https://aec8-196-89-1-210.ngrok-free.app").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
    });
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IEnfantRepository, EnfantRepository>();
builder.Services.AddScoped<IFamilleRepository, FamilleRepository>();
builder.Services.AddScoped<IParrainageRepository, ParrainageRepository>();
builder.Services.AddScoped<IParrainRepository, ParrainRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<JwtService>();
    
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("corspolicy");

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
