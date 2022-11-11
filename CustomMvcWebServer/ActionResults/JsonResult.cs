namespace CustomMvcWebServer.ActionResults;

public class JsonResult : IActionResult
{
    public object JsonObject { get; set; }


    public JsonResult(object jsonObject)
    {
        JsonObject = jsonObject;
    }


    public void ExecuteResult(HttpListenerContext context)
    {
        var jsonString = JsonSerializer.Serialize(JsonObject, new JsonSerializerOptions() { WriteIndented = true });
        var bytes = Encoding.UTF8.GetBytes(jsonString);

        context.Response.ContentType = MediaTypeNames.Application.Json;
        context.Response.OutputStream.Write(bytes);
    }
}
