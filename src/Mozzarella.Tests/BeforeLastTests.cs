using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class BeforeLastTests
	{

		[TestMethod]
		public void BeforeLast_ReturnsStringPriorToFirstInstanceOfSearchString()
		{
			var s = "Test:String:Extended";
			Assert.AreEqual("Test:String", s.BeforeLast(":"));
		}

		[TestMethod]
		public void BeforeFirst_ReturnsNullWhenValueStartsWithSearchValue()
		{
			var s = ":Test";
			Assert.AreEqual(null, s.BeforeLast(":"));
		}

		[TestMethod]
		public void BeforeLast_ReturnsNullOnNullSource()
		{
			string s = null;
			Assert.AreEqual(null, s.BeforeLast(":"));
		}

		[TestMethod]
		public void BeforeLast_ReturnsNullOnEmptySource()
		{
			var s = String.Empty;
			Assert.AreEqual(null, s.BeforeLast(":"));
		}

		[TestMethod]
		[ExpectedException(typeof(System.ArgumentNullException))]
		public void BeforeLast_ThrowsOnNullSearchString()
		{
			var s = "Test:String:Extended";
			Assert.AreEqual("Test:String", s.BeforeLast(null));
		}

		[TestMethod]
		public void BeforeLast_ReturnsNullWhenSearchValueNotFound()
		{
			string s = "The Eagles-BestOf";
			Assert.AreEqual(null, s.BeforeLast(":"));
		}

		[TestMethod]
		public void BeforeLast_UsesComparisonMethod()
		{
			var s = "aaaaaBccccccBddddd";
			Assert.AreEqual("aaaaaBcccccc", s.BeforeLast("b", StringComparison.OrdinalIgnoreCase));
			Assert.AreEqual(null, s.BeforeLast("b", StringComparison.Ordinal));
			Assert.AreEqual("aaaaaBcccccc", s.BeforeLast("B", StringComparison.Ordinal));
		}

	}
}