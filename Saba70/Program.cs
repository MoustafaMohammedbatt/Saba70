using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Helpers;
using Persistence.Repositories;
using Saba70.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddServicesRegistration(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add DataBase Register

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//Seed Data In DataBase 
DbInitializer.Seed(app);

app.Run();
