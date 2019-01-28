using System.Collections.Generic;
using MatrixCalculator.Domain.Entities;

namespace MatrixCalculator.Domain.Interfaces
{
	public interface IMatricesCalculationService
	{
		ResultOrError<Matrix, string> SumAllMatrices(Matrix[] matrices);
		ResultOrError<Matrix, string> MultiplyAllMatrices(Matrix[] matrices);
		ResultOrError<Matrix, string> SubtractAllMatrices(Matrix[] matrices);
		ResultOrError<Matrix[], string> TransposeAllMatrices(Matrix[] matrices);
	}
}