
using System.Text;

// ReSharper disable once CheckNamespace
using CliWrap.EventStream;


// ReSharper disable once CheckNamespace
namespace CliWrap;

public static class Cli
{
    public static Command Wrap(string command)
    {
        Console.WriteLine($"Executing command: {command}");

        return new Command(command);
    }
    
    public static IAsyncEnumerable<CommandEvent> ListenAsync(
        this Command command,
        CancellationToken cancellationToken = default
    )
    {
        return command.ListenAsync(Encoding.Default, cancellationToken);
    }
}