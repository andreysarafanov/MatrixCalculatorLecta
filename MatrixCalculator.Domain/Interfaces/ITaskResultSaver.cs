using System.Collections.Generic;
using MatrixCalculator.Domain.Entities;

namespace MatrixCalculator.Domain.Interfaces
{
	public interface ITaskResultSaver
	{
		void SaveResult(IReadOnlyList<Matrix> matrices);
		void SaveResult(Matrix matrix);
		void SaveErrorText(string text);
	}
}