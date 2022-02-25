
using ExampleContext;
using Microsoft.EntityFrameworkCore;

namespace DBApi;

public static class DBApi  {

    public static WebApplication UseDBApi(this WebApplication app) {

    app.MapGet("/Db/ExampleEntity", async(ExampleDbContext context) =>
    {
        return  await context.ExampleEntity!.ToListAsync();
    });
    
    app.MapPost("/Db/ExampleEntity", async(ExampleEntity exampleEntity, ExampleDbContext context) =>
    {
        context.ExampleEntity!.Add(exampleEntity);
        context.SaveChanges();
        return  await context.ExampleEntity!.ToListAsync();
    });

     return app;
 }
}




