/// <summary>
///     Passes a JavaScript function to an ArcGIS property.
/// </summary>/// <param name="Name">
///    
/// </param>
/// <param name="JavaScriptFunction">
///     The JavaScript function to call, passed as a string. Reference the other parameters with lowercase first letters inside the JS function. Function should return SpriteInfo value.
/// </param>
public record GetSpriteInfo(string Name,
    string JavaScriptFunction);

