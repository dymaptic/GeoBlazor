using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;


namespace dymaptic.GeoBlazor.Coreges;

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
[IgnoreAntiforgeryToken]
public class ErrorModel : PageModel
{
    public ErrorModel(ILogger<ErrorModel> logger)
    {
        _logger = logger;
    }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    public string? RequestId { get; set; }

    public void OnGet()
    {
        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
    }

    // ReSharper disable once NotAccessedField.Local
    private readonly ILogger<ErrorModel> _logger;
}