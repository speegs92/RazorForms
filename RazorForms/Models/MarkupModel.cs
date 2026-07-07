namespace RazorForms.Models;

/// <summary>
/// The data needed to render a RazorForms tag helper
/// </summary>
public class MarkupModel
{
	private string? _id;
	private bool _idInitialized;

	/// <summary>
	/// The form input markup content
	/// </summary>
	public required TagHelperOutput InputHtml { get; set; }

	/// <summary>
	/// The child content provided to the tag helper, if any
	/// </summary>
	public required TagHelperContent ChildContent { get; set; }

	/// <summary>
	/// The text of the label
	/// </summary>
	public required string LabelText { get; set; }

	/// <summary>
	/// The attributes provided to the tag helper
	/// </summary>
	public required TagHelperAttributeList Attributes { get; set; }

	/// <summary>
	/// The model state errors for the tag helper
	/// </summary>
	public required List<string> Errors { get; set; }

	/// <summary>
	/// The model validation state for the tag helper
	/// </summary>
	public required ModelValidationState ValidationState { get; set; }

	/// <summary>
	/// The HTML ID of the form element
	/// </summary>
	public string? Id
	{
		get
		{
			if (!_idInitialized)
			{
				_id = Attributes.FirstOrDefault(a => a.Name == "id")?.Value?.ToString();
				_idInitialized = true;
			}
			
			return _id;
		}
	}
}
