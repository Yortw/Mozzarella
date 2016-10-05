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
		/// Returns the first non-null, non-empty string from those provided. If there is no non-null, non-empty string in <paramref name="values"/> then null is returned.
		/// </summary>
		/// <param name="values">A set of strings to coalesce.</param>
		/// <returns>Returns a <see cref="System.String"/> if a non blank value is found, otherwise returns null.</returns>
		public static string Coalesce(this string[] values)
		{
			return Coalesce((IEnumerable<string>)values);
		}

		/// <summary>
		/// Returns the first non-null, non-empty string from those provided. If there is no non-null, non-empty string in <paramref name="values"/> then null is returned.
		/// </summary>
		/// <param name="values">A set of strings to coalesce.</param>
		/// <returns>Returns a <see cref="System.String"/> if a non blank value is found, otherwise returns null.</returns>
		public static string Coalesce(this IEnumerable<string> values)
		{
			if (values == null) return null;

			foreach (var value in values)
			{
				if (!String.IsNullOrEmpty(value)) return value;
			}
			return null;
		}
	}
}