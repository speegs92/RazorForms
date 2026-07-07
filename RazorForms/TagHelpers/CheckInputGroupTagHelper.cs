namespace RazorForms.TagHelpers;

/// <summary>
/// Wraps a group of checkbox-based &lt;input&gt;s in validation markup
/// </summary>
public class CheckInputGroupTagHelper : RazorFormsTagHelperBase<CheckInputGroupTagHelper>
{
	/// <inheritdoc />
	public CheckInputGroupTagHelper(
		IHtmlHelper htmlHelper,
		IFormElementGenerator<CheckInputGroupTagHelper> elementGenerator,
		RazorFormsOptions options)
		: base(
			htmlHelper, 
			elementGenerator,
			options.CheckInputGroupOptions) {}
}
