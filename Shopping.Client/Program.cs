using HealthChecks.UI.Client;
using Shopping.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("ShoppingAPIClient", client =>
{
    client.BaseAddress = new Uri("http://localhost:5001/api");
});

// Add services to the container.   
builder.Services.AddControllersWithViews();

builder.Services
    .AddHealthChecks()
    .AddCheck<CustomHealthCheck>(nameof(CustomHealthCheck));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();



app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHealthChecks("/health", new()
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();
