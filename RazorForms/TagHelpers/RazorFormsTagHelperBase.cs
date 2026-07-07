namespace RazorForms.TagHelpers;

/// <summary>
/// The base tag helper used for top-level form elements
/// </summary>
/// <typeparam name="T">The type of the tag helper</typeparam>
public abstract class RazorFormsTagHelperBase<T> : TagHelper
	where T : RazorFormsTagHelperBase<T>
{
	private readonly IHtmlHelper _htmlHelper;
	private readonly IFormElementGenerator<T> _elementGenerator;
	private readonly FormComponentOptions _options;

	/// <inheritdoc />
	protected RazorFormsTagHelperBase(
		IHtmlHelper htmlHelper,
		IFormElementGenerator<T> elementGenerator,
		FormComponentOptions options)
	{
		_htmlHelper = htmlHelper;
		_elementGenerator = elementGenerator;
		_options = options;
	}

	/// <summary>
	/// The model member for which the input should be rendered
	/// </summary>
	[HtmlAttributeName("asp-for")]
	public ModelExpression For { get; set; } = null!;

	/// <summary>
	/// The path to the <c>.cshtml</c> template to use to render the tag helper
	/// </summary>
	[HtmlAttributeName("template-path")]
	public string? TemplatePath { get; set; }

	/// <summary>
	/// The view execution context
	/// </summary>
	[HtmlAttributeNotBound]
	[ViewContext]
	public ViewContext ViewContext { get; set; } = null!;

	/// <inheritdoc />
	public override async Task ProcessAsync(
		TagHelperContext context,
		TagHelperOutput output)
	{
		(_htmlHelper as IViewContextAware)!.Contextualize(ViewContext);
		output.TagName = null;
		output.TagMode = TagMode.StartTagAndEndTag;

		var childContent = await output.GetChildContentAsync();

		var validationState = ViewContext.ModelState[For.Name]?.ValidationState ?? ModelValidationState.Unvalidated;

		var inputHtml = await _elementGenerator.Generate(
			(this as T)!,
			_options,
			context,
			childContent,
			output.Attributes,
			validationState);

		var model = new MarkupModel
		{
			InputHtml = inputHtml,
			ChildContent = childContent,
			LabelText = For.Metadata.GetDisplayName(),
			Attributes = output.Attributes,
			Errors = ViewContext.ModelState[For.Name]?.Errors.Select(e => e.ErrorMessage).ToList() ?? [],
			ValidationState = validationState
		};

		var content = await _htmlHelper.PartialAsync(
			TemplatePath ?? _options.TemplatePath,
			model);

		output.Content.SetHtmlContent(content);
	}
}
