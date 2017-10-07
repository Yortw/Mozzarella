using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class BeforeFirstTests
	{

		[TestMethod]
		public void BeforeFirst_ReturnsStringPriorToLastInstanceOfSearchString()
		{
			var s = "Test:String:Extended";
			Assert.AreEqual("Test", s.BeforeFirst(":"));
		}

		[TestMethod]
		public void BeforeFirst_ReturnsNullWhenValueStartsWithSearchValue()
		{
			var s = ":Test";
			Assert.AreEqual(null, s.BeforeFirst(":"));
		}

		[TestMethod]
		public void BeforeFirst_ReturnsNullOnNullSource()
		{
			string s = null;
			Assert.AreEqual(null, s.BeforeFirst(":"));
		}

		[TestMethod]
		public void BeforeFirst_ReturnsNullOnEmptySource()
		{
			var s = String.Empty;
			Assert.AreEqual(null, s.BeforeFirst(":"));
		}

		[TestMethod]
		[ExpectedException(typeof(System.ArgumentNullException))]
		public void BeforeFirst_ThrowsOnNullSearchString()
		{
			var s = "Test:String:Extended";
			Assert.AreEqual("Test", s.BeforeFirst(null));
		}

		[TestMethod]
		public void BeforeFirst_ReturnsNullWhenSearchValueNotFound()
		{
			string s = "The Eagles-BestOf";
			Assert.AreEqual(null, s.BeforeFirst(":"));
		}

		[TestMethod]
		public void BeforeFirst_UsesComparisonMethod()
		{
			var s = "aaaaaBcccccc";
			Assert.AreEqual("aaaaa", s.BeforeFirst("b", StringComparison.OrdinalIgnoreCase));
			Assert.AreEqual(null, s.BeforeFirst("b", StringComparison.Ordinal));
			Assert.AreEqual("aaaaa", s.BeforeFirst("B", StringComparison.Ordinal));
		}

	}
}