using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class ContainsTests
	{

		[TestMethod]
		public void Contains_UsesComparer()
		{
			var value = "The quick brown fox jumps over the lazy dog.";

			Assert.IsTrue(value.Contains("FOX", StringComparison.OrdinalIgnoreCase));
			Assert.IsFalse(value.Contains("FOX", StringComparison.Ordinal));
		}

		[TestMethod]
		public void Contains_ReturnsFalseForNullValue()
		{
			string value = null;

			Assert.IsFalse(value.Contains("FOX", StringComparison.Ordinal));
		}

	}
}