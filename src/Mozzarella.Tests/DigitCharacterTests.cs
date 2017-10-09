using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class DigitCharacterTests
	{

		[TestMethod]
		public void IsOnlyDigits_ReturnsTrueWhenAllNumeric()
		{
			Assert.IsTrue("0123456789".IsOnlyDigits());
		}

		[TestMethod]
		public void IsOnlyDigits_ReturnsFalseWhenNotAllNumeric()
		{
			Assert.IsFalse("01234-56789".IsOnlyDigits());
		}

		[TestMethod]
		public void StripNonDigits_RemovesNonNumericCharacters()
		{
			var expected = "0123456789";
			var source = "0A1B2C3D4-5E6F7G8H9I.";

			Assert.AreEqual(expected, source.StripNonDigits());
		}

		[TestMethod]
		public void StripNonDigits_RemovesLeadingNonNumericCharacters()
		{
			var expected = "123";
			var source = "ABC123";

			Assert.AreEqual(expected, source.StripNonDigits());
		}

		[TestMethod]
		public void StripNonDigits_RemovesTrailingNonNumericCharacters()
		{
			var expected = "123";
			var source = "123ABC";

			Assert.AreEqual(expected, source.StripNonDigits());
		}

		[TestMethod]
		public void StripNonDigits_ReturnsOriginalStringWhenAllNumeric()
		{
			var expected = "0123456789";

			Assert.IsTrue(Object.ReferenceEquals(expected, expected.StripNonDigits()));
		}

	}
}