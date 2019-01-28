using MatrixCalculator.Domain.Factories;
using MatrixCalculator.Domain.Interfaces;
using MatrixCalculator.Domain.Services;
using MatrixCalculator.IO;
using Ninject;
using Ninject.Extensions.Factory;

namespace MatrixCalculator.CUI
{
	public static class Bootstrapper
	{
		public static IKernel GetKernel()
		{
			var kernel = new StandardKernel();

			kernel.Bind<ProgramWithFileIoCompositionRoot>().ToSelf();
			kernel.Bind<ITaskRunnerFactory>().ToFactory();
			kernel.Bind<ITaskRunner>().To<TaskRunner>();
			kernel.Bind<IMatricesCalculationService>().To<MatricesCalculationService>();
			kernel.Bind<IMatrixCalculator>().To<MatrixCalculatorImpl>();

			return kernel;
		}
	}
}