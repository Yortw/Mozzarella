using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class ErasableStringTests
	{
		[TestMethod]
		public void ErasableString_Constructor_ConstructsWithNonBlankString()
		{
			using (var es = new ErasableString("test"))
			{
				Assert.AreEqual("test", es.Value);
			}
		}

		[TestMethod]
		public void ErasableString_Constructor_ConstructsWithNull()
		{
			using (var es = new ErasableString(null))
			{
			}
		}

		[TestMethod]
		public void ErasableString_Constructor_ConstructsWithEmptyString()
		{
			using (var es = new ErasableString(String.Empty))
			{
			}
		}

		[TestMethod]
		public void ErasableString_Clear_OverwritesString()
		{
			using (var es = new ErasableString("Test"))
			{
				Assert.AreEqual("Test", es.Value);
				es.Clear();
				Assert.AreEqual(new string((char)0, 4), es.Value);
			}
		}

		[TestMethod]
		public void ErasableString_Clear_SetsIsCleared()
		{
			using (var es = new ErasableString("Test"))
			{
				Assert.AreEqual("Test", es.Value);
				es.Clear();
				Assert.AreEqual(true, es.IsCleared);
			}
		}

		[TestMethod]
		public void ErasableString_Clear_DisposeClearsString()
		{
			var es = new ErasableString("Test");
			es.Dispose();
			Assert.AreEqual(true, es.IsCleared);
		}

		[ExpectedException(typeof(ObjectDisposedException))]
		[TestMethod]
		public void ErasableString_Clear_ThrowsWhenDisposed()
		{
			var es = new ErasableString("Test");
			es.Dispose();
			es.Clear();
			Assert.AreEqual(true, es.IsCleared);
		}

		[ExpectedException(typeof(ObjectDisposedException))]
		[TestMethod]
		public void ErasableString_Value_ThrowsWhenDisposed()
		{
			var es = new ErasableString("Test");
			es.Dispose();
			var s = es.Value;
		}

		[TestMethod]
		public void ErasableString_Dispose_CanDisposeSafelyMultipleTimes()
		{
			var es = new ErasableString("Test");
			es.Dispose();
			es.Dispose();
		}

	}
}