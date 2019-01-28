using System;
using System.Collections.Generic;
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

		public ResultOrError<Matrix, string> SumAllMatrices(IReadOnlyList<Matrix> matrices)
		{
			return CalculateMatrices(matrices, _matrixCalculator.AddMatrices);
		}

		public ResultOrError<Matrix, string> MultiplyAllMatrices(IReadOnlyList<Matrix> matrices)
		{
			return CalculateMatrices(matrices, _matrixCalculator.MultiplyMatrices);
		}

		public ResultOrError<Matrix, string> SubtractAllMatrices(IReadOnlyList<Matrix> matrices)
		{
			return CalculateMatrices(matrices, _matrixCalculator.SubtractMatrices);
		}

		public ResultOrError<IReadOnlyList<Matrix>, string> TransposeAllMatrices(IReadOnlyList<Matrix> matrices)
		{
			var resultMatrices = matrices
				.Select(_matrixCalculator.TransposeMatrix)
				.ToArray();
			return ResultOrError<IReadOnlyList<Matrix>, string>.FromResult(resultMatrices);
		}

		private ResultOrError<Matrix, string> CalculateMatrices(
			IReadOnlyList<Matrix> matrices,
			Func<Matrix, Matrix, ResultOrError<Matrix, string>> operation)
		{
			if (matrices.Count < 2)
			{
				return ResultOrError<Matrix, string>.FromError("Нужно минимум две матрицы");
			}

			Matrix result = null;
			for (var i = 1; i < matrices.Count; i++)
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