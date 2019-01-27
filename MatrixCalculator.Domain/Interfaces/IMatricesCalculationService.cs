using System.Collections.Generic;
using MatrixCalculator.Domain.Entities;

namespace MatrixCalculator.Domain.Interfaces
{
	public interface IMatricesCalculationService
	{
		ResultOrError<Matrix, string> SumAllMatrices(IReadOnlyCollection<Matrix> matrices);
		ResultOrError<Matrix, string> MultiplyAllMatrices(IReadOnlyCollection<Matrix> matrices);
		ResultOrError<Matrix, string> SubtractAllMatrices(IReadOnlyCollection<Matrix> matrices);
		ResultOrError<IReadOnlyCollection<Matrix>, string> TransposeAllMatrices(IReadOnlyCollection<Matrix> matrices);
	}
}