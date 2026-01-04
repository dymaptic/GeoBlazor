using Microsoft.Extensions.Configuration;
using System.Text;


namespace dymaptic.GeoBlazor.Core.Test.Automation;

public static class DotEnvFileSourceExtensions
{
    public static IConfigurationBuilder AddDotEnvFile(this IConfigurationBuilder builder, 
        bool optional, bool reloadOnChange)
    {
        DotEnvFileSource fileSource = new()
        {
            Path = ".env", 
            Optional = optional, 
            ReloadOnChange = reloadOnChange
        };
        fileSource.ResolveFileProvider();
        return builder.Add(fileSource);
    }
}

public class DotEnvFileSource: FileConfigurationSource
{
    public override IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        EnsureDefaults(builder);
        return new DotEnvConfigurationProvider(this);
    }
}

public class DotEnvConfigurationProvider(FileConfigurationSource source) : FileConfigurationProvider(source)
{
    public override void Load(Stream stream) => DotEnvStreamConfigurationProvider.Read(stream);
}

public class DotEnvStreamConfigurationProvider(StreamConfigurationSource source) : StreamConfigurationProvider(source)
{
    public override void Load(Stream stream)
    {
        Data = Read(stream);
    }
    
    public static IDictionary<string, string?> Read(Stream stream)
        {
            var data = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase);
            using var reader = new StreamReader(stream);
            int lineNumber = 0;
            bool multiline = false;
            StringBuilder? multilineValueBuilder = null;
            string multilineKey = string.Empty;

            while (reader.Peek() != -1)
            {
                string rawLine = reader.ReadLine()!; // Since Peak didn't return -1, stream hasn't ended.
                string line = rawLine.Trim();
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
                    int separator = line.IndexOf('=');
                    if (separator < 0)
                    {
                        throw new FormatException($"Line {lineNumber} is missing an '=' character in the .env file");
                    }

                    key = line[..separator].Trim();
                    value = line[(separator + 1)..].Trim();

                    // Remove single quotes
                    if (value.Length > 1 && value[0] == '\'' && value[^1] == '\'')
                    {
                        value = value[1..^1];
                    }
                
                    // Remove double quotes
                    if (value.Length > 1 && value[0] == '"' && value[^1] == '"')
                    {
                        value = value[1..^1];
                    }

                    // start of a multi-line value
                    if (value.Length > 1 && value[0] == '"')
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
}