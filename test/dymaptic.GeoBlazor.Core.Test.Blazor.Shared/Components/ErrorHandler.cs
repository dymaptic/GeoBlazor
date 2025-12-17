using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;


namespace dymaptic.GeoBlazor.Core.Test.Blazor.Shared.Components;

public class ErrorHandler : ErrorBoundary
{
    [Parameter]
    [EditorRequired]
    public required string MethodName { get; set; }

    [Parameter]
    public EventCallback<ErrorEventArgs> OnError { get; set; }

    protected override async Task OnErrorAsync(Exception exception)
    {
        await OnError.InvokeAsync(new ErrorEventArgs(exception, MethodName));
    }
}