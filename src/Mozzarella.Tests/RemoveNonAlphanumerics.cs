using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class RemoveNonAlphanumerics
	{

		[TestMethod]
		public void RemoveNonAlphanumerics_ReturnsNullForNull()
		{
			string s = null;
			Assert.IsNull(s.RemoveNonAlphanumerics());
		}

		[TestMethod]
		public void RemoveNonAlphanumerics_ReturnsEmptyForEmpty()
		{
			var s = String.Empty;
			Assert.AreEqual(String.Empty, s.RemoveNonAlphanumerics());
		}

		[TestMethod]
		public void RemoveNonAlphanumerics_ReturnsOriginalStringWhenNoCharactersRemoved()
		{
			var s = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			Assert.IsTrue(Object.ReferenceEquals(s, s.RemoveNonAlphanumerics()));
		}

		[TestMethod]
		public void RemoveNonAlphanumerics_DoesNotRemoveNumerics()
		{
			var s = "0800PIZZA83";
			Assert.AreEqual("0800PIZZA83", s.RemoveNonAlphanumerics());
		}

		[TestMethod]
		public void RemoveNonAlphanumerics_RemovesNonAlphanumerics()
		{
			var s = "+ 64 0800-PIZZA-83";
			Assert.AreEqual("640800PIZZA83", s.RemoveNonAlphanumerics());
		}

	}
}