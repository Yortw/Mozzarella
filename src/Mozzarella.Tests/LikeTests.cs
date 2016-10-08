using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mozzarella;

namespace Mozzarella.Tests
{
	[TestClass]
	public class LikeTests
	{

		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void StringExtensions_Like_ThrowsOnNullPattern()
		{
			string value = "abcdefg";
			value.Like(null, false);
		}

		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void StringExtensions_Like_ThrowsOnNullValue()
		{
			string value = null;
			value.Like("abc%", false);
		}

		[TestMethod]
		public void StringExtensions_Like_MatchesPrefix()
		{
			var value = "abcdefg";
			Assert.IsTrue(value.Like("abc%", false));
		}

		[TestMethod]
		public void StringExtensions_Like_MatchesSuffix()
		{
			var value = "abcdefg";
			Assert.IsTrue(value.Like("%defg", false));
		}

		[TestMethod]
		public void StringExtensions_Like_MatchesContains()
		{
			var value = "abcdefg";
			Assert.IsTrue(value.Like("%cde%", false));
		}

		[TestMethod]
		public void StringExtensions_Like_MatchesPrefixAndSuffix()
		{
			var value = "abcdefg";
			Assert.IsTrue(value.Like("ab%fg", false));
		}

		[TestMethod]
		public void StringExtensions_Like_MatchesMultipartContains()
		{
			var value = "abcdefg";
			Assert.IsTrue(value.Like("a%cd%f%", false));
		}

		[TestMethod]
		public void StringExtensions_Like_DoesNotMatchPrefixWithoutWildcard()
		{
			var value = "abcdefg";
			Assert.IsFalse(value.Like("abc", false));
		}

		[TestMethod]
		public void StringExtensions_Like_DoesNotMatchSuffixWithoutWildcard()
		{
			var value = "abcdefg";
			Assert.IsFalse(value.Like("efg", false));
		}

		[TestMethod]
		public void StringExtensions_Like_MatchesOnExactMatchWithoutWildcards()
		{
			var value = "abcdefg";
			Assert.IsTrue(value.Like("abcdefg", false));
		}

		[TestMethod]
		public void StringExtensions_Like_MatchesOnExactMatchWithWildcards()
		{
			var value = "abcdefg";
			Assert.IsTrue(value.Like("%abcdefg%", false));
		}

		[TestMethod]
		public void StringExtensions_Like_EncodesSpecialCharacters()
		{
			var value = "$12.00";
			Assert.IsTrue(value.Like("$%.00", false));
		}

	}
}