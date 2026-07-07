namespace RazorForms.Generators;

/// <summary>
/// Creates the HTML output for the <see cref="TextAreaInputTagHelper">&lt;text-area-input&gt;</see> tag helper
/// </summary>
public class TextAreaInputGenerator
	: FormElementGeneratorBase<TextAreaInputTagHelper>
{
	private readonly IHtmlGenerator _htmlGenerator;

	/// <inheritdoc />
	public TextAreaInputGenerator(
		IHtmlGenerator htmlGenerator)
	{
		_htmlGenerator = htmlGenerator;
	}

	/// <inheritdoc />
	protected override TagHelper CreateTagHelper(
		TextAreaInputTagHelper parentTagHelper,
		FormComponentOptions options,
		TagHelperContext context,
		TagHelperContent childContent,
		TagHelperAttributeList attributes,
		ModelValidationState validationState)
	{
		return new TextAreaTagHelper(_htmlGenerator)
		{
			ViewContext = parentTagHelper.ViewContext,
			For = parentTagHelper.For
		};
	}

	/// <inheritdoc />
	protected override TagHelperOutput CreateTagHelperOutput(
		TextAreaInputTagHelper parentTagHelper,
		FormComponentOptions options,
		TagHelperContext context,
		TagHelperContent childContent,
		TagHelperAttributeList attributes,
		ModelValidationState validationState)
	{
		var output = new TagHelperOutput(
			"textarea",
			new TagHelperAttributeList(attributes),
			Utilities.DefaultTagHelperContent)
		{
			TagMode = TagMode.StartTagAndEndTag
		};

		if (!childContent.IsEmptyOrWhiteSpace)
		{
			output.Content.SetContent(childContent.GetContent());
		}

		return output;
	}
}
