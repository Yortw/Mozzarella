using System;
using System.Collections.Generic;
using System.Text;

namespace Mozzarella
{
	/// <summary>
	/// Extension methods for <see cref="IEnumerable{T}"/> where T is a string, and also string arrays.
	/// </summary>
	public static class EnumerableOfStringExtensions
	{
		/// <summary>
		/// Returns the first non-null, non-empty and non-whitespace string from those provided. If there is no non-null, non-empty string containing at least one non-whitespace character in <paramref name="values"/> then null is returned.
		/// </summary>
		/// <remarks>
		/// <para>This overload treats strings containing only whitespace characters as being empty.</para>
		/// </remarks>
		/// <param name="values">A set of strings to coalesce.</param>
		/// <returns>Returns a <see cref="System.String"/> if a non blank value is found, otherwise returns null.</returns>
#if SUPPORTS_AGGRESSIVEINLINING
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
		public static string Coalesce(this string[] values)
		{
			return Coalesce(values, CoalesceOptions.WhiteSpaceAsEmpty);
		}

		/// <summary>
		/// Returns the first non-null, non-empty string from those provided. If there is no non-null, non-empty string in <paramref name="values"/> then null is returned.
		/// </summary>
		/// <param name="values">A set of strings to coalesce.</param>
		/// <param name="options">A value from the <see cref="CoalesceOptions"/> enum specifying options for deciding when to coalesce a value.</param>
		/// <returns>Returns a <see cref="System.String"/> if a non blank value is found, otherwise returns null.</returns>
		public static string Coalesce(this string[] values, CoalesceOptions options)
		{
			return Coalesce((IEnumerable<string>)values, options);
		}

		/// <summary>
		/// Returns the first non-null, non-empty string from those provided. If there is no non-null, non-empty string containing at least one non-whitespace character in <paramref name="values"/> then null is returned.
		/// </summary>
		/// <remarks>
		/// <para>This overload treats strings containing only whitespace characters as being empty.</para>
		/// </remarks>
		/// <param name="values">A set of strings to coalesce.</param>
		/// <returns>Returns a <see cref="System.String"/> if a non blank value is found, otherwise returns null.</returns>
#if SUPPORTS_AGGRESSIVEINLINING
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
		public static string Coalesce(this IEnumerable<string> values)
		{
			return Coalesce(values, CoalesceOptions.WhiteSpaceAsEmpty);
		}

		/// <summary>
		/// Returns the first non-null, non-empty string from those provided. If there is no non-null, non-empty string in <paramref name="values"/> then null is returned.
		/// </summary>
		/// <param name="values">A set of strings to coalesce.</param>
		/// <param name="options">A value from the <see cref="CoalesceOptions"/> enum specifying options for deciding when to coalesce a value.</param>
		/// <returns>Returns a <see cref="System.String"/> if a non blank value is found, otherwise returns null.</returns>
		public static string Coalesce(this IEnumerable<string> values, CoalesceOptions options)
		{
			if (values == null) return null;

			var whitespaceIsEmpty = (options & CoalesceOptions.WhiteSpaceAsEmpty) == CoalesceOptions.WhiteSpaceAsEmpty;

			foreach (var value in values)
			{
				if (whitespaceIsEmpty)
				{
					if (!String.IsNullOrWhiteSpace(value))
						return value;
				}
				else if (!String.IsNullOrEmpty(value)) return value;
			}
			return null;
		}
	}
}