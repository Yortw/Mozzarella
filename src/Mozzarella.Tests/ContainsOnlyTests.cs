using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class ContainsOnlyTests
	{

		[TestMethod]
		public void ContainsOnly_ReturnsFalseWhenValueEmpty()
		{
			var s = String.Empty;

			Assert.IsFalse(s.ContainsOnly('A', '1'));
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ContainsOnly_ThrownsWhenValueNull()
		{
			string s = null;

			Assert.IsFalse(s.ContainsOnly('A', '1'));
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ContainsOnly_ThrownsWhenCharactersNull()
		{
			string s = "A1";

			Assert.IsFalse(s.ContainsOnly((char[])null));
		}

		[TestMethod]
		public void ContainsOnly_ReturnsTrueWhenOnlyAllowedCharactersExist()
		{
			var s1 = "A";
			var s2 = "1";
			var s3 = "A1";

			Assert.IsTrue(s1.ContainsOnly('A', '1'));
			Assert.IsTrue(s2.ContainsOnly('A', '1'));
			Assert.IsTrue(s3.ContainsOnly('A', '1'));
		}

		[TestMethod]
		public void ContainsOnly_ReturnsFaseWhenDisallowedCharactersExist()
		{
			var s1 = "A-";
			var s2 = "1*";
			var s3 = "ZA1";

			Assert.IsFalse(s1.ContainsOnly('A', '1'));
			Assert.IsFalse(s2.ContainsOnly('A', '1'));
			Assert.IsFalse(s3.ContainsOnly('A', '1'));
		}

	}
}