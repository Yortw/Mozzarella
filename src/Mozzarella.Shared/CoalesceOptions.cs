using System;
using System.Collections.Generic;
using System.Text;

namespace Mozzarella
{
	/// <summary>
	/// Options for the <see cref="StringExtensions.Coalesce(string, CoalesceOptions, string)"/> extension method.
	/// </summary>
	[Flags]
	public enum CoalesceOptions
	{
		/// <summary>
		/// No special options. Null or empty string will be 'coalesced'.
		/// </summary>
		None = 0,
		/// <summary>
		/// Strings that contain only whitespace will be 'coalesced' in addition to those that are null or empty.
		/// </summary>
		WhiteSpaceAsEmpty
	}
}