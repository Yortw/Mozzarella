﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mozzarella
{
	/// <summary>
	/// Extension methods for <see cref="System.String"/>.
	/// </summary>
	public static class StringExtensions
	{
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

		/// <summary>
		/// Performs a case *insensitive* comparison of two strings, returning a boolean indicating if they match.
		/// </summary>
		/// <remarks>
		/// <para>This is equivalent to calling <see cref="String.Compare(string, string, StringComparison)"/> with the <see cref="StringComparison.CurrentCultureIgnoreCase"/> value and checking the value is equal to 0.</para>
		/// </remarks>
		/// <param name="value">The first value to compare.</param>
		/// <param name="otherValue">The second value to compare.</param>
		/// <returns><c>true</c> if the values are the same (ignoring case), <c>false</c> otherwise.</returns>
		public static bool CIEquals(this string value, string otherValue)
		{
			return String.Compare(value, otherValue, StringComparison.CurrentCultureIgnoreCase) == 0;
		}

		/// <summary>
		/// Performs a case *insensitive* comparison of two strings, returning an integer indicating if they match, or one is less than/greater than the other.
		/// </summary>
		/// <remarks>
		/// <para>This is equivalent to calling <see cref="String.Compare(string, string, StringComparison)"/> with the <see cref="StringComparison.CurrentCultureIgnoreCase"/> value.</para>
		/// </remarks>
		/// <param name="value">The first value to compare.</param>
		/// <param name="otherValue">The second value to compare.</param>
		/// <returns>Zero if the values are the same, 1 if <paramref name="value"/> greater than <paramref name="otherValue"/>, else -1.</returns>
		public static int CICompare(this string value, string otherValue)
		{
			return String.Compare(value, otherValue, StringComparison.CurrentCultureIgnoreCase);
		}

		/// <summary>
		/// Returns true if <paramref name="value" /> contains the substring specified by <paramref name="searchValue" />, ignoring the case of both strings.
		/// </summary>
		/// <param name="value">The value to search in.</param>
		/// <param name="searchValue">The string to search for.</param>
		/// <returns><c>true</c> if <paramref name="value" /> contains the substring <paramref name="searchValue" />, <c>false</c> otherwise.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown if <paramref name="value"/> is null.</exception>
		public static bool CIContains(this string value, string searchValue)
		{
			if (value == null) throw new ArgumentNullException(nameof(value));

			return value.IndexOf(searchValue, StringComparison.CurrentCultureIgnoreCase) >= 0;
		}
	}
}