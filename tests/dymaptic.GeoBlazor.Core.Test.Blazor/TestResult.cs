namespace dymaptic.GeoBlazor.Core.Test.Blazor;

public record TestResult(string ClassName, Dictionary<string, string?> Passed, Dictionary<string, string?> Failed);

public class TestException: Exception
{
    public TestException(string message) : base(message)
    {
    }
}

public record ErrorEventArgs(Exception Exception, string MethodName);