using MatrixCalculator.Domain.Interfaces;

namespace MatrixCalculator.Domain.Factories
{
	public interface ITaskRunnerFactory
	{
		ITaskRunner CreateTaskRunner(ITaskInfoReader taskInfoReader, ITaskResultSaver taskResultSaver);
	}
}