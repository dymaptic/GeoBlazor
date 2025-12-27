using Microsoft.Extensions.Logging;
using System.Net.Http.Json;


namespace dymaptic.GeoBlazor.Core.Test.Blazor.Shared.Logging;

public interface ITestLogger
{
    public Task Log(string message);

    public Task LogError(string message, Exception? exception = null);
}

public class ServerTestLogger(ILogger<ServerTestLogger> logger) : ITestLogger
{
    public Task Log(string message)
    {
        logger.LogInformation(message);

        return Task.CompletedTask;
    }

    public Task LogError(string message, Exception? exception = null)
    {
        logger.LogError(exception, message);
        return Task.CompletedTask;
    }
}

public class ClientTestLogger(IHttpClientFactory httpClientFactory, ILogger<ClientTestLogger> logger) : ITestLogger
{
    public async Task Log(string message)
    {
        using var httpClient = httpClientFactory.CreateClient(nameof(ClientTestLogger));
        logger.LogInformation(message);
        await httpClient.PostAsJsonAsync("/log", new LogMessage(message, null));
    }

    public async Task LogError(string message, Exception? exception = null)
    {
        using var httpClient = httpClientFactory.CreateClient(nameof(ClientTestLogger));
        logger.LogError(exception, message);
        await httpClient.PostAsJsonAsync("/log-error", new LogMessage(message, exception));
    }
}

public record LogMessage(string Message, Exception? Exception);