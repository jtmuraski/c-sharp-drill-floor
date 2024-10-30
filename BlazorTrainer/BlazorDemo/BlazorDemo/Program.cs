using BlazorDemo.Client.Pages;
using BlazorDemo.Components;
using DataAccessDemoLibrary.Data;

// Program.cs is the entry point for the application. It is where the application is configured and started. It is the first file that is run when the application is started
// This is the step at which all of the configurations are set up, and the services are added to the application
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// This is the spot where you will add any dependency injections that you need
// for your application. As well as any services.

// Add services to the container.
builder.Services.AddRazorComponents() // This is what adds Blazor to the application
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Adding the services from the DataAccessDemoLibrary
// YOu do not need to send the config data to the services. Blazor will automatically inject the config data to the service, as long as the service has a constructor that takes in the config data
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IPeopleData, PeopleData>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles(); // This is where files, like images or CSS files can be injected here
app.UseAntiforgery(); // Helps to tell if a user submitted a form from your site or a bot


app.MapRazorComponents<App>() //This is where the Blazor components are mapped to the application, starting with the App component/page
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorDemo.Client._Imports).Assembly);

app.Run(); //Start and run the applicationj
