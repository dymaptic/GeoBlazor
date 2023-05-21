using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;


namespace dymaptic.GeoBlazor.Core.Test.Blazor.Components;

public class ErrorHandler: ErrorBoundary
{
    [Parameter]
    public string MethodName { get; set; } = default!;
    
    [Parameter]
    public EventCallback<ErrorEventArgs> OnError { get; set; }

    protected override async Task OnErrorAsync(Exception exception)
    {
        await OnError.InvokeAsync(new ErrorEventArgs(exception, MethodName));
    }
}