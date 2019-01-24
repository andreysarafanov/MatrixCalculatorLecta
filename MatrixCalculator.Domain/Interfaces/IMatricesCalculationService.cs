using System.Collections.Generic;
using MatrixCalculator.Domain.Entities;

namespace MatrixCalculator.Domain.Interfaces
{
	public interface IMatricesCalculationService
	{
		TaskResult<Matrix, string> SumAllMatrices(IReadOnlyCollection<Matrix> matrices);
		TaskResult<Matrix, string> MultiplyAllMatrices(IReadOnlyCollection<Matrix> matrices);
		TaskResult<Matrix, string> SubtractAllMatrices(IReadOnlyCollection<Matrix> matrices);
		TaskResult<IReadOnlyCollection<Matrix>, string> TransposeAllMatrices(IReadOnlyCollection<Matrix> matrices);
	}
}