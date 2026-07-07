namespace RazorForms.Generators;

/// <summary>
/// A generator for form input elements
/// </summary>
/// <typeparam name="T">The type of the tag helper for which to render a form input</typeparam>
// ReSharper disable TypeParameterCanBeVariant
public interface IFormElementGenerator<T>
{
	/// <summary>
	/// Generates tag helper output representing a form element (e.g., <c>&lt;input&gt;</c>, <c>&lt;textarea&gt;</c>, etc.)
	/// </summary>
	/// <param name="tagHelper">The RazorForms tag helper being rendered</param>
	/// <param name="options">The form component options</param>
	/// <param name="context">The tag helper context</param>
	/// <param name="childContent">The child content provided to the tag helper</param>
	/// <param name="attributes">The attributes provided to the tag helper</param>
	/// <param name="validationState">The validation state of the tag helper</param>
	/// <returns>The generated tag helper output</returns>
	Task<TagHelperOutput> Generate(
		T tagHelper,
		FormComponentOptions options,
		TagHelperContext context,
		TagHelperContent childContent,
		TagHelperAttributeList attributes,
		ModelValidationState validationState);
}
