using System.IO;

namespace MatrixCalculator.IO.File
{
	public class FileContentProvider: IFileContentProvider
	{
		private readonly string _filePath;

		public FileContentProvider(string filePath)
		{
			_filePath = filePath;
		}

		public StreamReader GetFileContent()
		{
			return System.IO.File.OpenText(_filePath);
		}
	}
}