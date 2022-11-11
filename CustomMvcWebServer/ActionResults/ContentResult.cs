namespace CustomMvcWebServer.ActionResults;

public class ContentResult : IActionResult
{
    public string Content { get; set; }


    public ContentResult(string content)
    {
        Content = content;
    }


    public void ExecuteResult(HttpListenerContext context)
    {
        var bytes = Encoding.Default.GetBytes(Content);

        context.Response.ContentType = MediaTypeNames.Text.Html;
        context.Response.OutputStream.Write(bytes);
    }
}
