using FlatBrutal.Ui.Styling;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace FlatBrutal.Ui.Components.Button;

public partial class FbButton : ComponentBase
{
    [Parameter] public RenderFragment? ChildContent { get; set; }
    [Parameter] public RenderFragment? StartContent { get; set; }
    [Parameter] public RenderFragment? EndContent { get; set; }

    [Parameter] public FbButtonVariant? Variant { get; set; }

    [Parameter] public bool Disabled { get; set; }
    [Parameter] public bool Loading { get; set; }

    [Parameter] public string? Class { get; set; }

    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    private bool IsActuallyDisabled => Disabled || Loading;

    private string CssClass => FbClassBuilder
        .Create("fb-btn")
        .Add($"{Variant?.ToString().ToLowerInvariant()}")
        .Add(Class)
        .ToString();

    private async Task HandleClick(MouseEventArgs args)
    {
        if (IsActuallyDisabled)
        {
            return;
        }

        await OnClick.InvokeAsync(args);
    }
}