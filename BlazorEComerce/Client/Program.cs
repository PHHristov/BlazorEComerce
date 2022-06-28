global using BlazorEComerce.Shared;
global using BlazorEComerce.Shared.Models;
global using BlazorEComerce.Shared.Models.DTO;
global using System.Net.Http.Json;
global using BlazorEComerce.Client.Services;
global using BlazorEComerce.Client.Services.ProductService;
global using BlazorEComerce.Client.Services.CategoryService;
global using Microsoft.AspNetCore.Components;
global using BlazorEComerce.Client.Services.CartService;
global using BlazorEComerce.Client.Services.AuthService;
global using BlazorEComerce.Client.Services.OrderService;
global using BlazorEComerce.Client.Services.PaymentService;
global using Microsoft.AspNetCore.Components.Authorization;
global using Blazored.LocalStorage;

using BlazorEComerce.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>(); 


await builder.Build().RunAsync();
