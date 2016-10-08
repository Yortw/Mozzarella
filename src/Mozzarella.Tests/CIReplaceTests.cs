using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class CIReplaceTests
	{
		[TestMethod]
		public void StringExtensions_CIReplace_ReplacesIgnoringCase()
		{
			var test = "and this aNd that AND the other";
			var expected = ", this , that , the other";

			Assert.AreEqual(expected, test.CIReplace("AnD", ","));
		}


		[TestMethod]
		public void StringExtensions_CIReplace_ReplacesStartOfString()
		{
			var test = "and this and that and the other";
			var expected = ", this , that , the other";

			Assert.AreEqual(expected, test.CIReplace("and", ","));
		}

		[TestMethod]
		public void StringExtensions_CIReplace_ReplacesEndOfString()
		{
			var test = "and this and that and the other";
			var expected = "and this and that and the other one";

			Assert.AreEqual(expected, test.CIReplace("other", "other one"));
		}

		[TestMethod]
		public void StringExtensions_CIReplace_ReplacesMiddleOfString()
		{
			var test = "and this and that and the other";
			var expected = "and this and this and the other";

			Assert.AreEqual(expected, test.CIReplace("that", "this"));
		}

		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void StringExtensions_CIReplace_ThrowsOnNullSource()
		{
			string test = null;
			var expected = "and this and this and the other";

			Assert.AreEqual(expected, test.CIReplace("that", "this"));
		}

		[TestMethod]
		public void StringExtensions_CIReplace_RemovesSubstringWhenNewValueIsEmpty()
		{
			var test = "and this and that and the other";
			var expected = " this  that  the other";

			Assert.AreEqual(expected, test.CIReplace("and", String.Empty));
		}

		[TestMethod]
		public void StringExtensions_CIReplace_TreatsNullNewValueAsEmpty()
		{
			var test = "and this and that and the other";
			var expected = " this  that  the other";

			Assert.AreEqual(expected, test.CIReplace("and", null));
		}

		[TestMethod]
		public void StringExtensions_CIReplace_ReturnsOriginalWhenNoSubstring()
		{
			var test = "and this and that and the other";

			Assert.IsTrue((object)test == (object)test.CIReplace("food", "cheese"));
		}

		[TestMethod]
		public void StringExtensions_CIReplace_ReplacesRepeatedInstances()
		{
			var test = "aaaaaaaaaaaaaaa";
			var expected = "bbbbbbbbbbbbbbb";

			Assert.AreEqual(expected, test.CIReplace("a", "b"));
		}

		[TestMethod]
		public void StringExtensions_CIReplace_ReplacesWholeString()
		{
			var test = "and this and that and the other";
			var expected = "lots of stuff";

			Assert.AreEqual(expected, test.CIReplace(test, expected));
		}

	}
}