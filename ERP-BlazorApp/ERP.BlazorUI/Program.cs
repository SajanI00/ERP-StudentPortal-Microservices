using ERP.BlazorUI.Components;
using MudBlazor.Services;
using System.Text.Json;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();
//builder.Services.AddScoped<IStudentService, StudentService>();

//builder.Services.AddScoped(IServiceProvider=> new HttpClient() 
//{
//    BaseAddress = new Uri("https://localhost:7001/")
//});


//builder.Services.AddScoped(sp => new HttpClient
//{
//    BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiBaseAddress")), 
//    DefaultRequestHeaders =
//    {
//        Accept = { new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json") }
//    }
//}.ConfigureJsonOptions());



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


//public static class HttpClientExtensions
//{
//    public static HttpClient ConfigureJsonOptions(this HttpClient client)
//    {
//        var options = new JsonSerializerOptions
//        {
//            ReferenceHandler = ReferenceHandler.Preserve,
//            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
//        };
//        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
//        client.DefaultRequestHeaders.AcceptEncoding.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("utf-8"));
//        client.DefaultRequestHeaders.AcceptCharset.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("utf-8"));
//        client.DefaultRequestHeaders.AcceptLanguage.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("en-US"));

//        client.DefaultRequestHeaders.Add("JsonOptions", JsonSerializer.Serialize(options));

//        return client;
//    }
//}
