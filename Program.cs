
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(typeof(HelloMediatrHandler));
var app = builder.Build();

app.MapGet("/", () => "Hello MediatR!");
app.MapGet("/HelloMediatr", async(IMediator mediator ) => await mediator.Send(new HelloMediatr()) );


app.Run();
