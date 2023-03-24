using Middlewares.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

//app.Use(async (HttpContext context, RequestDelegate next) =>
//{
//    await context.Response.WriteAsync("HELLO");
//    await next(context);
//});

//app.UseMiddleware<MyCustomMiddleware>();
//app.Use(async (HttpContext context, RequestDelegate next) =>
//{
//    await context.Response.WriteAsync("GOODBYE");
//}); 
app.UseWhen(
    context => context.Request.Query.ContainsKey("username"),
    app =>
    {
        app.Use(async (context, next) =>
        {
            await context.Response.WriteAsync("Hello from when");
            await next();
        });
    }
    );
app.Run(async context =>
{
    await context.Response.WriteAsync("Hello from else");
});
app.MapGet("/", () => "Hello World!");

app.Run();
