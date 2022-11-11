namespace CustomMvcWebServer.Middlewares;

public class MvcMiddleware : Middleware
{
    public override void Handle(HttpListenerContext context)
    {
        if (!string.IsNullOrWhiteSpace(context.Request.RawUrl))
        {
            var sections = context.Request.RawUrl.Split("/", StringSplitOptions.RemoveEmptyEntries).ToList();
            var projectName = Assembly.GetExecutingAssembly().GetName().Name;

            if (sections.Count >= 2)
            {
                try
                {
                    var controllerType = Type.GetType(string.Format("{0}.Controllers.{1}Controller", projectName, sections[0]));
                    var methodInfo = controllerType?.GetMethod(sections[1]);

                    var controller = Activator.CreateInstance(controllerType) as Controller;
                    controller.Context = context;

                    methodInfo?.Invoke(controller, null);
                }
                catch { }
            }
        }

        Next?.Invoke(context);
    }
}
