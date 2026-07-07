using System.Text.Encodings.Web;

namespace RazorForms;

public static class Utilities
{
	/// <summary>
	/// An empty <see cref="DefaultTagHelperContent"/> wrapped in a task
	/// </summary>
	public static readonly Func<bool, HtmlEncoder, Task<TagHelperContent>> DefaultTagHelperContent =
		(_, _) => Task.FromResult((TagHelperContent)new DefaultTagHelperContent());

	/// <summary>
	/// Merges two CSS strings while accounting that either or both may be null
	/// </summary>
	/// <param name="a">The first string to merge</param>
	/// <param name="b">The second string to merge</param>
	/// <returns></returns>
	public static string MergeCssStrings(string? a, string? b)
	{
		var aIsEmpty = string.IsNullOrWhiteSpace(a);
		var bIsEmpty = string.IsNullOrWhiteSpace(b);

		if (aIsEmpty)
		{
			return bIsEmpty ? string.Empty : b!;
		}

		if (bIsEmpty)
		{
			return aIsEmpty ? string.Empty : a!;
		}

		return $"{a} {b}";
	}
}