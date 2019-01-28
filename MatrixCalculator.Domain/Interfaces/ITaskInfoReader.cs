using System.Collections.Generic;
using MatrixCalculator.Domain.Entities;

namespace MatrixCalculator.Domain.Interfaces
{
	public interface ITaskInfoReader
	{
		ResultOrError<CalculationTask, string> GetTaskDetails();
	}
}