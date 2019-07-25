using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozzarella.Tests
{
	[TestClass]
	public class PascalCaseToWordsTests
	{

		[TestMethod]
		public void StringExtensions_PascalCaseToWords_InsertsSpacesAtUppercaseCharacters()
		{
			var test = "MyReplicationHandler";
			var expected = "My Replication Handler";

			Assert.AreEqual(expected, test.PascalCaseToWords());
		}

		[TestMethod]
		public void StringExtensions_PascalCaseToWords_KeepsTrailingSpaces()
		{
			var test = "MyReplicationHandler  ";
			var expected = "My Replication Handler  ";

			Assert.AreEqual(expected, test.PascalCaseToWords());
		}

		[TestMethod]
		public void StringExtensions_PascalCaseToWords_KeepsLeadingSpaces()
		{
			var test = "  MyReplicationHandler";
			var expected = "  My Replication Handler";

			Assert.AreEqual(expected, test.PascalCaseToWords());
		}

		[TestMethod]
		public void StringExtensions_PascalCaseToWords_EmptyStringReturnsEmptyString()
		{
			var test = String.Empty;
			var expected = String.Empty;

			Assert.AreEqual(expected, test.PascalCaseToWords());
		}

		[TestMethod]
		public void StringExtensions_PascalCaseToWords_NullReturnsNull()
		{
			var test = String.Empty;
			var expected = String.Empty;

			Assert.AreEqual(expected, test.PascalCaseToWords());
		}

		[TestMethod]
		public void StringExtensions_PascalCaseToWords_InsertsSpacesAtUppercaseCharactersForCamelCaseString()
		{
			var test = "myReplicationHandler";
			var expected = "My Replication Handler";

			Assert.AreEqual(expected, test.PascalCaseToWords());
		}

		[TestMethod]
		public void StringExtensions_PascalCaseToWords_DoesNotModifyNormalText()
		{
			var test = "My Replication Handler";
			var expected = "My Replication Handler";

			Assert.AreEqual(expected, test.PascalCaseToWords());
		}

		[TestMethod]
		public void StringExtensions_PascalCaseToWords_UppercasesOnlyFirstLetterOfAllLowercaseText()
		{
			var test = "myreplicationhandler";
			var expected = "Myreplicationhandler";

			Assert.AreEqual(expected, test.PascalCaseToWords());
		}

		[TestMethod]
		public void StringExtensions_PascalCaseToWords_IgnoresAcronymOnly()
		{
			var test = "RTFM";
			var expected = "RTFM";

			Assert.AreEqual(expected, test.PascalCaseToWords());
		}

		[TestMethod]
		public void StringExtensions_PascalCaseToWords_IgnoresAcronymAtStartOfPascalString()
		{
			var test = "RTFMAlright";
			var expected = "RTFM Alright";

			Assert.AreEqual(expected, test.PascalCaseToWords());
		}

		[TestMethod]
		public void StringExtensions_PascalCaseToWords_IgnoresAcronymInsidePascalString()
		{
			var test = "JustRTFMWillYa";
			var expected = "Just RTFM Will Ya";

			Assert.AreEqual(expected, test.PascalCaseToWords());
		}

		[TestMethod]
		public void StringExtensions_PascalCaseToWords_IgnoresAcronymAtEndOfPascalString()
		{
			var test = "DontForgetToRTFM";
			var expected = "Dont Forget To RTFM";

			Assert.AreEqual(expected, test.PascalCaseToWords());
		}

		[TestMethod]
		public void StringExtensions_PascalCaseToWords_IgnoresSingleUpperCharacterAtEndOfPascalString()
		{
			var test = "ModelI";
			var expected = "Model I";

			Assert.AreEqual(expected, test.PascalCaseToWords());
		}

		[TestMethod]
		public void StringExtensions_PascalCaseToWords_IgnoresSingleUpperCharacterAtEndofText()
		{
			var test = "Model I";
			var expected = "Model I";

			Assert.AreEqual(expected, test.PascalCaseToWords());
		}

		[TestMethod]
		public void StringExtensions_PascalCaseToWords_HandlesSingleLowerCaseLetterAtStartFollowedByAcronym()
		{
			var test = "a TM88";
			var expected = "A TM88";

			Assert.AreEqual(expected, test.PascalCaseToWords());
		}

	}
}