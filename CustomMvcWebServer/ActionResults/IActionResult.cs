namespace CustomMvcWebServer.ActionResults;

public interface IActionResult
{
    void ExecuteResult(HttpListenerContext context);
}
