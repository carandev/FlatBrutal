using System.Text;

namespace FlatBrutal.Ui.Styling;

public class FbClassBuilder
{
    private readonly List<string> _classes = new();

    private FbClassBuilder(string? initialClass = null)
    {
        Add(initialClass);
    }

    public static FbClassBuilder Create(string? initialClass = null)
        => new(initialClass);

    public FbClassBuilder Add(string? value)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            _classes.Add(value.Trim());
        }

        return this;
    }

    public FbClassBuilder AddWhen(string value, bool condition)
    {
        if (condition)
        {
            _classes.Add(value);
        }

        return this;
    }

    public FbClassBuilder AddIf(string? value)
        => Add(value);

    public override string ToString()
    {
        if (_classes.Count == 0)
        {
            return string.Empty;
        }

        var sb = new StringBuilder();
        var seen = new HashSet<string>(StringComparer.Ordinal);

        foreach (var cssClass in _classes)
        {
            var parts = cssClass.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            foreach (var part in parts)
            {
                if (!seen.Add(part))
                {
                    continue;
                }

                if (sb.Length > 0)
                {
                    sb.Append(' ');
                }

                sb.Append(part);
            }
        }

        return sb.ToString();
    }
}