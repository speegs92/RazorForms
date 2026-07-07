namespace RazorForms.Generators;

/// <summary>
/// Creates the HTML output for the <see cref="SelectInputTagHelper">&lt;select-input&gt;</see> tag helper
/// </summary>
public class SelectInputGenerator : FormElementGeneratorBase<SelectInputTagHelper>
{
	private readonly IHtmlGenerator _htmlGenerator;

	/// <summary>
	/// Creates a new instance of <c>SelectInputGenerator</c>
	/// </summary>
	/// <param name="htmlGenerator">The HTML generator</param>
	public SelectInputGenerator(
		IHtmlGenerator htmlGenerator)
	{
		_htmlGenerator = htmlGenerator;
	}

	/// <inheritdoc />
	protected override TagHelper CreateTagHelper(
		SelectInputTagHelper parentTagHelper,
		FormComponentOptions options,
		TagHelperContext context,
		TagHelperContent childContent,
		TagHelperAttributeList attributes,
		ModelValidationState validationState)
	{
		return new SelectTagHelper(_htmlGenerator)
		{
			ViewContext = parentTagHelper.ViewContext,
			For = parentTagHelper.For,
			Items = parentTagHelper.Items
		};
	}

	/// <inheritdoc />
	protected override TagHelperOutput CreateTagHelperOutput(
		SelectInputTagHelper parentTagHelper,
		FormComponentOptions options,
		TagHelperContext context,
		TagHelperContent childContent,
		TagHelperAttributeList attributes,
		ModelValidationState validationState)
	{
		var output = new TagHelperOutput(
			"select",
			new TagHelperAttributeList(attributes),
			Utilities.DefaultTagHelperContent)
		{
			TagMode = TagMode.StartTagAndEndTag
		};

		if (!childContent.IsEmptyOrWhiteSpace)
		{
			output.Content.SetHtmlContent(childContent);
		}

		return output;
	}
}
