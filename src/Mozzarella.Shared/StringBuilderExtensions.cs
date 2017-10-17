using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Mozzarella
{
	/// <summary>
	/// Extension methods for <see cref="System.Text.StringBuilder"/>.
	/// </summary>
	public static class StringBuilderExtensions
	{

		#region AppendJoin Overloads

		/// <summary>
		/// Appends all the strings in <paramref name="parts"/> to <paramref name="builder"/> placing <paramref name="separator"/> between each part.
		/// </summary>
		/// <remarks>
		/// <para>If <paramref name="parts"/> is null or zero length, nothing is appended (and no exception is thrown).</para>
		/// <para>If <paramref name="parts"/> contains only a single item then <paramref name="separator"/> is not used.</para>
		/// <para>No <paramref name="separator"/> is placed as the start even if <paramref name="builder"/> is not empty.</para>
		/// <para>If <paramref name="parts"/> contains any null values an empty string is appended instead.</para>
		/// </remarks>
		/// <param name="builder">The <see cref="System.Text.StringBuilder"/> to append to.</param>
		/// <param name="separator">The value to place between each new appended part. If null or empty string, no separator is used.</param>
		/// <param name="parts">An array of strings to be appended.</param>
		/// <returns>A reference to <paramref name="builder"/>, allowing method calls to be chained.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown if <paramref name="builder"/> is null.</exception>
		public static StringBuilder AppendJoin(this StringBuilder builder, string separator, params string[] parts)
		{
			if (builder == null) throw new ArgumentNullException(nameof(builder));
			if (parts == null || parts.Length == 0) return builder;

			builder.Append(parts[0]);
			for (var cnt = 1; cnt < parts.Length; cnt++)
			{
				builder.Append(separator);
				builder.Append(parts[cnt]);
			}

			return builder;
		}

		/// <summary>
		/// Appends all the strings in <paramref name="parts"/> to <paramref name="builder"/> placing <paramref name="separator"/> between each part.
		/// </summary>
		/// <remarks>
		/// <para>If <paramref name="parts"/> is null or contains no items, nothing is appended (and no exception is thrown).</para>
		/// <para>If <paramref name="parts"/> contains only a single item then <paramref name="separator"/> is not used.</para>
		/// <para>No <paramref name="separator"/> is placed as the start even if <paramref name="builder"/> is not empty.</para>
		/// <para>If <paramref name="parts"/> contains any null values an empty string is appended instead.</para>
		/// </remarks>
		/// <param name="builder">The <see cref="System.Text.StringBuilder"/> to append to.</param>
		/// <param name="separator">The value to place between each new appended part. If null or empty string, no separator is used.</param>
		/// <param name="parts">An array of strings to be appended.</param>
		/// <returns>A reference to <paramref name="builder"/>, allowing method calls to be chained.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown if <paramref name="builder"/> is null.</exception>
		public static StringBuilder AppendJoin(this StringBuilder builder, string separator, IList<string> parts)
		{
			if (builder == null) throw new ArgumentNullException(nameof(builder));
			if (parts == null || parts.Count == 0) return builder;

			builder.Append(parts[0]);
			for (var cnt = 1; cnt < parts.Count; cnt++)
			{
				builder.Append(separator);
				builder.Append(parts[cnt]);
			}

			return builder;
		}

		/// <summary>
		/// Appends all the strings in <paramref name="parts"/> to <paramref name="builder"/> placing <paramref name="separator"/> between each part.
		/// </summary>
		/// <remarks>
		/// <para>If <paramref name="parts"/> is null or contains no items, nothing is appended (and no exception is thrown).</para>
		/// <para>If <paramref name="parts"/> contains only a single item then <paramref name="separator"/> is not used.</para>
		/// <para>No <paramref name="separator"/> is placed as the start even if <paramref name="builder"/> is not empty.</para>
		/// <para>If <paramref name="parts"/> contains any null values an empty string is appended instead.</para>
		/// </remarks>
		/// <param name="builder">The <see cref="System.Text.StringBuilder"/> to append to.</param>
		/// <param name="separator">The value to place between each new appended part. If null or empty string, no separator is used.</param>
		/// <param name="parts">An array of strings to be appended.</param>
		/// <returns>A reference to <paramref name="builder"/>, allowing method calls to be chained.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown if <paramref name="builder"/> is null.</exception>
		public static StringBuilder AppendJoin(this StringBuilder builder, string separator, IEnumerable<string> parts)
		{
			if (builder == null) throw new ArgumentNullException(nameof(builder));
			if (parts == null) return builder;

			//Avoid allocations if we were passed an array
			if (parts is string[] strArray)
				return AppendJoin(builder, separator, strArray);

			using (var enumerator = parts.GetEnumerator())
			{
				if (!enumerator.MoveNext()) return builder;

				builder.Append(enumerator.Current);

				while (enumerator.MoveNext())
				{
					builder.Append(separator);
					builder.Append(enumerator.Current);
				}
			}

			return builder;
		}

		#endregion

		#region IndexOf Overloads

		/// <summary>
		/// Returns the ordinal position of the start of <paramref name="searchValue"/> within <paramref name="searchValue"/>.
		/// </summary>
		/// <param name="builder">The string builder to search the contents of.</param>
		/// <param name="searchValue">The string to search for.</param>
		/// <returns>Returns -1 if <paramref name="searchValue"/> does not exist within <paramref name="builder"/>, otherwise returns the ordinal position at which <paramref name="searchValue"/> starts.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown if <paramref name="builder"/> or <paramref name="searchValue"/> is null.</exception>
		/// <exception cref="System.ArgumentException">Thrown if <paramref name="searchValue"/> is an empty string.</exception>
		public static int IndexOf(this StringBuilder builder, string searchValue)
		{
			return IndexOf(builder, searchValue, 0);
		}

		/// <summary>
		/// Returns the ordinal position of the start of <paramref name="searchValue"/> within <paramref name="searchValue"/>.
		/// </summary>
		/// <remarks>
		/// <para>This method uses ordinal comparisions when searching for <paramref name="searchValue"/>.</para>
		/// </remarks>
		/// <param name="builder">The string builder to search the contents of.</param>
		/// <param name="searchValue">The string to search for.</param>
		/// <param name="startIndex">The first character position at which to start the search.</param>
		/// <returns>Returns -1 if <paramref name="searchValue"/> does not exist within <paramref name="builder"/>, otherwise returns the ordinal position at which <paramref name="searchValue"/> starts.</returns>
		/// <exception cref="System.ArgumentOutOfRangeException">Thrown if <paramref name="startIndex"/> is less than 0 or greater than the length of the string builder.</exception>
		/// <exception cref="System.ArgumentNullException">Thrown if <paramref name="builder"/> or <paramref name="searchValue"/> is null.</exception>
		/// <exception cref="System.ArgumentException">Thrown if <paramref name="searchValue"/> is an empty string.</exception>
		public static int IndexOf(this StringBuilder builder, string searchValue, int startIndex)
		{
			if (builder == null) throw new ArgumentNullException(nameof(builder));
			if (searchValue == null) throw new ArgumentNullException(nameof(searchValue));
			if (searchValue.Length == 0) throw new ArgumentException(ErrorMessages.ArgumentCannotBeEmptyString, nameof(searchValue));
			if (startIndex < 0) throw new ArgumentOutOfRangeException(nameof(startIndex));
			if (startIndex > builder.Length) throw new ArgumentOutOfRangeException(nameof(startIndex));

			if (builder.Length == 0) return -1;
			if (searchValue.Length > builder.Length) return -1;

			var retVal = -1;

			var maxSearchIndex = (builder.Length - searchValue.Length) + 1;
			for (var cnt = startIndex; cnt < maxSearchIndex; cnt++)
			{
				var matched = true;
				for (var i = 0; i < searchValue.Length; i++)
				{
					if (builder[cnt + i] != searchValue[i])
					{
						matched = false;
						break;
					}
				}

				if (matched)
				{
					retVal = cnt;
					break;
				}
			}

			return retVal;
		}

		#endregion

		#region LastIndexOf Overloads

		/// <summary>
		/// Returns the last ordinal position of the start of <paramref name="searchValue"/> within <paramref name="searchValue"/>.
		/// </summary>
		/// <param name="builder">The string builder to search the contents of.</param>
		/// <param name="searchValue">The string to search for.</param>
		/// <returns>Returns -1 if <paramref name="searchValue"/> does not exist within <paramref name="builder"/>, otherwise returns the ordinal position at which <paramref name="searchValue"/> starts.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown if <paramref name="builder"/> or <paramref name="searchValue"/> is null.</exception>
		/// <exception cref="System.ArgumentException">Thrown if <paramref name="searchValue"/> is an empty string.</exception>
		public static int LastIndexOf(this StringBuilder builder, string searchValue)
		{
			return LastIndexOf(builder, searchValue, (builder?.Length ?? 1) - 1);
		}

		/// <summary>
		/// Returns the last ordinal position of the start of <paramref name="searchValue"/> within <paramref name="searchValue"/>.
		/// </summary>
		/// <remarks>
		/// <para>This method uses ordinal comparisions when searching for <paramref name="searchValue"/>.</para>
		/// </remarks>
		/// <param name="builder">The string builder to search the contents of.</param>
		/// <param name="searchValue">The string to search for.</param>
		/// <param name="startIndex">The first character position at which to start the search.</param>
		/// <returns>Returns -1 if <paramref name="searchValue"/> does not exist within <paramref name="builder"/>, otherwise returns the ordinal position at which <paramref name="searchValue"/> starts.</returns>
		/// <exception cref="System.ArgumentOutOfRangeException">Thrown if <paramref name="startIndex"/> is less than 0 or greater than the length of the string builder.</exception>
		/// <exception cref="System.ArgumentNullException">Thrown if <paramref name="builder"/> or <paramref name="searchValue"/> is null.</exception>
		/// <exception cref="System.ArgumentException">Thrown if <paramref name="searchValue"/> is an empty string.</exception>
		public static int LastIndexOf(this StringBuilder builder, string searchValue, int startIndex)
		{
			if (builder == null) throw new ArgumentNullException(nameof(builder));
			if (searchValue == null) throw new ArgumentNullException(nameof(searchValue));
			if (searchValue.Length == 0) throw new ArgumentException(ErrorMessages.ArgumentCannotBeEmptyString, nameof(searchValue));
			if (startIndex < 0) throw new ArgumentOutOfRangeException(nameof(startIndex));
			if (startIndex > builder.Length) throw new ArgumentOutOfRangeException(nameof(startIndex));

			if (builder.Length == 0) return -1;
			if (searchValue.Length > builder.Length) return -1;
			if (startIndex < searchValue.Length - 1) return -1;

			var retVal = -1;

			for (var cnt = startIndex; cnt >= 0; cnt--)
			{
				var matched = true;
				for (var i = searchValue.Length - 1; i >= 0; i--)
				{
					if (builder[cnt - (searchValue.Length - (i + 1))] != searchValue[i])
					{
						matched = false;
						break;
					}
				}

				if (matched)
				{
					retVal = cnt - (searchValue.Length - 1);
					break;
				}
			}

			return retVal;
		}

		#endregion

		/// <summary>
		/// Returns true if <paramref name="builder"/> contains <paramref name="searchValue"/>.
		/// </summary>
		/// <param name="builder">The <see cref="System.Text.StringBuilder"/> to search within.</param>
		/// <param name="searchValue">The <paramref name="searchValue"/> to search for.</param>
		/// <returns>True if <paramref name="searchValue"/> contains <paramref name="searchValue"/> otherwise false.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown if <paramref name="builder"/> or <paramref name="searchValue"/> is null.</exception>
		/// <exception cref="System.ArgumentException">Thrown if <paramref name="searchValue"/> is an empty string.</exception>
		public static bool Contains(this StringBuilder builder, string searchValue)
		{
			return IndexOf(builder, searchValue) >= 0;
		}

		/// <summary>
		/// If <paramref name="builder"/> is not empty, appends <paramref name="separator"/> then <paramref name="value"/>. If <paramref name="builder"/> is empty, appends only <paramref name="value"/>.
		/// </summary>
		/// <param name="builder">The <see cref="System.Text.StringBuilder"/> to append to.</param>
		/// <param name="separator">The separator to append if <paramref name="builder"/> is not empty.</param>
		/// <param name="value">The value to append.</param>
		/// <returns></returns>
		public static StringBuilder Append(this StringBuilder builder, string separator, string value)
		{
			if (builder == null) throw new ArgumentNullException(nameof(builder));

			if (builder.Length > 0)
				builder.Append(separator);

			builder.Append(value);

			return builder;
		}

		#region AppendIf Overloads

		/// <summary>
		/// Appends <paramref name="value"/> only if <paramref name="condition"/> is true, otherwise does nothing.
		/// </summary>
		/// <param name="builder">The <see cref="System.Text.StringBuilder"/> to append to.</param>
		/// <param name="condition">A boolean indicating whether or not to actually append <paramref name="value"/>.</param>
		/// <param name="value">The value to append.</param>
		/// <returns>A reference to <paramref name="builder"/>.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown if <paramref name="builder"/> is null.</exception>
		public static StringBuilder AppendIf(this StringBuilder builder, bool condition, string value)
		{
			if (builder == null) throw new ArgumentNullException(nameof(builder));

			if (condition)
				builder.Append(value);

			return builder;
		}

		/// <summary>
		/// Appends the result of <paramref name="valueFactory"/> only if <paramref name="condition"/> is true, otherwise does nothing.
		/// </summary>
		/// <param name="builder">The <see cref="System.Text.StringBuilder"/> to append to.</param>
		/// <param name="condition">A boolean indicating whether or not to actually append the value of <paramref name="valueFactory"/>.</param>
		/// <param name="valueFactory">The value to append.</param>
		/// <returns>A reference to <paramref name="builder"/>.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown if <paramref name="builder"/> or <paramref name="valueFactory"/> are null.</exception>
		public static StringBuilder AppendIf(this StringBuilder builder, bool condition, Func<string> valueFactory)
		{
			if (builder == null) throw new ArgumentNullException(nameof(builder));
			if (valueFactory == null) throw new ArgumentNullException(nameof(valueFactory));

			if (condition)
				builder.Append(valueFactory());

			return builder;
		}

		#endregion

		/// <summary>
		/// Removes all leading and trailing whitespace from <paramref name="builder"/>.
		/// </summary>
		/// <param name="builder">The <see cref="System.Text.StringBuilder"/> to remove leading and trailing whitespace from.</param>
		/// <returns>A reference to <paramref name="builder"/>.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown if <paramref name="builder"/> is null.</exception>
		public static StringBuilder Trim(this StringBuilder builder)
		{
			TrimStart(builder);
			TrimEnd(builder);

			return builder;
		}

		/// <summary>
		/// Removes all leading whitespace from <paramref name="builder"/>.
		/// </summary>
		/// <param name="builder">The <see cref="System.Text.StringBuilder"/> to remove leading whitespace from.</param>
		/// <returns>A reference to <paramref name="builder"/>.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown if <paramref name="builder"/> is null.</exception>
		public static StringBuilder TrimStart(this StringBuilder builder)
		{
			if (builder == null) throw new ArgumentNullException(nameof(builder));
			if (builder.Length == 0) return builder;

			int whitespaceChars = 0;
			for (int cnt = 0; cnt < builder.Length; cnt++)
			{
				if (!Char.IsWhiteSpace(builder[cnt]))
				{
					whitespaceChars = cnt;
					break;
				}
			}

			if (whitespaceChars > 0)
				builder.Remove(0, whitespaceChars);

			return builder;
		}

		/// <summary>
		/// Removes all trailing whitespace from <paramref name="builder"/>.
		/// </summary>
		/// <param name="builder">The <see cref="System.Text.StringBuilder"/> to remove trailing whitespace from.</param>
		/// <returns>A reference to <paramref name="builder"/>.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown if <paramref name="builder"/> is null.</exception>
		public static StringBuilder TrimEnd(this StringBuilder builder)
		{
			if (builder == null) throw new ArgumentNullException(nameof(builder));
			if (builder.Length == 0) return builder;

			int whitespaceChars = 0;
			for (int cnt = builder.Length - 1; cnt >= 0; cnt--)
			{
				if (!Char.IsWhiteSpace(builder[cnt]))
				{
					whitespaceChars = builder.Length - (cnt + 1);
					break;
				}
			}

			if (whitespaceChars > 0)
				builder.Remove(builder.Length - whitespaceChars, whitespaceChars);

			return builder;
		}

		/// <summary>
		/// Removes all leading and trailing characters in <paramref name="builder"/> that exist within <paramref name="trimChars"/>.
		/// </summary>
		/// <param name="builder">The <see cref="StringBuilder"/> to remove leading and trailing characters from.</param>
		/// <param name="trimChars">An array of <see cref="Char"/> representing the characters to be removed.</param>
		/// <returns>A reference to <paramref name="builder"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="builder"/> or <paramref name="trimChars"/> is null.</exception>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "chars", Justification = "Argument name matches the one used by framework for equivalent string method.")]
		public static StringBuilder Trim(this StringBuilder builder, params char[] trimChars)
		{
			TrimStart(builder, trimChars);
			TrimEnd(builder, trimChars);

			return builder;
		}

		/// <summary>
		/// Removes all leading characters in <paramref name="builder"/> that exist within <paramref name="trimChars"/>.
		/// </summary>
		/// <param name="builder">The <see cref="StringBuilder"/> to remove leading characters from.</param>
		/// <param name="trimChars">An array of <see cref="Char"/> representing the characters to be removed.</param>
		/// <returns>A reference to <paramref name="builder"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="builder"/> or <paramref name="trimChars"/> is null.</exception>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "chars", Justification = "Argument name matches the one used by framework for equivalent string method.")]
		public static StringBuilder TrimStart(this StringBuilder builder, params char[] trimChars)
		{
			if (builder == null) throw new ArgumentNullException(nameof(builder));
			if (builder.Length == 0) return builder;
			if (trimChars == null) throw new ArgumentNullException(nameof(trimChars));

			int charCountToRemove = 0;
			for (int cnt = 0; cnt < builder.Length; cnt++)
			{
				if (!trimChars.Contains(builder[cnt]))
				{
					charCountToRemove = cnt;
					break;
				}
			}

			if (charCountToRemove > 0)
				builder.Remove(0, charCountToRemove);

			return builder;
		}

		/// <summary>
		/// Removes all trailing characters in <paramref name="builder"/> that exist within <paramref name="trimChars"/>.
		/// </summary>
		/// <param name="builder">The <see cref="StringBuilder"/> to remove trailing characters from.</param>
		/// <param name="trimChars">An array of <see cref="Char"/> representing the characters to be removed.</param>
		/// <returns>A reference to <paramref name="builder"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="builder"/> or <paramref name="trimChars"/> is null.</exception>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "chars", Justification = "Argument name matches the one used by framework for equivalent string method.")]
		public static StringBuilder TrimEnd(this StringBuilder builder, params char[] trimChars)
		{
			if (builder == null) throw new ArgumentNullException(nameof(builder));
			if (builder.Length == 0) return builder;
			if (trimChars == null) throw new ArgumentNullException(nameof(trimChars));

			int charCountToRemove = 0;
			for (int cnt = builder.Length - 1; cnt >= 0; cnt--)
			{
				if (!trimChars.Contains(builder[cnt]))
				{
					charCountToRemove = builder.Length - (cnt + 1);
					break;
				}
			}

			if (charCountToRemove > 0)
				builder.Remove(builder.Length - charCountToRemove, charCountToRemove);

			return builder;
		}

		/// <summary>
		/// Ensures/converts the entire contents of the <paramref name="builder"/> to uppercase characters.
		/// </summary>
		/// <param name="builder">The <see cref="System.Text.StringBuilder"/> containing the data to be converted.</param>
		/// <returns>Returns <paramref name="builder"/>.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown if <paramref name="builder"/> is null.</exception>
		public static StringBuilder ToUpper(this StringBuilder builder)
		{
			return ToUpper(builder, System.Globalization.CultureInfo.CurrentCulture);
		}

#pragma warning disable 1574

		/// <summary>
		/// Ensures/converts the entire contents of the <paramref name="builder"/> to uppercase characters.
		/// </summary>
		/// <param name="builder">The <see cref="StringBuilder"/> containing the data to be converted.</param>
		/// <param name="culture">A <see cref="System.Globalization.CultureInfo"/> used to determine the case of individual characters.</param>
		/// <remarks>
		/// <para>The <paramref name="culture"/> parameter is ignored when using the net standard library as net standard does not support the <see cref="Char.ToLower(char, System.Globalization.CultureInfo)"/> overload.</para>
		/// </remarks>
		/// <returns>Returns <paramref name="builder"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="builder"/> is null.</exception>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "culture")]
		public static StringBuilder ToUpper(this StringBuilder builder, System.Globalization.CultureInfo culture)
		{
			if (builder == null) throw new ArgumentNullException(nameof(builder));
			if (builder.Length == 0) return builder;

			for (int cnt = 0; cnt < builder.Length; cnt++)
			{
				var c = builder[cnt];
				if (Char.IsLower(c))
#if LEGACYPORTABLE
					builder[cnt] = Char.ToUpper(c, culture);
#else
					builder[cnt] = Char.ToUpper(c);
#endif
			}

			return builder;
		}

		/// <summary>
		/// Ensures/converts the entire contents of the <paramref name="builder"/> to lowercase characters.
		/// </summary>
		/// <param name="builder">The <see cref="System.Text.StringBuilder"/> containing the data to be converted.</param>
		/// <returns>Returns <paramref name="builder"/>.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown if <paramref name="builder"/> is null.</exception>
		public static StringBuilder ToLower(this StringBuilder builder)
		{
			return ToLower(builder, System.Globalization.CultureInfo.CurrentCulture);
		}

		/// <summary>
		/// Ensures/converts the entire contents of the <paramref name="builder"/> to lowercase characters.
		/// </summary>
		/// <param name="builder">The <see cref="StringBuilder"/> containing the data to be converted.</param>
		/// <param name="culture">A <see cref="System.Globalization.CultureInfo"/> used to determine the case of individual characters.</param>
		/// <remarks>
		/// <para>The <paramref name="culture"/> parameter is ignored when using the net standard library as net standard does not support the <see cref="Char.ToLower(char, System.Globalization.CultureInfo)"/> overload.</para>
		/// </remarks>
		/// <returns>Returns <paramref name="builder"/>.</returns>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="builder"/> is null.</exception>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "culture")]
		public static StringBuilder ToLower(this StringBuilder builder, System.Globalization.CultureInfo culture)
		{
			if (builder == null) throw new ArgumentNullException(nameof(builder));
			if (builder.Length == 0) return builder;

			for (int cnt = 0; cnt < builder.Length; cnt++)
			{
				var c = builder[cnt];
				if (Char.IsUpper(c))
#if LEGACYPORTABLE
					builder[cnt] = Char.ToLower(c, culture);
#else
					builder[cnt] = Char.ToLower(c);
#endif
			}

			return builder;
		}

#pragma warning restore 1574


	}
}