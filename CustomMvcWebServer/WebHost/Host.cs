namespace CustomMvcWebServer.WebHost;

public class Host
{
    private HttpListener _listener;

    private string _ipAddress;
    private ushort _port;

    private MiddlewareBuilder _builder;
    private HttpHandler _builderAction;


    public Host(string ipAddress, ushort port)
    {
        _ipAddress = ipAddress;
        _port = port;

        _listener = new HttpListener();
        _builder = new MiddlewareBuilder();
    }


    public void UseStartup<T>() where T : IStartup, new()
        => _builderAction = new T().Configure(_builder).Build();

    public void HandlerRequest(HttpListenerContext context)
        => _builderAction.Invoke(context);

    public void Run()
    {
        _listener.Prefixes.Add(string.Format("http://{0}:{1}/", _ipAddress, _port));

        _listener.Start();

        Console.WriteLine("Server started on port {0}", _port);

        while (true)
        {
            var context = _listener.GetContext();

            Task.Factory.StartNew(() => _builderAction.Invoke(context));
        }
    }
}
