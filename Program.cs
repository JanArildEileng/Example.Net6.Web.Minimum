using Serilog;
using Microsoft.OpenApi.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ExampleMeditor;
using ExampleContext;
using DBApi;

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
    builder.Services.AddMediatR(typeof(HelloMediatrHandler));
    builder.Services.AddAutoMapper(typeof(AutoMapperProfiles.TestProfile));
    builder.Services.AddDbContext<ExampleDbContext>(op=>op.UseSqlite($"Data Source=.\\Context\\Test.db") );

    var app=builder.Build();

    app.UseSwagger((option)=>{
    }).UseSwaggerUI();

  
    app.MapGet("/", () => "Hello World , Swagger,Serilog,Mediator!");
    app.MapGet("/HelloMediatr", async(IMediator mediator ) => await mediator.Send(new HelloMediatr()) );
    app.MapGet("/Ping", async(IMediator mediator ) =>{
            await mediator.Publish(new Ping());
            return "Pong";
    });
    
   
    app.MapPost("/Automapper", (AutoMapperProfiles.FromTestClass from, AutoMapper.IMapper mapper) =>
    {
        return  mapper.Map<AutoMapperProfiles.ToTestClass>(from);
    });

    app.UseDBApi();

    app.Run();


} catch (Exception ex)  {
  
    string type = ex.GetType().Name;
   if (type.Equals("StopTheHostException", StringComparison.Ordinal))
   {
      throw;
   }
     Log.Error(ex, "Something went wrong");
}  finally  {
    Log.Information("Goodbye,Serilog!");
    Log.CloseAndFlush();
}
