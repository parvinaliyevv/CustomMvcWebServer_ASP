namespace CustomMvcWebServer.WebHost;

public class Startup : IStartup
{
    public MiddlewareBuilder Configure(MiddlewareBuilder builder)
    {
        builder.Use<LoggerMiddleware>();
        builder.Use<StaticFilesMiddleware>();
        builder.Use<MvcMiddleware>();

        return builder;
    }
}

