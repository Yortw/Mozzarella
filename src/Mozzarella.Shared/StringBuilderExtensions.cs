using System;
using System.Collections.Generic;
using System.Text;

namespace Mozzarella
{
	/// <summary>
	/// Extension methods for <see cref="System.Text.StringBuilder"/>.
	/// </summary>
	public static class StringBuilderExtensions
	{

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
			var strArray = parts as string[];
			if (strArray != null)
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

	}
}