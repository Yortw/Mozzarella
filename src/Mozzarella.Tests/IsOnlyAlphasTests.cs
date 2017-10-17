using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class IsOnlyAlphasTests
	{
		
		[TestMethod]
		public void IsOnlyAlphas_ReturnsFalseWhenNull()
		{
			string s = null;
			Assert.IsFalse(s.IsOnlyAlphas());
		}

		[TestMethod]
		public void IsOnlyAlphas_ReturnsFalseWhenEmpty()
		{
			string s = String.Empty;
			Assert.IsFalse(s.IsOnlyAlphas());
		}

		[TestMethod]
		public void IsOnlyAlphas_ReturnsTrueWithSingleAlphaCharacter()
		{
			string s = "A";
			Assert.IsTrue(s.IsOnlyAlphas());
		}

		[TestMethod]
		public void IsOnlyAlphas_ReturnsTrueWithAllAlphaCharacters()
		{
			string s = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcedfghijklmnopqrstuvwxyz";
			Assert.IsTrue(s.IsOnlyAlphas());
		}

		[TestMethod]
		public void IsOnlyAlphas_ReturnsFalseWithNonAlphaCharacters()
		{
			string s = "ABCDEFGHIJKLMNOPQRSTUVWXYZ-abcedfghijklmnopqrstuvwxyz";
			Assert.IsFalse(s.IsOnlyAlphas());
		}

		[TestMethod]
		public void IsOnlyAlphas_ReturnsFalseForNumerics()
		{
			string s = "0123456789";
			Assert.IsFalse(s.IsOnlyAlphas());
		}

	}
}