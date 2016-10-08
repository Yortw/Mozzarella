using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class IndexOfFirstDifferenceTests
	{

		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void StringExtensions_IndexOfFirstDifference_ThrowsOnNullValue()
		{
			string value = null;
			string otherValue = "Test";

			value.IndexOfFirstDifference(otherValue);
		}

		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void StringExtensions_IndexOfFirstDifference_ThrowsOnNullOthersValue()
		{
			string value = "Test";
			string otherValue = null;

			value.IndexOfFirstDifference(otherValue);
		}

		[TestMethod]
		public void StringExtensions_IndexOfFirstDifference_ReturnsNegative1WhenStringsMatch()
		{
			string value = "Test";
			string otherValue = "Test";

			Assert.AreEqual(-1, value.IndexOfFirstDifference(otherValue));
		}

		[TestMethod]
		public void StringExtensions_IndexOfFirstDifference_ReturnsFirstCharacterWhenDifferent()
		{
			string value = "Test";
			string otherValue = "test";

			Assert.AreEqual(0, value.IndexOfFirstDifference(otherValue));
		}

		[TestMethod]
		public void StringExtensions_IndexOfFirstDifference_ReturnsLastCharacterWhenDifferent()
		{
			string value = "Test";
			string otherValue = "TesT";

			Assert.AreEqual(3, value.IndexOfFirstDifference(otherValue));
		}

		[TestMethod]
		public void StringExtensions_IndexOfFirstDifference_ReturnsCorrectPositionWhenDifferent()
		{
			string value = "TeSt";
			string otherValue = "TesT";

			Assert.AreEqual(2, value.IndexOfFirstDifference(otherValue));
		}

		[TestMethod]
		public void StringExtensions_IndexOfFirstDifference_ReturnsCorrectPositionWhenValueIsLonger()
		{
			string value = "Test2";
			string otherValue = "Test";

			Assert.AreEqual(4, value.IndexOfFirstDifference(otherValue));
		}

		[TestMethod]
		public void StringExtensions_IndexOfFirstDifference_ReturnsCorrectPositionWhenOtherValueIsLonger()
		{
			string value = "Test";
			string otherValue = "Test2";

			Assert.AreEqual(4, value.IndexOfFirstDifference(otherValue));
		}

	}
}