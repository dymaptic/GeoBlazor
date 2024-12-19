namespace dymaptic.GeoBlazor.Core.Model;

#pragma warning disable CS1574, CS0419
/// <summary>
///     A handle to a <see cref="LayerView.Highlight" /> call result. The handle can be used to remove the installed
///     highlight.
/// </summary>
/// <param name="JsObjectReference">
///     The JavaScript object reference used by the handle.
/// </param>
#pragma warning restore CS1574, CS0419
public record HighlightHandle(IJSObjectReference JsObjectReference)
{
    /// <summary>
    ///     Removes the highlight.
    /// </summary>
    public async Task Remove()
    {
        await JsObjectReference.InvokeVoidAsync("remove");
    }
}