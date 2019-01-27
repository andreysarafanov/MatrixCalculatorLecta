using System.Collections.Generic;
using MatrixCalculator.Domain.Entities;

namespace MatrixCalculator.Domain.Interfaces
{
	public interface ITaskInfoProvider
	{
		ResultOrError<CalculationTask, string> GetTaskDetails();
	}
}