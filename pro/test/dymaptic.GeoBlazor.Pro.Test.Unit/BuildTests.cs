using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;


namespace dymaptic.GeoBlazor.Pro.Test.Unit;

[TestCategory("AutomationExclude")]
[CICondition(ConditionMode.Exclude)]
[TestClass]
public sealed class BuildTests
{
    private static string CorePackagePath => Path.Combine(coreRepositoryRootDirectory,
        $"dymaptic.GeoBlazor.Core.{_currentProVersion}.nupkg");
    private static string ProPackagePath => Path.Combine(coreRepositoryRootDirectory,
        $"dymaptic.GeoBlazor.Pro.{_currentProVersion}.nupkg");
    private static string OS => OperatingSystem.IsWindows() ? "win" : OperatingSystem.IsLinux() ? "linux" : "osx";
    private static string Architecture => RuntimeInformation.OSArchitecture.ToString().ToLowerInvariant();
    private static string BuildScriptsFolder => Path.Combine(coreRepositoryRootDirectory, "build-tools",
        $"{OS}-{Architecture}");

    [ClassInitialize]
    public static void ClassInit(TestContext context)
    {
        _currentProVersion = GetProVersion();

        // Back up packages if they exist
        if (File.Exists(CorePackagePath))
        {
            File.Copy(CorePackagePath, CorePackagePath + ".bak", true);
        }

        if (File.Exists(ProPackagePath))
        {
            File.Copy(ProPackagePath, ProPackagePath + ".bak", true);
        }
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {
        // Restore backed up packages
        if (File.Exists(CorePackagePath + ".bak") && !File.Exists(CorePackagePath))
        {
            File.Copy(CorePackagePath + ".bak", CorePackagePath, true);
            File.Delete(CorePackagePath + ".bak");
        }

        if (File.Exists(ProPackagePath + ".bak") && !File.Exists(ProPackagePath))
        {
            File.Copy(ProPackagePath + ".bak", ProPackagePath, true);
            File.Delete(ProPackagePath + ".bak");
        }
    }

    [TestInitialize]
    public void TestInit()
    {
        _logger = new ProcessLogger();

        // Clean up any existing packages
        File.Delete(CorePackagePath);
        File.Delete(ProPackagePath);
    }

    [TestCleanup]
    public void TestCleanup()
    {
        Console.Write(_logger.Log);
        Console.Error.Write(_logger.ErrorLog);
    }

    [TestMethod]
    [CICondition(ConditionMode.Exclude)]
    public void RunCoreBuildInReleaseModeAndGeneratePackage()
    {
        StartBuild("Release", true, true);
        Assert.IsTrue(File.Exists(CorePackagePath));
        Assert.IsFalse(File.Exists(ProPackagePath));
    }

    [TestMethod]
    public void RunFullBuildInReleaseModeAndGeneratePackage()
    {
        StartBuild("Release", false, true);
        Assert.IsTrue(File.Exists(CorePackagePath));
        Assert.IsTrue(File.Exists(ProPackagePath));
    }

    [TestMethod]
    [CICondition(ConditionMode.Exclude)]
    public void RunCoreBuildInDevelopmentMode()
    {
        StartBuild("Development", true, false);
        Assert.IsFalse(File.Exists(CorePackagePath));
        Assert.IsFalse(File.Exists(ProPackagePath));
    }

    [TestMethod]
    public void RunFullBuildInDevelopmentMode()
    {
        StartBuild("Development", false, false);
        Assert.IsFalse(File.Exists(CorePackagePath));
        Assert.IsFalse(File.Exists(ProPackagePath));
    }

    [TestMethod]
    [CICondition(ConditionMode.Exclude)]
    public void RunCoreBuildInReleaseModeWithCustomVersion()
    {
        string packagePath =
            Path.Combine(coreRepositoryRootDirectory, "dymaptic.GeoBlazor.Core.3.0.0.nupkg");

        try
        {
            StartBuild("Release", true, true, "3.0.0");
            Assert.IsTrue(File.Exists(packagePath));
            Assert.IsFalse(File.Exists(ProPackagePath));
        }
        finally
        {
            File.Delete(packagePath);
        }
    }

    private static string GetProVersion()
    {
        XmlDocument doc = new();
        doc.Load(proPropsFilePath);
        XmlNode? proVersionNode = doc.SelectSingleNode("//Project/PropertyGroup/ProVersion");

        if ((proVersionNode == null) || string.IsNullOrWhiteSpace(proVersionNode.InnerText))
        {
            throw new InvalidOperationException("Could not find ProVersion in Directory.Build.props");
        }

        return proVersionNode.InnerText.Trim();
    }

    private void StartBuild(string configuration, bool coreOnly, bool generatePackage, string? version = null)
    {
        version ??= _currentProVersion;

        string arguments =
            $"{(coreOnly ? "" : "-pro ")}-c {configuration} -v {version} {(generatePackage ? "-pkg " : "")} -bl";

        ProcessStartInfo startInfo = new()
        {
            FileName = "dotnet",
            Arguments = $"{Path.Combine(BuildScriptsFolder, "GeoBlazorBuild.dll")} -- {arguments}",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true,
            WorkingDirectory = coreRepositoryRootDirectory
        };

        Process? process = Process.Start(startInfo);

        if (process == null)
        {
            Assert.Fail("Failed to start build process");

            return;
        }

        process.OutputDataReceived += (sender, e) =>
        {
            if (e.Data != null)
            {
                _logger.WriteLine(e.Data);
            }
        };

        process.ErrorDataReceived += (sender, e) =>
        {
            if (e.Data != null)
            {
                _logger.WriteErrorLine(e.Data);
            }
        };
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        process.WaitForExit();

        if (process.ExitCode != 0)
        {
            Assert.Fail($"Build process failed with exit code {process.ExitCode}");
        }
    }

    private static readonly string currentAssemblyDirectory =
        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
    private static readonly string currentProjectDirectory =
        Path.GetFullPath(Path.Combine(currentAssemblyDirectory, "../../../"));
    private static readonly string proRepositoryRootDirectory =
        Path.GetFullPath(Path.Combine(currentProjectDirectory, "../../"));
    private static readonly string coreRepositoryRootDirectory =
        Path.GetFullPath(Path.Combine(proRepositoryRootDirectory, ".."));
    private static readonly string proPropsFilePath =
        Path.Combine(proRepositoryRootDirectory, "Directory.Build.props");
    private static string _currentProVersion = string.Empty;
    private static ProcessLogger _logger = new();
}

public class ProcessLogger
{
    public StringBuilder Log = new();
    public StringBuilder ErrorLog = new();

    public void WriteLine(string? message)
    {
        Log.AppendLine(message);
    }

    public void WriteErrorLine(string? message)
    {
        ErrorLog.AppendLine(message);
    }
}