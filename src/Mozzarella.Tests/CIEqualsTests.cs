using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class CIEqualsTests
	{

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

	}
}