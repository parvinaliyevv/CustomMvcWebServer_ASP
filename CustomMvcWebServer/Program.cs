namespace CustomMvcWebServer;

internal static class Program
{
    private static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;

        var ipAddress = ConfigurationManager.AppSettings["IpAddress"];
        var port = ushort.Parse(ConfigurationManager.AppSettings["PortNumber"]);

        var host = new Host(ipAddress, port);
        host.UseStartup<Startup>();

        host.Run();
    }
}
