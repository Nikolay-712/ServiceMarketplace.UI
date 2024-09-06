using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ServiceMarketplace.Client;
using ServiceMarketplace.Services;
using ServiceMarketplace.Services.Implementations;
using ServiceMarketplace.Services.Interfaces;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7247")
        });

        builder.Services.AddScoped<IHttpCategoryClient, HttpCategoryClient>();
        builder.Services.AddAuthorizationCore();
        builder.Services.AddScoped<AuthenticationStateProvider, AppAuthStateProvider>();

        await builder.Build().RunAsync();
    }
}