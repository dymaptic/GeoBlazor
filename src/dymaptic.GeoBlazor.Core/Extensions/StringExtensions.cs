namespace dymaptic.GeoBlazor.Core.Extensions;

internal static partial class StringExtensions
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
        bool previousWasDigit = false;
        StringBuilder sb = new();

        for (var i = 0; i < val.Length; i++)
        {
            char c = val[i];

            if (char.IsUpper(c) || char.IsDigit(c))
            {
                if (!previousWasDigit) // only add a dash if the previous character was not a digit
                {
                    if (i > 0)
                    {
                        sb.Append('-');
                    }
                }

                sb.Append(char.ToLower(c));
            }
            else
            {
                sb.Append(c);
            }

            previousWasDigit = char.IsDigit(c);
        }
        
        return sb.ToString();
    }
    
    public static string KebabToPascalCase(this string val)
    {
        if (val.Length == 0)
        {
            return val;
        }
        
        if (char.IsDigit(val[0]) && val.Length > 1)
        {
            List<char> numberPrefixChars = [val[0]];
            for (int i = 1; i < val.Length; i++)
            {
                if (char.IsDigit(val[i]))
                {
                    numberPrefixChars.Add(val[i]);
                }
                else
                {
                    break;
                }
            }
            
            string numWords = NumberToPascalCaseWords(int.Parse(new string(numberPrefixChars.ToArray())));
            string remaining = val.Substring(numberPrefixChars.Count);
            return $"{numWords}{remaining.KebabToPascalCase()}";
        }
        
        return string.Create(val.Length - val.Count(c => c == '-'), val, (span, txt) =>
        {
            var offset = 0;
            var nextUpper = true;
            
            for (var i = 0; i < txt.Length; i++)
            {
                char c = txt[i];

                switch (c)
                {
                    case '-':
                        nextUpper = true;
                        offset++;
                        break;
                    case '/': // handle slashes as underscores
                    case '.': // handle dots as underscores
                        span[i - offset] = '_';
                        nextUpper = true;
                        break;
                    default:
                        span[i - offset] = nextUpper ? char.ToUpper(c) : c;
                        nextUpper = char.IsDigit(c); // capitalize after digits
                        break;
                }
            }
        });
    }
    
    private static string NumberToPascalCaseWords(int number)
    {
        if (number == 0)
            return "Zero";
        if (number < 0)
            return $"Minus{NumberToPascalCaseWords(Math.Abs(number))}";
        
        StringBuilder sb = new();

        if (number / 1000000 > 0)
        {
            sb.Append($"{NumberToPascalCaseWords(number / 1000000)}Million");
            number %= 1000000;
        }

        if (number / 1000 > 0)
        {
            sb.Append($"{NumberToPascalCaseWords(number / 1000)}Thousand");
            number %= 1000;
        }

        if (number / 100 > 0)
        {
            sb.Append($"{NumberToPascalCaseWords(number / 100)}Hundred");
            number %= 100;
        }

        if (number > 0)
        {
            if (number < 20)
                sb.Append(numbers[number]);
            else
            {
                sb.Append(tens[number / 10]);
                if (number % 10 > 0)
                    sb.Append($"{numbers[number % 10]}");
            }
        }

        return sb.ToString();
    }

    private static readonly string[] numbers =
    [
        "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine",
        "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen",
        "Eighteen", "Nineteen"
    ];
    
    private static readonly string[] tens =
        ["Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"];
}