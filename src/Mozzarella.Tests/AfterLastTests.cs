
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class AfterLastTests
	{

		[TestMethod]
		public void AfterLast_ReturnsStringAfterLastInstanceOfSearchString()
		{
			var s = "Test:String:Extended";
			Assert.AreEqual("Extended", s.AfterLast(":"));
		}

		[TestMethod]
		public void AfterLast_ReturnsNullWhenValueEndsWithSearchValue()
		{
			var s = "Test:String:Extended:";
			Assert.AreEqual(null, s.AfterLast(":"));
		}

		[TestMethod]
		public void AfterLast_ReturnsNullOnNullSource()
		{
			string s = null;
			Assert.AreEqual(null, s.AfterLast(":"));
		}

		[TestMethod]
		public void AfterLast_ReturnsNullOnEmptySource()
		{
			var s = String.Empty;
			Assert.AreEqual(null, s.AfterLast(":"));
		}

		[TestMethod]
		[ExpectedException(typeof(System.ArgumentNullException))]
		public void AfterLast_ThrowsOnNullSearchString()
		{
			var s = "Test:String:Extended";
			Assert.AreEqual("Extended", s.AfterLast(null));
		}

		[TestMethod]
		public void AfterLast_ReturnsNullWhenSearchValueNotFound()
		{
			var s = "The Eagles-BestOf";
			Assert.AreEqual(null, s.AfterLast(":"));
		}

		[TestMethod]
		public void AfterLast_UsesComparisonMethod()
		{
			var s = "aaaaaBccccccBddddd";
			Assert.AreEqual("ddddd", s.AfterLast("b", StringComparison.OrdinalIgnoreCase));
			Assert.AreEqual(null, s.AfterLast("b", StringComparison.Ordinal));
			Assert.AreEqual("ddddd", s.AfterLast("B", StringComparison.Ordinal));
		}

	}
}