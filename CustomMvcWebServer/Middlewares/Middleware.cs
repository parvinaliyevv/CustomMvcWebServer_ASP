namespace CustomMvcWebServer.Middlewares;

public abstract class Middleware : IMiddleware
{
    public HttpHandler Next { get; set; }

    public abstract void Handle(HttpListenerContext context);
}
