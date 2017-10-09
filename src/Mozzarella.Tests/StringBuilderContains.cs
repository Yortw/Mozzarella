using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class StringBuilderContains
	{

		[TestMethod]
		public void StringBuilder_Contains_FindsMatch()
		{
			var sb = new StringBuilder("The quick brown fox jumps over the lazy dog.");

			Assert.IsTrue(sb.Contains("fox jumps"));
		}

		[TestMethod]
		public void StringBuilder_Contains_ReturnsFalseForNoMatch()
		{
			var sb = new StringBuilder("The quick brown fox jumps over the lazy dog.");

			Assert.IsFalse(sb.Contains("hey you"));
		}

	}
}