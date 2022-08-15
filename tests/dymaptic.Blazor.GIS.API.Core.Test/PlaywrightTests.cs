using System.Diagnostics;


namespace dymaptic.Blazor.GIS.API.Core.Test;

[TestClass]
public class PlaywrightTests
{
    [TestMethod]
    public void TestMethod1()
    {
        var processStartInfo = new ProcessStartInfo("dotnet", 
            "run --project ../../../../../samples/dymaptic.blazor.GIS.API.Core.Sample.Server/dymaptic.blazor.GIS.API.Core.Sample.Server.csproj --no-build")
        {
            UseShellExecute = true
        };
    
        _serverProcess = Process.Start(processStartInfo);

        Console.WriteLine("Hello!");
        Assert.IsNotNull(_serverProcess);
    }

    private static Process? _serverProcess;
}