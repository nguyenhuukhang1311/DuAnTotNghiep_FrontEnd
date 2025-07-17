using DuAnTotNghiep_FrontEnd;
using DuAnTotNghiep_FrontEnd.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7094") });
builder.Services.AddScoped<InputReceiptService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ColorService>();
builder.Services.AddScoped<SizeService>();
builder.Services.AddScoped<FabricService>();
builder.Services.AddScoped<OutputReceiptService>();
builder.Services.AddScoped<BranchService>();

builder.Services.AddBlazorBootstrap();
await builder.Build().RunAsync();
