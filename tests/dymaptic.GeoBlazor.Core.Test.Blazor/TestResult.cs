namespace dymaptic.GeoBlazor.Core.Test.Blazor;

public record TestResult(string ClassName, int Passed, int Failed);

public class TestException: Exception
{
    public TestException(string message) : base(message)
    {
    }
}