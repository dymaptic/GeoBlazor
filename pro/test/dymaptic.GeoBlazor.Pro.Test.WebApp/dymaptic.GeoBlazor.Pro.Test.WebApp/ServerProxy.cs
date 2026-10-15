using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Http.Resilience;
using Microsoft.Extensions.Primitives;
using Polly;
using System.Net;
using DelayBackoffType = Polly.DelayBackoffType;


namespace dymaptic.GeoBlazor.Pro.Test.WebApp;

public static class ServerProxy
{
    public static void AddProxyHttpClient(this IServiceCollection services)
    {
#pragma warning disable EXTEXP0001
        services.AddHttpClient(nameof(ServerProxy))
            .RemoveAllResilienceHandlers()
#pragma warning restore EXTEXP0001
            .AddResilienceHandler("ProxyPipeline",
                static builder =>
                {
                    builder.AddRetry(new HttpRetryStrategyOptions
                    {
                        BackoffType = DelayBackoffType.Exponential,
                        MaxRetryAttempts = 10,
                        UseJitter = true,
                        Delay = TimeSpan.FromMilliseconds(500),
                        ShouldHandle = static args => ValueTask.FromResult(args.Outcome.Exception is not null ||
                            args.Outcome.Result?.StatusCode is
                                HttpStatusCode.RequestTimeout or
                                HttpStatusCode.TooManyRequests or
                                HttpStatusCode.BadGateway or
                                HttpStatusCode.ServiceUnavailable or
                                HttpStatusCode.GatewayTimeout or
                                HttpStatusCode.BadRequest)
                    });

                    builder.AddCircuitBreaker(new HttpCircuitBreakerStrategyOptions
                    {
                        SamplingDuration = TimeSpan.FromSeconds(10),
                        FailureRatio = 0.2,
                        MinimumThroughput = 3,
                        ShouldHandle = static args => ValueTask.FromResult(args.Outcome.Exception is not null ||
                            args.Outcome.Result?.StatusCode is
                                HttpStatusCode.RequestTimeout or
                                HttpStatusCode.TooManyRequests)
                    });

                    builder.AddTimeout(TimeSpan.FromSeconds(30));
                });
    }

    public static void MapProxies(this WebApplication app)
    {
        app.MapGet("/proxy", ForwardRequest)
            .CacheOutput(policy => policy
                .Expire(TimeSpan.FromHours(6))
                .SetVaryByQuery("url", "service", "request", "outputFormat", "typename", "typenames",
                    "srsname", "bbox", "count", "startindex", "layer"));
    }

    private static async Task<IResult> ForwardRequest(HttpContext context,
        IHttpClientFactory httpClientFactory, IMemoryCache memoryCache, ILogger<Program> logger)
    {
        HttpClient httpClient = httpClientFactory.CreateClient(nameof(ServerProxy));

        Dictionary<string, string> queryDict = context.Request.Query
            .ToDictionary(q => q.Key.ToLowerInvariant(),
                q => q.Value.ToString());

        // get the real url, and remove from query dictionary
        if (!queryDict.Remove("url", out string? urlParam))
        {
            return Microsoft.AspNetCore.Http.Results.BadRequest("Missing 'url' query parameter");
        }

        // Build the target URL
        string targetUrl = urlParam.StartsWith("http") ? urlParam : $"https://{urlParam}";

        // remove arcgis token
        queryDict.Remove("token");

        queryDict.TryGetValue("service", out string? service);

        if (service == "wfs")
        {
            UpdateWfsQuery(queryDict, targetUrl, memoryCache);
        }

        // Build query string
        List<string> queryParams = queryDict
            .Select(q => $"{q.Key}={q.Value}")
            .ToList();

        if (queryParams.Count > 0)
        {
            targetUrl += (targetUrl.Contains('?') ? "&" : "?") + string.Join("&", queryParams);
        }

        // Forward the request
        HttpRequestMessage requestMessage = new(HttpMethod.Get, targetUrl);

        // Copy safe headers
        foreach (KeyValuePair<string, StringValues> header in context.Request.Headers)
        {
            if (header.Key.StartsWith("sec-", StringComparison.OrdinalIgnoreCase) ||
                header.Key.Equals("Host", StringComparison.OrdinalIgnoreCase) ||
                header.Key.Equals("Origin", StringComparison.OrdinalIgnoreCase) ||
                header.Key.Equals("Referer", StringComparison.OrdinalIgnoreCase) ||
                header.Key.Equals("priority", StringComparison.OrdinalIgnoreCase) ||
                header.Key.Equals("Cookie", StringComparison.OrdinalIgnoreCase) ||
                header.Key.Equals("User-Agent", StringComparison.OrdinalIgnoreCase) ||
                header.Key.Equals("traceparent", StringComparison.OrdinalIgnoreCase) ||
                header.Key.Equals("Accept-Encoding", StringComparison.OrdinalIgnoreCase) ||
                header.Key.Equals("Cache-Control", StringComparison.OrdinalIgnoreCase) ||
                header.Key.Equals("Pragma", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            try
            {
                requestMessage.Headers.TryAddWithoutValidation(header.Key, header.Value.ToArray());
            }
            catch
            {
                // Skip headers that can't be added
            }
        }

        try
        {
            HttpResponseMessage response = await httpClient.SendAsync(requestMessage);

            logger.LogInformation("""
                                  Proxy Response to {TargetUrl}: 
                                  - Status Code: {StatusCode}
                                  - Request Headers:
                                      {RequestHeaders}
                                  - Response Headers:
                                      {ResponseHeaders} 
                                  """,
                targetUrl, response.StatusCode,
                string.Join($"{Environment.NewLine}    ",
                    requestMessage.Headers.Select(h => $"{h.Key}: {string.Join(", ", h.Value)}")),
                string.Join($"{Environment.NewLine}    ",
                    response.Headers.Select(h => $"{h.Key}: {string.Join(", ", h.Value)}")));

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return Microsoft.AspNetCore.Http.Results.StatusCode((int)response.StatusCode);
            }

            byte[] content2 = await response.Content.ReadAsByteArrayAsync();
            string contentType = response.Content.Headers.ContentType?.ToString() ?? "application/octet-stream";

            return Microsoft.AspNetCore.Http.Results.Bytes(content2, contentType);
        }
        catch (HttpRequestException ex)
        {
            return Microsoft.AspNetCore.Http.Results.Problem($"Proxy error: {ex.Message}", statusCode: 502);
        }
    }

    private static void UpdateWfsQuery(Dictionary<string, string> queryDict, string targetUrl, IMemoryCache memoryCache)
    {
        queryDict.TryGetValue("request", out string? requestType);

        string memoryCacheKey = $"{targetUrl}_{requestType}_OutputFormat";

        if (queryDict.TryGetValue("outputformat", out string? outputFormat))
        {
            memoryCache.Set(memoryCacheKey, outputFormat);
        }
        else if (requestType is not null)
        {
            if (memoryCache.TryGetValue(memoryCacheKey, out string? cachedFormat))
            {
                queryDict["outputformat"] = cachedFormat!;
            }
            else if (requestType.Equals("getfeature", StringComparison.OrdinalIgnoreCase))
            {
                // set feature requests to default to json
                queryDict.TryAdd("outputformat", "json");
            }
        }
    }
}