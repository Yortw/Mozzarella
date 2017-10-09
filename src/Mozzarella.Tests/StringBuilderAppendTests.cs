using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class StringBuilderAppendTests
	{

		#region Append Overloads

		[TestMethod]
		public void Append_DoesNotAppendSeparatorWhenEmpty()
		{
			var sb = new StringBuilder();
			sb.Append(",", "Test");

			Assert.AreEqual("Test", sb.ToString());
		}

		[TestMethod]
		public void Append_AppendsSeparatorWhenNotEmpty()
		{
			var sb = new StringBuilder();
			sb.Append(",", "Test");
			sb.Append(",", "Test");

			Assert.AreEqual("Test,Test", sb.ToString());
		}

		#endregion

		#region AppendIf Overloads

		[TestMethod]
		public void AppendIf_AppendsWhenConditionTrue()
		{
			var sb = new StringBuilder();

			int a = 1, b = 2;

			sb.AppendIf(a * 2 == b, "Result: 2");
		}

		[TestMethod]
		public void AppendIf_DoesNotAppendWhenConditionFalse()
		{
			var sb = new StringBuilder();

			int a = 1, b = 4;

			sb.AppendIf(a * 2 == b, "Result: 2");
		}

		[TestMethod]
		public void AppendIf_AppendsFunctionResultWhenConditionTrue()
		{
			var sb = new StringBuilder();

			int a = 1, b = 2;

			sb.AppendIf(a * 2 == b, () => "Result: " + (a * 2).ToString());
		}

		[TestMethod]
		public void AppendIf_DoesNotAppendFunctionResultWhenConditionFalse()
		{
			var sb = new StringBuilder();

			int a = 1, b = 4;

			sb.AppendIf(a * 2 == b, () => "Result: " + (a * 2).ToString());
		}

		[TestMethod]
		public void AppendIf_DoesNotCallFunctionWhenConditionFalse()
		{
			var sb = new StringBuilder();

			var called = false;
			int a = 1, b = 4;

			sb.AppendIf(a * 2 == b, 
				() => 
				{
					called = true;
					return "Result: " + (a * 2).ToString();
				}
			);

			Assert.IsFalse(called);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void AppendIf_ThrowsWhenValueFunctionNull()
		{
			var sb = new StringBuilder();

			var called = false;
			int a = 1, b = 4;

			sb.AppendIf(a * 2 == b, (Func<string>)null);

			Assert.IsFalse(called);
		}

		#endregion

	}
}