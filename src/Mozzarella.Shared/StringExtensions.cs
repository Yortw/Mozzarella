using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Mozzarella
{
	/// <summary>
	/// Extension methods for <see cref="System.String"/>.
	/// </summary>
	public static class StringExtensions
	{

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
		/// Performs an "ordinal" and case *insensitive* comparison of two strings, returning a boolean indicating if they match. 
		/// </summary>
		/// <remarks>
		/// <para>This is equivalent to calling <see cref="String.Equals(string, string, StringComparison)"/> with the <see cref="StringComparison.OrdinalIgnoreCase"/> value.</para>
		/// </remarks>
		/// <param name="value">The first value to compare.</param>
		/// <param name="otherValue">The second value to compare.</param>
		/// <returns><c>true</c> if the values are the same (ignoring case), <c>false</c> otherwise.</returns>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "OCI")]
		public static bool OCIEquals(this string value, string otherValue)
		{
			return String.Equals(value, otherValue, StringComparison.OrdinalIgnoreCase);
		}

		/// <summary>
		/// Performs an "ordinal" comparison of two strings, returning a boolean indicating if they match. 
		/// </summary>
		/// <remarks>
		/// <para>This is equivalent to calling <see cref="String.Equals(string, string, StringComparison)"/> with the <see cref="StringComparison.Ordinal"/> value.</para>
		/// </remarks>
		/// <param name="value">The first value to compare.</param>
		/// <param name="otherValue">The second value to compare.</param>
		/// <returns><c>true</c> if the values are the same, <c>false</c> otherwise.</returns>
		public static bool OEquals(this string value, string otherValue)
		{
			return String.Equals(value, otherValue, StringComparison.OrdinalIgnoreCase);
		}

		/// <summary>
		/// Performs a case *insensitive* comparison of two strings, returning a boolean indicating if they match.
		/// </summary>
		/// <remarks>
		/// <para>This is equivalent to calling <see cref="String.Equals(string, string, StringComparison)"/> with the <see cref="StringComparison.CurrentCultureIgnoreCase"/> value.</para>
		/// </remarks>
		/// <param name="value">The first value to compare.</param>
		/// <param name="otherValue">The second value to compare.</param>
		/// <returns><c>true</c> if the values are the same (ignoring case), <c>false</c> otherwise.</returns>
		public static bool CIEquals(this string value, string otherValue)
		{
			return String.Equals(value, otherValue, StringComparison.CurrentCultureIgnoreCase);
		}

		/// <summary>
		/// Performs a case *insensitive* ordinal comparison of two strings, returning an integer indicating if they match, or one is less than/greater than the other.
		/// </summary>
		/// <remarks>
		/// <para>This is equivalent to calling <see cref="String.Compare(string, string, StringComparison)"/> with the <see cref="StringComparison.OrdinalIgnoreCase"/> value.</para>
		/// </remarks>
		/// <param name="value">The first value to compare.</param>
		/// <param name="otherValue">The second value to compare.</param>
		/// <returns>Zero if the values are the same (ignoring case), 1 if <paramref name="value"/> greater than <paramref name="otherValue"/>, else -1.</returns>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "OCI")]
		public static int OCICompare(this string value, string otherValue)
		{
			return String.Compare(value, otherValue, StringComparison.OrdinalIgnoreCase);
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

		/// <summary>
		/// Returns true if <paramref name="value" /> contains the substring specified by <paramref name="searchValue" />, ignoring the case of both strings and using an ordinal comparison.
		/// </summary>
		/// <param name="value">The value to search in.</param>
		/// <param name="searchValue">The string to search for.</param>
		/// <returns><c>true</c> if <paramref name="value" /> contains the substring <paramref name="searchValue" />, <c>false</c> otherwise.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is null.</exception>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "OCI")]
		public static bool OCIContains(this string value, string searchValue)
		{
			if (value == null) throw new ArgumentNullException(nameof(value));

			return value.IndexOf(searchValue, StringComparison.OrdinalIgnoreCase) >= 0;
		}

		/// <summary>
		/// Replaces all instances of a substring in a given string with another using a case insensitve, current culture based comparisoon.
		/// </summary>
		/// <param name="value">The value to replace the substring in.</param>
		/// <param name="searchValue">The substring to be replaced.</param>
		/// <param name="newValue">The new substring to use.</param>
		/// <returns>A <see cref="System.String"/> containing the replaced parts.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown if <paramref name="value"/> is null.</exception>
		/// <seealso cref="OCIReplace(string, string, string)"/>
		/// <seealso cref="Replace(string, string, string, StringComparison)"/>
		#if SUPPORTS_AGGRESSIVEINLINING
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		#endif
		public static string CIReplace(this string value, string searchValue, string newValue)
		{
			return value.Replace(searchValue, newValue, StringComparison.CurrentCultureIgnoreCase);
		}

		/// <summary>
		/// Replaces all instances of a substring in a given string with another using an ordinal and case insenstive comparison.
		/// </summary>
		/// <param name="value">The value to replace the substring in.</param>
		/// <param name="searchValue">The substring to be replaced.</param>
		/// <param name="newValue">The new substring to use.</param>
		/// <returns>A <see cref="String"/> containing the replaced parts.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is null.</exception>
		/// <seealso cref="CIReplace(string, string, string)"/>
		/// <seealso cref="Replace(string, string, string, StringComparison)"/>
#if SUPPORTS_AGGRESSIVEINLINING
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "OCI")]
		public static string OCIReplace(this string value, string searchValue, string newValue)
		{
			return value.Replace(searchValue, newValue, StringComparison.OrdinalIgnoreCase);
		}

		/// <summary>
		/// An overload for <see cref="System.String.Replace(String, String)"/> which allows manually specifying the <see cref="StringComparison"/> to use when locating the <paramref name="searchValue"/> within <paramref name="value"/>.
		/// </summary>
		/// <param name="value">The value to replace the substring in.</param>
		/// <param name="searchValue">The substring to be replaced.</param>
		/// <param name="newValue">The new substring to use.</param>
		/// <param name="stringComparison">A value from the <see cref="System.StringComparison"/> enum specifying how strings should be compared when searching for the <paramref name="searchValue"/>.</param>
		/// <returns>A <see cref="System.String"/> containing the replaced parts.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown if <paramref name="value"/> is null.</exception>
		/// <seealso cref="OCIReplace(string, string, string)"/>
		/// <seealso cref="CIReplace(string, string, string)"/>
		public static string Replace(this string value, string searchValue, string newValue, StringComparison stringComparison)
		{
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (String.IsNullOrEmpty(searchValue)) return value;
			if (value.Length == 0) return value;
			if (value.Length < (searchValue?.Length ?? 0)) return value;
			if (value == searchValue) return newValue;

			//Existing string.replace treats null and empty as the same thing,
			//so keep that behaviour.
			var newValueIsEmpty = String.IsNullOrEmpty(newValue);
			if (newValueIsEmpty) newValue = newValue ?? String.Empty;

			StringBuilder retVal = null;

			int initialCapacity = newValue.Length <= searchValue.Length ? value.Length : (value.Length / searchValue.Length) * (newValue.Length - searchValue.Length);

			int index = -1, partLength = 0;
			int startIndex = 0;
			while (startIndex < value.Length && (index = value.IndexOf(searchValue, startIndex, stringComparison)) >= 0)
			{
				if (retVal == null) retVal = new StringBuilder(initialCapacity);

				partLength = index - startIndex;
				if (partLength > 0)
					retVal.Append(value.Substring(startIndex, partLength));

				if (!newValueIsEmpty)
					retVal.Append(newValue);

				startIndex = index + searchValue.Length;
			}

			if (retVal != null && startIndex < value.Length)
				retVal.Append(value.Substring(startIndex, value.Length - startIndex));

			return retVal?.ToString() ?? value;
		}

		/// <summary>
		/// Returns the original character position of the first difference between two strings. If the strings are identical, returns -1.
		/// </summary>
		/// <param name="value">The first value to compare.</param>
		/// <param name="otherValue">The other value to compare.</param>
		/// <remarks>
		/// <para>If <paramref name="otherValue"/> is longer than <paramref name="value"/> but matches up to the end of <paramref name="value"/> then the index returned will be outside the length of <paramref name="value"/>.</para>
		/// </remarks>
		/// <returns>A <see cref="System.Int32"/> containing the index of the first non-matching character, otherwise returns -1 if the strings are identical.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown if <paramref name="value"/> or <paramref name="otherValue"/> is null.</exception>
		public static int IndexOfFirstDifference(this string value, string otherValue)
		{
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (otherValue == null) throw new ArgumentNullException(nameof(otherValue));

			for (int cnt = 0; cnt < value.Length; cnt++)
			{
				if (cnt >= otherValue.Length) return cnt;
				
				if (value[cnt] != otherValue[cnt]) return cnt;
			}

			return value.Length < otherValue.Length ? value.Length : -1;
		}

		/// <summary>
		/// Determines whether <paramref name="value"/> contains only numeric digits.
		/// </summary>
		/// <param name="value">The string to check the contents of.</param>
		/// <remarks>
		/// <para>If <paramref name="value"/> is an empty string the return value is false.</para>
		/// </remarks>
		/// <returns><c>true</c> if <paramref name="value"/> contains only numeric digits; otherwise, <c>false</c>.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown if <paramref name="value"/> is null.</exception>
		public static bool IsAllDigits(this string value)
		{
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (value.Length == 0) return false;

			for (int cnt = 0; cnt < value.Length; cnt++)
			{
				if (!Char.IsDigit(value[cnt])) return false;
			}
			return true;
		}

		/// <summary>
		/// Performs an operation similar to a T-Sql 'like' on a string.
		/// </summary>
		/// <remarks>
		/// <para>Use % as a wildcard for any character or characters, and _ as a wild card for any single character.</para>
		/// <para>This method is 'allocation heavy'. It's fine for use in execution paths that are infrequent/not performance critical, but in other 
		/// such places a fine tuned manual implementation would be better.</para>
		/// </remarks>
		/// <param name="value">The string to search.</param>
		/// <param name="pattern">The partial string to match, including wild cards.</param>
		/// <param name="caseInsensitive">If true case is ignored when matching strings, if false case sensitivity applies.</param>
		/// <returns>True if the partial string to match is found in the <paramref name="value" /> string.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown if <paramref name="value"/> or <paramref name="pattern"/> is null.</exception>
		public static bool Like(this string value, string pattern, bool caseInsensitive)
		{
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (pattern == null) throw new ArgumentNullException(nameof(pattern));

			RegexOptions options = RegexOptions.None;
			if (caseInsensitive)
				options = RegexOptions.IgnoreCase;

			var sb = new StringBuilder();
			sb.Append("\\A");
			sb.Append(Regex.Escape(pattern));
			sb.Replace("_", ".");
			sb.Replace("%", ".*");
			sb.Append("\\z");

			return new Regex(sb.ToString(), options).IsMatch(value);
		}

		/// <summary>
		/// If <paramref name="value"/> ends with <paramref name="suffix"/> then returns a new string without the suffix, otherwise returns <paramref name="value"/>.
		/// </summary>
		/// <remarks>
		/// <para>This overload is case sensitive. For a case insensitive version use <see cref="StripSuffix(string, string, bool)"/> with ignoreCase set to true.</para>
		/// </remarks>
		/// <param name="value">The value to strip the suffix from.</param>
		/// <param name="suffix">The suffix to be stripped.</param>
		/// <exception cref="System.ArgumentNullException">Throw if either <paramref name="value"/> or <paramref name="suffix"/> is null.</exception>
		/// <returns>Either a new string without the specified suffix, or else the original string.</returns>
		public static string StripSuffix(this string value, string suffix)
		{
			return StripSuffix(value, suffix, false);
		}

		/// <summary>
		/// If <paramref name="value" /> ends with <paramref name="suffix" /> then returns a new string without the suffix, otherwise returns <paramref name="value" />.
		/// </summary>
		/// <param name="value">The value to strip the suffix from.</param>
		/// <param name="suffix">The suffix to be stripped.</param>
		/// <param name="ignoreCase">A boolean indicating whether or not to match the suffix in a case sensitive (true) or insensitive (false) manner.</param>
		/// <returns>Either a new string without the specified suffix, or else the original string.</returns>
		/// <exception cref="System.ArgumentNullException">Throw if either <paramref name="value"/> or <paramref name="suffix"/> is null.</exception>
		/// <remarks>This overload is case sensitive. For a case insensitive version use <see cref="StripSuffix(string, string, bool)" /> with ignoreCase set to true.</remarks>
		public static string StripSuffix(this string value, string suffix, bool ignoreCase)
		{
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (suffix == null) throw new ArgumentNullException(nameof(suffix));

			if (value.EndsWith(suffix, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture))
				return value.Substring(0, value.Length - suffix.Length);

			return value;
		}

		/// <summary>
		/// If <paramref name="value"/> ends with <paramref name="prefix"/> then returns a new string without the prefix, otherwise returns <paramref name="value"/>.
		/// </summary>
		/// <remarks>
		/// <para>This overload is case sensitive. For a case insensitive version use <see cref="StripPrefix(string, string, bool)"/> with ignoreCase set to true.</para>
		/// </remarks>
		/// <param name="value">The value to strip the prefix from.</param>
		/// <param name="prefix">The prefix to be stripped.</param>
		/// <exception cref="System.ArgumentNullException">Throw if either <paramref name="value"/> or <paramref name="prefix"/> is null.</exception>
		/// <returns>Either a new string without the specified prefix, or else the original string.</returns>
		public static string StripPrefix(this string value, string prefix)
		{
			return StripPrefix(value, prefix, false);
		}

		/// <summary>
		/// If <paramref name="value" /> ends with <paramref name="prefix" /> then returns a new string without the prefix, otherwise returns <paramref name="value" />.
		/// </summary>
		/// <param name="value">The value to strip the prefix from.</param>
		/// <param name="prefix">The prefix to be stripped.</param>
		/// <param name="ignoreCase">A boolean indicating whether or not to match the prefix in a case sensitive (true) or insensitive (false) manner.</param>
		/// <returns>Either a new string without the specified prefix, or else the original string.</returns>
		/// <exception cref="System.ArgumentNullException">Throw if either <paramref name="value"/> or <paramref name="prefix"/> is null.</exception>
		/// <remarks>This overload is case sensitive. For a case insensitive version use <see cref="StripPrefix(string, string, bool)" /> with ignoreCase set to true.</remarks>
		public static string StripPrefix(this string value, string prefix, bool ignoreCase)
		{
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (prefix == null) throw new ArgumentNullException(nameof(prefix));

			if (value.StartsWith(prefix, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture))
				return value.Substring(prefix.Length);

			return value;
		}

		/// <summary>
		/// If <paramref name="value"/> does NOT end with <paramref name="suffix"/> then returns a new string with the suffix appended, otherwise returns <paramref name="value"/>.
		/// </summary>
		/// <remarks>
		/// <para>This overload is case sensitive. For a case insensitive version use <see cref="AddSuffix(string, string, bool)"/> with ignoreCase set to true.</para>
		/// </remarks>
		/// <param name="value">The value to add the suffix from.</param>
		/// <param name="suffix">The suffix to be added.</param>
		/// <exception cref="System.ArgumentNullException">Throw if either <paramref name="value"/> or <paramref name="suffix"/> is null.</exception>
		/// <returns>Either a new string with the specified suffix, or else the original string.</returns>
		public static string AddSuffix(this string value, string suffix)
		{
			return AddSuffix(value, suffix, false);
		}

		/// <summary>
		/// If <paramref name="value"/> does NOT end with <paramref name="suffix"/> then returns a new string with the suffix appended, otherwise returns <paramref name="value"/>.
		/// </summary>
		/// <param name="value">The value to add the suffix from.</param>
		/// <param name="suffix">The suffix to be added.</param>
		/// <param name="ignoreCase">A boolean indicating whether or not to match the suffix in a case sensitive (true) or insensitive (false) manner.</param>
		/// <returns>Either a new string with the specified suffix, or else the original string.</returns>
		/// <exception cref="System.ArgumentNullException">Throw if either <paramref name="value"/> or <paramref name="suffix"/> is null.</exception>
		/// <remarks>This overload is case sensitive. For a case insensitive version use <see cref="AddSuffix(string, string, bool)" /> with ignoreCase set to true.</remarks>
		public static string AddSuffix(this string value, string suffix, bool ignoreCase)
		{
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (suffix == null) throw new ArgumentNullException(nameof(suffix));

			if (!value.EndsWith(suffix, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture))
				return value + suffix;

			return value;
		}

		/// <summary>
		/// If <paramref name="value"/> does NOT start with <paramref name="prefix"/> then returns a new string with the prefix, otherwise returns <paramref name="value"/>.
		/// </summary>
		/// <remarks>
		/// <para>This overload is case sensitive. For a case insensitive version use <see cref="AddPrefix(string, string, bool)"/> with ignoreCase set to true.</para>
		/// </remarks>
		/// <param name="value">The value to add the prefix to.</param>
		/// <param name="prefix">The prefix to be added.</param>
		/// <exception cref="System.ArgumentNullException">Throw if either <paramref name="value"/> or <paramref name="prefix"/> is null.</exception>
		/// <returns>Either a new string without the specified prefix, or else the original string.</returns>
		public static string AddPrefix(this string value, string prefix)
		{
			return AddPrefix(value, prefix, false);
		}

		/// <summary>
		/// If <paramref name="value" /> ends with <paramref name="prefix" /> then returns a new string without the prefix, otherwise returns <paramref name="value" />.
		/// </summary>
		/// <param name="value">The value to add the prefix to.</param>
		/// <param name="prefix">The prefix to be added.</param>
		/// <param name="ignoreCase">A boolean indicating whether or not to match the prefix in a case sensitive (true) or insensitive (false) manner.</param>
		/// <returns>Either a new string without the specified prefix, or else the original string.</returns>
		/// <exception cref="System.ArgumentNullException">Throw if either <paramref name="value"/> or <paramref name="prefix"/> is null.</exception>
		/// <remarks>This overload is case sensitive. For a case insensitive version use <see cref="AddPrefix(string, string, bool)" /> with ignoreCase set to true.</remarks>
		public static string AddPrefix(this string value, string prefix, bool ignoreCase)
		{
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (prefix == null) throw new ArgumentNullException(nameof(prefix));

			if (!value.StartsWith(prefix, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture))
				return prefix + value;

			return value;
		}

		/// <summary>
		/// Returns <paramref name="otherValue"/> if <paramref name="value"/> is null, empty or contains only whitespace characters, otherwise returns <paramref name="value"/>.
		/// </summary>
		/// <param name="value">The first value to return if it is not considered empty.</param>
		/// <param name="otherValue">The second value to return if the first is considered empty.</param>
		/// <returns>Either <paramref name="value"/> or <paramref name="otherValue"/> depending on which is empty.</returns>
		/// <seealso cref="Coalesce(string, CoalesceOptions, string)"/>
		/// <seealso cref="Coalesce(string, string[])"/>
#if SUPPORTS_AGGRESSIVEINLINING
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
		public static string Coalesce(this string value, string otherValue)
		{
			return Coalesce(value, CoalesceOptions.WhiteSpaceAsEmpty, otherValue);
		}

		/// <summary>
		/// Returns <paramref name="otherValue"/> if <paramref name="value"/> is considered empty, otherwise returns <paramref name="value"/>.
		/// </summary>
		/// <remarks>
		/// <para>Whether or not a value is considered empty can be controlled (partially) via the <paramref name="options"/> argument.</para>
		/// </remarks>
		/// <param name="value">The first value to return if it is not considered empty.</param>
		/// <param name="options">A set of flags from the <see cref="CoalesceOptions"/> controlling how the method behaves.</param>
		/// <param name="otherValue">The second value to return if the first is considered empty.</param>
		/// <returns>Either <paramref name="value"/> or <paramref name="otherValue"/> depending on which is empty.</returns>
		public static string Coalesce(this string value, CoalesceOptions options, string otherValue)
		{
			if ((options & CoalesceOptions.WhiteSpaceAsEmpty) == CoalesceOptions.WhiteSpaceAsEmpty)
				return String.IsNullOrWhiteSpace(value) ? otherValue : value;

			return String.IsNullOrEmpty(value) ? otherValue : value;
		}

		/// <summary>
		/// Returns <paramref name="value"/> if it is not empty, otherwise returns the first non-empty, non-null, non-whitespace string from <paramref name="otherValues"/>.
		/// </summary>
		/// <remarks>
		/// <para>If <paramref name="otherValues"/> is null, then <paramref name="value"/> is returned.</para>
		/// </remarks>
		/// <param name="value">The first value to return if it is not considered empty.</param>
		/// <param name="otherValues">An array of values, in preferred order, the first non-empty, non-null, non-whitespace value to be returned.</param>
		/// <returns>Either <paramref name="value"/> or the first non-empty/null/whitespace value from <paramref name="otherValues"/>.</returns>
		/// <seealso cref="Coalesce(string, CoalesceOptions, string[])"/>
		/// <seealso cref="Coalesce(string, CoalesceOptions, string)"/>
#if SUPPORTS_AGGRESSIVEINLINING
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
		public static string Coalesce(this string value, params string[] otherValues)
		{
			return Coalesce(value, CoalesceOptions.WhiteSpaceAsEmpty, otherValues);
		}

		/// <summary>
		/// Returns <paramref name="value"/> if it is not empty, otherwise returns the first non-empty, non-null, non-whitespace string from <paramref name="otherValues"/>.
		/// </summary>
		/// <remarks>
		/// <para>If <paramref name="otherValues"/> is null, then <paramref name="value"/> is returned.</para>
		/// </remarks>
		/// <param name="value">The first value to return if it is not considered empty.</param>
		/// <param name="options">A set of flags from the <see cref="CoalesceOptions"/> controlling how the method behaves.</param>
		/// <param name="otherValues">An array of values, in preferred order, the first non-empty, non-null, non-whitespace value to be returned.</param>
		/// <returns>Either <paramref name="value"/> or the first non-empty/null/whitespace value from <paramref name="otherValues"/>.</returns>
		/// <seealso cref="Coalesce(string, CoalesceOptions, string)"/>
		/// <seealso cref="Coalesce(string, string[])"/>
		public static string Coalesce(this string value, CoalesceOptions options, params string[] otherValues)
		{
			if (otherValues == null) return value;

			var whitespaceAsEmpty = (options & CoalesceOptions.WhiteSpaceAsEmpty) == CoalesceOptions.WhiteSpaceAsEmpty;

			var retVal = value;
			for (int cnt = 0; cnt < otherValues.Length; cnt++)
			{
				retVal = Coalesce(retVal, options, otherValues[cnt]);

				if (whitespaceAsEmpty)
				{
					if (!String.IsNullOrWhiteSpace(retVal)) return retVal;
				}
				else if (!String.IsNullOrEmpty(retVal)) return retVal;
			}

			return retVal;
		}

		/// <summary>
		/// Returns true if <paramref name="value"/> is null or empty string.
		/// </summary>
		/// <remarks>
		/// <para>This is a convenience method that just calls <see cref="String.IsNullOrEmpty(string)"/>.</para>
		/// </remarks>
		/// <param name="value">The string value to be checked.</param>
		/// <returns>Returns true if <paramref name="value"/> is null or empty string.</returns>
#if SUPPORTS_AGGRESSIVEINLINING
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
		public static bool IsNullOrEmpty(this string value)
		{
			return String.IsNullOrEmpty(value);
		}

		/// <summary>
		/// Returns true if <paramref name="value"/> is null, empty string or contains only whitespace characters.
		/// </summary>
		/// <remarks>
		/// <para>This is a convenience method that just calls <see cref="String.IsNullOrWhiteSpace(string)"/>.
		/// </para>
		/// </remarks>
		/// <param name="value">The string value to be checked.</param>
		/// <returns>Returns true if <paramref name="value"/> is null, empty string or contains only whitespace characters.</returns>
#if SUPPORTS_AGGRESSIVEINLINING
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
		public static bool IsNullOrWhiteSpace(this string value)
		{
			return String.IsNullOrWhiteSpace(value);
		}

		/// <summary>
		/// Returns true if <paramref name="value"/> contains the substring <paramref name="searchValue"/> as matched according to <paramref name="comparisonMethod"/>.
		/// </summary>
		/// <remarks>
		/// <para>If <paramref name="value"/> is null returns false.</para>
		/// </remarks>
		/// <param name="value">The value to search in.</param>
		/// <param name="searchValue">The value to search for.</param>
		/// <param name="comparisonMethod">A <see cref="StringComparison"/> value specifying rules for matching <paramref name="searchValue"/> within <paramref name="value"/>.</param>
		/// <returns>True if <paramref name="value"/> contains <paramref name="searchValue"/>, otherwise false.</returns>
		public static bool Contains(this string value, string searchValue, StringComparison comparisonMethod)
		{
			if (value == null) return false;

			return value.IndexOf(searchValue, comparisonMethod) >= 0;
		}

		/// <summary>
		/// Returns the portion of <paramref name="value"/> that occurs before the first instance of <paramref name="searchValue"/>.
		/// </summary>
		/// <remarks>
		/// <para>Returns null if <paramref name="searchValue"/> is null, empty string or if <paramref name="searchValue"/> does not occur within <paramref name="value"/>.</para>
		/// <para>Matching of <paramref name="searchValue"/> is done using a <see cref="StringComparison.Ordinal"/> comparison.</para>
		/// </remarks>
		/// <param name="value">The value to search in.</param>
		/// <param name="searchValue">The value to search for.</param>
		/// <returns>Either null, or a new string containing the portion of the string prior to <paramref name="searchValue"/>.</returns>
#if SUPPORTS_AGGRESSIVEINLINING
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
		public static string BeforeFirst(this string value, string searchValue)
		{
			return BeforeFirst(value, searchValue, StringComparison.Ordinal);
		}

		/// <summary>
		/// Returns the portion of <paramref name="value"/> that occurs before the first instance of <paramref name="searchValue"/>.
		/// </summary>
		/// <remarks>
		/// <para>Returns null if <paramref name="searchValue"/> is null, empty string or if <paramref name="searchValue"/> does not occur within <paramref name="value"/>.</para>
		/// </remarks>
		/// <param name="value">The value to search in.</param>
		/// <param name="searchValue">The value to search for.</param>
		/// <param name="comparisonMethod">A value from the <see cref="StringComparison"/> enum specfying how <paramref name="searchValue"/> is matched (or not).</param>
		/// <returns>Either null, or a new string containing the portion of the string prior to <paramref name="searchValue"/>.</returns>
		public static string BeforeFirst(this string value, string searchValue, StringComparison comparisonMethod)
		{
			if (value == null) return null;
			if (value.Length == 0) return null;

			var index = value.IndexOf(searchValue, comparisonMethod);
			if (index <= 0) return null;

			return value.Substring(0, index);
		}

		/// <summary>
		/// Returns the portion of <paramref name="value"/> that occurs before the last instance of <paramref name="searchValue"/>.
		/// </summary>
		/// <remarks>
		/// <para>Returns null if <paramref name="searchValue"/> is null, empty string or if <paramref name="searchValue"/> does not occur within <paramref name="value"/>.</para>
		/// <para>Matching of <paramref name="searchValue"/> is done using a <see cref="StringComparison.Ordinal"/> comparison.</para>
		/// </remarks>
		/// <param name="value">The value to search in.</param>
		/// <param name="searchValue">The value to search for.</param>
		/// <returns>Either null, or a new string containing the portion of the string before the last occurrence of <paramref name="searchValue"/>.</returns>
#if SUPPORTS_AGGRESSIVEINLINING
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
		public static string BeforeLast(this string value, string searchValue)
		{
			return BeforeLast(value, searchValue, StringComparison.Ordinal);
		}

		/// <summary>
		/// Returns the portion of <paramref name="value"/> that occurs before the last instance of <paramref name="searchValue"/>.
		/// </summary>
		/// <remarks>
		/// <para>Returns null if <paramref name="searchValue"/> is null, empty string or if <paramref name="searchValue"/> does not occur within <paramref name="value"/>.</para>
		/// <para>Matching of <paramref name="searchValue"/> is done using a <see cref="StringComparison.Ordinal"/> comparison.</para>
		/// </remarks>
		/// <param name="value">The value to search in.</param>
		/// <param name="searchValue">The value to search for.</param>
		/// <param name="comparisonMethod">A value from the <see cref="StringComparison"/> enum specfying how <paramref name="searchValue"/> is matched (or not).</param>
		/// <returns>Either null, or a new string containing the portion of the string before the last occurrence of <paramref name="searchValue"/>.</returns>
		public static string BeforeLast(this string value, string searchValue, StringComparison comparisonMethod)
		{
			if (value == null) return null;
			if (value.Length == 0) return null;

			var index = value.LastIndexOf(searchValue, comparisonMethod);
			if (index <= 0) return null;

			return value.Substring(0, index);
		}

		/// <summary>
		/// Returns the portion of <paramref name="value"/> that occurs after the first occurrence of <paramref name="searchValue"/>.
		/// </summary>
		/// <remarks>
		/// <para>Returns null if <paramref name="searchValue"/> is null, empty string or if <paramref name="searchValue"/> does not occur within <paramref name="value"/>.</para>
		/// <para>Matching of <paramref name="searchValue"/> is done using a <see cref="StringComparison.Ordinal"/> comparison.</para>
		/// </remarks>
		/// <param name="value">The value to search within.</param>
		/// <param name="searchValue">The value to search for.</param>
		/// <returns>Either null, or a new string containing the portion of the string after the first occurrence of <paramref name="searchValue"/>.</returns>
#if SUPPORTS_AGGRESSIVEINLINING
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
		public static string AfterFirst(this string value, string searchValue)
		{
			return AfterFirst(value, searchValue, StringComparison.Ordinal);
		}

		/// <summary>
		/// Returns the portion of <paramref name="value"/> that occurs after the first occurrence of <paramref name="searchValue"/>.
		/// </summary>
		/// <remarks>
		/// <para>Returns null if <paramref name="searchValue"/> is null, empty string or if <paramref name="searchValue"/> does not occur within <paramref name="value"/>.</para>
		/// </remarks>
		/// <param name="value">The value to search within.</param>
		/// <param name="searchValue">The value to search for.</param>
		/// <param name="comparisonMethod">The <see cref="StringComparison"/> method to use when searching for <paramref name="searchValue"/>.</param>
		/// <returns>Either null, or a new string containing the portion of the string after the first occurrence of <paramref name="searchValue"/>.</returns>
		public static string AfterFirst(this string value, string searchValue, StringComparison comparisonMethod)
		{
			if (value == null) return null;
			if (value.Length == 0) return null;

			var index = value.IndexOf(searchValue, comparisonMethod);
			if (index <= 0 || index + 1 == value.Length) return null;

			return value.Substring(index + 1);
		}

		/// <summary>
		/// Returns the portion of <paramref name="value"/> that occurs after the last occurrence of <paramref name="searchValue"/>.
		/// </summary>
		/// <remarks>
		/// <para>Returns null if <paramref name="searchValue"/> is null, empty string, <paramref name="searchValue"/> does not occur within <paramref name="value"/> or it occurs at the very end.</para>
		/// <para>Matching of <paramref name="searchValue"/> is done using a <see cref="StringComparison.Ordinal"/> comparison.</para>
		/// </remarks>
		/// <param name="value">The value to search within.</param>
		/// <param name="searchValue">The value to search for.</param>
		/// <returns>Either null, or a new string containing the portion of the string after the last occurrence of <paramref name="searchValue"/>.</returns>
#if SUPPORTS_AGGRESSIVEINLINING
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
		public static string AfterLast(this string value, string searchValue)
		{
			return AfterLast(value, searchValue, StringComparison.Ordinal);
		}

		/// <summary>
		/// Returns the portion of <paramref name="value"/> that occurs after the last occurrence of <paramref name="searchValue"/>.
		/// </summary>
		/// <remarks>
		/// <para>Returns null if <paramref name="searchValue"/> is null, empty string, <paramref name="searchValue"/> does not occur within <paramref name="value"/> or it occurs at the very end.</para>
		/// </remarks>
		/// <param name="value">The value to search within.</param>
		/// <param name="searchValue">The value to search for.</param>
		/// <param name="comparisonMethod">The <see cref="StringComparison"/> method to use when searching for <paramref name="searchValue"/>.</param>
		/// <returns>Either null, or a new string containing the portion of the string after the last occurrence of <paramref name="searchValue"/>.</returns>
		public static string AfterLast(this string value, string searchValue, StringComparison comparisonMethod)
		{
			if (value == null) return null;
			if (value.Length == 0) return null;

			var index = value.LastIndexOf(searchValue, comparisonMethod);
			if (index <= 0 || index + 1== value.Length) return null;

			return value.Substring(index + 1);
		}

		/// <summary>
		/// Returns true if <paramref name="value"/> contains only characters representing numeric digits.
		/// </summary>
		/// <remarks>
		/// <para>A character is a digit if <see cref="Char.IsDigit(char)"/> returns true.</para>
		/// </remarks>
		/// <param name="value">The string to check.</param>
		/// <returns>Returns true if <paramref name="value"/> contains only characters representing numeric digits, otherwise false.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown if <paramref name="value"/> is null.</exception>
		/// <exception cref="System.ArgumentException">Thrown if <paramref name="value"/> is an empty string.</exception>
		public static bool IsOnlyDigits(this string value)
		{
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (value.Length == 0) throw new ArgumentException(ErrorMessages.ArgumentCannotBeEmptyString, nameof(value));

			for (int cnt = 0; cnt < value.Length; cnt++)
			{
				if (!Char.IsDigit(value[cnt])) return false;
			}

			return true;
		}

		/// <summary>
		/// Removes all non-digit characters from a string and returns the result.
		/// </summary>
		/// <remarks>
		/// <para>If value contains only digits then this method returns <paramref name="value"/> and minimises allocations.</para>
		/// </remarks>
		/// <param name="value">The string to strip values from.</param>
		/// <returns>A string containing only the numeric characters of <paramref name="value"/>.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown if <paramref name="value"/> is null.</exception>
		/// <exception cref="System.ArgumentException">Thrown if <paramref name="value"/> is an empty string.</exception>
		public static string StripNonDigits(this string value)
		{
			if (value == null) throw new ArgumentNullException(nameof(value));
			if (value.Length == 0) throw new ArgumentException(ErrorMessages.ArgumentCannotBeEmptyString, nameof(value));

			StringBuilder sb = null;

			for (int cnt = 0; cnt < value.Length; cnt++)
			{
				if (!Char.IsDigit(value[cnt]))
				{
					if (sb == null)
					{
						sb = new StringBuilder(value.Length);
						if (cnt > 0)
						{
							sb.Append(value.Substring(0, cnt));
						}
					}
				}
				else if (sb != null)
					sb.Append(value[cnt]);
			}

			return sb?.ToString() ?? value;
		}

	}
}