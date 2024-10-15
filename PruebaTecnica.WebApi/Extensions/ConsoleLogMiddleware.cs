using System;

namespace PruebaTecnica.WebApi.Extensions;

public class ConsoleLogMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        context.Request.EnableBuffering();
        var stream = new StreamReader(context.Request.Body);
        string body = await stream.ReadToEndAsync();

        Console.WriteLine("------------ Middleware -------------");
        Console.WriteLine($"HTTP type request {context.Request.Method}");
        Console.WriteLine($"Path: {context.Request.Path}{context.Request.QueryString}");
        if(!string.IsNullOrWhiteSpace(body)) Console.WriteLine(body);
        Console.WriteLine("------------ End Middleware -------------");


        context.Request.Body.Position = 0;
        await next(context);
    }
}
