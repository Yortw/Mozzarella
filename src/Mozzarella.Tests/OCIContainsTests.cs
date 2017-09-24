using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class OCIContainsTests
	{

		/// <summary>
		/// Strings the extensions_ ci compare_ returns match on different case.
		/// </summary>
		[TestMethod]
		public void StringExtensions_OCIContains_ReturnsTrueOnMatch()
		{
			var text1 = "The quick brown fox jumps over the lazy dog.";

			Assert.IsTrue(text1.OCIContains("DoG"));
		}

		/// <summary>
		/// Strings the extensions_ ci compare_ returns match on different case.
		/// </summary>
		[TestMethod]
		public void StringExtensions_OCIContains_ReturnsFalseOnNoMatch()
		{
			var text1 = "The quick brown fox jumps over the lazy dog.";

			Assert.IsFalse(text1.OCIContains("news"));
		}

		/// <summary>
		/// Strings the extensions_ ci compare_ returns match on different case.
		/// </summary>
		[TestMethod]
		public void StringExtensions_OCIContains_ReturnsFalseOnCulturallySimilarButOrdinallyDifferentMatch()
		{
			var text1 = "Our house, in the middle of the strasse";

			Assert.IsFalse(text1.OCIContains("Straße"));
		}

	}
}