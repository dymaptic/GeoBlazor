using dymaptic.GeoBlazor.Core.Components;
using dymaptic.GeoBlazor.Core.Components.Layers;
using dymaptic.GeoBlazor.Core.Events;
using dymaptic.GeoBlazor.Core.Test.Blazor.Shared.Logging;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Polly;
using Polly.Retry;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.RegularExpressions;
using DelayBackoffType = Polly.DelayBackoffType;


namespace dymaptic.GeoBlazor.Core.Test.Blazor.Shared.Components;

[TestClass]
public partial class TestRunnerBase : IAsyncDisposable
{
    public TestRunnerBase()
    {
        var retryStrategyOptions = new RetryStrategyOptions
        {
            BackoffType = DelayBackoffType.Exponential,
            MaxRetryAttempts = 2, // one retry is usually plenty, two just in case
            Delay = TimeSpan.FromSeconds(1),
            ShouldHandle = new PredicateBuilder().Handle<Exception>(ex =>
                !ex.Message.Contains("Invalid GeoBlazor registration key")
                && !ex.Message.Contains("Invalid GeoBlazor Pro license key")
                && !ex.Message.Contains("No GeoBlazor Registration key provided")
                && !ex.Message.Contains("No GeoBlazor Pro license key provided")
                && !ex.Message.Contains("Map component view is in an invalid state")),
            OnRetry = async args =>
            {
                if (args.Context.OperationKey is null)
                {
                    return;
                }

                await CleanupTest(args.Context.OperationKey!, true);
                _testResults[args.Context.OperationKey!] = $"Attempt {args.AttemptNumber + 1} failed. Retrying...";
            }
        };

        _retryPipeline = new ResiliencePipelineBuilder()
            .AddRetry(retryStrategyOptions)
            .Build();
    }

    [Inject]
    public required IJSRuntime JsRuntime { get; set; }
    [Inject]
    public required NavigationManager NavigationManager { get; set; }
    [Inject]
    public required JsModuleManager JsModuleManager { get; set; }
    [Inject]
    public required ITestLogger TestLogger { get; set; }
    [Parameter]
    public EventCallback<TestResult> OnTestResults { get; set; }
    [Parameter]
    public TestResult? Results { get; set; }
    [Parameter]
    public IJSObjectReference? JsTestRunner { get; set; }

    [CascadingParameter(Name = nameof(TestFilter))]
    public string? TestFilter { get; set; }

    protected bool IsCI => Environment.GetEnvironmentVariable("CI") is not null
        && bool.TryParse(Environment.GetEnvironmentVariable("CI"), out var isCI) && isCI;

    private string? FilterValue => TestFilter?.Contains('.') == true ? TestFilter.Split('.')[1] : null;
    private string ClassName => GetType().Name;
    private int Remaining => _methodInfos is null
        ? 0
        : _methodInfos.Length - (_passed.Count + _failed.Count + _inconclusive.Count);

    public async ValueTask DisposeAsync()
    {
        if (JsTestRunner != null)
        {
            try
            {
                await JsTestRunner.DisposeAsync();
            }
            catch (JSDisconnectedException)
            {
                // ignore
            }
        }

        foreach (var cts in _cancellationTokenSources.Values)
        {
            try
            {
                await cts.CancelAsync();
                cts.Dispose();
            }
            catch
            {
                // ignore
            }
        }
    }

