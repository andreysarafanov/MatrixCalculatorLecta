using System;
using MatrixCalculator.IO;
using Ninject;

namespace MatrixCalculator.CUI
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			if (args.Length != 1)
			{
				Console.WriteLine("You should provide a single argument - the path to the folder");
			}

			var kernel = Bootstrapper.GetKernel();
			var root = kernel.Get<ProgramWithFileIoCompositionRoot>();
			root.ProcessDirectory(args[0], WriteProgress);
		}

		private static void WriteProgress(string fileName)
		{
			Console.WriteLine(fileName);
		}
	}
}