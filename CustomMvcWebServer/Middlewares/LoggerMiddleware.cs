namespace CustomMvcWebServer.Middlewares;

public class LoggerMiddleware: Middleware
{
    public override void Handle(HttpListenerContext context)
    {
        Console.WriteLine("{0} {1}", context.Request.HttpMethod, context.Request.RemoteEndPoint);

        Next?.Invoke(context);
    }
}
