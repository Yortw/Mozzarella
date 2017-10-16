using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class StringBuilderLastIndexOfTests
	{

		[TestMethod]
		public void StringBuilder_LastIndexOf_FindsSingleCharString()
		{
			var sb = new StringBuilder("Test:Test2");

			var index = sb.LastIndexOf(":");

			Assert.AreEqual(4, index);
		}

		[TestMethod]
		public void StringBuilder_LastIndexOf_FindsSingleCharStringAtBeginning()
		{
			var sb = new StringBuilder("ABCD:Test2");

			var index = sb.LastIndexOf("A");

			Assert.AreEqual(0, index);
		}

		[TestMethod]
		public void StringBuilder_LastIndexOf_FindsSingleCharStringAtEnd()
		{
			var sb = new StringBuilder("Test:Test2");

			var index = sb.LastIndexOf("2");

			Assert.AreEqual(sb.Length - 1, index);
		}

		[TestMethod]
		public void StringBuilder_LastIndexOf_FindsSingleCharString_ExactMatch()
		{
			var sb = new StringBuilder("T");

			var index = sb.LastIndexOf("T");

			Assert.AreEqual(0, index);
		}

		[TestMethod]
		public void StringBuilder_LastIndexOf_FindsMultiCharString()
		{
			var sb = new StringBuilder("The quick brown fox jumps over the lazy dog.");

			var index = sb.LastIndexOf("fox");

			Assert.AreEqual(16, index);
		}

		[TestMethod]
		public void StringBuilder_LastIndexOf_FindsMultiCharString_AtBeginning()
		{
			var sb = new StringBuilder("The quick brown fox jumps over the lazy dog.");

			var index = sb.LastIndexOf("The");

			Assert.AreEqual(0, index);
		}

		[TestMethod]
		public void StringBuilder_LastIndexOf_FindsMultiCharString_AtEnd()
		{
			var sb = new StringBuilder("The quick brown fox jumps over the lazy dog.");
			
			var index = sb.LastIndexOf("dog.");

			Assert.AreEqual(sb.Length - 4, index);
		}

		[TestMethod]
		public void StringBuilder_LastIndexOf_FindsMultiCharString_ExactMatch()
		{
			var sb = new StringBuilder("dog.");

			var index = sb.LastIndexOf("dog.");

			Assert.AreEqual(0, index);
		}

		[TestMethod]
		public void StringBuilder_LastIndexOf_ObeysStartIndex()
		{
			var sb = new StringBuilder("Test:Test2");

			var index = sb.LastIndexOf("T");
			Assert.AreEqual(5, index);

			index = sb.LastIndexOf("T", 3);

			Assert.AreEqual(0, index);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void StringBuilder_LastIndexOf_ThrowsOnNullBuilder()
		{
			StringBuilder sb = null;

			var index = sb.LastIndexOf("fox");

			Assert.Fail("Exception not thrown.");
		}

	}
}