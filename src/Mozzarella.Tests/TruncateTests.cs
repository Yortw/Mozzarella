using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class TruncateTests
	{

		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[TestMethod]
		public void StringExtensions_Truncate_ThrowsOnNegativeMaxLength()
		{
			var longText = "The quick brown fox jumps over the lazy dog.";

			var truncatedText = longText.Truncate(-1);
			Assert.Fail("Did not throw");
		}

		[TestMethod]
		public void StringExtensions_Truncate_ReturnsEmptyWhenMaxLengthIsZero()
		{
			var longText = "The quick brown fox jumps over the lazy dog.";

			var truncatedText = longText.Truncate(0);
			Assert.AreEqual(String.Empty, truncatedText);
		}

		[TestMethod]
		public void StringExtensions_Truncate_ReturnsNullFromNull()
		{
			string longText = null;

			var truncatedText = longText.Truncate(10);
			Assert.AreEqual(null, truncatedText);
		}

		[TestMethod]
		public void StringExtensions_Truncate_DoesntTruncateShorterString()
		{
			var longText = "The quick brown fox jumps over the lazy dog.";

			var truncatedText = longText.Truncate(200);
			Assert.AreEqual(longText, truncatedText);
		}

		[TestMethod]
		public void StringExtensions_Truncate_TruncatesLongerString()
		{
			var longText = "The quick brown fox jumps over the lazy dog.";
			var shortText = "The quick";

			var truncatedText = longText.Truncate(9);
			Assert.AreEqual(9, truncatedText.Length);
			Assert.AreEqual(shortText, truncatedText);
		}

	}
}