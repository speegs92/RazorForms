namespace RazorForms.TagHelpers;

/// <summary>
/// Creates a text- or numeric-based &lt;input&gt;
/// </summary>
public class TextInputTagHelper : RazorFormsTagHelperBase<TextInputTagHelper>
{
	/// <summary>
	/// The format string used to format the <c>For</c> result
	/// </summary>
	[HtmlAttributeName("asp-format")]
	public string? Format { get; set; }

	/// <inheritdoc />
	public TextInputTagHelper(
		IHtmlHelper htmlHelper,
		IFormElementGenerator<TextInputTagHelper> elementGenerator,
		RazorFormsOptions options)
		: base(
			htmlHelper, 
			elementGenerator,
			options.TextInputOptions) {}
}
