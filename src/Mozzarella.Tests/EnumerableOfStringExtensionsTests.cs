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
	public class EnumerableOfStringExtensionsTests
	{

		#region Coalesce

		[TestMethod]
		public void EnumerableOfString_Coalesce_CoalescesArray()
		{
			var values = new string[] { null, String.Empty, "Test1", "Test2" };

			Assert.AreEqual("Test1", values.Coalesce());
		}

		[TestMethod]
		public void EnumerableOfString_Coalesce_CoalescesEnumerable()
		{
			var values = new List<string>();
			values.Add(null);
			values.Add(String.Empty);
			values.Add("Test1");
			values.Add("Test2");

			Assert.AreEqual("Test1", values.Coalesce());
		}

		[TestMethod]
		public void EnumerableOfString_Coalesce_ReturnsNullWhenValuesNull()
		{
			IEnumerable<string> values = null;

			Assert.AreEqual(null, values.Coalesce());
		}

		[TestMethod]
		public void EnumerableOfString_Coalesce_ReturnsNullWhenOnlyBlankValues()
		{
			IEnumerable<string> values = new string[] { String.Empty, null, null, String.Empty };

			Assert.AreEqual(null, values.Coalesce());
		}

		[TestMethod]
		public void EnumerableOfString_Coalesce_CoalescesEmpty()
		{
			IEnumerable<string> values = new string[] { String.Empty, "Test1" };

			Assert.AreEqual("Test1", values.Coalesce());
		}

		[TestMethod]
		public void EnumerableOfString_Coalesce_CoalescesNull()
		{
			IEnumerable<string> values = new string[] { null, "Test1" };

			Assert.AreEqual("Test1", values.Coalesce());
		}

		#endregion

	}
}