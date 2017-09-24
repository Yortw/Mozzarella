using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class OCIEqualsTests
	{

		[TestMethod]
		public void StringExtensions_OCIEquals_ReturnsMatchOnDifferentCase()
		{
			var text1 = "The quick brown fox jumps over the lazy dog.";
			var text2 = "The QUICK brown Fox jumps OVER the Lazy Dog.";

			Assert.IsTrue(text1.OCIEquals(text2));
		}

		[TestMethod]
		public void StringExtensions_OCIEquals_ReturnsMatchOnSameCase()
		{
			var text1 = "The quick brown fox jumps over the lazy dog.";
			var text2 = "The quick brown fox jumps over the lazy dog.";

			Assert.IsTrue(text1.OCIEquals(text2));
		}

		[TestMethod]
		public void StringExtensions_OCIEquals_ReturnsNoMatchOnDifferentStrings()
		{
			var text1 = "The quick brown fox jumps over the lazy dog.";
			var text2 = "The quick brown fox. But same length       .";

			Assert.IsFalse(text1.OCIEquals(text2));
		}

		[TestMethod]
		public void StringExtensions_OCIEquals_ReturnsNoMatchOnWhenStringsAreCulturallySimilarButOrdinallyDifferent()
		{
			var text1 = "Strasse";
			var text2 = "Straße";

			Assert.IsFalse(text1.OCIEquals(text2));
		}

		[TestMethod]
		public void StringExtensions_OCIEquals_NullsConsideredEqual()
		{
			string text1 = null;
			string text2 = null;

			Assert.IsTrue(text1.OCIEquals(text2));
		}

		[TestMethod]
		public void StringExtensions_OCIEquals_NullNotEqualToNonNull()
		{
			string text1 = null;
			string text2 = "Test";

			Assert.IsFalse(text1.OCIEquals(text2));
		}

		[TestMethod]
		public void StringExtensions_OCIEquals_EmptyNotEqualToNonEmpty()
		{
			string text1 = String.Empty;
			string text2 = "Test";

			Assert.IsFalse(text1.OCIEquals(text2));
		}

		[TestMethod]
		public void StringExtensions_OCIEquals_EmptyNotEqualToNull()
		{
			string text1 = String.Empty;
			string text2 = null;

			Assert.IsFalse(text1.OCIEquals(text2));
		}

		[TestMethod]
		public void StringExtensions_OCIEquals_EmptyConsideredEqual()
		{
			string text1 = "";
			string text2 = "";

			Assert.IsTrue(text1.OCIEquals(text2));
		}

	}
}