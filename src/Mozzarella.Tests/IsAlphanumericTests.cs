using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class IsAlphanumericTests
	{
		
		[TestMethod]
		public void IsAlphanumeric_ReturnsFalseWhenNull()
		{
			string s = null;
			Assert.IsFalse(s.IsAlphanumeric());
		}

		[TestMethod]
		public void IsAlphanumeric_ReturnsFalseWhenEmpty()
		{
			string s = String.Empty;
			Assert.IsFalse(s.IsAlphanumeric());
		}

		[TestMethod]
		public void IsAlphanumeric_ReturnsTrueWithSingleAlphaCharacter()
		{
			string s = "A";
			Assert.IsTrue(s.IsAlphanumeric());
		}


		[TestMethod]
		public void IsAlphanumeric_ReturnsTrueWithSingleNumericCharacter()
		{
			string s = "A";
			Assert.IsTrue(s.IsAlphanumeric());
		}

		[TestMethod]
		public void IsAlphanumeric_ReturnsTrueWithAllAlphaCharacters()
		{
			string s = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcedfghijklmnopqrstuvwxyz";
			Assert.IsTrue(s.IsAlphanumeric());
		}

		[TestMethod]
		public void IsAlphanumeric_ReturnsTrueWithAllAlphanumericCharacters()
		{
			string s = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcedfghijklmnopqrstuvwxyz0123456789";
			Assert.IsTrue(s.IsAlphanumeric());
		}

		[TestMethod]
		public void IsAlphanumeric_ReturnsFalseWithNonAlphaCharacters()
		{
			string s = "ABCDEFGHIJKLMNOPQRSTUVWXYZ-abcedfghijklmnopqrstuvwxyz0123456789";
			Assert.IsFalse(s.IsAlphanumeric());
		}

		[TestMethod]
		public void IsAlphanumeric_ReturnsTrueForNumerics()
		{
			string s = "0123456789";
			Assert.IsTrue(s.IsAlphanumeric());
		}

	}
}