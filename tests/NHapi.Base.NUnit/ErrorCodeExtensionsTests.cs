using NUnit.Framework;
using System;

namespace NHapi.Base.NUnit
{
	[TestFixture]
	public class ErrorCodeExtensionsTests
	{
		#region ToErrorCode

		[TestCase(-1)]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(20)]
		public void ToErrorCode_InvalidInput_ThrowsArgumentOutOfRangeException(int sut)
		{
			var ex = Assert.Throws<ArgumentOutOfRangeException>(() => sut.ToErrorCode());

#if NETCOREAPP
			var expectedMessage = "The integer provided is not a valid ErrorCode value (Parameter 'errorCode')";
#elif NETFRAMEWORK
			var expectedMessage = $"The integer provided is not a valid ErrorCode value{Environment.NewLine}Parameter name: errorCode";
#endif

			Assert.That(ex.Message, Is.EqualTo(expectedMessage));
			Assert.That(ex.ParamName, Is.EqualTo("errorCode"));
		}

		[TestCase(0, ErrorCode.MESSAGE_ACCEPTED)]
		[TestCase(100, ErrorCode.SEGMENT_SEQUENCE_ERROR)]
		[TestCase(200, ErrorCode.UNSUPPORTED_MESSAGE_TYPE)]
		public void ToErrorCode_ValidInput_ReturnsExpectedErrorCode(int sut, ErrorCode expected)
		{
			// Arrange / Action
			var actual = sut.ToErrorCode();

			// Assert
			Assert.AreEqual(expected, actual);
		}

#endregion

#region GetCode

		[TestCase(ErrorCode.MESSAGE_ACCEPTED, 0)]
		[TestCase(ErrorCode.SEGMENT_SEQUENCE_ERROR, 100)]
		[TestCase(ErrorCode.UNSUPPORTED_MESSAGE_TYPE, 200)]
		public void GetCode_ReturnsErrorCodeAsInt(ErrorCode sut, int expected)
		{
			// Arrange / Action
			var actual = sut.GetCode();

			// Assert
			Assert.AreEqual(expected, actual);
		}

#endregion

#region GetName

		[TestCase(ErrorCode.MESSAGE_ACCEPTED, "Message accepted")]
		[TestCase(ErrorCode.SEGMENT_SEQUENCE_ERROR, "Segment sequence error")]
		[TestCase(ErrorCode.UNSUPPORTED_MESSAGE_TYPE, "Unsupported message type")]
		public void GetName_ReturnsErrorCodeDescription(ErrorCode sut, string expected)
		{
			// Arrange / Action
			var actual = sut.GetName();

			// Assert
			Assert.AreEqual(expected, actual);
		}

#endregion
	}
}