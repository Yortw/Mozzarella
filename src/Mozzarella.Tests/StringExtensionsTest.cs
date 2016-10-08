using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mozzarella;

namespace Mozzarella.Tests
{
	[TestClass]
	public class StringExtensionsTest
	{

		#region Truncate

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

		#endregion

		#region CIEquals

		[TestMethod]
		public void StringExtensions_CIEquals_ReturnsMatchOnDifferentCase()
		{
			var text1 = "The quick brown fox jumps over the lazy dog.";
			var text2 = "The QUICK brown Fox jumps OVER the Lazy Dog.";

			Assert.IsTrue(text1.CIEquals(text2));
		}

		[TestMethod]
		public void StringExtensions_CIEquals_ReturnsMatchOnSameCase()
		{
			var text1 = "The quick brown fox jumps over the lazy dog.";
			var text2 = "The quick brown fox jumps over the lazy dog.";

			Assert.IsTrue(text1.CIEquals(text2));
		}

		[TestMethod]
		public void StringExtensions_CIEquals_ReturnsNoMatchOnDifferentStrings()
		{
			var text1 = "The quick brown fox jumps over the lazy dog.";
			var text2 = "The quick brown fox. But same length       .";

			Assert.IsFalse(text1.CIEquals(text2));
		}

		[TestMethod]
		public void StringExtensions_CIEquals_NullsConsideredEqual()
		{
			string text1 = null;
			string text2 = null;

			Assert.IsTrue(text1.CIEquals(text2));
		}

		[TestMethod]
		public void StringExtensions_CIEquals_NullNotEqualToNonNull()
		{
			string text1 = null;
			string text2 = "Test";

			Assert.IsFalse(text1.CIEquals(text2));
		}

		[TestMethod]
		public void StringExtensions_CIEquals_EmptyNotEqualToNonEmpty()
		{
			string text1 = String.Empty;
			string text2 = "Test";

			Assert.IsFalse(text1.CIEquals(text2));
		}

		[TestMethod]
		public void StringExtensions_CIEquals_EmptyNotEqualToNull()
		{
			string text1 = String.Empty;
			string text2 = null;

			Assert.IsFalse(text1.CIEquals(text2));
		}

		[TestMethod]
		public void StringExtensions_CIEquals_EmptyConsideredEqual()
		{
			string text1 = "";
			string text2 = "";

			Assert.IsTrue(text1.CIEquals(text2));
		}

		#endregion

		#region CICompare

		[TestMethod]
		public void StringExtensions_CICompare_ReturnsMatchOnDifferentCase()
		{
			var text1 = "The quick brown fox jumps over the lazy dog.";
			var text2 = "The QUICK brown Fox jumps OVER the Lazy Dog.";

			Assert.AreEqual(0, text1.CICompare(text2));
		}

		[TestMethod]
		public void StringExtensions_CICompare_ReturnsNegativeOneOnLowerValue()
		{
			var text1 = "a";
			var text2 = "b";

			Assert.AreEqual(-1, text1.CICompare(text2));
		}

		[TestMethod]
		public void StringExtensions_CICompare_Returns1OnGreaterValue()
		{
			var text1 = "b";
			var text2 = "a";

			Assert.AreEqual(1, text1.CICompare(text2));
		}

		#endregion

		#region CIContains

		/// <summary>
		/// Strings the extensions_ ci compare_ returns match on different case.
		/// </summary>
		[TestMethod]
		public void StringExtensions_CIContains_ReturnsTrueOnMatch()
		{
			var text1 = "The quick brown fox jumps over the lazy dog.";

			Assert.IsTrue(text1.CIContains("DoG"));
		}

		/// <summary>
		/// Strings the extensions_ ci compare_ returns match on different case.
		/// </summary>
		[TestMethod]
		public void StringExtensions_CIContains_ReturnsFalseOnNoMatch()
		{
			var text1 = "The quick brown fox jumps over the lazy dog.";

			Assert.IsFalse(text1.CIContains("news"));
		}

		#endregion

	}
}