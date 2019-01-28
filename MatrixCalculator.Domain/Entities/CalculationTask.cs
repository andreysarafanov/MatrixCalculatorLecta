using System.Collections.Generic;

namespace MatrixCalculator.Domain.Entities
{
	public class CalculationTask
	{
		public Operation Operation { get; set; }
		public Matrix[] Matrices { get; set; }
	}
}