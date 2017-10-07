using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class AppendJoinTests
	{

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void AppendJoin_Array_ThrowsOnNullBuilder()
		{
			StringBuilder sb = null;

			sb.AppendJoin(".", "Yort", "Mozzarella", "Tests");
		}

		[TestMethod]
		public void AppendJoin_Array_AppendsStringsAsExpected()
		{
			var sb = new StringBuilder(200);

			sb.AppendJoin(".", "Yort", "Mozzarella", "Tests");

			Assert.AreEqual("Yort.Mozzarella.Tests", sb.ToString());
		}

		[TestMethod]
		public void AppendJoin_Array_DoesNotUseSeparatorWithOnlyOneItem()
		{
			var sb = new StringBuilder(200);

			sb.AppendJoin(".", "Yort");

			Assert.AreEqual("Yort", sb.ToString());
		}

		[TestMethod]
		public void AppendJoin_Array_AppendsNullAsEmptyString()
		{
			var sb = new StringBuilder(200);

			sb.AppendJoin(".", "Yort", null, "Mozzarella", String.Empty, "Tests");

			Assert.AreEqual("Yort..Mozzarella..Tests", sb.ToString());
		}

		[TestMethod]
		public void AppendJoin_Array_IgnoresNullSeparator()
		{
			var sb = new StringBuilder(200);

			sb.AppendJoin(null, "Yort", "Mozzarella", "Tests");

			Assert.AreEqual("YortMozzarellaTests", sb.ToString());
		}

		[TestMethod]
		public void AppendJoin_Array_IgnoresEmptySeparator()
		{
			var sb = new StringBuilder(200);

			sb.AppendJoin(String.Empty, "Yort", "Mozzarella", "Tests");

			Assert.AreEqual("YortMozzarellaTests", sb.ToString());
		}

		[TestMethod]
		public void AppendJoin_Array_IgnoresNullArray()
		{
			var sb = new StringBuilder(200);

			sb.AppendJoin(String.Empty, (string[])null);

			Assert.AreEqual(String.Empty, sb.ToString());
		}

		[TestMethod]
		public void AppendJoin_Array_IgnoresEmptyArray()
		{
			var sb = new StringBuilder(200);

			sb.AppendJoin(String.Empty, new string[] { });

			Assert.AreEqual(String.Empty, sb.ToString());
		}



		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void AppendJoin_List_ThrowsOnNullBuilder()
		{
			StringBuilder sb = null;

			sb.AppendJoin(".", new List<string>() { "Yort", "Mozzarella", "Tests" });
		}

		[TestMethod]
		public void AppendJoin_List_AppendsStringsAsExpected()
		{
			var sb = new StringBuilder(200);

			sb.AppendJoin(".", new List<string>() { "Yort", "Mozzarella", "Tests" });

			Assert.AreEqual("Yort.Mozzarella.Tests", sb.ToString());
		}

		[TestMethod]
		public void AppendJoin_List_DoesNotUseSeparatorWithOnlyOneItem()
		{
			var sb = new StringBuilder(200);

			sb.AppendJoin(".", new List<string>() { "Yort" });

			Assert.AreEqual("Yort", sb.ToString());
		}

		[TestMethod]
		public void AppendJoin_List_AppendsNullAsEmptyString()
		{
			var sb = new StringBuilder(200);

			sb.AppendJoin(".", new List<string>() { "Yort", null, "Mozzarella", String.Empty, "Tests" });

			Assert.AreEqual("Yort..Mozzarella..Tests", sb.ToString());
		}

		[TestMethod]
		public void AppendJoin_List_IgnoresNullSeparator()
		{
			var sb = new StringBuilder(200);

			sb.AppendJoin(null, new List<string>() { "Yort", "Mozzarella", "Tests" });

			Assert.AreEqual("YortMozzarellaTests", sb.ToString());
		}

		[TestMethod]
		public void AppendJoin_List_IgnoresEmptySeparator()
		{
			var sb = new StringBuilder(200);

			sb.AppendJoin(String.Empty, new List<string>() { "Yort", "Mozzarella", "Tests" });

			Assert.AreEqual("YortMozzarellaTests", sb.ToString());
		}

		[TestMethod]
		public void AppendJoin_List_IgnoresNullList()
		{
			var sb = new StringBuilder(200);

			sb.AppendJoin(String.Empty, (List<string>)null);

			Assert.AreEqual(String.Empty, sb.ToString());
		}

		[TestMethod]
		public void AppendJoin_List_IgnoresEmptyList()
		{
			var sb = new StringBuilder(200);

			sb.AppendJoin(String.Empty, new List<string>());

			Assert.AreEqual(String.Empty, sb.ToString());
		}



		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void AppendJoin_IEnumerable_ThrowsOnNullBuilder()
		{
			StringBuilder sb = null;

			sb.AppendJoin(".", (from s in new string[] { "Yort", "Mozzarella", "Tests" } select s));
		}

		[TestMethod]
		public void AppendJoin_IEnumerable_AppendsStringsAsExpected()
		{
			var sb = new StringBuilder(200);

			sb.AppendJoin(".", (from s in new string[] { "Yort", "Mozzarella", "Tests" } select s));

			Assert.AreEqual("Yort.Mozzarella.Tests", sb.ToString());
		}

		[TestMethod]
		public void AppendJoin_IEnumerable_DoesNotUseSeparatorWithOnlyOneItem()
		{
			var sb = new StringBuilder(200);

			sb.AppendJoin(".", (from s in new string[] { "Yort" } select s));

			Assert.AreEqual("Yort", sb.ToString());
		}

		[TestMethod]
		public void AppendJoin_IEnumerable_AppendsNullAsEmptyString()
		{
			var sb = new StringBuilder(200);

			sb.AppendJoin(".", (from s in new string[] { "Yort", null, "Mozzarella", String.Empty, "Tests" } select s));

			Assert.AreEqual("Yort..Mozzarella..Tests", sb.ToString());
		}

		[TestMethod]
		public void AppendJoin_IEnumerable_IgnoresNullSeparator()
		{
			var sb = new StringBuilder(200);

			sb.AppendJoin(null, (from s in new string[] { "Yort", "Mozzarella", "Tests" } select s));

			Assert.AreEqual("YortMozzarellaTests", sb.ToString());
		}

		[TestMethod]
		public void AppendJoin_IEnumerable_IgnoresEmptySeparator()
		{
			var sb = new StringBuilder(200);

			sb.AppendJoin(String.Empty, (from s in new string[] { "Yort", "Mozzarella", "Tests" } select s));

			Assert.AreEqual("YortMozzarellaTests", sb.ToString());
		}

		[TestMethod]
		public void AppendJoin_IEnumerable_IgnoresNullIEnumerable()
		{
			var sb = new StringBuilder(200);

			sb.AppendJoin(String.Empty, (IEnumerable<string>)null);

			Assert.AreEqual(String.Empty, sb.ToString());
		}

		[TestMethod]
		public void AppendJoin_IEnumerable_IgnoresEmptyIEnumerable()
		{
			var sb = new StringBuilder(200);

			sb.AppendJoin(String.Empty, (from s in new string[] { } select s));

			Assert.AreEqual(String.Empty, sb.ToString());
		}
	}
}