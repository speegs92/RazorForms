namespace RazorForms.TagHelpers;

/// <summary>
/// Wraps a group of radio-based &lt;input&gt;s in validation markup
/// </summary>
public class RadioInputGroupTagHelper : RazorFormsTagHelperBase<RadioInputGroupTagHelper>
{
	/// <inheritdoc />
	public RadioInputGroupTagHelper(
		IHtmlHelper htmlHelper,
		IFormElementGenerator<RadioInputGroupTagHelper> elementGenerator,
		RazorFormsOptions options)
		: base(
			htmlHelper, 
			elementGenerator,
			options.RadioInputGroupOptions) {}
}
