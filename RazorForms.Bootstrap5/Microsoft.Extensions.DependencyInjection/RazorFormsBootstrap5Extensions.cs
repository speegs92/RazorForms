using System;
using RazorForms;
using RazorForms.Options;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class RazorFormsBootstrap5Extensions
{
	/// <summary>
	/// Adds RazorForms support, configured to use basic Bootstrap 5 settings
	/// </summary>
	/// <remarks>
	/// Use this overload when you want to include basic Bootstrap 5 support. This will probably serve as a starting place for your own app, but you'll probably want to add customized options in all but the most basic of scenarios.
	/// </remarks>
	/// <param name="self">The <see cref="IServiceCollection"/> instance</param>
	/// <returns></returns>
	public static IServiceCollection UseRazorFormsWithBootstrap5(this IServiceCollection self)
		=> self.UseRazorForms<RazorFormsOptions>(ApplyBootstrapDefaults);

	/// <summary>
	/// Adds RazorForms support with configurable Bootstrap 5 settings
	/// </summary>
	/// <remarks>
	/// Use this overload when you want to include customizable Bootstrap 5 support with a custom subclass of <see cref="RazorFormsOptions"/>.
	/// </remarks>
	/// <param name="self">The <see cref="IServiceCollection"/> instance</param>
	/// <param name="action">An <see cref="Action"/> that can be used to mutate the default Bootstrap5 options</param>
	/// <typeparam name="T">The type of the options class</typeparam>
	/// <returns></returns>
	public static IServiceCollection UseRazorFormsWithBootstrap5<T>(
		this IServiceCollection self,
		Action<T> action)
		where T : RazorFormsOptions, new()
	{
		var bootstrap = new T();
		action(bootstrap);
		ApplyBootstrapDefaults(bootstrap);

		return self.UseRazorForms(bootstrap);
	}

	/// <summary>
	/// Adds RazorForms support with configurable Bootstrap 5 settings
	/// </summary>
	/// <remarks>
	/// Use this overload when you want to include customizable Bootstrap 5 support with the built-in <see cref="RazorFormsOptions"/>.
	/// </remarks>
	/// <param name="self">The <see cref="IServiceCollection"/> instance</param>
	/// <param name="action">An <see cref="Action"/> that can be used to mutate the default Bootstrap5 options</param>
	/// <returns></returns>
	public static IServiceCollection UseRazorFormsWithBootstrap5(
		this IServiceCollection self,
		Action<RazorFormsOptions> action)
		=> UseRazorFormsWithBootstrap5<RazorFormsOptions>(self, action);

	/// <summary>
	/// Add RazorForms support with default Bootstrap 5 settings, along with added configuration to set up Bootstrap floating form labels
	/// </summary>
	/// <remarks>
	/// Use this overload when you want to include basic support for Bootstrap 5 with floating labels. This method doesn't allow any customization.
	/// </remarks>
	/// <param name="self">The <see cref="IServiceCollection"/> instance</param>
	/// <returns></returns>
	public static IServiceCollection UseRazorFormsWithBootstrap5FloatingLabels(this IServiceCollection self)
		=> self.UseRazorForms<RazorFormsOptions>(o =>
		{
			ApplyBootstrapDefaults(o);
			ApplyBootstrapFloatingLabel(o);
		});

	/// <summary>
	/// Add RazorForms support with configurable Bootstrap 5 settings, along with added configuration to set up Bootstrap floating form labels
	/// </summary>
	/// <remarks>
	/// Use this overload when you want to include customizable Bootstrap 5 support with a custom subclass of <see cref="RazorFormsOptions"/>.
	/// </remarks>
	/// <param name="self">The <see cref="IServiceCollection"/> instance</param>
	/// <param name="action">An <see cref="Action"/> that can be used to mutate the default Bootstrap5 options</param>
	/// <typeparam name="T">The type of the options class</typeparam>
	/// <returns></returns>
	public static IServiceCollection UseRazorFormsWithBootstrap5FloatingLabels<T>(
		this IServiceCollection self,
		Action<T> action)
		where T : RazorFormsOptions, new()
	{
		var bootstrap = new T();
		action(bootstrap);
		ApplyBootstrapDefaults(bootstrap);
		ApplyBootstrapFloatingLabel(bootstrap);

		return self.UseRazorForms(bootstrap);
	}

	/// <summary>
	/// Add RazorForms support with configurable Bootstrap 5 settings, along with added configuration to set up Bootstrap floating form labels
	/// </summary>
	/// <remarks>
	/// Use this overload when you want to include customizable Bootstrap 5 support with the built-in <see cref="RazorFormsOptions"/>.
	/// </remarks>
	/// <param name="self">The <see cref="IServiceCollection"/> instance</param>
	/// <param name="action">An <see cref="Action"/> that can be used to mutate the default Bootstrap5 options</param>
	/// <returns></returns>
	public static IServiceCollection UseRazorFormsWithBootstrap5FloatingLabels(
		this IServiceCollection self,
		Action<RazorFormsOptions> action)
		=> UseRazorFormsWithBootstrap5FloatingLabels<RazorFormsOptions>(self, action);

	public static void ApplyBootstrapDefaults<T>(T o)
		where T : RazorFormsOptions
	{
		// Text input
		o.TextInputOptions.InputClasses = Utilities.MergeCssStrings("form-control", o.TextInputOptions.InputClasses);
		o.TextInputOptions.InputValidClasses = Utilities.MergeCssStrings("is-valid", o.TextInputOptions.InputValidClasses);
		o.TextInputOptions.InputInvalidClasses = Utilities.MergeCssStrings("is-invalid", o.TextInputOptions.InputInvalidClasses);

		// Text area input
		o.TextAreaInputOptions.InputClasses = Utilities.MergeCssStrings("form-control", o.TextAreaInputOptions.InputClasses);
		o.TextAreaInputOptions.InputValidClasses = Utilities.MergeCssStrings("is-valid", o.TextAreaInputOptions.InputValidClasses);
		o.TextAreaInputOptions.InputInvalidClasses = Utilities.MergeCssStrings("is-invalid", o.TextAreaInputOptions.InputInvalidClasses);

		// Select input
		o.SelectInputOptions.InputClasses = Utilities.MergeCssStrings("form-control", o.SelectInputOptions.InputClasses);
		o.SelectInputOptions.InputValidClasses = Utilities.MergeCssStrings("is-valid", o.SelectInputOptions.InputValidClasses);
		o.SelectInputOptions.InputInvalidClasses = Utilities.MergeCssStrings("is-invalid", o.SelectInputOptions.InputInvalidClasses);

		// Check input
		o.CheckInputOptions.InputClasses = Utilities.MergeCssStrings("form-check-input", o.CheckInputOptions.InputClasses);

		// Check input group

		// Radio input
		o.RadioInputOptions.InputClasses = Utilities.MergeCssStrings("form-check-input", o.RadioInputOptions.InputClasses);

		// Radio input group
	}

	public static void ApplyBootstrapFloatingLabel<T>(T o)
		where T : RazorFormsOptions
	{
		// Inputs

		// TextAreas

		// Selects
	}
}