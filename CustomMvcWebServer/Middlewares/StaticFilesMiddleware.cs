namespace CustomMvcWebServer.Middlewares;

public class StaticFilesMiddleware : Middleware
{
    public override void Handle(HttpListenerContext context)
    {
        var filename = context.Request.RawUrl.Substring(1);
        var projectFolder = Directory.GetCurrentDirectory().Split("\\bin")[0];

        if (Path.HasExtension(filename))
        {
            var path = string.Format(@"{0}\wwwroot\{1}", projectFolder, filename);
            var extension = Path.GetExtension(filename);

            if (File.Exists(path))
            {
                if (extension == ".htm") context.Response.ContentType = MediaTypeNames.Text.Html;
                else if (extension == ".png") context.Response.ContentType = MediaTypeNames.Image.Jpeg;

                var bytes = File.ReadAllBytes(path);
                context.Response.OutputStream.Write(bytes, 0, bytes.Length);

                context.Response.Close();
            }
        }
        else Next?.Invoke(context);
    }
}
