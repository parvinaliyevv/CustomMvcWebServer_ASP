namespace CustomMvcWebServer.ActionResults;

public class FileContentResult : IActionResult
{
    public string FileName { get; set; }
    public string FileExtension { get; set; }
    public string FolderPath { get; set; }


    public FileContentResult(string fileName, string fileExtension, string folderPath)
    {
        FileName = fileName;
        FileExtension = fileExtension;
        FolderPath = folderPath;
    }


    public void ExecuteResult(HttpListenerContext context)
    {
        var path = string.Format(@"{0}\{1}.{2}", FolderPath, FileName, FileExtension);

        if (File.Exists(path))
        {
            var bytes = File.ReadAllBytes(path);

            context.Response.ContentType = $"Application/{FileExtension}";
            context.Response.OutputStream.Write(bytes);
        }
    }
}
