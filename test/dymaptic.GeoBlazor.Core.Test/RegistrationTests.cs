using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using Microsoft.JSInterop.Infrastructure;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json;


namespace dymaptic.GeoBlazor.Core.Test;

[TestClass]
public class RegistrationTests
{
    [TestInitialize]
    public void SetupTest()
    {
        Type validatorType = typeof(RegistrationValidator);
        FieldInfo? field = validatorType.GetField("_inMemoryValidationResult", 
            BindingFlags.Static | BindingFlags.NonPublic);
        if (field != null) field.SetValue(null, null);
        FieldInfo? messageField = validatorType.GetField("_messageShown", 
            BindingFlags.Static | BindingFlags.NonPublic);
        if (messageField != null) messageField.SetValue(null, false);
    }

    [TestCleanup]
    public void CleanupTest()
    {
        ClearServerFile();
    }

    [TestMethod]
    public async Task TestCanValidateRegistrationOnBlazorServer()
    {
        ValidationResult result = new(true, DateTime.MaxValue)
        {
            BaseUri = "http://localhost/", MachineName = Environment.MachineName, Version = new Version(0, 1, 0, 0)
        };
        FakeHttpMessageHandler messageHandler = new(result, HttpStatusCode.OK);
        RegistrationValidator validator = GetValidator(result, HttpStatusCode.OK, new FakeRemoteJsRuntime(null),
            messageHandler);
        await validator.ValidateLicense();
        AssertMessageCalled(false);
        Assert.AreEqual(1, messageHandler.CallCount);
    }

    [TestMethod]
    public async Task TestCanValidateStoredRegistrationOnBlazorServer()
    {
        ValidationResult result = new(true, DateTime.MaxValue)
        {
            BaseUri = "http://localhost/", MachineName = Environment.MachineName, Version = new Version(0, 1, 0, 0)
        };
        await SetServerFile(result);
        FakeHttpMessageHandler messageHandler = new(result, HttpStatusCode.OK);
        RegistrationValidator validator = GetValidator(result, HttpStatusCode.OK, new FakeRemoteJsRuntime(result));
        await validator.ValidateLicense();

        Assert.AreEqual(0, messageHandler.CallCount);
        AssertMessageCalled(false);
    }

    [TestMethod]
    public async Task TestCanValidateRegistrationOnBlazorWasm()
    {
        ValidationResult result = new(true, DateTime.MaxValue)
        {
            BaseUri = "http://localhost/", MachineName = Environment.MachineName, Version = new Version(0, 1, 0, 0)
        };
        FakeHttpMessageHandler messageHandler = new(result, HttpStatusCode.OK);
        RegistrationValidator validator = GetValidator(result, HttpStatusCode.OK, new FakeInProcessJsRuntime(null),
            messageHandler);
        await validator.ValidateLicense();
        AssertMessageCalled(false);
        Assert.AreEqual(1, messageHandler.CallCount);
    }

    [TestMethod]
    public async Task TestCanValidateStoredRegistrationOnBlazorWasm()
    {
        ValidationResult result = new(true, DateTime.MaxValue)
        {
            BaseUri = "http://localhost/", MachineName = Environment.MachineName, Version = new Version(0, 1, 0, 0)
        };
        FakeHttpMessageHandler messageHandler = new(result, HttpStatusCode.OK);

        RegistrationValidator validator = GetValidator(result, HttpStatusCode.OK,
            new FakeInProcessJsRuntime(result),
            messageHandler);
        await validator.ValidateLicense();

        Assert.AreEqual(0, messageHandler.CallCount);
        AssertMessageCalled(false);
    }

    [TestMethod]
    public async Task TestInvalidRegistrationOnBlazorServer()
    {
        ValidationResult result = new ValidationResult(false, DateTime.MinValue,
            $"This registration is only for version Test of GeoBlazor")
        {
            BaseUri = "http://localhost/", MachineName = Environment.MachineName, Version = new Version(0, 1, 0, 0)
        };
        RegistrationValidator validator = GetValidator(result, HttpStatusCode.OK, new FakeRemoteJsRuntime(result));
        await validator.ValidateLicense();
        AssertMessageCalled(true);
    }

