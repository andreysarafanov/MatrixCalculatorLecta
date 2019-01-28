using MatrixCalculator.Domain.Services;
using MatrixCalculator.Domain.Entities;
using NUnit.Framework;

namespace MatrixCalculator.Tests.Unit
{
	[TestFixture]
	public class MatrixCalculatorImplTests
	{
		private readonly MatrixCalculatorImpl _calculator = new MatrixCalculatorImpl();

		[Test]
		public void AddOperation_WhenProvidedWithValidData_ReturnsCorrectResult()
		{
			var expectedResult = new Matrix(3, 2, new[]
			{
				2, 3, 5,
				7, 10, 14
			});

			var result = _calculator.AddMatrices(FirstMatrix3x2, SecondMatrix3x2);
			Assert.IsFalse(result.IsError);
			Assert.That(result.Result, Is.EqualTo(expectedResult).Using(new MatrixEqualityComparer()));
		}

		[Test]
		public void AddOperation_WhenProvidedWithInvalidData_ReturnsCorrectError()
		{
			var result = _calculator.AddMatrices(FirstMatrix3x2, FirstMatrix2x2);
			Assert.IsTrue(result.IsError);
		}

		[Test]
		public void SubtractOperation_WhenProvidedWithValidData_ReturnsCorrectResult()
		{
			var expectedResult = new Matrix(3, 2, new[]
			{
				0, -1, -1,
				-1, 0, 2
			});

			var result = _calculator.SubtractMatrices(SecondMatrix3x2, FirstMatrix3x2);
			Assert.IsFalse(result.IsError);
			Assert.That(result.Result, Is.EqualTo(expectedResult).Using(new MatrixEqualityComparer()));
		}

		[Test]
		public void SubtractOperation_WhenProvidedWithInvalidData_ReturnsCorrectError()
		{
			var result = _calculator.SubtractMatrices(FirstMatrix3x2, FirstMatrix2x2);
			Assert.IsTrue(result.IsError);
		}

		#region MatrixConstants
		private readonly Matrix FirstMatrix3x2 = new Matrix(3, 2, new[]
		{
			1, 2, 3,
			4, 5, 6
		});

		private readonly Matrix SecondMatrix3x2 = new Matrix(3, 2, new[]
		{
			1, 1, 2,
			3, 5, 8
		});

		private readonly Matrix FirstMatrix2x2 = new Matrix(2, 2, new[]
		{
			11, 13,
			17, 19
		});

		private readonly Matrix SecondMatrix2x2 = new Matrix(2, 2, new[]
		{
			110, 150,
			210, 219
		});

		private readonly Matrix FirstMatrix2x3 = new Matrix(2, 3, new[]
		{
			110, 150,
			210, 219,
			10, 15
		});

		private readonly Matrix SecondMatrix2x3 = new Matrix(2, 3, new[]
		{
			110, 150,
			210, 219,
			10, 15
		});
		#endregion
	}
}