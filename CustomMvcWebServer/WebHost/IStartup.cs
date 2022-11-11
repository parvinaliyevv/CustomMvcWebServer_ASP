namespace CustomMvcWebServer.WebHost;

public interface IStartup
{
    MiddlewareBuilder Configure(MiddlewareBuilder builder);
}