    [TestMethod]
    public async Task TestCanValidateInMemoryRegistration()
    {
        ValidationResult result = new(true, DateTime.MaxValue)
        {
            BaseUri = "http://localhost/", MachineName = Environment.MachineName, Version = new Version(0, 1, 0, 0)
        };

        FieldInfo? field = typeof(RegistrationValidator).GetField("_inMemoryValidationResult",
            BindingFlags.Static | BindingFlags.NonPublic);
        if (field != null) field.SetValue(null, result);
        FakeHttpMessageHandler messageHandler = new(result, HttpStatusCode.OK);

        RegistrationValidator validator = GetValidator(result, HttpStatusCode.OK, new FakeInProcessJsRuntime(result),
            messageHandler);
        await validator.ValidateLicense();

        Assert.AreEqual(0, messageHandler.CallCount);
        AssertMessageCalled(false);
    }

    [TestMethod]
    public async Task TestInvalidRegistrationOnBlazorWasm()
    {
        ValidationResult result = new ValidationResult(false, DateTime.MinValue,
            $"This registration is only for version Test of GeoBlazor")
        {
            BaseUri = "http://localhost/", MachineName = Environment.MachineName, Version = new Version(0, 1, 0, 0)
        };
        RegistrationValidator validator = GetValidator(result, HttpStatusCode.OK, new FakeInProcessJsRuntime(result));
        await validator.ValidateLicense();
        AssertMessageCalled(true);
    }

    [TestMethod]
    public async Task TestChangedUrlInvalidatesLicense()
    {
        ValidationResult result = new(true, DateTime.MaxValue)
        {
            BaseUri = "https://test1.com", MachineName = Environment.MachineName, Version = new Version(0, 1, 0, 0)
        };
        await SetServerFile(result);
        FakeHttpMessageHandler messageHandler = new(result, HttpStatusCode.OK);

        RegistrationValidator validator = GetValidator(result, HttpStatusCode.OK, new FakeRemoteJsRuntime(result),
            messageHandler);
        await validator.ValidateLicense();
        Assert.AreEqual(1, messageHandler.CallCount);
        AssertMessageCalled(false);
    }

    [TestMethod]
    public async Task TestChangedUrlInvalidatesInMemoryRegistration()
    {
        ValidationResult result = new(true, DateTime.MaxValue)
        {
            BaseUri = "https://test1.com", MachineName = Environment.MachineName, Version = new Version(0, 1, 0, 0)
        };
        await SetServerFile(result);

        FieldInfo? field = typeof(RegistrationValidator).GetField("_inMemoryValidationResult",
            BindingFlags.Static | BindingFlags.NonPublic);
        if (field != null) field.SetValue(null, result);
        FakeHttpMessageHandler messageHandler = new(result, HttpStatusCode.OK);

        RegistrationValidator validator = GetValidator(result, HttpStatusCode.OK, new FakeRemoteJsRuntime(result),
            messageHandler);
        await validator.ValidateLicense();
        Assert.AreEqual(1, messageHandler.CallCount);
        AssertMessageCalled(false);
    }

    [TestMethod]
    public async Task TestChangedMachineNameInvalidatesRegistration()
    {
        ValidationResult result = new(true, DateTime.MaxValue)
        {
            BaseUri = "http://localhost/",
            MachineName = Environment.MachineName + "new",
            Version = new Version(0, 1, 0, 0)
        };
        await SetServerFile(result);
        FakeHttpMessageHandler messageHandler = new(result, HttpStatusCode.OK);

        RegistrationValidator validator = GetValidator(result, HttpStatusCode.OK, new FakeRemoteJsRuntime(result),
            messageHandler);
        await validator.ValidateLicense();

        Assert.AreEqual(1, messageHandler.CallCount);
        AssertMessageCalled(false);
    }

    private void AssertMessageCalled(bool wasCalled)
    {
        FieldInfo? field = typeof(RegistrationValidator).GetField("_messageShown",
            BindingFlags.Static | BindingFlags.NonPublic);

        if (wasCalled)
        {
            Assert.IsTrue((bool?)field?.GetValue(null));
        }
        else
        {
            Assert.IsFalse((bool?)field?.GetValue(null));
        }
    }

