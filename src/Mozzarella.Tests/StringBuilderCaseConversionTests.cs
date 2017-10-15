using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class StringBuilderCaseConversionTests
	{

		[TestMethod]
		public void StringBuilder_ToUpper_IgnoresEmptyBuilder()
		{
			var sb = new StringBuilder();

			Assert.AreEqual(String.Empty, sb.ToUpper().ToString());
		}

		[TestMethod]
		public void StringBuilder_ToUpper_ConvertsAllLowercaseToAllUppercase()
		{
			var sb = new StringBuilder("it was the best of times, it was the worst of times.");

			Assert.AreEqual("IT WAS THE BEST OF TIMES, IT WAS THE WORST OF TIMES.", sb.ToUpper().ToString());
		}

		[TestMethod]
		public void StringBuilder_ToUpper_ConvertsMixedcaseToAllUppercase()
		{
			var sb = new StringBuilder("It WAS the best of times, It WAS the worst of times.");

			Assert.AreEqual("IT WAS THE BEST OF TIMES, IT WAS THE WORST OF TIMES.", sb.ToUpper().ToString());
		}


		[TestMethod]
		public void StringBuilder_ToUpper_ConvertsReturnsAllUppercaseWhenAlreadyUppercase()
		{
			var sb = new StringBuilder("IT WAS THE BEST OF TIMES, IT WAS THE WORST OF TIMES.");

			Assert.AreEqual("IT WAS THE BEST OF TIMES, IT WAS THE WORST OF TIMES.", sb.ToUpper().ToString());
		}

		[TestMethod]
		public void StringBuilder_ToLower_IgnoresEmptyBuilder()
		{
			var sb = new StringBuilder();

			Assert.AreEqual(String.Empty, sb.ToLower().ToString());
		}

		[TestMethod]
		public void StringBuilder_ToLower_ConvertsAllUppercaseToAllLowercase()
		{
			var sb = new StringBuilder("IT WAS THE BEST OF TIMES, IT WAS THE WORST OF TIMES.");

			Assert.AreEqual("it was the best of times, it was the worst of times.", sb.ToLower().ToString());
		}

		[TestMethod]
		public void StringBuilder_ToLower_ConvertsMixedcaseToAllLowercase()
		{
			var sb = new StringBuilder("IT was THE BEST OF TIMES, IT was THE WORST OF TIMES.");

			Assert.AreEqual("it was the best of times, it was the worst of times.", sb.ToLower().ToString());
		}

		[TestMethod]
		public void StringBuilder_ToLower_ReturnsAllLowercaseWhenAlreadyAllLowercase()
		{
			var sb = new StringBuilder("it was the best of times, it was the worst of times.");

			Assert.AreEqual("it was the best of times, it was the worst of times.", sb.ToLower().ToString());
		}

	}
}