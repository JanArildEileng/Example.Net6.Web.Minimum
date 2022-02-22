
using Serilog;
using Swashbuckle.AspNetCore;
using Microsoft.OpenApi.Models;

//Sett om logging med Serilog , uten å bruke Appsetting.json
Log.Logger= new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();


try {
    Log.Information("Hello, world Serilog!");

    var builder = WebApplication.CreateBuilder(args);
 //       builder.Logging.AddSerilog();  //bruk Serilog i tilegg til annen logging

    //bruk Appsetting.json til å konfigurer Serilog
     var serilogger= new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .CreateLogger();

    builder.Host.UseSerilog(serilogger);  //kun bruk Serilog til logging


    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });                
    });


    var app=builder.Build();
    app.UseSwagger((option)=>{
    }).UseSwaggerUI();

    app.MapGet("/", () => "Hello World with Swagger!");


  
    app.MapGet("/", () => "Hello World!");
    app.Run();

} catch (Exception ex)  {
     Log.Error(ex, "Something went wrong");
}  finally  {
    Log.Information("Goodbye,Serilog!");
    Log.CloseAndFlush();
}
