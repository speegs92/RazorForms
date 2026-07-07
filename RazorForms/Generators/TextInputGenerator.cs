namespace RazorForms.Generators;

/// <summary>
/// Creates the HTML output for the <see cref="TextInputTagHelper">&lt;text-input&gt;</see> tag helper
/// </summary>
public class TextInputGenerator : FormElementGeneratorBase<TextInputTagHelper>
{
	private readonly IHtmlGenerator _htmlGenerator;

	/// <summary>
	/// Creates a new instance of <c>TextInputGenerator</c>
	/// </summary>
	/// <param name="htmlGenerator">The HTML generator</param>
	public TextInputGenerator(
		IHtmlGenerator htmlGenerator)
	{
		_htmlGenerator = htmlGenerator;
	}

	/// <inheritdoc />
	protected override TagHelper CreateTagHelper(
		TextInputTagHelper parentTagHelper,
		FormComponentOptions options,
		TagHelperContext context,
		TagHelperContent childContent,
		TagHelperAttributeList attributes,
		ModelValidationState validationState)
	{
		return new InputTagHelper(_htmlGenerator)
		{
			ViewContext = parentTagHelper.ViewContext,
			For = parentTagHelper.For,
			Format = parentTagHelper.Format
		};
	}

	/// <inheritdoc />
	protected override TagHelperOutput CreateTagHelperOutput(
		TextInputTagHelper parentTagHelper,
		FormComponentOptions options,
		TagHelperContext context,
		TagHelperContent childContent,
		TagHelperAttributeList attributes,
		ModelValidationState validationState)
	{
		return new TagHelperOutput(
			"input",
			new TagHelperAttributeList(attributes),
			Utilities.DefaultTagHelperContent)
		{
			TagMode = TagMode.SelfClosing
		};
	}
}
