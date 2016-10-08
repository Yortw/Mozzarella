using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mozzarella;

namespace Mozzarella.Tests
{
	[TestClass]
	public class IsAllDigitsTests
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void StringExtensions_IsAllDigitsTests_ThrowsOnNullString()
		{
			string value = null;
			value.IsAllDigits();
		}

		[TestMethod]
		public void StringExtensions_IsAllDigitsTests_ReturnsFalseForEmptyString()
		{
			string value = String.Empty;
			Assert.IsFalse(value.IsAllDigits());
		}

		[TestMethod]
		public void StringExtensions_IsAllDigitsTests_ReturnsTrueForNumericString()
		{
			string value = "0123456789";
			Assert.IsTrue(value.IsAllDigits());
		}

		[TestMethod]
		public void StringExtensions_IsAllDigitsTests_ReturnsFalseForNonNumericString()
		{
			string value = "ABCDEFG";
			Assert.IsFalse(value.IsAllDigits());
		}

		[TestMethod]
		public void StringExtensions_IsAllDigitsTests_ReturnsFalseForStringEndingInNonNumericString()
		{
			string value = "0123ABCDEFG";
			Assert.IsFalse(value.IsAllDigits());
		}

		[TestMethod]
		public void StringExtensions_IsAllDigitsTests_ReturnsFalseForStringStartingWithNonNumericString()
		{
			string value = "ABCDEFG0123";
			Assert.IsFalse(value.IsAllDigits());
		}

		[TestMethod]
		public void StringExtensions_IsAllDigitsTests_ReturnsFalseForNonNumericStringStartingAndEndingWithNumbers()
		{
			string value = "567ABCDEFG0123";
			Assert.IsFalse(value.IsAllDigits());
		}

	}
}