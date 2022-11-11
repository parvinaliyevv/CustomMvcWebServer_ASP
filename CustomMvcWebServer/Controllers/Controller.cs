namespace CustomMvcWebServer.Controllers;

public abstract class Controller
{
    public HttpListenerContext Context { get; set; }


    private T TemplateMethod<T>(T result) where T : IActionResult
    {
        result.ExecuteResult(Context);
        return result;
    }

    public ContentResult Content(string content) => TemplateMethod(new ContentResult(content));

    public JsonResult Json(object jsonObject) => TemplateMethod(new JsonResult(jsonObject));

    public EmptyResult Empty() => TemplateMethod(new EmptyResult());

    public FileContentResult File(string fileName, string fileExtension, string folderPath)
        => TemplateMethod(new FileContentResult(fileName, fileExtension, folderPath));

    public ViewResult View()
    {
        var sections = Context.Request.RawUrl.Split("/", StringSplitOptions.RemoveEmptyEntries).ToList();
        
        var viewResult = new ViewResult(sections[0], sections[1], "htm");

        return TemplateMethod(viewResult);
    }
}
