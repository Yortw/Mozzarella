using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mozzarella.Tests
{
	[TestClass]
	public class LevenshteinDistanceToTests
	{

		[TestMethod()]
		public void LevenshteinDistance_ReturnsZeroForNulls()
		{
			string first = null;
			string second = null;
			var expected = 0;

			var actual = first.LevenshteinDistanceTo(second);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void LevenshteinDistance_ReturnsZeroForNullAndEmpty()
		{
			string first = null;
			string second = String.Empty;
			var expected = 0;

			var actual = first.LevenshteinDistanceTo(second);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void LevenshteinDistance_ReturnsZeroForEmptyAndNull()
		{
			string first = String.Empty;
			string second = null;
			var expected = 0;

			var actual = first.LevenshteinDistanceTo(second);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void LevenshteinDistance_ReturnsSecondLengthForNullAndNonNull()
		{
			string first = null;
			string second = "Test";
			var expected = 4;

			var actual = first.LevenshteinDistanceTo(second);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void LevenshteinDistance_ReturnsSecondLengthForEmptyAndNonNull()
		{
			string first = String.Empty;
			string second = "Test";
			var expected = 4;

			var actual = first.LevenshteinDistanceTo(second);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void LevenshteinDistance_ReturnsFirstLengthForNotNullAndNull()
		{
			string first = null;
			string second = "Test";
			var expected = 4;

			var actual = first.LevenshteinDistanceTo(second);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		public void LevenshteinDistance_ReturnsFirstLengthForNotNullAndEmpty()
		{
			string first = "Test";
			string second = String.Empty;
			var expected = 4;

			var actual = first.LevenshteinDistanceTo(second);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod()]
		[DataRow("ant", "aunt", 1)]
		[DataRow("ant", "antidote", 5)]
		[DataRow("gmail", "gnail", 1)]
		[DataRow("extra.co.nz", "xtra.co.nz", 1)]
		public void LevenshteinDistance_ReturnsExpectedDistance(string first, string second, int expectedDistance)
		{
			var actualDistance = first.LevenshteinDistanceTo(second);
			Assert.AreEqual(expectedDistance, actualDistance, $"Expected distance of {expectedDistance} between \"{first}\" and \"{second}\" but got {actualDistance}.");
		}
	}
}
