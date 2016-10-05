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
	public class ByteArrayExtensionsTests
	{

		#region AsString

		[TestMethod]
		public void ByteArrayExtensions_AsString_CreatesString()
		{
			var expectedString = "The quick brown fox jumps over the lazy dog 😊.";
			var buffer = System.Text.UTF8Encoding.UTF8.GetBytes(expectedString);

			Assert.AreEqual(expectedString, buffer.AsString());
		}

		[TestMethod]
		public void ByteArrayExtensions_AsString_CreatesStringUsingEncoding()
		{
			var expectedString = "The quick brown fox jumps over the lazy dog 😊.";
			var buffer = System.Text.UTF8Encoding.UTF32.GetBytes(expectedString);

			Assert.AreEqual(expectedString, buffer.AsString(System.Text.UTF8Encoding.UTF32));
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ByteArrayExtensions_AsString_ThrowsWhenEncodingNull()
		{
			var expectedString = "The quick brown fox jumps over the lazy dog 😊.";
			var buffer = System.Text.UTF8Encoding.UTF32.GetBytes(expectedString);

			Assert.AreEqual(expectedString, buffer.AsString(null));
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ByteArrayExtensions_AsString_ThrowsWhenBufferNull()
		{
			byte[] buffer = null;

			buffer.AsString(null);
		}

		#endregion

		#region ToHexString

		[TestMethod]
		public void ByteArrayExtensions_ToHexString_ConvertsCorrectly()
		{
			var testBytes = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 255 };
			Assert.AreEqual("000102030405060708090A0B0C0D0E0F10FF", testBytes.ToHexString());
		}

		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void ByteArrayExtensions_ToHexString_ThrowsOnNullSource()
		{
			byte[] testBytes = null;
			var s = testBytes.ToHexString();
		}

		[ExpectedException(typeof(ArgumentException))]
		[TestMethod]
		public void ByteArrayExtensions_ToHexString_ThrowsOnEmptyArray()
		{
			byte[] testBytes = new byte[] { };
			var s = testBytes.ToHexString();
		}

		#endregion

	}
}