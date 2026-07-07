namespace RazorForms.Generators;

/// <summary>
/// Creates the HTML output for the <see cref="CheckInputGroupTagHelper">&lt;check-input-group&gt;</see> tag helper
/// </summary>
public class CheckInputGroupGenerator
	: IFormElementGenerator<CheckInputGroupTagHelper>
{
	/// <inheritdoc />
	public Task<TagHelperOutput> Generate(
		CheckInputGroupTagHelper tagHelper,
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