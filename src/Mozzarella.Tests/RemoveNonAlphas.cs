using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class RemoveNonAlphas
	{

		[TestMethod]
		public void RemoveNonAlphas_ReturnsNullForNull()
		{
			string s = null;
			Assert.IsNull(s.RemoveNonAlphas());
		}

		[TestMethod]
		public void RemoveNonAlphas_ReturnsEmptyForEmpty()
		{
			var s = String.Empty;
			Assert.AreEqual(String.Empty, s.RemoveNonAlphas());
		}

		[TestMethod]
		public void RemoveNonAlphas_ReturnsOriginalStringWhenNoCharactersRemoved()
		{
			var s = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
			Assert.IsTrue(Object.ReferenceEquals(s, s.RemoveNonAlphas()));
		}

		[TestMethod]
		public void RemoveNonAlphas_RemovesNumerics()
		{
			var s = "0800PIZZA83";
			Assert.AreEqual("PIZZA", s.RemoveNonAlphas());
		}

		[TestMethod]
		public void RemoveNonAlphas_RemovesNonNumericNonAlphas()
		{
			var s = "+ 64 0800-PIZZA-83";
			Assert.AreEqual("PIZZA", s.RemoveNonAlphas());
		}

	}
}