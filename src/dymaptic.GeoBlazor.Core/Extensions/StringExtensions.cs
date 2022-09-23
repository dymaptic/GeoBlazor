namespace dymaptic.GeoBlazor.Core.Extensions;

public static class StringExtensions
{
    public static string ToLowerFirstChar(this string val)
    {
        return string.Create(val.Length, val, (span, txt) =>
        {
            span[0] = char.ToLower(txt[0]);

            for (var i = 1; i < txt.Length; i++)
            {
                span[i] = txt[i];
            }
        });
    }

    public static string ToKebabCase(this string val)
    {
        return string.Create(val.Length + (val.Count(char.IsUpper) - 1), val, (span, txt) =>
        {
            var offset = 0;

            for (var i = 0; i < txt.Length; i++)
            {
                char c = txt[i];

                if (char.IsUpper(c))
                {
                    if (i > 0)
                    {
                        span[i + offset] = '-';
                        offset++;
                    }

                    span[i + offset] = char.ToLower(c);
                }
                else
                {
                    span[i + offset] = c;
                }
            }
        });
    }
}