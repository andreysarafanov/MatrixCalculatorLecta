using System.IO;

namespace MatrixCalculator.IO.FileWrite
{
	class FileWriteStreamProvider : IFileWriteStreamProvider
	{
		private readonly string _filePath;

		public FileWriteStreamProvider(string filePath)
		{
			_filePath = filePath;
		}

		public TextWriter GetWriteStream()
		{
			return System.IO.File.CreateText(_filePath);
		}
	}
}