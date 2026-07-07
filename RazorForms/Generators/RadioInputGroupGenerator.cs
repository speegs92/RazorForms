namespace RazorForms.Generators;

/// <summary>
/// Creates the HTML output for the <see cref="RadioInputGroupTagHelper">&lt;radio-input-group&gt;</see> tag helper
/// </summary>
public class RadioInputGroupGenerator
	: IFormElementGenerator<RadioInputGroupTagHelper>
{
	/// <inheritdoc />
	public Task<TagHelperOutput> Generate(
		RadioInputGroupTagHelper tagHelper,
		FormComponentOptions options,
		TagHelperContext context,
		TagHelperContent childContent,
		TagHelperAttributeList attributes,
		ModelValidationState validationState)
	{
		var output = new TagHelperOutput(
			string.Empty,
			new TagHelperAttributeList(),
			Utilities.DefaultTagHelperContent);
		output.Content.SetHtmlContent(childContent);

		return Task.FromResult(output);
	}
}
