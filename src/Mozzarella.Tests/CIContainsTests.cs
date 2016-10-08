using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class CIContainsTests
	{

		/// <summary>
		/// Strings the extensions_ ci compare_ returns match on different case.
		/// </summary>
		[TestMethod]
		public void StringExtensions_CIContains_ReturnsTrueOnMatch()
		{
			var text1 = "The quick brown fox jumps over the lazy dog.";

			Assert.IsTrue(text1.CIContains("DoG"));
		}

		/// <summary>
		/// Strings the extensions_ ci compare_ returns match on different case.
		/// </summary>
		[TestMethod]
		public void StringExtensions_CIContains_ReturnsFalseOnNoMatch()
		{
			var text1 = "The quick brown fox jumps over the lazy dog.";

			Assert.IsFalse(text1.CIContains("news"));
		}

	}
}