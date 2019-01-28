using System.IO;

namespace MatrixCalculator.IO.FileRead
{
	public class FileReadStreamProvider : IFileReadStreamProvider
	{
		private readonly string _filePath;

		public FileReadStreamProvider(string filePath)
		{
			_filePath = filePath;
		}

		public TextReader GetFileContent()
		{
			return System.IO.File.OpenText(_filePath);
		}
	}
}