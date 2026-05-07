using Polly;
using Polly.Retry;


namespace Utilities;

internal static class ResilienceSetup
{
    public static ResiliencePipeline AppRetryPipeline = new ResiliencePipelineBuilder()
        .AddRetry(new RetryStrategyOptions
        {
            BackoffType = DelayBackoffType.Exponential,
            MaxRetryAttempts = 3,
            Delay = TimeSpan.FromSeconds(1),
            OnRetry = context =>
            {
                Console.WriteLine($"Attempt #{context.AttemptNumber + 1} for task failed. Retrying...",
                    context.Context.OperationKey);
                context.Context.Properties.Set(retryAttemptKey, context.AttemptNumber);

                return ValueTask.CompletedTask;
            }
        })
        .Build();

    private static readonly ResiliencePropertyKey<int> retryAttemptKey = new("RetryAttempt");
}