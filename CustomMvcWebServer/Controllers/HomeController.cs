namespace CustomMvcWebServer.Controllers;

public class HomeController: Controller
{
    public IActionResult GetContentResult() => Content("Lorem Ipsum Dolor");

    public IActionResult GetJsonResult() => Json(new { Name = "Lorem", Surname = "Ipsum", FatherName = "Dolor" });

    public IActionResult GetEmptyResult() => Empty();

    public IActionResult GetFileContentResult()
    {
        var fileName = "C 10 in a Nutshell The Definitive Reference (Joseph Albahari) (z-lib.org)";
        var fileExtension = "pdf";

        var folderPath = string.Format(@"{0}\wwwroot", $"{Directory.GetCurrentDirectory().Split("\\bin")[0]}");

        return File(fileName, fileExtension, folderPath);
    }

    public IActionResult GetViewResult() => View();
}
