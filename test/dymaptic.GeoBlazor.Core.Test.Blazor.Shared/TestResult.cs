﻿namespace dymaptic.GeoBlazor.Core.Test.Blazor.Shared;

public record TestResult(string ClassName, int TestCount, Dictionary<string, string?> Passed, Dictionary<string, string?> Failed);


public record ErrorEventArgs(Exception Exception, string MethodName);