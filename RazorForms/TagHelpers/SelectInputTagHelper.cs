namespace RazorForms.TagHelpers;

/// <summary>
/// Creates a <c>&lt;select&gt;</c>
/// </summary>
public class SelectInputTagHelper : RazorFormsTagHelperBase<SelectInputTagHelper>
{
	/// <summary>
	/// A collection of <see cref="SelectListItem"/> objects used to populate the <c>&lt;select&gt;</c> element with <c>&lt;optgroup&gt;</c> and <c>&lt;option&gt;</c> elements.
	/// </summary>
	[HtmlAttributeName("asp-items")]
	public IEnumerable<SelectListItem>? Items { get; set; }

	/// <inheritdoc />
	public SelectInputTagHelper(
		IHtmlHelper htmlHelper,
		IFormElementGenerator<SelectInputTagHelper> elementGenerator,
		RazorFormsOptions options)
		: base(
			htmlHelper, 
			elementGenerator,
			options.SelectInputOptions) {}
}
