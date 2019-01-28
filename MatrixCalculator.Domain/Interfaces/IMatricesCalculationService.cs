using System.Collections.Generic;
using MatrixCalculator.Domain.Entities;

namespace MatrixCalculator.Domain.Interfaces
{
	public interface IMatricesCalculationService
	{
		ResultOrError<Matrix, string> SumAllMatrices(IReadOnlyList<Matrix> matrices);
		ResultOrError<Matrix, string> MultiplyAllMatrices(IReadOnlyList<Matrix> matrices);
		ResultOrError<Matrix, string> SubtractAllMatrices(IReadOnlyList<Matrix> matrices);
		ResultOrError<IReadOnlyList<Matrix>, string> TransposeAllMatrices(IReadOnlyList<Matrix> matrices);
	}
}