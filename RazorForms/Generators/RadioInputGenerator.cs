namespace RazorForms.Generators;

/// <summary>
/// Creates the HTML output for the <see cref="RadioInputTagHelper">&lt;radio-input&gt;</see> tag helper
/// </summary>
public class RadioInputGenerator
	: FormElementGeneratorBase<RadioInputTagHelper>
{
	private readonly IHtmlGenerator _htmlGenerator;

	/// <summary>
	/// Creates a new instance of <c>RadioInputGenerator</c>
	/// </summary>
	/// <param name="htmlGenerator">The HTML generator</param>
	public RadioInputGenerator(
		IHtmlGenerator htmlGenerator)
	{
		_htmlGenerator = htmlGenerator;
	}

	/// <inheritdoc />
	protected override TagHelper CreateTagHelper(
		RadioInputTagHelper parentTagHelper,
		FormComponentOptions options,
		TagHelperContext context,
		TagHelperContent childContent,
		TagHelperAttributeList attributes,
		ModelValidationState validationState)
	{
		return new InputTagHelper(_htmlGenerator)
		{
			ViewContext = parentTagHelper.ViewContext,
			For = parentTagHelper.For
		};
	}

	/// <inheritdoc />
	protected override TagHelperOutput CreateTagHelperOutput(
		RadioInputTagHelper parentTagHelper,
		FormComponentOptions options,
		TagHelperContext context,
		TagHelperContent childContent,
		TagHelperAttributeList attributes,
		ModelValidationState validationState)
	{
		SetupAttributes(parentTagHelper, attributes);

		return new TagHelperOutput(
			"input",
			new TagHelperAttributeList(attributes),
			Utilities.DefaultTagHelperContent)
		{
			TagMode = TagMode.SelfClosing
		};
	}

	private static void SetupAttributes(
		RadioInputTagHelper tagHelper,
		TagHelperAttributeList attributes)
	{
		var idAttribute = attributes.FirstOrDefault(a => a.Name == "id");
		if (idAttribute is null)
		{
			var id = Guid.NewGuid().ToString();
			attributes.Add("id", id);
		}

		attributes.Add("type", "radio");

		var valueAttribute = attributes.FirstOrDefault(a => a.Name == "value");
		if (valueAttribute is null)
		{
			return;
		}

		var selectedValue = tagHelper.ViewContext.ViewData.Eval(tagHelper.For.Name);
		if (selectedValue is null)
		{
			return;
		}

		if (valueAttribute.Value.ToString() == selectedValue.ToString())
		{
			attributes.Add("checked", null);
		}
	}
}
