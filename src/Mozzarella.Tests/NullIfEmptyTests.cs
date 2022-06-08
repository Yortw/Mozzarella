using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mozzarella.Tests
{
	[TestClass]
	public class NullIfEmptyTests
	{

		[TestMethod]
		public void NullIfEmpty_ReturnsNullForEmptyString()
		{
			var s = "";
			Assert.IsNull(s.NullIfEmpty());
		}

		[TestMethod]
		public void NullIfEmpty_ReturnsNullForNullString()
		{
			string s = null;
			Assert.IsNull(s.NullIfEmpty());
		}

		[TestMethod]
		public void NullIfEmpty_ReturnsOriginalStringForNonEmptyString()
		{
			string s = "Test";
			Assert.AreEqual("Test", s.NullIfEmpty());
		}

	}
}