    private RegistrationValidator GetValidator(object? responseContent, HttpStatusCode responseStatusCode,
        IJSRuntime jsRuntime, FakeHttpMessageHandler? messageHandler = null)
    {
        messageHandler ??= new(responseContent, responseStatusCode);
        HttpClient httpClient = new(messageHandler);
        NavigationManager navigationManager = new FakeNavigationManager();
        IConfiguration config = new ConfigurationBuilder().Build();

        return new RegistrationValidator(_settings, jsRuntime, httpClient, navigationManager, config);
    }

    private void ClearServerFile()
    {
        string directoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
        string filePath = Path.Combine(directoryPath, "geoblazor-registration-validation");

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }

    private async Task SetServerFile(ValidationResult result)
    {
        string jsonResult = JsonSerializer.Serialize(result);
        string encodedResult = Convert.ToBase64String(Encoding.UTF8.GetBytes(jsonResult));
        string directoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
        string filePath = Path.Combine(directoryPath, "geoblazor-registration-validation");
        await File.WriteAllTextAsync(filePath, encodedResult);
    }

    private readonly GeoBlazorSettings _settings = new()
    {
        RegistrationKey = "Test123",
        ValidationServerStoragePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!
    };
}

public class FakeRemoteJsRuntime : FakeInProcessJsRuntime
{
    public FakeRemoteJsRuntime(ValidationResult? storedValidation) : base(storedValidation)
    {
    }
}

public class FakeInProcessJsRuntime : IJSRuntime
{
    public FakeInProcessJsRuntime(ValidationResult? storedValidation)
    {
        _storedValidation = JsonSerializer.Serialize(storedValidation);
    }

    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, object?[]? args)
    {
        if (typeof(TValue) == typeof(IJSObjectReference))
        {
            return ValueTask.FromResult((TValue)(object)new FakeJsObjectReference(_storedValidation));
        }
        if (_storedValidation is null || typeof(TValue) == typeof(IJSVoidResult)) return default;
        return ValueTask.FromResult((TValue)Convert.ChangeType(_storedValidation, typeof(TValue)));
    }

    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken,
        object?[]? args)
    {
        if (typeof(TValue) == typeof(IJSObjectReference))
        {
            return ValueTask.FromResult((TValue)(object)new FakeJsObjectReference(_storedValidation));
        }
        if (_storedValidation is null || typeof(TValue) == typeof(IJSVoidResult)) return default;
        return ValueTask.FromResult((TValue)Convert.ChangeType(_storedValidation, typeof(TValue)));
    }

    private readonly string? _storedValidation;
}

public class FakeJsObjectReference : IJSObjectReference
{
    private readonly string? _storedValidation;

    public FakeJsObjectReference(string? storedValidation)
    {
        _storedValidation = storedValidation;
    }

    public ValueTask DisposeAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, object?[]? args)
    {
        if (_storedValidation is null || typeof(TValue) == typeof(IJSVoidResult)) return default;

        return ValueTask.FromResult((TValue)Convert.ChangeType(_storedValidation, typeof(TValue)));
    }

    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken,
        object?[]? args)
    {
        if (_storedValidation is null || typeof(TValue) == typeof(IJSVoidResult)) return default;

        return ValueTask.FromResult((TValue)Convert.ChangeType(_storedValidation, typeof(TValue)));
    }
}

public class FakeNavigationManager : NavigationManager
{
    public FakeNavigationManager()
    {
        Initialize("http://localhost/", "http://localhost/");
    }
}

public class FakeHttpMessageHandler : HttpMessageHandler
{
    public FakeHttpMessageHandler(object? responseContent, HttpStatusCode responseStatusCode)
    {
        _responseContent = responseContent;
        _responseStatusCode = responseStatusCode;
    }

    public int CallCount { get; private set; } = 0;

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        string contentMessage = _responseContent is null ? string.Empty : JsonSerializer.Serialize(_responseContent);
        CallCount++;
        return Task.FromResult(new HttpResponseMessage
        {
            StatusCode = _responseStatusCode, Content = new StringContent(contentMessage)
        });
    }
    
    private readonly object? _responseContent;
    private readonly HttpStatusCode _responseStatusCode;
}