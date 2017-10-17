using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class RemoveAllExceptTests
	{

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void RemoveAllExcept_ThrowsOnNullCharacterSet()
		{
			var s = "+64 (0800)-PIZZA";

			s.RemoveAllExcept(null);
		}

		[TestMethod]
		public void RemoveAllExcept_RemovesDisallowedCharacters()
		{
			var s = "+64 (0800)-PIZZA";

			Assert.AreEqual("PIZZA", s.RemoveAllExcept('P', 'I', 'Z', 'A'));
		}


		[TestMethod]
		public void RemoveAllExcept_ReturnsOriginalStringWhenNoChanges()
		{
			var s = "+64 (0800)-PIZZA";

			Assert.AreEqual("+64 (0800)-PIZZA", s.RemoveAllExcept(s.ToCharArray().Distinct()));
		}

		[TestMethod]
		public void RemoveAllExcept_ReturnsNullWhenNull()
		{
			string s = null;

			Assert.IsNull(s.RemoveAllExcept('P', 'I', 'Z', 'A'));
		}


		[TestMethod]
		public void RemoveAllExcept_ReturnsEmptyWhenEmpty()
		{
			string s = String.Empty;

			Assert.AreEqual(String.Empty, s.RemoveAllExcept('P', 'I', 'Z', 'A'));
		}

	}
}