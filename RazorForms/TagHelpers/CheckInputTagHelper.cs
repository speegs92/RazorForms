namespace RazorForms.TagHelpers;

/// <summary>
/// Creates a checkbox &lt;input&gt;
/// </summary>
public class CheckInputTagHelper : RazorFormsTagHelperBase<CheckInputTagHelper>
{
	/// <inheritdoc />
	public CheckInputTagHelper(
		IHtmlHelper htmlHelper,
		IFormElementGenerator<CheckInputTagHelper> elementGenerator,
		RazorFormsOptions options)
		: base(
			htmlHelper,
			elementGenerator,
			options.CheckInputOptions) {}
}
