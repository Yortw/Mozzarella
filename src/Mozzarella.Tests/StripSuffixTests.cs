using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class StripSuffixTests
	{

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void StringExtensions_StripSuffix_ThrowsOnNullValue()
		{
			string value = null;
			value.StripSuffix("\\");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void StringExtensions_StripSuffix_ThrowsOnNullSuffix()
		{
			string value = @"c:\program files\";
			value.StripSuffix(null);
		}

		[TestMethod]
		public void StringExtensions_StripSuffix_ReturnsOriginalStringWhenMissingSuffix()
		{
			string value = @"c:\program files";
			Assert.IsTrue((object)value == (object)value.StripSuffix("\\"));
		}

		[TestMethod]
		public void StringExtensions_StripSuffix_RemovesSuffix()
		{
			string value = @"c:\program files\";
			Assert.AreEqual(@"c:\program files", value.StripSuffix("\\"));
		}

		[TestMethod]
		public void StringExtensions_StripSuffix_RemovesSuffixIgnoringCase()
		{
			string value = @"c:\program files\";
			Assert.AreEqual(@"c:\program", value.StripSuffix(" files\\"), true);
		}

		[TestMethod]
		public void StringExtensions_StripSuffix_DoesNotRemoveSuffixWhenCaseDoesntMatch()
		{
			string value = @"c:\program files\";
			Assert.AreEqual(@"c:\program", value.StripSuffix(" files\\"));
		}

	}
}