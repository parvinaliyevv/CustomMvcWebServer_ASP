namespace CustomMvcWebServer.Middlewares;

public class MiddlewareBuilder
{
    private Stack<Type> _middlewares;


    public MiddlewareBuilder()
    {
        _middlewares = new Stack<Type>();
    }


    public void Use<T>() where T: IMiddleware, new() => _middlewares.Push(typeof(T));

    public HttpHandler Build()
    {
        HttpHandler handler = context => context.Response.Close();

        while (_middlewares.Count != default)
        {
            var type = _middlewares.Pop();
            var middleware = Activator.CreateInstance(type) as Middleware;

            if (middleware is null) continue;

            middleware.Next = handler;
            handler = middleware.Handle;
        }

        return handler;
    }
}
