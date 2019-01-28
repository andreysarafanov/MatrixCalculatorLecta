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
			var expectedResult = new Matrix(2, 3, new[]
			{
				2, 3, 5,
				7, 10, 14
			});

			var result = _calculator.AddMatrices(_firstMatrix2X3, _secondMatrix2X3);
			Assert.IsFalse(result.IsError);
			Assert.That(result.Result, Is.EqualTo(expectedResult).Using(new MatrixEqualityComparer()));
		}

		[Test]
		public void AddOperation_WhenProvidedWithInvalidData_ReturnsCorrectError()
		{
			var result = _calculator.AddMatrices(_firstMatrix2X3, _firstMatrix2X2);
			Assert.IsTrue(result.IsError);
		}

		[Test]
		public void SubtractOperation_WhenProvidedWithValidData_ReturnsCorrectResult()
		{
			var expectedResult = new Matrix(2, 3, new[]
			{
				0, -1, -1,
				-1, 0, 2
			});

			var result = _calculator.SubtractMatrices(_secondMatrix2X3, _firstMatrix2X3);
			Assert.IsFalse(result.IsError);
			Assert.That(result.Result, Is.EqualTo(expectedResult).Using(new MatrixEqualityComparer()));
		}

		[Test]
		public void SubtractOperation_WhenProvidedWithInvalidData_ReturnsCorrectError()
		{
			var result = _calculator.SubtractMatrices(_firstMatrix2X3, _firstMatrix2X2);
			Assert.IsTrue(result.IsError);
		}

		[Test]
		public void TransposeOperation_WhenProvidedWithASquareMatrix_ReturnsCorrectResult()
		{
			var expectedResult = new Matrix(2, 2, new[]
			{
				2, 8,
				4, 16
			});
			var result = _calculator.TransposeMatrix(_firstMatrix2X2);
			Assert.IsFalse(result.IsError);
			Assert.That(result.Result, Is.EqualTo(expectedResult).Using(new MatrixEqualityComparer()));
		}

		[Test]
		public void TransposeOperation_WhenProvidedWithANonSquareMatrix_ReturnsCorrectResult()
		{
			var expectedResult = new Matrix(3, 2, new[]
			{
				1, 4,
				2, 5,
				3, 6
			});
			var result = _calculator.TransposeMatrix(_firstMatrix2X3);
			Assert.IsFalse(result.IsError);
			Assert.That(result.Result, Is.EqualTo(expectedResult).Using(new MatrixEqualityComparer()));
		}

		[Test]
		public void MultiplyOperation_WhenProvidedWithTwoSquareMatrices_ReturnsCorrectResult()
		{
			var expectedResult = new Matrix(2, 2, new[]
			{
				22, 34,
				88, 136,
			});
			var result = _calculator.MultiplyMatrices(_firstMatrix2X2, _secondMatrix2X2);
			Assert.IsFalse(result.IsError);
			Assert.That(result.Result, Is.EqualTo(expectedResult).Using(new MatrixEqualityComparer()));
		}

		[Test]
		public void MultiplyOperation_WhenProvidedWithTwoRectangularMatrices_ReturnsCorrectResult()
		{
			var expectedResult = new Matrix(2, 2, new[]
			{
				-4, 4,
				2, -2,
			});
			var result = _calculator.MultiplyMatrices(_firstMatrix2X3, _firstMatrix3X2);
			Assert.IsFalse(result.IsError);
			Assert.That(result.Result, Is.EqualTo(expectedResult).Using(new MatrixEqualityComparer()));
		}

		[Test]
		public void MultiplyOperation_WhenProvidedWithTwoIncompatibleMatrices_ReturnsCorrectError()
		{
			var result = _calculator.MultiplyMatrices(_firstMatrix2X3, _firstMatrix2X3);
			Assert.IsTrue(result.IsError);
		}

		#region MatrixConstants
		private readonly Matrix _firstMatrix2X3 = new Matrix(2, 3, new[]
		{
			1, 2, 3,
			4, 5, 6
		});

		private readonly Matrix _secondMatrix2X3 = new Matrix(2, 3, new[]
		{
			1, 1, 2,
			3, 5, 8
		});

		private readonly Matrix _firstMatrix2X2 = new Matrix(2, 2, new[]
		{
			2, 4,
			8, 16
		});

		private readonly Matrix _secondMatrix2X2 = new Matrix(2, 2, new[]
		{
			1, 3,
			5, 7
		});

		private readonly Matrix _firstMatrix3X2 = new Matrix(3, 2, new[]
		{
			3, -3,
			4, -4,
			-5, 5
		});

		private readonly Matrix _secondMatrix3X2 = new Matrix(3, 2, new[]
		{
			110, 150,
			210, 219,
			10, 15
		});
		#endregion
	}
}