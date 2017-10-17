using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class RemoveAllWhiteSpaceTests
	{

		[TestMethod]
		public void RemoveAllWhiteSpace_RemovesLeadingWhiteSpace()
		{
			var source = "  TEST";
			Assert.AreEqual("TEST", source.RemoveAllWhiteSpace());
		}

		[TestMethod]
		public void RemoveAllWhiteSpace_RemovesTrailingWhiteSpace()
		{
			var source = "TEST   ";
			Assert.AreEqual("TEST", source.RemoveAllWhiteSpace());
		}

		[TestMethod]
		public void RemoveAllWhiteSpace_RemovesInnerWhiteSpace()
		{
			var source = "TEST TEST";
			Assert.AreEqual("TESTTEST", source.RemoveAllWhiteSpace());
		}

		[TestMethod]
		public void RemoveAllWhiteSpace_RemovesLeadingInnerAndTrailingWhiteSpace()
		{
			var source = "  TEST TEST  ";
			Assert.AreEqual("TESTTEST", source.RemoveAllWhiteSpace());
		}

		[TestMethod]
		public void RemoveAllWhiteSpace_ReturnsOriginalStringWhenNoWhiteSpace()
		{
			var source = "TEST";
			Assert.IsTrue(Object.ReferenceEquals(source, source.RemoveAllWhiteSpace()));
		}

	}
}