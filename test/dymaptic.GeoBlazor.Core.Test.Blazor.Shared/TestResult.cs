

namespace dymaptic.GeoBlazor.Core.Test.Blazor.Shared;

public record TestResult(
    string ClassName,
    int TestCount,
    Dictionary<string, string?> Passed,
    Dictionary<string, string?> Failed,
    Dictionary<string, string?> Inconclusive,
    bool InProgress)
{
    public int Pending => TestCount - (Passed.Count + Failed.Count);
}


public record ErrorEventArgs(Exception Exception, string MethodName);