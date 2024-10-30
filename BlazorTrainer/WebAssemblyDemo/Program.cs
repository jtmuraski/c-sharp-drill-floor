using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebAssemblyDemo;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// This is where you would the services needed
builder.Services.AddScoped(sp => new HttpClient
    {
        BaseAddress = new Uri("https://jsonplaceholder.typicode.com/") // This is the base URL for the API. Using JSON Placeholder as an example, which will also supply dummy API data
});
await builder.Build().RunAsync();
