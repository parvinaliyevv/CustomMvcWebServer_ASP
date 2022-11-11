namespace CustomMvcWebServer.ActionResults;

public class ViewResult : IActionResult
{
    public string ControllerName { get; set; }

    public string ViewName { get; set; }
    public string ViewExtension { get; set; }


    public ViewResult(string controllerName, string viewName, string viewExtension)
    {
        ControllerName = controllerName;

        ViewName = viewName;
        ViewExtension = viewExtension;
    }


    public void ExecuteResult(HttpListenerContext context)
    {
        var projectFolder = Directory.GetCurrentDirectory().Split("\\bin")[0];
        var path = string.Format("{0}/Views/{1}/{2}.{3}", projectFolder, ControllerName, ViewName, ViewExtension);

        var bytes = File.ReadAllBytes(path);

        context.Response.ContentType = MediaTypeNames.Text.Html;
        context.Response.OutputStream.Write(bytes);
    }
}
