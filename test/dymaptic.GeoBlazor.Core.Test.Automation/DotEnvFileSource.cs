using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.FileProviders.Physical;
using Microsoft.Extensions.Primitives;
using System.Runtime.CompilerServices;
using System.Text;


namespace dymaptic.GeoBlazor.Core.Test.Automation;

public static class DotEnvFileSourceExtensions
{
    public static IConfigurationBuilder AddDotEnvFile(this IConfigurationBuilder builder,
        bool optional, bool reloadOnChange, [CallerFilePath] string callerFilePath = "")
    {
        var directory = Path.GetDirectoryName(callerFilePath)!;

        DotEnvFileSource fileSource = new()
        {
            Path = Path.Combine(directory, ".env"),
            Optional = optional,
            ReloadOnChange = reloadOnChange,
            FileProvider = new DotEnvFileProvider(directory)
        };

        return builder.Add(fileSource);
    }
}

public class DotEnvFileProvider(string directory) : IFileProvider
{
    public IFileInfo GetFileInfo(string subpath)
    {
        if (string.IsNullOrEmpty(subpath))
        {
            return new NotFoundFileInfo(subpath);
        }

        var fullPath = Path.Combine(directory, subpath);

        var fileInfo = new FileInfo(fullPath);

        return new PhysicalFileInfo(fileInfo);
    }

    public IDirectoryContents GetDirectoryContents(string subpath)
    {
        return _fileProvider.GetDirectoryContents(subpath);
    }

    public IChangeToken Watch(string filter)
    {
        return _fileProvider.Watch(filter);
    }

    private readonly PhysicalFileProvider _fileProvider = new(directory);
}

public class DotEnvFileSource : FileConfigurationSource
{
    public override IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        EnsureDefaults(builder);

        return new DotEnvConfigurationProvider(this);
    }
}

public class DotEnvConfigurationProvider(FileConfigurationSource source) : FileConfigurationProvider(source)
{
    public override void Load(Stream stream)
    {
        Data = DotEnvStreamConfigurationProvider.Read(stream);
    }
}

public class DotEnvStreamConfigurationProvider(StreamConfigurationSource source) : StreamConfigurationProvider(source)
{
    public static IDictionary<string, string?> Read(Stream stream)
    {
        var data = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase);
        using var reader = new StreamReader(stream);
        var lineNumber = 0;
        var multiline = false;
        StringBuilder? multilineValueBuilder = null;
        var multilineKey = string.Empty;

        while (reader.Peek() != -1)
        {
            var rawLine = reader.ReadLine()!; // Since Peak didn't return -1, stream hasn't ended.
            var line = rawLine.Trim();
            lineNumber++;

            string key;
            string value;

            if (multiline)
            {
                if (!line.EndsWith('"'))
                {
                    multilineValueBuilder!.AppendLine(line);

                    continue;
                }

                // end of multi-line value
                line = line[..^1];
                multilineValueBuilder!.AppendLine(line);
                key = multilineKey!;
                value = multilineValueBuilder.ToString();
                multilineKey = string.Empty;
                multilineValueBuilder = null;
                multiline = false;
            }
            else
            {
                // Ignore blank lines
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                // Ignore comments
                if (line[0] is ';' or '#' or '/')
                {
                    continue;
                }

                // key = value OR "value"
                var separator = line.IndexOf('=');

                if (separator < 0)
                {
                    throw new FormatException($"Line {lineNumber} is missing an '=' character in the .env file");
                }

                key = line[..separator].Trim();
                value = line[(separator + 1)..].Trim();

                // Remove single quotes
                if ((value.Length > 1) && (value[0] == '\'') && (value[^1] == '\''))
                {
                    value = value[1..^1];
                }

                // Remove double quotes
                if ((value.Length > 1) && (value[0] == '"') && (value[^1] == '"'))
                {
                    value = value[1..^1];
                }

                // start of a multi-line value
                if ((value.Length > 1) && (value[0] == '"'))
                {
                    multiline = true;
                    multilineValueBuilder = new StringBuilder(value);
                    multilineKey = key;

                    // don't add yet, get the rest of the lines
                    continue;
                }
            }

            if (!data.TryAdd(key, value))
            {
                throw new FormatException($"A duplicate key '{key}' was found in the .env file on line {lineNumber}");
            }
        }

        if (multiline)
        {
            throw new FormatException(
                "The .env file contains an unterminated multi-line value. Ensure that multiline values start and end with double quotes.");
        }

        return data;
    }

    public override void Load(Stream stream)
    {
        Data = Read(stream);
    }
}