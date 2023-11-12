using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorWASM;
using MudBlazor.Services;
using ShopClient;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(sp => new HttpClient() { 
    Timeout = TimeSpan.FromSeconds(5)
});
builder.Services.AddSingleton(provider 
    => new ShopClient.ShopClient(provider.GetRequiredService<HttpClient>(), "https://localhost:7183"));
//builder.Services.AddScoped<IProductCatalog, ProductCatalog>();
builder.Services.AddMudServices();

await builder.Build().RunAsync();
