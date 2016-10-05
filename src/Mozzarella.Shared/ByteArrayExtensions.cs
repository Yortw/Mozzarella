using System;
using System.Collections.Generic;
using System.Text;

namespace Mozzarella
{
	/// <summary>
	/// Extensions for byte arrays.
	/// </summary>
	public static class ByteArrayExtensions
	{

		#region AsString

		/// <summary>
		/// Returns a string created by converting <paramref name="buffer"/> to UTF8 characters.
		/// </summary>
		/// <param name="buffer">The byte array to convert.</param>
		/// <returns>Returns a <see cref="System.String"/>.</returns>
		public static string AsString(this byte[] buffer)
		{
			return AsString(buffer, System.Text.UTF8Encoding.UTF8);
		}

		/// <summary>
		/// Returns a string created by converting <paramref name="buffer"/> to a string using the specified encoding.
		/// </summary>
		/// <param name="buffer">The byte array to convert.</param>
		/// <param name="encoding">The text encoding used to convert the buffer to a string.</param>
		/// <returns>Returns a <see cref="System.String"/>.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown if <paramref name="buffer"/> or <paramref name="encoding"/> is null.</exception>
		public static string AsString(this byte[] buffer, Encoding encoding)
		{
			if (buffer == null) throw new ArgumentNullException(nameof(buffer));
			if (encoding == null) throw new ArgumentNullException(nameof(encoding));

			return encoding.GetString(buffer, 0, buffer.Length);
		}

		#endregion
		
		#region ToHexString

		/// <summary>
		/// Converts a byte array into a string containing it's hexadecimal representation.
		/// </summary>
		/// <param name="values">The bytes to convert.</param>
		/// <returns>A string containing the hexadecimal representation of the bytes.</returns>
		public static string ToHexString(this byte[] values)
		{
			if (values == null) throw new ArgumentNullException(nameof(values));
			if (values.Length == 0) throw new ArgumentException(nameof(values) + " cannot be zero length.", nameof(values));

			StringBuilder sb = new StringBuilder(values.Length * 2);
			foreach (byte x in values)
			{
				sb.AppendFormat(null, "{0:X2}", x);
			}
			return sb.ToString();
		}

		#endregion

	}
}