using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MatrixCalculator.Domain.Factories;
using MatrixCalculator.Domain.Interfaces;
using MatrixCalculator.IO.FileRead;
using MatrixCalculator.IO.FileWrite;
using MoreLinq.Extensions;

namespace MatrixCalculator.IO
{
	public class ProgramWithFileIoCompositionRoot
	{
		private readonly ITaskRunnerFactory _taskRunnerFactory;

		public ProgramWithFileIoCompositionRoot(ITaskRunnerFactory taskRunnerFactory)
		{
			_taskRunnerFactory = taskRunnerFactory;
		}

		public void ProcessDirectory(string directoryPath, Action<string> threadSafeCallback)
		{
			var files = Directory.GetFiles(directoryPath).Where(p => !p.EndsWith("_result.txt")).ToArray();
			Parallel.ForEach(files, file =>
			{
				var runner = _taskRunnerFactory.CreateTaskRunner(GetReaderForFile(file), GetSaverForFile(file));
				runner.Run();
				threadSafeCallback(file);
			});
		}

		//тут можно было бы 4 фабрики ввести зависимостями, чтобы избежать new, но оно того не стоит
		private static ITaskResultSaver GetSaverForFile(string filePath)
		{
			return new FileResultWriter(new FileWriteStreamProvider(TransformResultFilePath(filePath)));
		}

		private static ITaskInfoReader GetReaderForFile(string filePath)
		{
			return new FileTaskInfoReader(new FileReadStreamProvider(filePath));
		}

		private static string TransformResultFilePath(string initialFilePath)
		{
			// ReSharper disable once StringIndexOfIsCultureSpecific.1
			var dotPosition = initialFilePath.IndexOf(".");
			if (dotPosition >= 0)
			{
				return initialFilePath.Substring(0, dotPosition) + "_result.txt";
			}

			return initialFilePath + "_result.txt";
		}
	}
}