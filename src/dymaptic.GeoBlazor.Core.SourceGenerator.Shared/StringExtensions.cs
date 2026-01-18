namespace dymaptic.GeoBlazor.Core.SourceGenerator.Shared;

/// <summary>
///     Provides extension methods for string manipulation in the source generator.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    ///     Converts the first character of a string to lowercase.
    /// </summary>
    /// <param name="input">The input string to convert.</param>
    /// <returns>
    ///     The input string with its first character converted to lowercase,
    ///     or the original string if it is null, empty, or already starts with a lowercase character.
    /// </returns>
    public static string ToLowerFirstChar(this string input)
    {
        if (string.IsNullOrEmpty(input) || char.IsLower(input[0]))
        {
            return input;
        }

        return char.ToLower(input[0]) + input.Substring(1);
    }
}