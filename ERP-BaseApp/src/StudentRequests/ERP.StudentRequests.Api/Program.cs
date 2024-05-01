using ERP.StudentRequests.DataService.Repositories;
using ERP.StudentRequests.Core.Interfaces;
using ERP.StudentRequests.DataService.Data;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString)
);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
