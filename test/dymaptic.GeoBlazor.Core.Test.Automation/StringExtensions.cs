using System.Text;


namespace dymaptic.GeoBlazor.Core.Test.Automation;

public static class StringExtensions
{
    public static string ToKebabCase(this string val)
    {
        bool previousWasDigit = false;
        StringBuilder sb = new();

        for (var i = 0; i < val.Length; i++)
        {
            char c = val[i];

            if (char.IsUpper(c) || char.IsDigit(c))
            {
                if (!previousWasDigit && i > 0)
                {
                    // only add a dash if the previous character was not a digit
                    sb.Append('-');
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
}