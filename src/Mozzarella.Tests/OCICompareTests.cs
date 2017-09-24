using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class OCICompareTests
	{

		[TestMethod]
		public void StringExtensions_OCICompare_ReturnsMatchOnDifferentCase()
		{
			var text1 = "The quick brown fox jumps over the lazy dog.";
			var text2 = "The QUICK brown Fox jumps OVER the Lazy Dog.";

			Assert.AreEqual(0, text1.OCICompare(text2));
		}

		[TestMethod]
		public void StringExtensions_OCICompare_ReturnsNegativeOneOnLowerValue()
		{
			var text1 = "a";
			var text2 = "b";

			Assert.AreEqual(-1, text1.OCICompare(text2));
		}

		[TestMethod]
		public void StringExtensions_OCICompare_Returns1OnGreaterValue()
		{
			var text1 = "b";
			var text2 = "a";

			Assert.AreEqual(1, text1.OCICompare(text2));
		}

		[TestMethod]
		public void StringExtensions_OCICompare_ReturnsNonEqualForCulturallySimilarMatch()
		{
			var text1 = "strasse";
			var text2 = "Straße";

			Assert.AreNotEqual(0, text1.OCICompare(text2));
		}

	}
}