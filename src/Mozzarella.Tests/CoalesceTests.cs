using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class CoalesceTests
	{

		[TestMethod]
		public void Coalesce_DualString_DefaultOptions_TreatsWhitespaceAsEmpty()
		{
			var expected = "Test";
			var actual = "   \r\n\t ".Coalesce(expected);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Coalesce_DualString_WhitespaceOption_TreatsWhitespaceAsEmpty()
		{
			var expected = "Test";
			var actual = "   \r\n\t ".Coalesce(CoalesceOptions.WhiteSpaceAsEmpty, expected);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Coalesce_DualString_NoneOption_WhiteSpaceIsNotEmpty()
		{
			var unexpected = "Test";
			var expected = "   \r\n\t ";
			var actual = expected.Coalesce(CoalesceOptions.None, unexpected);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Coalesce_DualString_TreatsNullAsEmpty()
		{
			var expected = "Test";
			string source = null;
			var actual = source.Coalesce(expected);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Coalesce_DualString_TreatsEmptyStringAsEmpty()
		{
			var expected = "Test";
			var source = String.Empty;
			var actual = source.Coalesce(expected);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Coalesce_DualString_ReturnsOtherValueWhenBothEmpty()
		{
			string source = null;
			var expected = String.Empty;
			var actual = source.Coalesce(expected);

			Assert.IsTrue(Object.ReferenceEquals(expected, actual));
		}


		[TestMethod]
		public void Coalesce_Params_DefaultOptions_TreatsWhitespaceAsEmpty()
		{
			var unexpected1 = String.Empty;
			var unexpected2 = " ";
			var expected = "Test";

			var actual = "   \r\n\t ".Coalesce(unexpected1, unexpected2, expected);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Coalesce_Params_WhitespaceOption_TreatsWhitespaceAsEmpty()
		{
			var unexpected1 = String.Empty;
			var unexpected2 = " ";
			var expected = "Test";
			var actual = "   \r\n\t ".Coalesce(CoalesceOptions.WhiteSpaceAsEmpty, unexpected1, unexpected2, expected);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Coalesce_Params_NoneOption_WhiteSpaceIsNotEmpty()
		{
			var unexpected1 = String.Empty;
			string unexpected2 = null;
			var expected = "   \r\n\t ";
			var actual = expected.Coalesce(CoalesceOptions.None, unexpected1, unexpected2);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Coalesce_Params_TreatsNullAsEmpty()
		{
			var unexpected1 = String.Empty;
			var unexpected2 = " ";
			var expected = "Test";
			string source = null;
			var actual = source.Coalesce(unexpected1, unexpected2, expected);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Coalesce_Params_TreatsEmptyStringAsEmpty()
		{
			var unexpected1 = String.Empty;
			var unexpected2 = " ";
			var expected = "Test";
			var source = String.Empty;
			var actual = source.Coalesce(unexpected1, unexpected2, expected);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Coalesce_Params_ReturnsOtherValueWhenBothEmpty()
		{
			var unexpected1 = String.Empty;
			var unexpected2 = " ";
			string source = null;
			var expected = String.Empty;
			var actual = source.Coalesce(unexpected1, unexpected2, expected);

			Assert.IsTrue(Object.ReferenceEquals(expected, actual));
		}

		[TestMethod]
		public void Coalesce_Params_ReturnsValueWhenOtherValuesNull()
		{
			var source = String.Empty;
			var actual = source.Coalesce((string[])null);

			Assert.IsTrue(Object.ReferenceEquals(source, actual));
		}

	}
}