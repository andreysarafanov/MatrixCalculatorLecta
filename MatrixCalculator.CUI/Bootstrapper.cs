using MatrixCalculator.Domain.Factories;
using Ninject;
using Ninject.Extensions.Factory;

namespace MatrixCalculator.CUI
{
	public static class Bootstrapper
	{
		public static IKernel GetKernel()
		{
			var kernel = new StandardKernel();

			kernel.Bind<ITaskRunnerFactory>().ToFactory();

			return kernel;
		}
	}
}