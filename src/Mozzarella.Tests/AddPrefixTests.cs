using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class AddPrefixTests
	{
		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void StringExtensions_AddPrefix_ThrowsOnNullValue()
		{
			string value = null;
			value.AddPrefix("c:\\");
		}

		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void StringExtensions_AddPrefix_ThrowsOnNullPrefix()
		{
			string value = @"program files";
			value.AddPrefix(null);
		}

		[TestMethod]
		public void StringExtensions_AddPrefix_AddsPrefixWhenNotMatched()
		{
			string value = @"program files";
			Assert.AreEqual("c:\\program files", value.AddPrefix("c:\\"));
		}

		[TestMethod]
		public void StringExtensions_AddPrefix_AddsPrefixWhenNotMatchedCaseInsensitive()
		{
			string value = "program files";
			Assert.AreEqual("C:\\program files", value.AddPrefix("C:\\", true));
		}

		[TestMethod]
		public void StringExtensions_AddPrefix_DoesNotAddPrefixWhenMatched()
		{
			string value = "c:\\program files";
			Assert.AreEqual("c:\\program files", value.AddPrefix("c:\\"));
		}

		[TestMethod]
		public void StringExtensions_AddPrefix_DoesNotAddPrefixWhenMatchedCaseInsensitive()
		{
			string value = @"c:\program files";
			Assert.AreEqual("c:\\program files", value.AddPrefix("C:\\", true));
		}

	}
}