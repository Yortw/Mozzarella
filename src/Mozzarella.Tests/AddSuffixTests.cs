using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class AddSuffixTests
	{
		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void StringExtensions_AddSuffix_ThrowsOnNullValue()
		{
			string value = null;
			value.AddSuffix("\\");
		}

		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void StringExtensions_AddSuffix_ThrowsOnNullSuffix()
		{
			string value = "c:\\program";
			value.AddSuffix(null);
		}

		[TestMethod]
		public void StringExtensions_AddSuffix_AddsSuffixWhenNotMatched()
		{
			string value = "c:\\program";
			Assert.AreEqual("c:\\program files\\", value.AddSuffix(" files\\"));
		}

		[TestMethod]
		public void StringExtensions_AddSuffix_AddsSuffixWhenNotMatchedCaseInsensitive()
		{
			string value = "c:\\program";
			Assert.AreEqual("c:\\program Files\\", value.AddSuffix(" Files\\", true));
		}

		[TestMethod]
		public void StringExtensions_AddSuffix_DoesNotAddSuffixWhenMatched()
		{
			string value = "c:\\program";
			Assert.AreEqual("c:\\program files\\", value.AddSuffix(" files\\"));
		}

		[TestMethod]
		public void StringExtensions_AddSuffix_DoesNotAddSuffixWhenMatchedCaseInsensitive()
		{
			string value = "c:\\program files\\";
			Assert.AreEqual("c:\\program files\\", value.AddSuffix(" Files\\", true));
		}

	}
}