using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class StringBuilderTrimTests
	{
		[TestMethod]
		public void StringBuilder_Trim_TrimsStartAndEnd()
		{
			var sb = new StringBuilder();
			sb.Append(" \r\n\tTest\t\r\n ");

			sb.Trim();
			Assert.AreEqual("Test", sb.ToString());
		}

		[TestMethod]
		public void StringBuilder_TrimStart_TrimsOnlyStart()
		{
			var sb = new StringBuilder();
			sb.Append(" \r\n\tTest \r\n\t");

			sb.TrimStart();
			Assert.AreEqual("Test \r\n\t", sb.ToString());
		}

		[TestMethod]
		public void StringBuilder_Trim_SucceedsWhenNoLeadingChars()
		{
			var sb = new StringBuilder();
			sb.Append("Test \r\n\t");

			sb.Trim();
			Assert.AreEqual("Test", sb.ToString());
		}

		[TestMethod]
		public void StringBuilder_TrimEnd_TrimsOnlyEnd()
		{
			var sb = new StringBuilder();
			sb.Append("\t\r\n Test\t\r\n ");

			sb.TrimEnd();
			Assert.AreEqual("\t\r\n Test", sb.ToString());
		}

		[TestMethod]
		public void StringBuilder_Trim_SucceedsWhenNoTrailingChars()
		{
			var sb = new StringBuilder();
			sb.Append("\t\r\n Test");

			sb.Trim();
			Assert.AreEqual("Test", sb.ToString());
		}

		[TestMethod]
		public void StringBuilder_Trim_TrimsEmpty()
		{
			var sb = new StringBuilder();

			sb.Trim();
			Assert.AreEqual(String.Empty, sb.ToString());
		}

		[TestMethod]
		public void StringBuilder_TrimChars_TrimsStartAndEnd()
		{
			var sb = new StringBuilder();
			sb.Append("ABTestAB");

			sb.Trim('A', 'B');
			Assert.AreEqual("Test", sb.ToString());
		}

		[TestMethod]
		public void StringBuilder_TrimStartChars_TrimsOnlyStart()
		{
			var sb = new StringBuilder();
			sb.Append("ABTestAB");

			sb.TrimStart('A', 'B');
			Assert.AreEqual("TestAB", sb.ToString());
		}

		[TestMethod]
		public void StringBuilder_TrimEndChars_TrimsOnlyEnd()
		{
			var sb = new StringBuilder();
			sb.Append("ABTestAB");

			sb.TrimEnd('A', 'B');
			Assert.AreEqual("ABTest", sb.ToString());
		}

		[TestMethod]
		public void StringBuilder_TrimChars_TrimsEmpty()
		{
			var sb = new StringBuilder();

			sb.Trim('A', 'B');
			Assert.AreEqual(String.Empty, sb.ToString());
		}

	}
}