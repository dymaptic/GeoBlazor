using Microsoft.Extensions.Logging;
using System.Net.Http.Json;
using System.Text;


namespace dymaptic.GeoBlazor.Core.Test.Blazor.Shared.Logging;

public interface ITestLogger
{
    public Task Log(string message);

    public Task LogError(string message, Exception? exception = null);

    public Task LogError(string message, SerializableException? exception);
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

    public Task LogError(string message, SerializableException? exception)
    {
        if (exception is not null)
        {
            logger.LogError("{Message}\n{Exception}", message, exception.ToString());
        }
        else
        {
            logger.LogError("{Message}", message);
        }

        return Task.CompletedTask;
    }
}

public class ClientTestLogger(IHttpClientFactory httpClientFactory, ILogger<ClientTestLogger> logger) : ITestLogger
{
    public async Task Log(string message)
    {
        using var httpClient = httpClientFactory.CreateClient(nameof(ClientTestLogger));
        logger.LogInformation(message);

        try
        {
            await httpClient.PostAsJsonAsync("/log", new LogMessage(message, null));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error sending log message to server");
        }
    }

    public async Task LogError(string message, Exception? exception = null)
    {
        await LogError(message, SerializableException.FromException(exception));
    }

    public async Task LogError(string message, SerializableException? exception)
    {
        using var httpClient = httpClientFactory.CreateClient(nameof(ClientTestLogger));

        if (exception is not null)
        {
            logger.LogError("{Message}\n{Exception}", message, exception.ToString());
        }
        else
        {
            logger.LogError("{Message}", message);
        }

        try
        {
            await httpClient.PostAsJsonAsync("/log-error", new LogMessage(message, exception));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error sending log message to server");
        }
    }
}

public record LogMessage(string Message, SerializableException? Exception);

/// <summary>
/// A serializable representation of an exception that preserves all important information
/// including the stack trace, which is lost when deserializing a regular Exception.
/// </summary>
public record SerializableException(
    string Type,
    string Message,
    string? StackTrace,
    SerializableException? InnerException)
{
    public static SerializableException? FromException(Exception? exception)
    {
        if (exception is null) return null;

        return new SerializableException(
            exception.GetType().FullName ?? exception.GetType().Name,
            exception.Message,
            exception.StackTrace,
            FromException(exception.InnerException));
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{Type}: {Message}");

        if (!string.IsNullOrEmpty(StackTrace))
        {
            sb.AppendLine(StackTrace);
        }

        if (InnerException is not null)
        {
            sb.AppendLine($" ---> {InnerException}");
        }

        return sb.ToString();
    }
}