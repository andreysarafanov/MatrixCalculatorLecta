using MatrixCalculator.Domain.Entities;
using MatrixCalculator.Domain.Interfaces;

namespace MatrixCalculator.IO.File
{
	public class FileTaskInfoProvider: ITaskInfoProvider
	{
		public const string MultiplyString = "multiply";
		public const string AddString = "add";
		public const string SubtractString = "subtract";
		public const string TransposeString = "transpose";

		private readonly IFileContentProvider _fileContentProvider;

		public FileTaskInfoProvider(IFileContentProvider fileContentProvider)
		{
			_fileContentProvider = fileContentProvider;
		}

		public TaskResult<CalculationTask, string> GetTaskDetails()
		{
			using (var streamReader = _fileContentProvider.GetFileContent())
			{
				return TaskResult<CalculationTask, string>.FromError("");
			}
		}
	}
}