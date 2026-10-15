using Microsoft.JSInterop;
using System.Text;
using System.Text.Json;


namespace dymaptic.GeoBlazor.Core.Test.Unit;

[TestClass]
public class RegistrationValidatorTests
{
    [TestInitialize]
    public void TestInitialize()
    {
        RegistrationValidator.ResetForTests();
        _originalOut = Console.Out;
        _consoleOutput = new StringWriter();
        Console.SetOut(_consoleOutput);
    }

    [TestCleanup]
    public void TestCleanup()
    {
        Console.SetOut(_originalOut!);
        RegistrationValidator.ResetForTests();
    }

    [TestMethod]
    public async Task NoKey_ShowsRegistrationMessage()
    {
        RegistrationValidator validator = new(new GeoBlazorSettings(), new FakeJsRuntime());

        await validator.ValidateLicense();

        Assert.Contains(MessageFragment, _consoleOutput!.ToString());
    }

    [TestMethod]
    public async Task MalformedKey_ShowsRegistrationMessageAndDoesNotThrow()
    {
        string notJson = Convert.ToBase64String(Encoding.UTF8.GetBytes("this is not json"));

        foreach (string key in new[] { "not base64 at all!", notJson, "." })
        {
            RegistrationValidator.ResetForTests();
            _consoleOutput!.GetStringBuilder().Clear();
            RegistrationValidator validator = new(new GeoBlazorSettings { RegistrationKey = key },
                new FakeJsRuntime());

            await validator.ValidateLicense();

            Assert.Contains(MessageFragment, _consoleOutput.ToString(), $"Key '{key}' should not be recognized");
        }
    }

    [TestMethod]
    public async Task CoreFreeKey_IsRecognizedAndShowsNoMessage()
    {
        string key = BuildKey("GeoBlazorCore", "Free", 1);
        RegistrationValidator validator = new(new GeoBlazorSettings { RegistrationKey = key }, new FakeJsRuntime());

        await validator.ValidateLicense();

        Assert.DoesNotContain(MessageFragment, _consoleOutput!.ToString());
    }

    [TestMethod]
    public async Task CoreKeyWithWrongTypeVersionOrSoftware_IsNotRecognized()
    {
        foreach (string key in new[]
                 {
                     BuildKey("GeoBlazorCore", "Paid", 1), BuildKey("GeoBlazorCore", "Free", 2),
                     BuildKey("SomethingElse", "Free", 1)
                 })
        {
            RegistrationValidator.ResetForTests();
            _consoleOutput!.GetStringBuilder().Clear();
            RegistrationValidator validator = new(new GeoBlazorSettings { RegistrationKey = key },
                new FakeJsRuntime());

            await validator.ValidateLicense();

            Assert.Contains(MessageFragment, _consoleOutput.ToString());
        }
    }

    [TestMethod]
    public async Task ProKeyWithSignature_IsRecognizedAndShowsNoMessage()
    {
        string key = $"{BuildKey("GeoBlazorPro", "Standard", 3)}.{Convert.ToBase64String("signature"u8.ToArray())}";
        RegistrationValidator validator = new(new GeoBlazorSettings { RegistrationKey = key }, new FakeJsRuntime());

        await validator.ValidateLicense();

        Assert.DoesNotContain(MessageFragment, _consoleOutput!.ToString());
    }

    [TestMethod]
    public async Task LicenseKeyFallback_IsRecognizedWhenRegistrationKeyIsMissing()
    {
        string key = $"{BuildKey("GeoBlazorPro", "Standard", 3)}.c2ln";
        RegistrationValidator validator = new(new GeoBlazorSettings { LicenseKey = key }, new FakeJsRuntime());

        await validator.ValidateLicense();

        Assert.DoesNotContain(MessageFragment, _consoleOutput!.ToString());
    }

    [TestMethod]
    public async Task MessageIsShownOnlyOncePerAppRun()
    {
        GeoBlazorSettings settings = new();
        RegistrationValidator first = new(settings, new FakeJsRuntime());
        RegistrationValidator second = new(settings, new FakeJsRuntime());

        await first.ValidateLicense();
        await first.ValidateLicense();
        await second.ValidateLicense();

        string output = _consoleOutput!.ToString();
        int firstIndex = output.IndexOf(MessageFragment, StringComparison.Ordinal);

        Assert.IsGreaterThanOrEqualTo(0, firstIndex);
        Assert.AreEqual(-1, output.IndexOf(MessageFragment, firstIndex + 1, StringComparison.Ordinal));
    }

    [TestMethod]
    public async Task ServerRuntime_AlsoWritesMessageToBrowserConsole()
    {
        RemoteFakeJsRuntime jsRuntime = new();
        RegistrationValidator validator = new(new GeoBlazorSettings(), jsRuntime);

        await validator.ValidateLicense();

        Assert.AreEqual("console.log", jsRuntime.LastIdentifier);
        Assert.IsNotNull(jsRuntime.LastArgs);
        Assert.Contains(MessageFragment, jsRuntime.LastArgs!.Single()!.ToString()!);
    }

    [TestMethod]
    public async Task ClientRuntime_DoesNotWriteToBrowserConsole()
    {
        FakeJsRuntime jsRuntime = new();
        RegistrationValidator validator = new(new GeoBlazorSettings(), jsRuntime);

        await validator.ValidateLicense();

        Assert.IsNull(jsRuntime.LastIdentifier);
    }

    [TestMethod]
    public async Task ValidateLicense_NeverThrows_WhenBrowserConsoleCallFails()
    {
        RemoteFakeJsRuntime jsRuntime = new() { ThrowOnInvoke = true };
        RegistrationValidator validator = new(new GeoBlazorSettings { RegistrationKey = "garbage" }, jsRuntime);

        await validator.ValidateLicense();

        Assert.Contains(MessageFragment, _consoleOutput!.ToString());
    }

    private static string BuildKey(string software, string licenseType, int licenseVersion)
    {
        string json = JsonSerializer.Serialize(new
        {
            Software = software, LicenseType = licenseType, LicenseVersion = licenseVersion
        });

        return Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
    }

    private const string MessageFragment = "https://licensing.dymaptic.com";
    private TextWriter? _originalOut;
    private StringWriter? _consoleOutput;


    private class FakeJsRuntime : IJSRuntime
    {
        public string? LastIdentifier { get; private set; }
        public object?[]? LastArgs { get; private set; }
        public bool ThrowOnInvoke { get; init; }

        public ValueTask<TValue> InvokeAsync<TValue>(string identifier, object?[]? args)
        {
            if (ThrowOnInvoke)
            {
                throw new JSDisconnectedException("circuit lost");
            }

            LastIdentifier = identifier;
            LastArgs = args;

            return ValueTask.FromResult(default(TValue)!);
        }

        public ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken,
            object?[]? args)
        {
            return InvokeAsync<TValue>(identifier, args);
        }
    }


    // RegistrationValidator detects Blazor Server by the runtime type name containing "Remote"
    private class RemoteFakeJsRuntime : FakeJsRuntime;
}
