using System.Text.RegularExpressions;

namespace WebAPI.Helpers;

public partial class KebabCaseParameterTransformer : IOutboundParameterTransformer
{
    public string TransformOutbound(object input)
    {
        string value = input?.ToString();
        if (string.IsNullOrEmpty(value))
            return value;

        return PascalToKebabCaseRegex().Replace(value, "-$1").Trim().ToLower();
    }

    [GeneratedRegex("(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z0-9])", RegexOptions.Compiled)]
    private static partial Regex PascalToKebabCaseRegex();
}
