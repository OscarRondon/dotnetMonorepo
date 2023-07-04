using Series_101_4_0_aspnet.Models;
using Series_101_4_0_aspnet.Services;
using System.Text.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddTransient<JsonFileProductService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        // We can add the endpoints at main but its better to have it separated in a controller e.g ProductsController.cs
        //app.MapGet("/products", (context) => {
        //    IEnumerable<Product> products = app.Services.GetService<JsonFileProductService>().GetProducts();
        //    string jsonResp = JsonSerializer.Serialize(products);
        //    return context.Response.WriteAsJsonAsync(jsonResp);
        //});

        app.MapControllers();
        app.MapBlazorHub();
        
        app.Run();
    }
}