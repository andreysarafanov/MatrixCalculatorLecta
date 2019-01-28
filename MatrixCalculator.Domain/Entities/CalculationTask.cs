using System.Collections.Generic;

namespace MatrixCalculator.Domain.Entities
{
	public class CalculationTask
	{
		public Operation Operation { get; set; }
		public IReadOnlyList<Matrix> Matrices { get; set; }
	}
}