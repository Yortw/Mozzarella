using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class StripPrefixTests
	{

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void StringExtensions_StripPrefix_ThrowsOnNullValue()
		{
			string value = null;
			value.StripPrefix("c:\\");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void StringExtensions_StripPrefix_ThrowsOnNullPrefix()
		{
			var value = @"c:\program files\";
			value.StripPrefix(null);
		}

		[TestMethod]
		public void StringExtensions_StripPrefix_ReturnsOriginalStringWhenMissingPrefix()
		{
			var value = @"c:\program files";
			Assert.IsTrue((object)value == (object)value.StripPrefix("z:\\"));
		}

		[TestMethod]
		public void StringExtensions_StripPrefix_RemovesPrefix()
		{
			var value = @"c:\program files\";
			Assert.AreEqual(@"program files\", value.StripPrefix("c:\\"));
		}

		[TestMethod]
		public void StringExtensions_StripPrefix_RemovesPrefixIgnoringCase()
		{
			var value = @"c:\program files\";
			Assert.AreEqual(@"\program files\", value.StripPrefix("C:", true));
		}

		[TestMethod]
		public void StringExtensions_StripPrefix_DoesNotRemovePrefixWhenCaseDoesntMatch()
		{
			var value = @"c:\program files\";
			Assert.AreEqual(@"c:\program files\", value.StripPrefix("C:"));
		}

	}
}