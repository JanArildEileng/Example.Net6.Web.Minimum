using Swashbuckle.AspNetCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });                
    });



var app = builder.Build();

app.UseSwagger((option)=>{
}).UseSwaggerUI();


app.MapGet("/", () => "Hello World with Swagger!");

app.Run();
