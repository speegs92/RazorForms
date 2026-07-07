namespace RazorForms.Generators;

/// <summary>
/// Creates the HTML output for the <see cref="CheckInputTagHelper">&lt;check-input&gt;</see> tag helper
/// </summary>
public class CheckInputGenerator : FormElementGeneratorBase<CheckInputTagHelper>
{
	private readonly IHtmlGenerator _htmlGenerator;

	/// <summary>
	/// Creates a new instance of <c>CheckInputGenerator</c>
	/// </summary>
	/// <param name="htmlGenerator">The HTML generator</param>
	public CheckInputGenerator(
		IHtmlGenerator htmlGenerator)
	{
		_htmlGenerator = htmlGenerator;
	}

	/// <inheritdoc />
	protected override TagHelper CreateTagHelper(
		CheckInputTagHelper parentTagHelper,
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
		CheckInputTagHelper parentTagHelper,
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
		CheckInputTagHelper tagHelper,
		TagHelperAttributeList attributes)
	{
		var idAttribute = attributes.FirstOrDefault(a => a.Name == "id");
		if (idAttribute is null)
		{
			var id = Guid.NewGuid().ToString();
			attributes.Add("id", id);
		}

		attributes.Add("type", "checkbox");

		var valueAttribute = attributes.FirstOrDefault(a => a.Name == "value");
		if (valueAttribute is null)
		{
			return;
		}

		var selectedValues = tagHelper.ViewContext.ViewData.Eval(tagHelper.For.Name);
		if (selectedValues is null)
		{
			return;
		}

		if (!selectedValues.GetType().IsGenericType ||
			selectedValues.GetType().GetGenericTypeDefinition() != typeof(List<>))
		{
			return;
		}

		IList usableValues;

		try
		{
			usableValues = (IList)selectedValues;
		}
		catch (Exception)
		{
			return;
		}

		var value = valueAttribute.Value.ToString();

		foreach (var v in usableValues)
		{
			if (v?.ToString() == value)
			{
				attributes.Add("checked", null);
				return;
			}
		}
	}
}
