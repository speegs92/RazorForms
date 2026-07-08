namespace RazorForms.Options;

/// <summary>
/// The options used to configure validity-aware tag helpers
/// </summary>
public class ValidityAwareFormComponentOptions : FormComponentOptions
{
	/// <summary>
	/// CSS classes applied to the &lt;input&gt; when model validation succeeds
	/// </summary>
	public string InputValidClasses { get; set; } = string.Empty;

	/// <summary>
	/// CSS classes applied to the &lt;input&gt; when model validation fails
	/// </summary>
	public string InputInvalidClasses { get; set; } = string.Empty;
}