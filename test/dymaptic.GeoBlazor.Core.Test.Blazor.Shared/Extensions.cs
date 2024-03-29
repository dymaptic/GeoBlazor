﻿using System.Text.RegularExpressions;


namespace dymaptic.GeoBlazor.Core.Test.Blazor.Shared;

public static class Extensions
{
    public static string CamelCaseToSpaces(string input)
    {
        return Regex.Replace(input, "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", " $1");
    }
}