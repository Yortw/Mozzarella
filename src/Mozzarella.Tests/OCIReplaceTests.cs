using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class OCIReplaceTests
	{
		[TestMethod]
		public void StringExtensions_OCIReplace_ReplacesIgnoringCase()
		{
			var test = "and this aNd that AND the other";
			var expected = ", this , that , the other";

			Assert.AreEqual(expected, test.OCIReplace("AnD", ","));
		}

		[TestMethod]
		public void StringExtensions_OCIReplace_ReplacesStartOfString()
		{
			var test = "and this and that and the other";
			var expected = ", this , that , the other";

			Assert.AreEqual(expected, test.OCIReplace("and", ","));
		}

		[TestMethod]
		public void StringExtensions_OCIReplace_ReplacesEndOfString()
		{
			var test = "and this and that and the other";
			var expected = "and this and that and the other one";

			Assert.AreEqual(expected, test.OCIReplace("other", "other one"));
		}

		[TestMethod]
		public void StringExtensions_OCIReplace_ReplacesMiddleOfString()
		{
			var test = "and this and that and the other";
			var expected = "and this and this and the other";

			Assert.AreEqual(expected, test.OCIReplace("that", "this"));
		}

		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void StringExtensions_OCIReplace_ThrowsOnNullSource()
		{
			string test = null;
			var expected = "and this and this and the other";

			Assert.AreEqual(expected, test.OCIReplace("that", "this"));
		}

		[TestMethod]
		public void StringExtensions_OCIReplace_RemovesSubstringWhenNewValueIsEmpty()
		{
			var test = "and this and that and the other";
			var expected = " this  that  the other";

			Assert.AreEqual(expected, test.OCIReplace("and", String.Empty));
		}

		[TestMethod]
		public void StringExtensions_OCIReplace_TreatsNullNewValueAsEmpty()
		{
			var test = "and this and that and the other";
			var expected = " this  that  the other";

			Assert.AreEqual(expected, test.OCIReplace("and", null));
		}

		[TestMethod]
		public void StringExtensions_OCIReplace_ReturnsOriginalWhenNoSubstring()
		{
			var test = "and this and that and the other";

			Assert.IsTrue((object)test == (object)test.OCIReplace("food", "cheese"));
		}

		[TestMethod]
		public void StringExtensions_OCIReplace_ReplacesRepeatedInstances()
		{
			var test = "aaaaaaaaaaaaaaa";
			var expected = "bbbbbbbbbbbbbbb";

			Assert.AreEqual(expected, test.OCIReplace("a", "b"));
		}

		[TestMethod]
		public void StringExtensions_OCIReplace_ReplacesWholeString()
		{
			var test = "and this and that and the other";
			var expected = "lots of stuff";

			Assert.AreEqual(expected, test.OCIReplace(test, expected));
		}

		[TestMethod]
		public void StringExtensions_OCIReplace_NoReplacementWhenSubstringCulturallySimilarButOrdinallyDifferent()
		{
			var test = "Our house, in the middle of the strasse";
			var expected = "Our house, in the middle of the strasse";

			Assert.AreEqual(expected, test.OCIReplace("Straße", "street"));
		}

	}
}