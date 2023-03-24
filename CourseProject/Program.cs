var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    if (context.Request.Method == "GET")
    {
        //if (context.Request.Query.ContainsKey("id"))
        //{
        //    string id = context.Request.Query["id"];
        //    await context.Response.WriteAsync($"<p>{id}</p>");
        //}
        if (context.Request.Query.ContainsKey("User-Agent"))
        {
            string UserAgent = context.Request.Headers["User-Agent"];
            await context.Response.WriteAsync($"<p>{UserAgent}</p>");
        }
    }
    context.Response.Headers["Context-type"] = "text/html";

});

app.MapGet("/", () => "Hello World!");

app.Run();
