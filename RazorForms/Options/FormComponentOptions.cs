namespace RazorForms.Options;

/// <summary>
/// The options used to configure validity-unaware tag helpers
/// </summary>
public class FormComponentOptions
{
	/// <summary>
	/// Specifies the root-relative path to the tag helper's Razor template
	/// </summary>
	public string? TemplatePath { get; set; }

	/// <summary>
	/// CSS classes applied to the &lt;input&gt;
	/// </summary>
	public string InputClasses { get; set; } = string.Empty;
}