namespace CustomMvcWebServer.Middlewares;

public delegate void HttpHandler(HttpListenerContext context);

public interface IMiddleware
{
    void Handle(HttpListenerContext context);
}
