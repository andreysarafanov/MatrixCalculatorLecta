using System;
using System.Linq;
using MatrixCalculator.Domain.Entities;
using MatrixCalculator.Domain.Interfaces;

namespace MatrixCalculator.Domain.Services
{
	public class MatricesCalculationService : IMatricesCalculationService
	{
		private readonly IMatrixCalculator _matrixCalculator;

		public MatricesCalculationService(IMatrixCalculator matrixCalculator)
		{
			_matrixCalculator = matrixCalculator;
		}

		public ResultOrError<Matrix, string> SumAllMatrices(Matrix[] matrices)
		{
			return CalculateMatrices(matrices, _matrixCalculator.AddMatrices);
		}

		public ResultOrError<Matrix, string> MultiplyAllMatrices(Matrix[] matrices)
		{
			return CalculateMatrices(matrices, _matrixCalculator.MultiplyMatrices);
		}

		public ResultOrError<Matrix, string> SubtractAllMatrices(Matrix[] matrices)
		{
			return CalculateMatrices(matrices, _matrixCalculator.SubtractMatrices);
		}

		public ResultOrError<Matrix[], string> TransposeAllMatrices(Matrix[] matrices)
		{
			var resultMatrices = matrices
				.Select(_matrixCalculator.TransposeMatrix)
				.ToArray();
			return ResultOrError<Matrix[], string>.FromResult(resultMatrices);
		}

		private ResultOrError<Matrix, string> CalculateMatrices(
			Matrix[] matrices,
			Func<Matrix, Matrix, ResultOrError<Matrix, string>> operation)
		{
			if (matrices.Length < 2)
			{
				return ResultOrError<Matrix, string>.FromError("Нужно минимум две матрицы");
			}

			Matrix result = null;
			for (var i = 1; i < matrices.Length; i++)
			{
				var rightOp = matrices[i];
				var leftOp = result ?? matrices[i - 1];
				var resultOrError = operation(leftOp, rightOp);
				if (resultOrError.IsError)
				{
					return ResultOrError<Matrix, string>.FromError($"Ошибка при обработке матрицы #{i}: {resultOrError.Error}");
				}

				result = resultOrError.Result;
			}
			return ResultOrError<Matrix, string>.FromResult(result);
		}
	}
}