using AutoMapper;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using RestaurantOrder.Api.Dtos.Profiles;
using RestaurantOrder.Data;
using RestaurantOrder.Repositories.Implementations;
using RestaurantOrder.Repositories.Interfaces;
using RestaurantOrder.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.Configure<RestaurantOrderDbSettings>(builder.Configuration.GetSection(nameof(RestaurantOrderDbSettings)));

builder.Services.AddSingleton<IRestaurantOrderDbSettings>(rodb => rodb.GetRequiredService<IOptions<RestaurantOrderDbSettings>>().Value);
builder.Services.AddSingleton<IMongoClient>(s => 
            new MongoClient(builder.Configuration.GetValue<string>("RestaurantOrderDbSettings:ConnectionString")));

builder.Services.AddScoped<IOrderService, OrderService>()
                .AddScoped<IOrderDetailRepository, OrderDetailRepository>();

builder.Services.AddCors(options => options.AddPolicy("mycorspolicy", p => p.WithOrigins("*").AllowAnyMethod().AllowAnyHeader()));
builder.Services.AddAutoMapper(typeof(CommonProfile));
builder.Services.AddSingleton<IMapper, Mapper>();

builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo
{    
    Title = "Restaurant Order System Api",
    Description = "Restaurant Order System - Api",
    Version = "v1"
}));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{        
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {        
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant Api Documentation");
    });
}
app.UseCors("mycorspolicy");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
