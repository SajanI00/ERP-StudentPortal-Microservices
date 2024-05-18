using ERP.Announcements.Api.Services.Publishers;
using ERP.Announcements.Api.Services.Publishers.Interfaces;
using ERP.Announcements.Core.Interfaces;
using ERP.Announcements.DataService.Data;
using ERP.Announcements.DataService.Repositories;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString)
);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IAnnouncementNotificationPublisherService,
    AnnouncementNotificationPublisherService>();

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