    public async Task RunTests(bool onlyFailedTests = false, int skip = 0,
        CancellationToken cancellationToken = default)
    {
        _running = true;

        try
        {
            _resultBuilder = new StringBuilder();

            if (!onlyFailedTests)
            {
                _passed.Clear();
                _inconclusive.Clear();
            }

            List<MethodInfo> methodsToRun = [];
            _filteredTestCount = 0;

            foreach (var method in _methodInfos!.Skip(skip))
            {
                if (onlyFailedTests
                    && (_passed.ContainsKey(method.Name) || _inconclusive.ContainsKey(method.Name)))
                {
                    continue;
                }

                if (!FilterMatch(method.Name))
                {
                    // skip filtered out test
                    continue;
                }

                _testResults[method.Name] = string.Empty;
                methodsToRun.Add(method);
                _filteredTestCount++;
            }

            _failed.Clear();

            foreach (var method in methodsToRun)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }

                await RunTest(method, cancellationToken);
            }
        }
        finally
        {
            _running = false;

            await OnTestResults.InvokeAsync(new TestResult(ClassName, _filteredTestCount, _passed, _failed,
                _inconclusive, _running));
            StateHasChanged();
        }
    }

    public void Toggle(bool open)
    {
        _collapsed = !open;
        StateHasChanged();
    }

    protected override void OnInitialized()
    {
        _type = GetType();

        _methodInfos = _type
            .GetMethods()
            .Where(m => (m.GetCustomAttribute(typeof(TestMethodAttribute), false) != null)
                && FilterMatch(m.Name))
            .ToArray();

        _testResults = _methodInfos
            .ToDictionary(m => m.Name, _ => string.Empty);
        _interactionToggles = _methodInfos.ToDictionary(m => m.Name, _ => false);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender && Results is not null)
        {
            _passed = Results.Passed;
            _failed = Results.Failed;
            _inconclusive = Results.Inconclusive;

            foreach (var passedTest in _passed.Keys)
            {
                _testResults[passedTest] = "<p class=\"passed bold\">Passed</p>";
            }

            foreach (var failedTest in _failed.Keys)
            {
                _testResults[failedTest] = "<p class=\"failed bold\">Failed</p>";
            }

            foreach (var inconclusiveTest in _inconclusive.Keys)
            {
                _testResults[inconclusiveTest] = "<p class=\"inconclusive bold\">Inconclusive</p>";
            }

            StateHasChanged();
        }
    }

    protected void AddMapRenderFragment(RenderFragment fragment, [CallerMemberName] string methodName = "")
    {
        _testRenderFragments[methodName] = fragment;
    }

    protected async Task WaitForMapToRender([CallerMemberName] string methodName = "", int timeoutInSeconds = 10)
    {
        //we are delaying by 100 milliseconds each try.
        //multiplying the timeout by 10 will get the correct number of tries
        var tries = timeoutInSeconds * 10;

        await InvokeAsync(StateHasChanged);

        while (!methodsWithRenderedMaps.Contains(methodName) && (tries > 0))
        {
            if (_mapRenderingExceptions.Remove(methodName, out var ex))
            {
                await TestLogger.LogError("Test Failed", ex);

                ExceptionDispatchInfo.Capture(ex).Throw();
            }

            await Task.Delay(100);
            tries--;
        }

        if (!methodsWithRenderedMaps.Contains(methodName))
        {
            throw new TimeoutException("Map did not render in allotted time.");
        }

        methodsWithRenderedMaps.Remove(methodName);
    }

    protected async Task<string> WaitForDisplayedError([CallerMemberName] string methodName = "",
        int timeoutInSeconds = 10)
    {
        //we are delaying by 100 milliseconds each try.
        //multiplying the timeout by 10 will get the correct number of tries
        var tries = timeoutInSeconds * 10;

        await InvokeAsync(StateHasChanged);

        while (!methodsWithDisplayedErrors.ContainsKey(methodName) && (tries > 0))
        {
            if (_mapRenderingExceptions.Remove(methodName, out var ex))
            {
                await TestLogger.LogError("Test Failed", ex);

                ExceptionDispatchInfo.Capture(ex).Throw();
            }

            await Task.Delay(100);
            tries--;
        }

        if (!methodsWithDisplayedErrors.TryGetValue(methodName, out var error))
        {
            throw new TimeoutException("Map did not throw exception in allotted time.");
        }

        return error;
    }

    /// <summary>
    ///     Handles the LayerViewCreated event and waits for a specific layer type to render.
    /// </summary>
    /// <param name="methodName">
    ///     The name of the test method calling this function, used to track which layer view
    /// </param>
    /// <param name="timeoutInSeconds">
    ///     Optional timeout in seconds to wait for the layer to render. Defaults to 10 seconds.
    /// </param>
    /// <typeparam name="TLayer">
    ///     The type of layer to wait for rendering. Must inherit from <see cref="Layer" />.
    /// </typeparam>
    /// <returns>
    ///     Returns the <see cref="LayerViewCreateEvent" /> for the specified layer type once it has rendered.
    /// </returns>
    /// <exception cref="TimeoutException">
    ///     Throws if the specified layer type does not render within the allotted time.
    /// </exception>
    protected async Task<LayerViewCreateEvent> WaitForLayerToRender<TLayer>([CallerMemberName] string methodName = "",
        int timeoutInSeconds = 10) where TLayer : Layer
    {
        var tries = timeoutInSeconds * 10;

        while ((!layerViewCreatedEvents.ContainsKey(methodName)

                // check if the layer view was created for the specified layer type
                || layerViewCreatedEvents[methodName].All(lvce => lvce.Layer is not TLayer))
            && (tries > 0))
        {
            await Task.Delay(100);
            tries--;
        }

        if (!layerViewCreatedEvents.ContainsKey(methodName)
            || layerViewCreatedEvents[methodName].All(lvce => lvce.Layer is not TLayer))
        {
            throw new TimeoutException($"Layer {typeof(TLayer).Name
            } did not render in allotted time, or LayerViewCreated was not set in MapView.OnLayerViewCreate");
        }

        var createEvent = layerViewCreatedEvents[methodName].First(lvce => lvce.Layer is TLayer);
        layerViewCreatedEvents[methodName].Remove(createEvent);

        return createEvent;
    }

    protected void ClearLayerViewEvents([CallerMemberName] string methodName = "")
    {
        layerViewCreatedEvents.Remove(methodName);
    }

    /// <summary>
    ///     Handles the ListItemCreated event and waits for a ListItem to be created.
    /// </summary>
    /// <param name="methodName">
    ///     The name of the test method calling this function, used to track which layer view
    /// </param>
    /// <param name="timeoutInSeconds">
    ///     Optional timeout in seconds to wait for the layer to render. Defaults to 10 seconds.
    /// </param>
    /// <returns>
    ///     Returns the <see cref="ListItem" />.
    /// </returns>
    /// <exception cref="TimeoutException">
    ///     Throws if the specified layer type does not render within the allotted time.
    /// </exception>
    protected async Task<ListItem> WaitForListItemToBeCreated([CallerMemberName] string methodName = "",
        int timeoutInSeconds = 10)
    {
        var tries = timeoutInSeconds * 10;

        while (!listItems.ContainsKey(methodName)
            && (tries > 0))
        {
            await Task.Delay(100);
            tries--;
        }

        if (!listItems.TryGetValue(methodName, out var items))
        {
            throw new TimeoutException(
                "List Item did not render in allotted time, or ListItemCreated was not set in LayerListWidget.OnListItemCreatedHandler");
        }

        var firstItem = items.First();
        listItems[methodName].Remove(firstItem);

        return firstItem;
    }

    protected async Task AssertJavaScript(string jsAssertFunction, [CallerMemberName] string methodName = "",
        params object?[] args)
    {
        await _retryPipeline.ExecuteAsync(async token =>
        {
            List<object?> jsArgs = [methodName];
            jsArgs.AddRange(args);

            if (jsAssertFunction.Contains("."))
            {
                var parts = jsAssertFunction.Split('.');

                var module = await JsRuntime.InvokeAsync<IJSObjectReference>("import",
                    token, $"./_content/dymaptic.GeoBlazor.Core.Test.Blazor.Shared/{parts[0]}.js");
                await module.InvokeVoidAsync(parts[1], token, jsArgs.ToArray());
            }
            else
            {
                await JsTestRunner!.InvokeVoidAsync(jsAssertFunction, token, jsArgs.ToArray());
            }
        });
    }

    protected async Task WaitForJsTimeout(long time, [CallerMemberName] string methodName = "")
    {
        await JsTestRunner!.InvokeVoidAsync("setJsTimeout", time, methodName);

        while (!await JsTestRunner!.InvokeAsync<bool>("timeoutComplete", methodName))
        {
            await Task.Delay(100);
        }
    }

    protected void Log(string message)
    {
        _resultBuilder.AppendLine($"<p>{message}</p>");
    }

    protected async Task CleanupTest(string testName, bool retry = false)
    {
        methodsWithRenderedMaps.Remove(testName);
        layerViewCreatedEvents.Remove(testName);

        _testResults[testName] = _resultBuilder.ToString();
        _testRenderFragments.Remove(testName);

        await InvokeAsync(async () =>
        {
            StateHasChanged();

            await OnTestResults.InvokeAsync(new TestResult(ClassName, _filteredTestCount, _passed, _failed,
                _inconclusive, _running));
        });
        _interactionToggles[testName] = false;

        if (!retry)
        {
            _currentTest = null;

            if (_cancellationTokenSources.TryGetValue(testName, out var cts))
            {
                await cts.CancelAsync();
                cts.Dispose();
                _cancellationTokenSources.Remove(testName);
            }
        }
    }

    private static void RenderHandler(string methodName)
    {
        methodsWithRenderedMaps.Add(methodName);
    }

    private static Task<bool> ErrorHandler(Exception exception, string methodName)
    {
        methodsWithDisplayedErrors[methodName] = exception.Message;

        return Task.FromResult(true);
    }

    private static void LayerViewCreatedHandler(LayerViewCreateEvent createEvent, string methodName)
    {
        if (!layerViewCreatedEvents.ContainsKey(methodName))
        {
            layerViewCreatedEvents[methodName] = [];
        }

        layerViewCreatedEvents[methodName].Add(createEvent);
    }

    private static Task<ListItem> ListItemCreatedHandler(ListItem item, string methodName)
    {
        if (!listItems.ContainsKey(methodName))
        {
            listItems[methodName] = [];
        }

        listItems[methodName].Add(item);

        return Task.FromResult(item);
    }

    private async Task RunTest(MethodInfo methodInfo, CancellationToken cancellationToken)
    {
        if (JsTestRunner is null)
        {
            await GetJsTestRunner();
        }

        if (_cancellationTokenSources.TryGetValue(methodInfo.Name, out var cts))
        {
            await cts.CancelAsync();
            cts.Dispose();
        }

        cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        _cancellationTokenSources[methodInfo.Name] = cts;

        _testResults[methodInfo.Name] = "<p style=\"color: orange; font-weight: bold\">Running...</p>";
        await TestLogger.Log($"Running test {methodInfo.Name}");

        try
        {
            var actions = methodInfo.GetParameters()
                .Select<ParameterInfo, object>(pi =>
                {
                    var paramType = pi.ParameterType;

                    if (paramType == typeof(Action<LayerViewCreateEvent>))
                    {
                        return (Action<LayerViewCreateEvent>)(createEvent =>
                            LayerViewCreatedHandler(createEvent, methodInfo.Name));
                    }

                    if (paramType == typeof(Func<ListItem, Task<ListItem>>))
                    {
                        return (Func<ListItem, Task<ListItem>>)(item => ListItemCreatedHandler(item, methodInfo.Name));
                    }

                    if (paramType == typeof(Func<Exception, Task<bool>>))
                    {
                        return (Func<Exception, Task<bool>>)(ex => ErrorHandler(ex, methodInfo.Name));
                    }

                    return (Action)(() => RenderHandler(methodInfo.Name));
                })
                .ToArray();

            var context = ResilienceContextPool.Shared.Get(
                new ResilienceContextCreationArguments(methodInfo.Name, null, cts.Token));

            await _retryPipeline.ExecuteAsync(async ctx =>
            {
                if (ctx.CancellationToken.IsCancellationRequested)
                {
                    return;
                }

                _currentTest = methodInfo.Name;
                _resultBuilder = new StringBuilder();
                _passed.Remove(methodInfo.Name);
                _failed.Remove(methodInfo.Name);
                _inconclusive.Remove(methodInfo.Name);
                _testRenderFragments.Remove(methodInfo.Name);
                _mapRenderingExceptions.Remove(methodInfo.Name);
                methodsWithRenderedMaps.Remove(methodInfo.Name);
                layerViewCreatedEvents.Remove(methodInfo.Name);
                listItems.Remove(methodInfo.Name);

                try
                {
                    if (methodInfo.ReturnType == typeof(Task))
                    {
                        await (Task)methodInfo.Invoke(this, actions)!;
                    }
                    else
                    {
                        methodInfo.Invoke(this, actions);
                    }
                }
                catch (TargetInvocationException tie) when (tie.InnerException is not null)
                {
                    throw tie.InnerException;
                }
            }, context);

            ResilienceContextPool.Shared.Return(context);

            _passed[methodInfo.Name] = _resultBuilder.ToString();
            _resultBuilder.AppendLine("<p style=\"color: green; font-weight: bold\">Passed</p>");
        }
        catch (Exception ex)
        {
            if (_currentTest is null)
            {
                return;
            }

            var textResult = $"{_resultBuilder}{Environment.NewLine}{ex.Message}{Environment.NewLine}{ex.StackTrace
            }";
            string displayColor;

            if (ex is AssertInconclusiveException)
            {
                _inconclusive[methodInfo.Name] = textResult;
                displayColor = "white";
            }
            else
            {
                _failed[methodInfo.Name] = textResult;
                displayColor = "red";
            }

            _resultBuilder.AppendLine($"<p style=\"color: {displayColor}; font-weight: bold\">{
                ex.Message.Replace(Environment.NewLine, "<br/>")}<br/>{
                    ex.StackTrace?.Replace(Environment.NewLine, "<br/>")}</p>");
        }
        finally
        {
            if (!_interactionToggles[methodInfo.Name])
            {
                await CleanupTest(methodInfo.Name);
            }
        }
    }

    private void OnRenderError(ErrorEventArgs arg)
    {
        _mapRenderingExceptions[arg.MethodName] = arg.Exception;
    }

    private async Task GetJsTestRunner()
    {
        JsTestRunner = await JsRuntime.InvokeAsync<IJSObjectReference>("import",
            "./_content/dymaptic.GeoBlazor.Core.Test.Blazor.Shared/testRunner.js");
        var proJs = await JsModuleManager.GetProJsModule(JsRuntime, CancellationToken.None);
        var coreJs = await JsModuleManager.GetCoreJsModule(JsRuntime, proJs, CancellationToken.None);
        await JsTestRunner.InvokeVoidAsync("initialize", coreJs);
    }

    private bool FilterMatch(string testName)
    {
        return FilterValue is null
            || Regex.IsMatch(testName, $"^{FilterValue}$", RegexOptions.IgnoreCase);
    }

    private static readonly List<string> methodsWithRenderedMaps = new();
    private static readonly Dictionary<string, string> methodsWithDisplayedErrors = new();
    private static readonly Dictionary<string, List<LayerViewCreateEvent>> layerViewCreatedEvents = new();
    private static readonly Dictionary<string, List<ListItem>> listItems = new();
    private readonly Dictionary<string, RenderFragment> _testRenderFragments = new();
    private readonly Dictionary<string, Exception> _mapRenderingExceptions = new();

    private readonly ResiliencePipeline _retryPipeline;
    private readonly Dictionary<string, CancellationTokenSource> _cancellationTokenSources = new();
    private StringBuilder _resultBuilder = new();
    private Type? _type;
    private MethodInfo[]? _methodInfos;
    private Dictionary<string, string> _testResults = new();
    private bool _collapsed = true;
    private bool _running;
    private Dictionary<string, string?> _passed = new();
    private Dictionary<string, string?> _failed = new();
    private Dictionary<string, string?> _inconclusive = new();
    private int _filteredTestCount;
    private Dictionary<string, bool> _interactionToggles = [];
    private string? _currentTest;
}