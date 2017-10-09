using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class StringBuilderIndexOf
	{

		[TestMethod]
		public void StringBuilder_IndexOf_FindsSingleCharString()
		{
			var sb = new StringBuilder("Test:Test2");

			var index = sb.IndexOf(":");

			Assert.AreEqual(4, index);
		}

		[TestMethod]
		public void StringBuilder_IndexOf_FindsSingleCharStringAtBeginning()
		{
			var sb = new StringBuilder("Test:Test2");

			var index = sb.IndexOf("T");

			Assert.AreEqual(0, index);
		}

		[TestMethod]
		public void StringBuilder_IndexOf_FindsSingleCharStringAtEnd()
		{
			var sb = new StringBuilder("Test:Test2");

			var index = sb.IndexOf("2");

			Assert.AreEqual(sb.Length - 1, index);
		}

		[TestMethod]
		public void StringBuilder_IndexOf_FindsSingleCharString_ExactMatch()
		{
			var sb = new StringBuilder("T");

			var index = sb.IndexOf("T");

			Assert.AreEqual(0, index);
		}

		[TestMethod]
		public void StringBuilder_IndexOf_FindsMultiCharString()
		{
			var sb = new StringBuilder("The quick brown fox jumps over the lazy dog.");

			var index = sb.IndexOf("fox");

			Assert.AreEqual(16, index);
		}

		[TestMethod]
		public void StringBuilder_IndexOf_FindsMultiCharString_AtBeginning()
		{
			var sb = new StringBuilder("The quick brown fox jumps over the lazy dog.");

			var index = sb.IndexOf("The");

			Assert.AreEqual(0, index);
		}

		[TestMethod]
		public void StringBuilder_IndexOf_FindsMultiCharString_AtEnd()
		{
			var sb = new StringBuilder("The quick brown fox jumps over the lazy dog.");

			var index = sb.IndexOf("dog.");

			Assert.AreEqual(sb.Length - 4, index);
		}

		[TestMethod]
		public void StringBuilder_IndexOf_FindsMultiCharString_ExactMatch()
		{
			var sb = new StringBuilder("dog.");

			var index = sb.IndexOf("dog.");

			Assert.AreEqual(0, index);
		}

		[TestMethod]
		public void StringBuilder_IndexOf_ObeysStartIndex()
		{
			var sb = new StringBuilder("Test:Test2");

			var index = sb.IndexOf("T");
			Assert.AreEqual(0, index);

			index = sb.IndexOf("T", 3);

			Assert.AreEqual(5, index);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void StringBuilder_IndexOf_ThrowsOnNullBuilder()
		{
			StringBuilder sb = null;

			var index = sb.IndexOf("fox");

			Assert.Fail("Exception not thrown.");
		}

	}
}