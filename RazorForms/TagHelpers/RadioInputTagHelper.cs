namespace RazorForms.TagHelpers;

/// <summary>
/// Creates a radio &lt;input&gt;
/// </summary>
public class RadioInputTagHelper
	: RazorFormsTagHelperBase<RadioInputTagHelper>
{
	/// <inheritdoc />
	public RadioInputTagHelper(
		IHtmlHelper htmlHelper,
		IFormElementGenerator<RadioInputTagHelper> elementGenerator,
		RazorFormsOptions options)
		: base(
			htmlHelper,
			elementGenerator,
			options.RadioInputOptions) {}
}
