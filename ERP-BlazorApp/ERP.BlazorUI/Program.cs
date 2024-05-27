using ERP.BlazorUI.Components;
using MudBlazor.Services;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();
//builder.Services.AddScoped<IStudentService, StudentService>();

//builder.Services.AddScoped(IServiceProvider=> new HttpClient() 
//{
//    BaseAddress = new Uri("https://localhost:7001/")
//});

var app = builder.Build();



if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
