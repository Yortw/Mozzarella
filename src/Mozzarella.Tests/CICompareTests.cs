using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class CICompareTests
	{

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

		[TestMethod]
		public void StringExtensions_CICompare_ReturnsEqualForCulturallySimilarMatch()
		{
			var text1 = "strasse";
			var text2 = "Straße";

			Assert.AreEqual(0, text1.CICompare(text2));
		}

	}
}