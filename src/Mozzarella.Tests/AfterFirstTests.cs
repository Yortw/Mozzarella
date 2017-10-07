
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class AfterFirstTests
	{

		[TestMethod]
		public void AfterFirst_ReturnsStringAfterLastInstanceOfSearchString()
		{
			var s = "Test:String:Extended";
			Assert.AreEqual("String:Extended", s.AfterFirst(":"));
		}

		[TestMethod]
		public void AfterLast_ReturnsNullWhenValueEndsWithSearchValue()
		{
			var s = "Test:";
			Assert.AreEqual(null, s.AfterFirst(":"));
		}

		[TestMethod]
		public void AfterFirst_ReturnsNullOnNullSource()
		{
			string s = null;
			Assert.AreEqual(null, s.AfterFirst(":"));
		}

		[TestMethod]
		public void AfterFirst_ReturnsNullOnEmptySource()
		{
			var s = String.Empty;
			Assert.AreEqual(null, s.AfterFirst(":"));
		}

		[TestMethod]
		[ExpectedException(typeof(System.ArgumentNullException))]
		public void AfterFirst_ThrowsOnNullSearchString()
		{
			var s = "Test:String:Extended";
			Assert.AreEqual("String:Extended", s.AfterFirst(null));
		}

		[TestMethod]
		public void AfterFirst_ReturnsNullWhenSearchValueNotFound()
		{
			string s = "The Eagles-BestOf";
			Assert.AreEqual(null, s.AfterFirst(":"));
		}

		[TestMethod]
		public void AfterFirst_UsesComparisonMethod()
		{
			var s = "aaaaaBcccccc";
			Assert.AreEqual("cccccc", s.AfterFirst("b", StringComparison.OrdinalIgnoreCase));
			Assert.AreEqual(null, s.AfterFirst("b", StringComparison.Ordinal));
			Assert.AreEqual("cccccc", s.AfterFirst("B", StringComparison.Ordinal));
		}

	}
}