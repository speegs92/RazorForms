namespace RazorForms.TagHelpers;

/// <summary>
/// Creates a <c>&lt;textarea&gt;</c>
/// </summary>
public class TextAreaInputTagHelper
	: RazorFormsTagHelperBase<TextAreaInputTagHelper>
{
	/// <inheritdoc />
	public TextAreaInputTagHelper(
		IHtmlHelper htmlHelper,
		IFormElementGenerator<TextAreaInputTagHelper> generator,
		RazorFormsOptions options)
		: base(
			htmlHelper,
			generator,
			options.TextAreaInputOptions) {}
}
