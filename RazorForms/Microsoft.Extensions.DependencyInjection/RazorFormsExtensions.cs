using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class RazorFormsExtensions
{
	/// <summary>
	/// Adds RazorForms support using the supplied <see cref="RazorFormsOptions"/> instance
	/// </summary>
	/// <param name="self">The <see cref="IServiceCollection"/> instance</param>
	/// <param name="o">The options to use when creating markup</param>
	/// <param name="types">An array of <see cref="Type"/>s that the options should be registered as. <c>T</c> and <c>RazorFormsOptions</c> are added by default, so only include types other than these.</param>
	/// <returns></returns>
	public static IServiceCollection UseRazorForms<T>(
		this IServiceCollection self,
		T o,
		params Type[] types)
		where T : RazorFormsOptions, new()
	{
		// Set up types to add options as
		var typesList = new List<Type>(types)
		{
			typeof(RazorFormsOptions),
			typeof(T)
		};

		// Add options to DI
		foreach (var t in typesList)
		{
			self.TryAdd(new ServiceDescriptor(t, o));
		}

		return self;
	}

	/// <summary>
	/// Adds RazorForms support with configurable settings
	/// </summary>
	/// <remarks>
	/// Use this overload when you want to include customizable options with a custom subclass of <see cref="RazorFormsOptions"/>
	/// </remarks>
	/// <param name="self">The <see cref="IServiceCollection"/> instance</param>
	/// <param name="action">An <see cref="Action"/> that can be used to mutate the default options</param>
	/// <param name="types">An array of <see cref="Type"/> that the options should be registered as</param>
	/// <returns></returns>
	public static IServiceCollection UseRazorForms<T>(
		this IServiceCollection self,
		Action<T> action,
		params Type[] types)
		where T : RazorFormsOptions, new()
	{
		var options = new T();
		action(options);
		return self.UseRazorForms(options, types);
	}

	/// <summary>
	/// Adds RazorForms support with configurable settings
	/// </summary>
	/// <remarks>
	/// Use this overload when you want to include customizable options with the built-in <see cref="RazorFormsOptions"/>
	/// </remarks>
	/// <param name="self">The <see cref="IServiceCollection"/> instance</param>
	/// <param name="action">An <see cref="Action"/> that can be used to mutate the default options</param>
	/// <param name="types">An array of <see cref="Type"/> that the options should be registered as</param>
	/// <returns></returns>
	public static IServiceCollection UseRazorForms(
		this IServiceCollection self,
	    Action<RazorFormsOptions> action,
	    params Type[] types)
		=> UseRazorForms<RazorFormsOptions>(self, action, types);

	/// <summary>
	/// Adds an <see cref="IFormElementGenerator{T}"/> for the given tag helper if one isn't already registered
	/// </summary>
	/// <param name="self">The service collection</param>
	/// <typeparam name="TTagHelper">The type of the tag helper</typeparam>
	/// <typeparam name="TGenerator">The type of the generator to add</typeparam>
	/// <returns>The service collection</returns>
	public static IServiceCollection TryAddElementGenerator<TTagHelper, TGenerator>(
		this IServiceCollection self)
		where TGenerator : class, IFormElementGenerator<TTagHelper>
	{
		self.TryAddScoped<IFormElementGenerator<TTagHelper>, TGenerator>();
		return self;
	}
}