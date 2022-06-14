using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RestaurantOrder.Data;
using RestaurantOrder.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RestaurantOrderDbSettings>(builder.Configuration.GetSection(nameof(RestaurantOrderDbSettings)));
builder.Services.AddSingleton<IRestaurantOrderDbSettings>(rodb => rodb.GetRequiredService<IOptions<RestaurantOrderDbSettings>>().Value);
builder.Services.AddSingleton<IMongoClient>(s => 
            new MongoClient(builder.Configuration.GetValue<string>("RestaurantDbConfig:ConnectionString")));
builder.Services.AddScoped<IOrderService, OrderService>();

// Add services to the container.
builder.Services.AddRazorPages();

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

app.Run();
