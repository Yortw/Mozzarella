using System;
using System.Collections.Generic;
using System.Text;

namespace Mozzarella
{
	/// <summary>
	/// Extension methods for <see cref="System.String"/>.
	/// </summary>
	public static class StringExtensions
	{
		//TODO: Case insensitive compare
		//TODO: Case insensitive contains
		//TODO: Case insensitive replace?
		//TODO: IndexOfFirstDifference
		//TODO: IsAllDigits
		//TODO: Like?
		//TODO: StripSuffix
		//TODO: AddSuffix
		//TODO: Add Prefix
		//TODO: StripPrefix
		//TODO: Wrap 

		/// <summary>
		/// If <paramref name="value"/> is longer than <paramref name="maxLength"/> it is truncated at that character position, otherwise the original string is returned.
		/// </summary>
		/// <remarks>
		/// <para>If value is null, null is returned. If <paramref name="maxLength"/> is zero, <see cref="String.Empty"/> is returned.</para>
		/// </remarks>
		/// <param name="value">The string to truncate.</param>
		/// <param name="maxLength">The the point at which to truncate the string, if it exceeds that length.</param>
		/// <returns>A <see cref="System.String"/> that is no longer than <paramref name="maxLength"/>.</returns>
		/// <exception cref="System.ArgumentOutOfRangeException">Thrown if <paramref name="maxLength"/> is less than 0.</exception>
		public static string Truncate(this string value, int maxLength)
		{
			if (value == null) return null;
			if (maxLength < 0) throw new ArgumentOutOfRangeException(nameof(maxLength));

			if (value.Length == 0) return String.Empty;
			if (value.Length <= maxLength) return value;
			return value.Substring(0, maxLength);
		}

	}
}