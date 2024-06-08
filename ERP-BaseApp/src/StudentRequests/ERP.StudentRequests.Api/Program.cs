using ERP.StudentRequests.DataService.Repositories;
using ERP.StudentRequests.Core.Interfaces;
using ERP.StudentRequests.DataService.Data;
using Microsoft.EntityFrameworkCore;
using MassTransit;
using ERP.StudentRequests.Api.Services.Publishers.Interfaces;
using ERP.StudentRequests.Api.Services.Publishers;
using System.Text.Json.Serialization;



var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString)
);


builder.Services.AddControllers()
    //.AddJsonOptions(options =>
    //{
    //    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    //})
    ;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IRequestNotificationPublisherService,
    RequestNotificationPublisherService>();

builder.Services.AddMassTransit(conf =>
{
    conf.SetKebabCaseEndpointNameFormatter();
    conf.SetInMemorySagaRepositoryProvider();

    var asb = typeof(Program).Assembly;
    conf.AddConsumers(asb);
    conf.AddSagaStateMachines(asb);
    conf.AddSagas(asb);
    conf.AddActivities(asb);


    conf.UsingRabbitMq((ctx, cfg) => {
        cfg.Host("localhost", "/", h => {
            h.Username("user");
            h.Password("password");
        });

        cfg.ConfigureEndpoints(ctx);
    });

});

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
