namespace RazorForms.Generators;

/// <summary>
/// A base form element generator
/// </summary>
public abstract class FormElementGeneratorBase<T>
	: IFormElementGenerator<T>
{
	/// <inheritdoc />
	public async Task<TagHelperOutput> Generate(
		T tagHelper,
		FormComponentOptions options,
		TagHelperContext context,
		TagHelperContent childContent,
		TagHelperAttributeList attributes,
		ModelValidationState validationState)
	{
		var existingClasses = attributes.FirstOrDefault(a => a.Name == "class");
		var computedClasses = options.InputClasses;

		if (existingClasses is not null)
		{
			computedClasses += $" {existingClasses.Value}";
			attributes.Remove(existingClasses);
		}

		if (options is ValidityAwareFormComponentOptions v)
		{
			if (validationState is ModelValidationState.Valid)
			{
				computedClasses += $" {v.InputValidClasses}";
			}
			else if (validationState is ModelValidationState.Invalid)
			{
				computedClasses += $" {v.InputInvalidClasses}";
			}
		}

		var classAttribute = new TagHelperAttribute("class", computedClasses);
		attributes.Add(classAttribute);

		var element = CreateTagHelper(
			tagHelper,
			options,
			context,
			childContent,
			attributes,
			validationState);

		var output = CreateTagHelperOutput(
			tagHelper,
			options,
			context,
			childContent,
			attributes,
			validationState);

		element.Init(context);
		await element.ProcessAsync(context, output);

		return output;
	}

	/// <summary>
	/// Creates the tag helper appropriate to render the form element
	/// </summary>
	/// <param name="parentTagHelper">The parent RazorForms tag helper being rendered</param>
	/// <param name="options">The form component options</param>
	/// <param name="context">The tag helper context</param>
	/// <param name="childContent">The child content provided to the tag helper</param>
	/// <param name="attributes">The attributes provided to the tag helper</param>
	/// <param name="validationState">The validation state of the tag helper</param>
	/// <returns>The new tag helper</returns>
	protected abstract TagHelper CreateTagHelper(
		T parentTagHelper,
		FormComponentOptions options,
		TagHelperContext context,
		TagHelperContent childContent,
		TagHelperAttributeList attributes,
		ModelValidationState validationState);

	/// <summary>
	/// Creates the tag helper output appropriate to render the form element
	/// </summary>
	/// <param name="parentTagHelper">The parent RazorForms tag helper being rendered</param>
	/// <param name="options">The form component options</param>
	/// <param name="context">The tag helper context</param>
	/// <param name="childContent">The child content provided to the tag helper</param>
	/// <param name="attributes">The attributes provided to the tag helper</param>
	/// <param name="validationState">The validation state of the tag helper</param>
	/// <returns>The form element's tag helper output</returns>
	protected abstract TagHelperOutput CreateTagHelperOutput(
		T parentTagHelper,
		FormComponentOptions options,
		TagHelperContext context,
		TagHelperContent childContent,
		TagHelperAttributeList attributes,
		ModelValidationState validationState);
}
