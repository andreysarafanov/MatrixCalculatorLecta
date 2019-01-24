using MatrixCalculator.Domain.Interfaces;

namespace MatrixCalculator.Domain.Factories
{
	public interface ITaskRunnerFactory
	{
		ITaskRunner CreateTaskRunner(ITaskInfoProvider taskInfoProvider, ITaskResultSaver taskResultSaver);
	}
}