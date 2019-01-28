using MatrixCalculator.Domain.Entities;
using MatrixCalculator.Domain.Interfaces;

namespace MatrixCalculator.Domain.Services
{
	public class MatrixCalculatorImpl: IMatrixCalculator
	{
		public ResultOrError<Matrix, string> AddMatrices(Matrix leftOp, Matrix rightOp)
		{
			if (leftOp.Width != rightOp.Width || leftOp.Height != rightOp.Height)
			{
				return ResultOrError<Matrix, string>.FromError("У матриц при сложении не совпали размеры");
			}
			var newMatrix = new int[leftOp.ValuesOneDimensional.Length];
			for (var i = 0; i < leftOp.ValuesOneDimensional.Length; i++)
			{
				newMatrix[i] = leftOp.ValuesOneDimensional[i] + rightOp.ValuesOneDimensional[i];
			}
			return ResultOrError<Matrix, string>.FromResult(new Matrix(leftOp.Height, leftOp.Width, newMatrix));
		}

		public ResultOrError<Matrix, string> SubtractMatrices(Matrix leftOp, Matrix rightOp)
		{
			if (leftOp.Width != rightOp.Width || leftOp.Height != rightOp.Height)
			{
				return ResultOrError<Matrix, string>.FromError("У матриц при вычитании не совпали размеры");
			}
			var newMatrix = new int[leftOp.ValuesOneDimensional.Length];
			for (var i = 0; i < leftOp.ValuesOneDimensional.Length; i++)
			{
				newMatrix[i] = leftOp.ValuesOneDimensional[i] - rightOp.ValuesOneDimensional[i];
			}
			return ResultOrError<Matrix, string>.FromResult(new Matrix(leftOp.Height, leftOp.Width, newMatrix));
		}

		public ResultOrError<Matrix, string> MultiplyMatrices(Matrix leftOp, Matrix rightOp)
		{
			throw new System.NotImplementedException();
		}

		public ResultOrError<Matrix, string> TransposeMatrix(Matrix matrix)
		{
			var result = new Matrix(matrix.Width, matrix.Height);
			for (var i = 0; i < matrix.Width; i++)
			{
				for (var j = 0; j < matrix.Height; j++)
				{
					result[j, i] = matrix[i, j];
				}
			}
			return ResultOrError<Matrix, string>.FromResult(result);
		}
	}
}